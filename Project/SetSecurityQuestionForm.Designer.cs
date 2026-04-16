namespace Project
{
    partial class SetSecurityQuestionForm
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
            comboBoxQuestions = new ComboBox();
            SaveBtn = new Button();
            txtAnswer = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBoxQuestions
            // 
            comboBoxQuestions.FormattingEnabled = true;
            comboBoxQuestions.Location = new Point(12, 12);
            comboBoxQuestions.Name = "comboBoxQuestions";
            comboBoxQuestions.Size = new Size(245, 23);
            comboBoxQuestions.TabIndex = 0;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(273, 25);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 1;
            SaveBtn.Text = "저장";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(56, 40);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(201, 23);
            txtAnswer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "답변";
            // 
            // SetSecurityQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 83);
            Controls.Add(label1);
            Controls.Add(txtAnswer);
            Controls.Add(SaveBtn);
            Controls.Add(comboBoxQuestions);
            Name = "SetSecurityQuestionForm";
            Text = "보안확인 질문 설정";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxQuestions;
        private Button SaveBtn;
        private TextBox txtAnswer;
        private Label label1;
    }
}