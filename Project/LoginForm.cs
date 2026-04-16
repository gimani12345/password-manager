using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Project
{
    public partial class LoginForm : Form
    {
        private string passwordFilePath = "programPassword.json";
        private string currentPasswordHash;

        private int failedAttempts = 0; // 틀린 시도 횟수
        private System.Windows.Forms.Timer lockoutTimer; // 잠금 타이머
        private int lockoutDuration = 0; // 잠금 시간 (초)
        private DateTime lockoutEndTime; // 잠금 해제 시간

        public LoginForm()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';

            // 비밀번호 로드
            LoadPassword();

            // 타이머 초기화
            lockoutTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1초 간격
            };
            lockoutTimer.Tick += LockoutTimer_Tick;
        }

        private void LoadPassword()
        {
            if (File.Exists(passwordFilePath))
            {
                string jsonData = File.ReadAllText(passwordFilePath);
                currentPasswordHash = JsonSerializer.Deserialize<string>(jsonData);
            }
            else
            {
                currentPasswordHash = HashPassword("1234a!"); // 초기 비밀번호
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            // 잠금 상태인지 확인
            if (lockoutTimer.Enabled)
            {
                TimeSpan remainingTime = lockoutEndTime - DateTime.Now;
                MessageBox.Show($"너무 많은 실패 시도가 있었습니다. {remainingTime.Seconds}초 후에 다시 시도하세요.");
                return;
            }

            // 비밀번호 확인
            string inputHash = HashPassword(textBox1.Text);
            if (inputHash == currentPasswordHash)
            {
                MessageBox.Show("인증 성공!");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                failedAttempts++;
                HandleFailedAttempts();
            }
        }

        private void HandleFailedAttempts()
        {
            if (failedAttempts == 5)
            {
                StartLockout(30); // 5번 실패 → 30초 잠금
            }
            else if (failedAttempts == 10)
            {
                StartLockout(60); // 10번 실패 → 1분 잠금
            }
            else if (failedAttempts >= 15)
            {
                StartLockout(300); // 15번 이상 실패 → 5분 잠금
            }
            else
            {
                MessageBox.Show($"비밀번호를 확인해주세요. (남은 시도 횟수: {5 - (failedAttempts % 5)})");
            }
        }

        private void StartLockout(int durationInSeconds)
        {
            lockoutDuration = durationInSeconds;
            lockoutEndTime = DateTime.Now.AddSeconds(lockoutDuration);
            lockoutTimer.Start();
            button1.Enabled = false; // 로그인 버튼 비활성화
            MessageBox.Show($"비밀번호를 너무 많이 틀렸습니다. {lockoutDuration}초 후에 다시 시도하세요.");
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= lockoutEndTime)
            {
                lockoutTimer.Stop();
                button1.Enabled = true; // 로그인 버튼 활성화
                MessageBox.Show("이제 다시 시도할 수 있습니다.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void FindPwdBtn_Click(object sender, EventArgs e)
        {
            using (FindPasswordForm findPasswordForm = new FindPasswordForm())
            {
                if (findPasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // 비밀번호 변경 후, 새로운 비밀번호를 로드
                    LoadPassword(); // 변경된 비밀번호를 로드하여 로그인 시 확인
                    MessageBox.Show("비밀번호가 성공적으로 재설정되었습니다. 새로운 비밀번호로 로그인하세요.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
