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
            buttonMyCourses = new Button();
            buttonSearchCourses = new Button();
            buttonShoppingCart = new Button();
            labelCurrentTerm = new Label();
            tabControl1 = new TabControl();
            tabPageMyCourses = new TabPage();
            listBox1 = new ListBox();
            tabPageSearch = new TabPage();
            tabPageCart = new TabPage();
            comboBoxSemester = new ComboBox();
            comboBoxYear = new ComboBox();
            tabControl1.SuspendLayout();
            tabPageMyCourses.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMyCourses
            // 
            buttonMyCourses.Location = new Point(22, 46);
            buttonMyCourses.Name = "buttonMyCourses";
            buttonMyCourses.Size = new Size(201, 57);
            buttonMyCourses.TabIndex = 0;
            buttonMyCourses.Text = "My Courses";
            buttonMyCourses.UseVisualStyleBackColor = true;
            buttonMyCourses.Click += myCoursesBtn_Click;
            // 
            // buttonSearchCourses
            // 
            buttonSearchCourses.Location = new Point(22, 109);
            buttonSearchCourses.Name = "buttonSearchCourses";
            buttonSearchCourses.Size = new Size(201, 57);
            buttonSearchCourses.TabIndex = 1;
            buttonSearchCourses.Text = "Search Courses";
            buttonSearchCourses.UseVisualStyleBackColor = true;
            buttonSearchCourses.Click += searchBtn_Click;
            // 
            // buttonShoppingCart
            // 
            buttonShoppingCart.Location = new Point(22, 172);
            buttonShoppingCart.Name = "buttonShoppingCart";
            buttonShoppingCart.Size = new Size(201, 57);
            buttonShoppingCart.TabIndex = 2;
            buttonShoppingCart.Text = "Shopping Cart";
            buttonShoppingCart.UseVisualStyleBackColor = true;
            buttonShoppingCart.Click += cartBtn_Click;
            // 
            // labelCurrentTerm
            // 
            labelCurrentTerm.AutoSize = true;
            labelCurrentTerm.Location = new Point(266, 46);
            labelCurrentTerm.Name = "labelCurrentTerm";
            labelCurrentTerm.Size = new Size(101, 20);
            labelCurrentTerm.TabIndex = 4;
            labelCurrentTerm.Text = "Current Term: ";
            labelCurrentTerm.Click += label1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(tabPageMyCourses);
            tabControl1.Controls.Add(tabPageSearch);
            tabControl1.Controls.Add(tabPageCart);
            tabControl1.Location = new Point(266, 109);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(654, 625);
            tabControl1.TabIndex = 6;
            // 
            // tabPageMyCourses
            // 
            tabPageMyCourses.Controls.Add(listBox1);
            tabPageMyCourses.Location = new Point(30, 4);
            tabPageMyCourses.Name = "tabPageMyCourses";
            tabPageMyCourses.Size = new Size(620, 617);
            tabPageMyCourses.TabIndex = 0;
            tabPageMyCourses.Text = "My Courses";
            tabPageMyCourses.UseVisualStyleBackColor = true;
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
            // tabPageSearch
            // 
            tabPageSearch.Location = new Point(30, 4);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Size = new Size(620, 617);
            tabPageSearch.TabIndex = 1;
            tabPageSearch.Text = "Search Courses";
            tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageCart
            // 
            tabPageCart.Location = new Point(30, 4);
            tabPageCart.Name = "tabPageCart";
            tabPageCart.Size = new Size(620, 617);
            tabPageCart.TabIndex = 2;
            tabPageCart.Text = "Shopping Cart";
            tabPageCart.UseVisualStyleBackColor = true;
            // 
            // comboBoxSemester
            // 
            comboBoxSemester.FormattingEnabled = true;
            comboBoxSemester.Location = new Point(373, 43);
            comboBoxSemester.Name = "comboBoxSemester";
            comboBoxSemester.Size = new Size(151, 28);
            comboBoxSemester.TabIndex = 7;
            comboBoxSemester.Text = "Semester";
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(530, 43);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(151, 28);
            comboBoxYear.TabIndex = 8;
            comboBoxYear.Text = "Year";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 746);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxSemester);
            Controls.Add(tabControl1);
            Controls.Add(labelCurrentTerm);
            Controls.Add(buttonShoppingCart);
            Controls.Add(buttonSearchCourses);
            Controls.Add(buttonMyCourses);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageMyCourses.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonMyCourses;
        private Button buttonSearchCourses;
        private Button buttonShoppingCart;
        private Label labelCurrentTerm;
        private TabControl tabControl1;
        private TabPage tabPageMyCourses;
        private ListBox listBox1;
        private TabPage tabPageSearch;
        private TabPage tabPageCart;
        private ComboBox comboBoxSemester;
        private ComboBox comboBoxYear;
    }
}