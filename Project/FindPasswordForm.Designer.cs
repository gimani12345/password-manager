namespace Project
{
    partial class FindPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblQuestion = new Label();
            txtAnswer = new TextBox();
            label1 = new Label();
            VerifyAnswerBtn = new Button();
            grpNewPassword = new GroupBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            SaveNewPasswordBtn = new Button();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            pageSetupDialog1 = new PageSetupDialog();
            errorProvider1 = new ErrorProvider(components);
            grpNewPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(127, 10);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(99, 15);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "저장된 질문 표시";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(126, 28);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(161, 23);
            txtAnswer.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 31);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "답변";
            // 
            // VerifyAnswerBtn
            // 
            VerifyAnswerBtn.Location = new Point(318, 28);
            VerifyAnswerBtn.Name = "VerifyAnswerBtn";
            VerifyAnswerBtn.Size = new Size(75, 23);
            VerifyAnswerBtn.TabIndex = 3;
            VerifyAnswerBtn.Text = "인증";
            VerifyAnswerBtn.UseVisualStyleBackColor = true;
            VerifyAnswerBtn.Click += VerifyAnswerBtn_Click;
            // 
            // grpNewPassword
            // 
            grpNewPassword.Controls.Add(checkBox2);
            grpNewPassword.Controls.Add(checkBox1);
            grpNewPassword.Controls.Add(label3);
            grpNewPassword.Controls.Add(label2);
            grpNewPassword.Controls.Add(SaveNewPasswordBtn);
            grpNewPassword.Controls.Add(txtNewPassword);
            grpNewPassword.Controls.Add(txtConfirmPassword);
            grpNewPassword.Location = new Point(12, 74);
            grpNewPassword.Name = "grpNewPassword";
            grpNewPassword.Size = new Size(381, 105);
            grpNewPassword.TabIndex = 4;
            grpNewPassword.TabStop = false;
            grpNewPassword.Text = "새 비밀번호";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(237, 54);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(56, 19);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Show";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(237, 27);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(56, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Show";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 55);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 9;
            label3.Text = "새 비밀번호 확인";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 26);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 8;
            label2.Text = "새 비밀번호";
            // 
            // SaveNewPasswordBtn
            // 
            SaveNewPasswordBtn.Location = new Point(306, 23);
            SaveNewPasswordBtn.Name = "SaveNewPasswordBtn";
            SaveNewPasswordBtn.Size = new Size(75, 23);
            SaveNewPasswordBtn.TabIndex = 7;
            SaveNewPasswordBtn.Text = "저장";
            SaveNewPasswordBtn.UseVisualStyleBackColor = true;
            SaveNewPasswordBtn.Click += SaveNewPasswordBtn_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(131, 23);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(100, 23);
            txtNewPassword.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(131, 52);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 23);
            txtConfirmPassword.TabIndex = 6;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FindPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 202);
            Controls.Add(grpNewPassword);
            Controls.Add(VerifyAnswerBtn);
            Controls.Add(label1);
            Controls.Add(txtAnswer);
            Controls.Add(lblQuestion);
            Name = "FindPasswordForm";
            Text = "비밀번호 찾기";
            grpNewPassword.ResumeLayout(false);
            grpNewPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private TextBox txtAnswer;
        private Label label1;
        private Button VerifyAnswerBtn;
        private GroupBox grpNewPassword;
        private Button SaveNewPasswordBtn;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private PageSetupDialog pageSetupDialog1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label2;
        private ErrorProvider errorProvider1;
    }
}