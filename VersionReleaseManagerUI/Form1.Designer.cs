namespace VersionReleaseManagerUI
{
    partial class Form1
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
            if (disposing && (components != null)) {
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
            u_cb_ProjectName = new ComboBox();
            u_tb_repoUr = new TextBox();
            u_b_release = new Button();
            u_button2 = new Button();
            u_button3 = new Button();
            u_tb_msg = new TextBox();
            u_cb_brachName = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            u_tb_tagName = new TextBox();
            u_button4 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            u_b_testConfig = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // u_cb_ProjectName
            // 
            u_cb_ProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            u_cb_ProjectName.FormattingEnabled = true;
            u_cb_ProjectName.Location = new Point(3, 3);
            u_cb_ProjectName.Name = "u_cb_ProjectName";
            u_cb_ProjectName.Size = new Size(427, 25);
            u_cb_ProjectName.TabIndex = 0;
            // 
            // u_tb_repoUr
            // 
            u_tb_repoUr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            u_tb_repoUr.Location = new Point(3, 34);
            u_tb_repoUr.Name = "u_tb_repoUr";
            u_tb_repoUr.PlaceholderText = "github responsity uri";
            u_tb_repoUr.Size = new Size(427, 23);
            u_tb_repoUr.TabIndex = 1;
            // 
            // u_b_release
            // 
            u_b_release.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            u_b_release.Location = new Point(3, 3);
            u_b_release.Name = "u_b_release";
            u_b_release.Size = new Size(94, 23);
            u_b_release.TabIndex = 2;
            u_b_release.Text = "Release";
            u_b_release.UseVisualStyleBackColor = true;
            u_b_release.Click += b_release_Click;
            // 
            // u_button2
            // 
            u_button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            u_button2.Enabled = false;
            u_button2.Location = new Point(3, 32);
            u_button2.Name = "u_button2";
            u_button2.Size = new Size(94, 23);
            u_button2.TabIndex = 3;
            u_button2.Text = "Update";
            u_button2.UseVisualStyleBackColor = true;
            // 
            // u_button3
            // 
            u_button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            u_button3.Enabled = false;
            u_button3.Location = new Point(3, 61);
            u_button3.Name = "u_button3";
            u_button3.Size = new Size(94, 23);
            u_button3.TabIndex = 2;
            u_button3.Text = "Delete";
            u_button3.UseVisualStyleBackColor = true;
            // 
            // u_tb_msg
            // 
            u_tb_msg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            u_tb_msg.Location = new Point(16, 103);
            u_tb_msg.Multiline = true;
            u_tb_msg.Name = "u_tb_msg";
            u_tb_msg.Size = new Size(549, 253);
            u_tb_msg.TabIndex = 4;
            // 
            // u_cb_brachName
            // 
            u_cb_brachName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            u_cb_brachName.FormattingEnabled = true;
            u_cb_brachName.Items.AddRange(new object[] { "Auto Branch" });
            u_cb_brachName.Location = new Point(438, 3);
            u_cb_brachName.Name = "u_cb_brachName";
            u_cb_brachName.Size = new Size(108, 25);
            u_cb_brachName.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.04412F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.955883F));
            tableLayoutPanel1.Controls.Add(u_cb_brachName, 1, 0);
            tableLayoutPanel1.Controls.Add(u_cb_ProjectName, 0, 0);
            tableLayoutPanel1.Controls.Add(u_tb_repoUr, 0, 1);
            tableLayoutPanel1.Controls.Add(u_tb_tagName, 1, 1);
            tableLayoutPanel1.Location = new Point(16, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.5423737F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.4576263F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(549, 59);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // u_tb_tagName
            // 
            u_tb_tagName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            u_tb_tagName.Location = new Point(436, 34);
            u_tb_tagName.Name = "u_tb_tagName";
            u_tb_tagName.PlaceholderText = "tag Name";
            u_tb_tagName.Size = new Size(110, 23);
            u_tb_tagName.TabIndex = 1;
            // 
            // u_button4
            // 
            u_button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            u_button4.Enabled = false;
            u_button4.Location = new Point(3, 90);
            u_button4.Name = "u_button4";
            u_button4.Size = new Size(94, 23);
            u_button4.TabIndex = 2;
            u_button4.Text = "Add";
            u_button4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(u_b_release);
            flowLayoutPanel1.Controls.Add(u_button2);
            flowLayoutPanel1.Controls.Add(u_button3);
            flowLayoutPanel1.Controls.Add(u_button4);
            flowLayoutPanel1.Controls.Add(u_b_testConfig);
            flowLayoutPanel1.Location = new Point(571, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(114, 341);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // u_b_testConfig
            // 
            u_b_testConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            u_b_testConfig.Location = new Point(3, 119);
            u_b_testConfig.Name = "u_b_testConfig";
            u_b_testConfig.Size = new Size(94, 23);
            u_b_testConfig.TabIndex = 2;
            u_b_testConfig.Text = "生成配置模板";
            u_b_testConfig.UseVisualStyleBackColor = true;
            u_b_testConfig.Click += u_b_testConfig_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 368);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(u_tb_msg);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox u_cb_ProjectName;
        private TextBox u_tb_repoUr;
        private Button u_b_release;
        private Button u_button2;
        private Button u_button3;
        private TextBox u_tb_msg;
        private ComboBox u_cb_brachName;
        private TableLayoutPanel tableLayoutPanel1;
        private Button u_button4;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox u_tb_tagName;
        private Button u_b_testConfig;
    }
}
