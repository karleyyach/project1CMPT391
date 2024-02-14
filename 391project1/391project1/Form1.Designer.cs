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
            tabControl1 = new TabControl();
            tabPageMyCourses = new TabPage();
            closeButton = new Button();
            courseInfoListBox = new ListBox();
            courseInfoLabel = new Label();
            viewCourseButton = new Button();
            MyCoursesHeading = new Label();
            listBox1 = new ListBox();
            tabPageSearch = new TabPage();
            searchButton = new Button();
            addToCart = new Button();
            searchTextBox = new TextBox();
            searchListBox = new ListBox();
            tabPageCart = new TabPage();
            shoppingCartList = new ListBox();
            comboBoxSemester = new ComboBox();
            comboBoxYear = new ComboBox();
            applyFilter = new Button();
            tabControl1.SuspendLayout();
            tabPageMyCourses.SuspendLayout();
            tabPageSearch.SuspendLayout();
            tabPageCart.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(tabPageMyCourses);
            tabControl1.Controls.Add(tabPageSearch);
            tabControl1.Controls.Add(tabPageCart);
            tabControl1.Location = new Point(20, 171);
            tabControl1.Margin = new Padding(4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1475, 1001);
            tabControl1.TabIndex = 6;
            // 
            // tabPageMyCourses
            // 
            tabPageMyCourses.Controls.Add(closeButton);
            tabPageMyCourses.Controls.Add(courseInfoListBox);
            tabPageMyCourses.Controls.Add(courseInfoLabel);
            tabPageMyCourses.Controls.Add(viewCourseButton);
            tabPageMyCourses.Controls.Add(MyCoursesHeading);
            tabPageMyCourses.Controls.Add(listBox1);
            tabPageMyCourses.Location = new Point(43, 4);
            tabPageMyCourses.Margin = new Padding(4);
            tabPageMyCourses.Name = "tabPageMyCourses";
            tabPageMyCourses.Size = new Size(1428, 993);
            tabPageMyCourses.TabIndex = 0;
            tabPageMyCourses.Text = "My Courses";
            tabPageMyCourses.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(658, 506);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(150, 46);
            closeButton.TabIndex = 5;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Visible = false;
            closeButton.Click += closeButton_Click;
            // 
            // courseInfoListBox
            // 
            courseInfoListBox.BackColor = SystemColors.Window;
            courseInfoListBox.ColumnWidth = 525;
            courseInfoListBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            courseInfoListBox.FormattingEnabled = true;
            courseInfoListBox.ItemHeight = 32;
            courseInfoListBox.Location = new Point(62, 188);
            courseInfoListBox.Name = "courseInfoListBox";
            courseInfoListBox.Size = new Size(1307, 420);
            courseInfoListBox.TabIndex = 4;
            courseInfoListBox.Visible = false;
            courseInfoListBox.SelectedIndexChanged += courseInfoListBox_SelectedIndexChanged;
            // 
            // courseInfoLabel
            // 
            courseInfoLabel.AutoSize = true;
            courseInfoLabel.Location = new Point(907, 21);
            courseInfoLabel.Margin = new Padding(6, 0, 6, 0);
            courseInfoLabel.Name = "courseInfoLabel";
            courseInfoLabel.Size = new Size(78, 32);
            courseInfoLabel.TabIndex = 3;
            courseInfoLabel.Text = "label1";
            courseInfoLabel.UseWaitCursor = true;
            // 
            // viewCourseButton
            // 
            viewCourseButton.Location = new Point(1043, 436);
            viewCourseButton.Margin = new Padding(6);
            viewCourseButton.Name = "viewCourseButton";
            viewCourseButton.Size = new Size(247, 96);
            viewCourseButton.TabIndex = 2;
            viewCourseButton.Text = "View Course Details";
            viewCourseButton.UseVisualStyleBackColor = true;
            viewCourseButton.Click += viewCourseButton_Click;
            // 
            // MyCoursesHeading
            // 
            MyCoursesHeading.AutoSize = true;
            MyCoursesHeading.Location = new Point(28, 32);
            MyCoursesHeading.Margin = new Padding(6, 0, 6, 0);
            MyCoursesHeading.Name = "MyCoursesHeading";
            MyCoursesHeading.Size = new Size(430, 32);
            MyCoursesHeading.TabIndex = 1;
            MyCoursesHeading.Text = "Course ID | Section ID | Semester | Year";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 32;
            listBox1.Items.AddRange(new object[] { "" });
            listBox1.Location = new Point(7, 73);
            listBox1.Margin = new Padding(7, 9, 7, 9);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(882, 900);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPageSearch
            // 
            tabPageSearch.Controls.Add(searchButton);
            tabPageSearch.Controls.Add(addToCart);
            tabPageSearch.Controls.Add(searchTextBox);
            tabPageSearch.Controls.Add(searchListBox);
            tabPageSearch.Location = new Point(43, 4);
            tabPageSearch.Margin = new Padding(4);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Size = new Size(1428, 993);
            tabPageSearch.TabIndex = 1;
            tabPageSearch.Text = "Search Courses";
            tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.Silver;
            searchButton.FlatAppearance.BorderColor = Color.Silver;
            searchButton.Location = new Point(537, 30);
            searchButton.Margin = new Padding(6);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(139, 49);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // addToCart
            // 
            addToCart.Location = new Point(802, 17);
            addToCart.Margin = new Padding(4);
            addToCart.Name = "addToCart";
            addToCart.Size = new Size(197, 62);
            addToCart.TabIndex = 9;
            addToCart.Text = "Add to Cart";
            addToCart.UseVisualStyleBackColor = true;
            addToCart.Click += button1_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(145, 30);
            searchTextBox.Margin = new Padding(6);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(377, 39);
            searchTextBox.TabIndex = 1;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // searchListBox
            // 
            searchListBox.FormattingEnabled = true;
            searchListBox.HorizontalScrollbar = true;
            searchListBox.ItemHeight = 32;
            searchListBox.Location = new Point(6, 92);
            searchListBox.Margin = new Padding(6);
            searchListBox.Name = "searchListBox";
            searchListBox.Size = new Size(1402, 868);
            searchListBox.TabIndex = 0;
            searchListBox.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // tabPageCart
            // 
            tabPageCart.Controls.Add(shoppingCartList);
            tabPageCart.Location = new Point(43, 4);
            tabPageCart.Margin = new Padding(4);
            tabPageCart.Name = "tabPageCart";
            tabPageCart.Size = new Size(1428, 993);
            tabPageCart.TabIndex = 2;
            tabPageCart.Text = "Shopping Cart";
            tabPageCart.UseVisualStyleBackColor = true;
            // 
            // shoppingCartList
            // 
            shoppingCartList.FormattingEnabled = true;
            shoppingCartList.ItemHeight = 32;
            shoppingCartList.Location = new Point(6, 6);
            shoppingCartList.Margin = new Padding(6);
            shoppingCartList.Name = "shoppingCartList";
            shoppingCartList.Size = new Size(990, 964);
            shoppingCartList.TabIndex = 0;
            // 
            // comboBoxSemester
            // 
            comboBoxSemester.FormattingEnabled = true;
            comboBoxSemester.Location = new Point(607, 68);
            comboBoxSemester.Margin = new Padding(4);
            comboBoxSemester.Name = "comboBoxSemester";
            comboBoxSemester.Size = new Size(242, 40);
            comboBoxSemester.TabIndex = 7;
            comboBoxSemester.Text = "Semester";
            comboBoxSemester.SelectedIndexChanged += comboBoxSemester_SelectedIndexChanged;
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(862, 68);
            comboBoxYear.Margin = new Padding(4);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(242, 40);
            comboBoxYear.TabIndex = 8;
            comboBoxYear.Text = "Year";
            comboBoxYear.SelectedIndexChanged += comboBoxYear_SelectedIndexChanged;
            // 
            // applyFilter
            // 
            applyFilter.Location = new Point(1146, 66);
            applyFilter.Margin = new Padding(4);
            applyFilter.Name = "applyFilter";
            applyFilter.Size = new Size(180, 51);
            applyFilter.TabIndex = 10;
            applyFilter.Text = "Apply";
            applyFilter.UseVisualStyleBackColor = true;
            applyFilter.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1515, 1195);
            Controls.Add(applyFilter);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxSemester);
            Controls.Add(tabControl1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageMyCourses.ResumeLayout(false);
            tabPageMyCourses.PerformLayout();
            tabPageSearch.ResumeLayout(false);
            tabPageSearch.PerformLayout();
            tabPageCart.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonMyCourses;
        private Button buttonSearchCourses;
        private Button buttonShoppingCart;
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
        private Button searchButton;
        private ListBox shoppingCartList;
        private ListBox searchListBox;
        private Label MyCoursesHeading;
        private Button viewCourseButton;
        private ListBox courseInfoListBox;
        private Button closeButton;
        private Label courseInfoLabel;
    }
}