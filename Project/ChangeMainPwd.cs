using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class ChangeMainPwd : Form
    {
        private string currentPasswordHash;

        // 새 비밀번호 해시값을 저장
        public string NewPasswordHash { get; private set; }

        public ChangeMainPwd(string currentPasswordHash)
        {
            InitializeComponent();
            this.currentPasswordHash = currentPasswordHash;
            txtOldPassword.PasswordChar = '*';
            txtNewPassword1.PasswordChar = '*';
            txtNewPassword2.PasswordChar = '*';
        }

        // SHA256 해싱 함수
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // 현재 비밀번호 확인
            if (HashPassword(txtOldPassword.Text) != currentPasswordHash)
            {
                MessageBox.Show("현재 비밀번호가 올바르지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 새 비밀번호와 확인 비밀번호 비교
            if (string.IsNullOrWhiteSpace(txtNewPassword1.Text) || txtNewPassword1.Text != txtNewPassword2.Text)
            {
                MessageBox.Show("새 비밀번호가 일치하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 새 비밀번호 해싱 후 저장
            NewPasswordHash = HashPassword(txtNewPassword1.Text);
            MessageBox.Show("비밀번호가 성공적으로 변경되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            this.Close();
        }


        private void txtNewPassword1_TextChanged(object sender, EventArgs e)
        {

            int score = 0;

            // 비밀번호 강도 계산
            if (txtNewPassword1.Text.Length >= 8) score++;
            if (txtNewPassword1.Text.Any(char.IsUpper)) score++;
            if (txtNewPassword1.Text.Any(char.IsLower)) score++;
            if (txtNewPassword1.Text.Any(char.IsDigit)) score++;
            if (txtNewPassword1.Text.Any(ch => "!@#$%^&*()_+-=".Contains(ch))) score++;

            if (score <= 2)
            {
                PwdStrength.Text = "약함";
                PwdStrength.ForeColor = Color.Red;
            }
            else if (score <= 3)
            {
                PwdStrength.Text = "보통";
                PwdStrength.ForeColor = Color.Orange;
            }
            else
            {
                PwdStrength.Text = "강함";
                PwdStrength.ForeColor = Color.Green;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtNewPassword1.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword1.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtNewPassword2.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword2.PasswordChar = '*';
            }
        }
    }
}
