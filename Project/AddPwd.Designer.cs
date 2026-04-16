namespace Project
{
    partial class AddPwd
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSiteName = new TextBox();
            txtIdName = new TextBox();
            txtPwd = new TextBox();
            txtPwdCheck = new TextBox();
            SaveBtn = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            PwdStrength = new Label();
            RndBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 10);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "사이트";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 39);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "아이디";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 68);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 2;
            label3.Text = "비밀번호";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 97);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 3;
            label4.Text = "비밀번호 확인";
            // 
            // txtSiteName
            // 
            txtSiteName.Location = new Point(114, 7);
            txtSiteName.Name = "txtSiteName";
            txtSiteName.Size = new Size(158, 23);
            txtSiteName.TabIndex = 4;
            // 
            // txtIdName
            // 
            txtIdName.Location = new Point(114, 36);
            txtIdName.Name = "txtIdName";
            txtIdName.Size = new Size(158, 23);
            txtIdName.TabIndex = 5;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(114, 65);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(158, 23);
            txtPwd.TabIndex = 6;
            txtPwd.TextChanged += txtPwd_TextChanged;
            // 
            // txtPwdCheck
            // 
            txtPwdCheck.Location = new Point(114, 94);
            txtPwdCheck.Name = "txtPwdCheck";
            txtPwdCheck.Size = new Size(158, 23);
            txtPwdCheck.TabIndex = 7;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(303, 7);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(59, 23);
            SaveBtn.TabIndex = 8;
            SaveBtn.Text = "저장";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(278, 67);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(56, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Show";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(278, 96);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(56, 19);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "Show";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // PwdStrength
            // 
            PwdStrength.AutoSize = true;
            PwdStrength.Location = new Point(339, 68);
            PwdStrength.Name = "PwdStrength";
            PwdStrength.Size = new Size(31, 15);
            PwdStrength.TabIndex = 11;
            PwdStrength.Text = "강도";
            // 
            // RndBtn
            // 
            RndBtn.Location = new Point(114, 123);
            RndBtn.Name = "RndBtn";
            RndBtn.Size = new Size(158, 23);
            RndBtn.TabIndex = 12;
            RndBtn.Text = "비밀번호 랜덤 생성";
            RndBtn.UseVisualStyleBackColor = true;
            RndBtn.Click += RndBtn_Click;
            // 
            // AddPwd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 150);
            Controls.Add(RndBtn);
            Controls.Add(PwdStrength);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(SaveBtn);
            Controls.Add(txtPwdCheck);
            Controls.Add(txtPwd);
            Controls.Add(txtIdName);
            Controls.Add(txtSiteName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddPwd";
            Text = "비밀번호 추가";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSiteName;
        private TextBox txtIdName;
        private TextBox txtPwd;
        private TextBox txtPwdCheck;
        private Button SaveBtn;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label PwdStrength;
        private Button RndBtn;
    }
}