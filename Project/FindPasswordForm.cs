using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Security.Cryptography;
using static Project.AddPwd;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class FindPasswordForm : Form
    {
        private string securityFilePath = "securityQuestion.json"; // 보안 질문 파일 경로
        private string correctAnswer;

        public FindPasswordForm()
        {
            InitializeComponent();
            LoadSecurityQuestion();
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            grpNewPassword.Enabled = false; // 기본적으로 새 비밀번호 입력을 비활성화
        }

        public class SecurityData
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }

        private void LoadSecurityQuestion()
        {
            if (File.Exists(securityFilePath))
            {
                // JSON 파일 읽기
                string jsonData = File.ReadAllText(securityFilePath);

                // JSON을 SecurityData 객체로 역직렬화
                SecurityData securityData = JsonSerializer.Deserialize<SecurityData>(jsonData);

                if (securityData != null)
                {
                    // 복호화된 질문과 답변
                    string decryptedQuestion = AesEncryption.Decrypt(securityData.Question);
                    string decryptedAnswer = AesEncryption.Decrypt(securityData.Answer);

                    // 질문 표시
                    lblQuestion.Text = decryptedQuestion;
                    correctAnswer = decryptedAnswer; // 답변 저장
                }
                else
                {
                    MessageBox.Show("보안 질문 데이터가 손상되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("설정된 보안 질문이 없습니다. 먼저 보안 질문을 설정해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void VerifyAnswerBtn_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Trim().ToLower() == correctAnswer.ToLower())
            {
                MessageBox.Show("보안 질문 답변이 올바릅니다. 새 비밀번호를 입력하세요.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpNewPassword.Enabled = true; // 새 비밀번호 입력 활성화
            }
            else
            {
                MessageBox.Show("보안 질문 답변이 올바르지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveNewPasswordBtn_Click(object sender, EventArgs e)
        {
            // 새 비밀번호가 일치하는지 확인
            if (txtNewPassword.Text == txtConfirmPassword.Text && !string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                string newPassword = txtNewPassword.Text;
                string newPasswordHash = HashPassword(newPassword);  // 새 비밀번호 해시화

                // 비밀번호 파일에 새 비밀번호 저장
                SavePassword(newPasswordHash);  // 새 비밀번호 파일에 저장

                MessageBox.Show("새 비밀번호가 성공적으로 설정되었습니다.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("새 비밀번호가 일치하지 않거나 비밀번호가 비어 있습니다.");
            }
        }

        // 비밀번호 해싱 함수
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // 새 비밀번호 파일에 저장
        private void SavePassword(string passwordHash)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(passwordHash);
                File.WriteAllText("programPassword.json", jsonData); // 비밀번호 파일 경로에 저장
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비밀번호 저장 중 오류 발생: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = checkBox2.Checked ? '\0' : '*';

        }
    }
}
