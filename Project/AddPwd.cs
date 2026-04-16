using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using static Project.AddPwd;
using static System.Windows.Forms.DataFormats;
using System.DirectoryServices;

namespace Project
{


    public partial class AddPwd : Form
    {
        private MainForm form1;
        string jsonFilePath = "password.json";
        public AddPwd(MainForm form1)
        {
            InitializeComponent();
            this.form1 = form1;
            txtPwd.PasswordChar = '*';
            txtPwdCheck.PasswordChar = '*';
        }

        public static class KeyGenerator
        {
            private static readonly string KeyFilePath = "encryptionKey.dat";  // 키 파일 경로
            private static readonly string IvFilePath = "encryptionIv.dat";    // IV 파일 경로

            // 키 생성 및 저장
            public static byte[] GenerateKey(int size)
            {
                if (File.Exists(KeyFilePath)) // 키 파일이 이미 있으면 읽어오기
                {
                    return File.ReadAllBytes(KeyFilePath);
                }

                byte[] key = new byte[size];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                }

                // 키를 파일에 저장
                File.WriteAllBytes(KeyFilePath, key);

                return key;
            }

            // IV 생성 및 저장
            public static byte[] GenerateIv(int size)
            {
                if (File.Exists(IvFilePath)) // IV 파일이 이미 있으면 읽어오기
                {
                    return File.ReadAllBytes(IvFilePath);
                }

                byte[] iv = new byte[size];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(iv);
                }

                // IV를 파일에 저장
                File.WriteAllBytes(IvFilePath, iv);

                return iv;
            }
        }



        public static class AesEncryption
        {
            private static readonly byte[] Key = KeyGenerator.GenerateKey(32); // 32바이트 키 (AES-256)
            private static readonly byte[] Iv = KeyGenerator.GenerateIv(16);  // 16바이트 IV

            public static string Encrypt(string plainText)
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = Iv;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                        byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }

            public static string Decrypt(string cipherText)
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = Iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        byte[] inputBytes = Convert.FromBase64String(cipherText);
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                        return Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            }
        }








        // 항목 추가
        public void SaveData(PasswordEntry newEntry)
        {
            try
            {
                List<PasswordEntry> passwordList = new List<PasswordEntry>();
                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    string decryptedData = AesEncryption.Decrypt(jsonData); // 복호화
                    passwordList = JsonSerializer.Deserialize<List<PasswordEntry>>(decryptedData);
                }

                passwordList.Add(newEntry);

                // 리스트를 JSON으로 직렬화, 암호화
                string updatedJson = JsonSerializer.Serialize(passwordList, new JsonSerializerOptions { WriteIndented = true });
                string encryptedJson = AesEncryption.Encrypt(updatedJson);

                // Json파일에 저장
                File.WriteAllText(jsonFilePath, encryptedJson);


                // AddPasswordToUI(newEntry);

                MainForm form1 = new MainForm();
                form1.LoadPasswordEntries();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }

        }


        // 리스트 전체 저장
        public void SaveData(List<PasswordEntry> passwordList)
        {
            try
            {
                // 리스트를 JSON으로 직렬화, 암호화
                string updatedJson = JsonSerializer.Serialize(passwordList, new JsonSerializerOptions { WriteIndented = true });
                string encryptedJson = AesEncryption.Encrypt(updatedJson);

                // Json파일에 저장
                File.WriteAllText(jsonFilePath, encryptedJson);

                Console.WriteLine("데이터 파일 저장 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }


        //데이터 읽기
        public List<PasswordEntry> LoadFromJsonFile()
        {
            try
            {

                if (!File.Exists(jsonFilePath))
                {
                    return new List<PasswordEntry>();
                }

                string encryptedData = File.ReadAllText(jsonFilePath);
                string decryptedData = AesEncryption.Decrypt(encryptedData); // 복호화
                List<PasswordEntry> entries = JsonSerializer.Deserialize<List<PasswordEntry>>(decryptedData);

                return entries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
                return new List<PasswordEntry>();
            }
        }




        private void ClearInputs()
        {
            txtSiteName.Text = "";
            txtIdName.Text = "";
            txtPwd.Text = "";
            txtPwdCheck.Text = "";
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            int score = 0;

            // 비밀번호 강도 계산
            if (txtPwd.Text.Length >= 8) score++;
            if (txtPwd.Text.Any(char.IsUpper)) score++;
            if (txtPwd.Text.Any(char.IsLower)) score++;
            if (txtPwd.Text.Any(char.IsDigit)) score++;
            if (txtPwd.Text.Any(ch => "!@#$%^&*()_+-=".Contains(ch))) score++;

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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSiteName.Text.Trim()))
            {
                MessageBox.Show("사이트명을 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtIdName.Text.Trim()))
            {
                MessageBox.Show("아이디를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtPwd.Text.Trim()))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            else if (txtPwd.Text != txtPwdCheck.Text)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }

            PasswordEntry newEntry = new PasswordEntry
            {
                SiteName = txtSiteName.Text.Trim(),
                IdName = txtIdName.Text.Trim(),
                Password = txtPwd.Text.Trim(),
            };

            SaveData(newEntry);
            ClearInputs();


            this.form1.LoadPasswordEntries();
            MessageBox.Show("데이터 저장 완료.");

            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPwd.PasswordChar = '\0';
            }
            else
            {
                txtPwd.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtPwdCheck.PasswordChar = '\0';
            }
            else
            {
                txtPwdCheck.PasswordChar = '*';
            }
        }


        private string GenerateSecurePassword()
        {
            // 비밀번호 길이를 12에서 16자리 사이로 랜덤 설정
            Random random = new Random();
            int passwordLength = random.Next(12, 17); // 12~16 사이의 길이 랜덤 생성

            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=?"; // 사용할 문자들

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[passwordLength];
                rng.GetBytes(randomBytes);

                var password = new StringBuilder(passwordLength);
                foreach (var b in randomBytes)
                {
                    password.Append(validChars[b % validChars.Length]); // 문자 범위 내에서 랜덤 선택
                }

                return password.ToString();
            }
        }




        private void RndBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 사이트명과 아이디 입력값 가져오기
                string siteName = txtSiteName.Text.Trim();
                string idName = txtIdName.Text.Trim();

                // 사이트명과 아이디가 입력되지 않으면 오류 메시지 출력
                if (string.IsNullOrEmpty(siteName) || string.IsNullOrEmpty(idName))
                {
                    MessageBox.Show("사이트명과 아이디를 입력해주세요.");
                    return;
                }

                // 랜덤 비밀번호 생성
                string randomPassword = GenerateSecurePassword();

                // 비밀번호 입력 필드에 랜덤 비밀번호 설정
                txtPwd.Text = randomPassword;
                txtPwdCheck.Text = randomPassword; // 비밀번호 확인란에도 동일한 랜덤 비밀번호 설정

                // 새로운 데이터 항목 생성
                PasswordEntry newEntry = new PasswordEntry
                {
                    SiteName = siteName,
                    IdName = idName,
                    Password = randomPassword
                };

                // 데이터 저장
                SaveData(newEntry);

                // 입력값 초기화
                ClearInputs();

                this.Close();

                this.form1.LoadPasswordEntries();

                MessageBox.Show("랜덤 비밀번호가 생성되어 저장되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

    }
}
