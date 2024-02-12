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
            addToCart = new Button();
            applyFilter = new Button();
            tabControl1.SuspendLayout();
            tabPageMyCourses.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMyCourses
            // 
            buttonMyCourses.Location = new Point(33, 69);
            buttonMyCourses.Margin = new Padding(4);
            buttonMyCourses.Name = "buttonMyCourses";
            buttonMyCourses.Size = new Size(302, 86);
            buttonMyCourses.TabIndex = 0;
            buttonMyCourses.Text = "My Courses";
            buttonMyCourses.UseVisualStyleBackColor = true;
            buttonMyCourses.Click += myCoursesBtn_Click;
            // 
            // buttonSearchCourses
            // 
            buttonSearchCourses.Location = new Point(33, 164);
            buttonSearchCourses.Margin = new Padding(4);
            buttonSearchCourses.Name = "buttonSearchCourses";
            buttonSearchCourses.Size = new Size(302, 86);
            buttonSearchCourses.TabIndex = 1;
            buttonSearchCourses.Text = "Search Courses";
            buttonSearchCourses.UseVisualStyleBackColor = true;
            buttonSearchCourses.Click += searchBtn_Click;
            // 
            // buttonShoppingCart
            // 
            buttonShoppingCart.Location = new Point(33, 258);
            buttonShoppingCart.Margin = new Padding(4);
            buttonShoppingCart.Name = "buttonShoppingCart";
            buttonShoppingCart.Size = new Size(302, 86);
            buttonShoppingCart.TabIndex = 2;
            buttonShoppingCart.Text = "Shopping Cart";
            buttonShoppingCart.UseVisualStyleBackColor = true;
            buttonShoppingCart.Click += cartBtn_Click;
            // 
            // labelCurrentTerm
            // 
            labelCurrentTerm.AutoSize = true;
            labelCurrentTerm.Location = new Point(399, 69);
            labelCurrentTerm.Margin = new Padding(4, 0, 4, 0);
            labelCurrentTerm.Name = "labelCurrentTerm";
            labelCurrentTerm.Size = new Size(144, 30);
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
            tabControl1.Location = new Point(399, 164);
            tabControl1.Margin = new Padding(4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(981, 938);
            tabControl1.TabIndex = 6;
            // 
            // tabPageMyCourses
            // 
            tabPageMyCourses.Controls.Add(listBox1);
            tabPageMyCourses.Location = new Point(38, 4);
            tabPageMyCourses.Margin = new Padding(4);
            tabPageMyCourses.Name = "tabPageMyCourses";
            tabPageMyCourses.Size = new Size(939, 930);
            tabPageMyCourses.TabIndex = 0;
            tabPageMyCourses.Text = "My Courses";
            tabPageMyCourses.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Items.AddRange(new object[] { "" });
            listBox1.Location = new Point(24, 21);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(922, 844);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPageSearch
            // 
            tabPageSearch.Location = new Point(38, 4);
            tabPageSearch.Margin = new Padding(4);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Size = new Size(939, 930);
            tabPageSearch.TabIndex = 1;
            tabPageSearch.Text = "Search Courses";
            tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageCart
            // 
            tabPageCart.Location = new Point(38, 4);
            tabPageCart.Margin = new Padding(4);
            tabPageCart.Name = "tabPageCart";
            tabPageCart.Size = new Size(939, 930);
            tabPageCart.TabIndex = 2;
            tabPageCart.Text = "Shopping Cart";
            tabPageCart.UseVisualStyleBackColor = true;
            // 
            // comboBoxSemester
            // 
            comboBoxSemester.FormattingEnabled = true;
            comboBoxSemester.Location = new Point(560, 64);
            comboBoxSemester.Margin = new Padding(4);
            comboBoxSemester.Name = "comboBoxSemester";
            comboBoxSemester.Size = new Size(224, 38);
            comboBoxSemester.TabIndex = 7;
            comboBoxSemester.Text = "Semester";
            comboBoxSemester.SelectedIndexChanged += comboBoxSemester_SelectedIndexChanged;
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(795, 64);
            comboBoxYear.Margin = new Padding(4);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(224, 38);
            comboBoxYear.TabIndex = 8;
            comboBoxYear.Text = "Year";
            comboBoxYear.SelectedIndexChanged += comboBoxYear_SelectedIndexChanged;
            // 
            // addToCart
            // 
            addToCart.Location = new Point(33, 658);
            addToCart.Margin = new Padding(4);
            addToCart.Name = "addToCart";
            addToCart.Size = new Size(302, 86);
            addToCart.TabIndex = 9;
            addToCart.Text = "Add to Cart";
            addToCart.UseVisualStyleBackColor = true;
            addToCart.Click += button1_Click;
            // 
            // applyFilter
            // 
            applyFilter.Location = new Point(1057, 62);
            applyFilter.Name = "applyFilter";
            applyFilter.Size = new Size(166, 40);
            applyFilter.TabIndex = 10;
            applyFilter.Text = "Apply";
            applyFilter.UseVisualStyleBackColor = true;
            applyFilter.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 1119);
            Controls.Add(applyFilter);
            Controls.Add(addToCart);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxSemester);
            Controls.Add(tabControl1);
            Controls.Add(labelCurrentTerm);
            Controls.Add(buttonShoppingCart);
            Controls.Add(buttonSearchCourses);
            Controls.Add(buttonMyCourses);
            Margin = new Padding(4);
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
        private Button addToCart;
        private Button applyFilter;
        private TextBox searchTextBox;
        private ListBox searchListBox;
        private Button searchButton;
        private ListBox shoppingCartList;
    }
}
