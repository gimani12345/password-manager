namespace Project
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            설정ToolStripMenuItem = new ToolStripMenuItem();
            프로그램비밀번호ToolStripMenuItem = new ToolStripMenuItem();
            보안질문설정ToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            txtSearch = new TextBox();
            PlusBtn = new Button();
            DeleteBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 설정ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(323, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // 설정ToolStripMenuItem
            // 
            설정ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 프로그램비밀번호ToolStripMenuItem, 보안질문설정ToolStripMenuItem });
            설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            설정ToolStripMenuItem.Size = new Size(43, 20);
            설정ToolStripMenuItem.Text = "설정";
            // 
            // 프로그램비밀번호ToolStripMenuItem
            // 
            프로그램비밀번호ToolStripMenuItem.Name = "프로그램비밀번호ToolStripMenuItem";
            프로그램비밀번호ToolStripMenuItem.Size = new Size(202, 22);
            프로그램비밀번호ToolStripMenuItem.Text = "프로그램 비밀번호 변경";
            프로그램비밀번호ToolStripMenuItem.Click += 프로그램비밀번호ToolStripMenuItem_Click_1;
            // 
            // 보안질문설정ToolStripMenuItem
            // 
            보안질문설정ToolStripMenuItem.Name = "보안질문설정ToolStripMenuItem";
            보안질문설정ToolStripMenuItem.Size = new Size(202, 22);
            보안질문설정ToolStripMenuItem.Text = "보안 질문 설정";
            보안질문설정ToolStripMenuItem.Click += 보안질문설정ToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 27);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "사이트";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(49, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // PlusBtn
            // 
            PlusBtn.Location = new Point(276, 22);
            PlusBtn.Name = "PlusBtn";
            PlusBtn.Size = new Size(22, 23);
            PlusBtn.TabIndex = 5;
            PlusBtn.Text = "+";
            PlusBtn.UseVisualStyleBackColor = true;
            PlusBtn.Click += PlusBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(299, 22);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(22, 23);
            DeleteBtn.TabIndex = 6;
            DeleteBtn.Text = "-";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 64);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(323, 386);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(DeleteBtn);
            Controls.Add(PlusBtn);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "비밀번호 관리자";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 설정ToolStripMenuItem;
        private ToolStripMenuItem 프로그램비밀번호ToolStripMenuItem;
        private Label label1;
        private TextBox txtSearch;
        private Button PlusBtn;
        private Button DeleteBtn;
        public FlowLayoutPanel flowLayoutPanel1;
        private ToolStripMenuItem 보안질문설정ToolStripMenuItem;
    }
}
