namespace _391project1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            button4 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listBox1 = new ListBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(22, 46);
            button1.Name = "button1";
            button1.Size = new Size(201, 57);
            button1.TabIndex = 0;
            button1.Text = "My Courses";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(22, 109);
            button2.Name = "button2";
            button2.Size = new Size(201, 57);
            button2.TabIndex = 1;
            button2.Text = "Search Courses";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(22, 172);
            button3.Name = "button3";
            button3.Size = new Size(201, 57);
            button3.TabIndex = 2;
            button3.Text = "Shopping Cart";
            button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 46);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 4;
            label1.Text = "Current Term: -- -- --";
            label1.Click += label1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(271, 71);
            button4.Name = "button4";
            button4.Size = new Size(83, 37);
            button4.TabIndex = 5;
            button4.Text = "Change";
            button4.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(266, 109);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(654, 625);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listBox1);
            tabPage1.Location = new Point(30, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(620, 617);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "My Courses";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Items.AddRange(new object[] { "Course Title 1 | Course 1 Time | Course 1 Instructor", "Course Title 2 | Course 2 Time | Course 2 Instructor" });
            listBox1.Location = new Point(16, 14);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(616, 564);
            listBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(30, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(620, 617);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Search Courses";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(30, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(620, 617);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Shopping Cart";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 746);
            Controls.Add(tabControl1);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Button button4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ListBox listBox1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}