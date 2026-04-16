namespace Project
{
    partial class ChangeMainPwd
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
            txtOldPassword = new TextBox();
            txtNewPassword1 = new TextBox();
            txtNewPassword2 = new TextBox();
            SaveBtn = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            PwdStrength = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            SuspendLayout();
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(111, 11);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(155, 23);
            txtOldPassword.TabIndex = 1;
            // 
            // txtNewPassword1
            // 
            txtNewPassword1.Location = new Point(111, 39);
            txtNewPassword1.Name = "txtNewPassword1";
            txtNewPassword1.Size = new Size(155, 23);
            txtNewPassword1.TabIndex = 2;
            txtNewPassword1.TextChanged += txtNewPassword1_TextChanged;
            // 
            // txtNewPassword2
            // 
            txtNewPassword2.Location = new Point(111, 68);
            txtNewPassword2.Name = "txtNewPassword2";
            txtNewPassword2.Size = new Size(155, 23);
            txtNewPassword2.TabIndex = 3;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(291, 12);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 4;
            SaveBtn.Text = "저장";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 14);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 5;
            label2.Text = "현재 비밀번호";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 42);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 6;
            label3.Text = "새 비밀번호";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 71);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 7;
            label4.Text = "새 비밀번호 확인";
            // 
            // PwdStrength
            // 
            PwdStrength.AutoSize = true;
            PwdStrength.Location = new Point(332, 45);
            PwdStrength.Name = "PwdStrength";
            PwdStrength.Size = new Size(31, 15);
            PwdStrength.TabIndex = 12;
            PwdStrength.Text = "강도";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(272, 43);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(56, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Show";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(272, 70);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(56, 19);
            checkBox2.TabIndex = 14;
            checkBox2.Text = "Show";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // ChangeMainPwd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 108);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(PwdStrength);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(SaveBtn);
            Controls.Add(txtNewPassword2);
            Controls.Add(txtNewPassword1);
            Controls.Add(txtOldPassword);
            Name = "ChangeMainPwd";
            Text = "인증 비밀번호 변경";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtOldPassword;
        private TextBox txtNewPassword1;
        private TextBox txtNewPassword2;
        private Button SaveBtn;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label PwdStrength;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}