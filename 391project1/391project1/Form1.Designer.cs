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
            myCoursesBtn = new Button();
            searchBtn = new Button();
            cartBtn = new Button();
            termLabel = new Label();
            changeBtn = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listBox1 = new ListBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // myCoursesBtn
            // 
            myCoursesBtn.Location = new Point(28, 58);
            myCoursesBtn.Margin = new Padding(4);
            myCoursesBtn.Name = "myCoursesBtn";
            myCoursesBtn.Size = new Size(251, 71);
            myCoursesBtn.TabIndex = 0;
            myCoursesBtn.Text = "My Courses";
            myCoursesBtn.UseVisualStyleBackColor = true;
            myCoursesBtn.Click += myCoursesBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(28, 136);
            searchBtn.Margin = new Padding(4);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(251, 71);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search Courses";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // cartBtn
            // 
            cartBtn.Location = new Point(28, 215);
            cartBtn.Margin = new Padding(4);
            cartBtn.Name = "cartBtn";
            cartBtn.Size = new Size(251, 71);
            cartBtn.TabIndex = 2;
            cartBtn.Text = "Shopping Cart";
            cartBtn.UseVisualStyleBackColor = true;
            cartBtn.Click += cartBtn_Click;
            // 
            // termLabel
            // 
            termLabel.AutoSize = true;
            termLabel.Location = new Point(332, 58);
            termLabel.Margin = new Padding(4, 0, 4, 0);
            termLabel.Name = "termLabel";
            termLabel.Size = new Size(174, 25);
            termLabel.TabIndex = 4;
            termLabel.Text = "Current Term: -- -- --";
            termLabel.Click += label1_Click;
            // 
            // changeBtn
            // 
            changeBtn.Location = new Point(339, 89);
            changeBtn.Margin = new Padding(4);
            changeBtn.Name = "changeBtn";
            changeBtn.Size = new Size(104, 46);
            changeBtn.TabIndex = 5;
            changeBtn.Text = "Change";
            changeBtn.UseVisualStyleBackColor = true;
            changeBtn.Click += changeBtn_Click;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(332, 136);
            tabControl1.Margin = new Padding(4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(818, 781);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listBox1);
            tabPage1.Location = new Point(34, 4);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(780, 773);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "My Courses";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Items.AddRange(new object[] { "Course Title 1 | Course 1 Time | Course 1 Instructor", "Course Title 2 | Course 2 Time | Course 2 Instructor" });
            listBox1.Location = new Point(20, 18);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(769, 704);
            listBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(34, 4);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(780, 773);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Search Courses";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(34, 4);
            tabPage3.Margin = new Padding(4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(780, 773);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Shopping Cart";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 932);
            Controls.Add(tabControl1);
            Controls.Add(changeBtn);
            Controls.Add(termLabel);
            Controls.Add(cartBtn);
            Controls.Add(searchBtn);
            Controls.Add(myCoursesBtn);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button myCoursesBtn;
        private Button searchBtn;
        private Button cartBtn;
        private Label termLabel;
        private Button changeBtn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ListBox listBox1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}