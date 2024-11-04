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
            comboBox1 = new ComboBox();
            m_repoUrl_textBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(349, 25);
            comboBox1.TabIndex = 0;
            // 
            // m_repoUrl_textBox
            // 
            m_repoUrl_textBox.Location = new Point(13, 48);
            m_repoUrl_textBox.Name = "m_repoUrl_textBox";
            m_repoUrl_textBox.PlaceholderText = "url to git clone sources";
            m_repoUrl_textBox.Size = new Size(348, 23);
            m_repoUrl_textBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(382, 14);
            button1.Name = "button1";
            button1.Size = new Size(84, 23);
            button1.TabIndex = 2;
            button1.Text = "Release";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(382, 48);
            button2.Name = "button2";
            button2.Size = new Size(84, 23);
            button2.TabIndex = 3;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(472, 14);
            button3.Name = "button3";
            button3.Size = new Size(84, 23);
            button3.TabIndex = 2;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 88);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(648, 163);
            textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 263);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(m_repoUrl_textBox);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox m_repoUrl_textBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
    }
}
