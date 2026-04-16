using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using System.Windows.Forms;
using static Project.AddPwd;

namespace Project
{
    public partial class SetSecurityQuestionForm : Form
    {
        private string securityFilePath = "securityQuestion.json"; // 보안 질문 저장 파일 경로

        public SetSecurityQuestionForm()
        {
            InitializeComponent();

            // 보안 질문 리스트 초기화
            List<string> questions = new List<string>
            {
                "출신 초등학교는?",
                "가장 좋아하는 동물은?",
                "가장 좋아하는 음식은?",
                "가장 친한 친구의 이름은?",
                "첫 번째 애완동물의 이름은?"

            };
            comboBoxQuestions.DataSource = questions; // 콤보박스에 질문 리스트 연결
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string selectedQuestion = comboBoxQuestions.SelectedItem.ToString();
            string answer = txtAnswer.Text.Trim();

            if (string.IsNullOrWhiteSpace(answer))
            {
                MessageBox.Show("답변을 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 보안 질문과 답변 암호화
            string encryptedQuestion = AesEncryption.Encrypt(selectedQuestion);
            string encryptedAnswer = AesEncryption.Encrypt(answer);

            // JSON 데이터 저장
            var securityData = new { Question = encryptedQuestion, Answer = encryptedAnswer };
            string jsonData = JsonSerializer.Serialize(securityData);
            File.WriteAllText(securityFilePath, jsonData);

            MessageBox.Show("보안 질문이 저장되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
