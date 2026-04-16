using System.Text.Json;
using System.Text;
using System.Security.Cryptography;

namespace Project
{
    public partial class MainForm : Form
    {
        private string passwordFilePath = "programPassword.json";
        private string currentPasswordHash;

        public MainForm()
        {
            InitializeComponent();
            LoadPassword();

        }
        List<char> newPwd = new List<char>();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPasswordEntries();
        }

        

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            AddPwd addPwdForm = new AddPwd(this);
            addPwdForm.ShowDialog();
        }

        private void AddPasswordToUI(PasswordEntry entry, int index)
        {
            // 사이트 이름, ID, 비밀번호 표시
            Label siteLabel = new Label
            {
                Text = entry.SiteName,
                AutoSize = true,
                ForeColor = Color.Blue, // 파란색으로 글씨 색상 변경
                Cursor = Cursors.Hand, // 마우스 커서를 손 모양으로 설정
                Font = new Font("Arial", 10, FontStyle.Underline) // 밑줄 추가
            };
            Label idLabel = new Label { Text = entry.IdName, AutoSize = true };
            Label passwordLabel = new Label { Text = "******", AutoSize = true };

            Button copyButton = new Button { Text = "복사", AutoSize = true };
            copyButton.Click += (s, e) =>
            {
                Clipboard.SetText(entry.Password);
                MessageBox.Show("비밀번호가 복사되었습니다!");
            };

            // 삭제 버튼 (X 버튼) 초기 상태에서 숨김
            Button deleteButton = new Button { Text = "X", AutoSize = true, Visible = false, Tag = index };

            // X 버튼 클릭 시 삭제 처리
            deleteButton.Click += (s, e) =>
            {
                try
                {
                    Button deleteBtn = (Button)s;
                    int itemIndex = (int)deleteBtn.Tag;

                    // 데이터 삭제
                    AddPwd addPwd = new AddPwd(this);
                    List<PasswordEntry> entries = addPwd.LoadFromJsonFile();

                    if (itemIndex >= 0 && itemIndex < entries.Count)
                    {
                        entries.RemoveAt(itemIndex); // 해당 항목 삭제
                        addPwd.SaveData(entries); // 데이터 저장

                        // UI 갱신
                        flowLayoutPanel1.Controls.Clear();
                        LoadPasswordEntries(); // 데이터 재로딩 및 UI 갱신
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류 발생: {ex.Message}");
                }
            };

            // 사이트 라벨 클릭 시 웹 브라우저 열기
            siteLabel.Click += (s, e) =>
            {
                OpenWebsite(entry.SiteName);  // 사이트 URL 열기
            };

            // FlowLayoutPanel에 항목 추가
            FlowLayoutPanel itemPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(10)
            };

            itemPanel.Controls.Add(siteLabel); // 사이트명 라벨 추가
            itemPanel.Controls.Add(idLabel);
            itemPanel.Controls.Add(passwordLabel);
            itemPanel.Controls.Add(copyButton);
            itemPanel.Controls.Add(deleteButton); // X 버튼 추가 (초기에는 숨김)

            flowLayoutPanel1.Controls.Add(itemPanel); // FlowLayoutPanel에 항목 추가
        }



        public void LoadPasswordEntries()
        {
            AddPwd addPwd = new AddPwd(this);

            // 데이터 로드
            List<PasswordEntry> entries = addPwd.LoadFromJsonFile();

            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < entries.Count; i++)
            {
                AddPasswordToUI(entries[i], i); // index를 제공
            }
        }



        private void CopyPassword(string password)
        {
            Clipboard.SetText(password);
            MessageBox.Show("비밀번호가 복사되었습니다.", "복사 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // X 버튼을 보이거나 숨기는 역할만 담당
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if (item is FlowLayoutPanel panel)
                {
                    // 각 항목에서 X 버튼을 찾고 보이거나 숨김
                    Button deleteButton = panel.Controls.OfType<Button>().FirstOrDefault(btn => btn.Text == "X");

                    if (deleteButton != null)
                    {
                        // X 버튼의 가시성 토글
                        deleteButton.Visible = !deleteButton.Visible; // X 버튼을 보이게 또는 숨기기
                    }
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToUpper(); // 대소문자 구분 없이 검색

            // flowLayoutPanel1에 있는 모든 항목을 순회하며 표시 여부 설정
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if (item is FlowLayoutPanel panel) // 각 항목이 FlowLayoutPanel이라면
                {
                    // 사이트명을 표시하는 Label을 찾아서 비교 (사이트명이 Label인 경우)
                    Label siteLabel = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Text != null);

                    // 사이트명이 존재하면 검색어와 비교
                    if (siteLabel != null)
                    {
                        // 검색어가 사이트명에 포함되는지 확인 (대소문자 구분 없이)
                        if (string.IsNullOrEmpty(searchText) || siteLabel.Text.ToUpper().Contains(searchText))
                        {
                            item.Visible = true; // 포함되면 보이도록 설정
                        }
                        else
                        {
                            item.Visible = false; // 포함되지 않으면 숨김
                        }
                    }
                    else
                    {
                        item.Visible = false; // 사이트명이 없는 항목은 숨김
                    }
                }
            }
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
                // 초기 비밀번호 설정 (기본 비밀번호: "1234a!")
                currentPasswordHash = HashPassword("1234a!");
                SavePassword(currentPasswordHash);
            }
        }

        // 비밀번호 저장
        private void SavePassword(string hashedPassword)
        {
            string jsonData = JsonSerializer.Serialize(hashedPassword);
            File.WriteAllText(passwordFilePath, jsonData);
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

        private void 프로그램비밀번호ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // 비밀번호 변경 폼 호출
            using (ChangeMainPwd changePasswordForm = new ChangeMainPwd(currentPasswordHash))
            {
                if (changePasswordForm.ShowDialog() == DialogResult.OK)
                {
                    currentPasswordHash = changePasswordForm.NewPasswordHash;
                    SavePassword(currentPasswordHash);
                    MessageBox.Show("새 비밀번호가 저장되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void OpenWebsite(string siteName)
        {
            // URL 형식으로 변환 (http://이 없는 경우 추가)
            string url = siteName.StartsWith("http://") || siteName.StartsWith("https://")? siteName : "http://" + siteName;

            try 
            {
                // 웹 브라우저로 해당 URL 열기
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // 기본 브라우저로 사이트 열기
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("웹사이트를 여는 중 오류가 발생했습니다: " + ex.Message);
            }
        }


        private void 보안질문설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 로그인 폼 띄우기
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 로그인 성공 시 보안 질문 설정 폼 열기
                    using (SetSecurityQuestionForm setSecurityQuestionForm = new SetSecurityQuestionForm())
                    {
                        if (setSecurityQuestionForm.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("보안 질문이 성공적으로 설정되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    // 로그인 실패 시 알림
                    MessageBox.Show("인증 실패. 보안 질문을 설정할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
