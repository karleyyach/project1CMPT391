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
            tabControl1 = new TabControl();
            tabPageMyCourses = new TabPage();
            listBox1 = new ListBox();
            tabPageSearch = new TabPage();
            searchButton = new Button();
            searchTextBox = new TextBox();
            searchListBox = new ListBox();
            tabPageCart = new TabPage();
            shoppingCartList = new ListBox();
            comboBoxSemester = new ComboBox();
            comboBoxYear = new ComboBox();
            addToCart = new Button();
            applyFilter = new Button();
            tabControl1.SuspendLayout();
            tabPageMyCourses.SuspendLayout();
            tabPageSearch.SuspendLayout();
            tabPageCart.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMyCourses
            // 
            buttonMyCourses.Location = new Point(27, 58);
            buttonMyCourses.Margin = new Padding(6, 7, 6, 7);
            buttonMyCourses.Name = "buttonMyCourses";
            buttonMyCourses.Size = new Size(251, 68);
            buttonMyCourses.TabIndex = 0;
            buttonMyCourses.Text = "My Courses";
            buttonMyCourses.UseVisualStyleBackColor = true;
            buttonMyCourses.Click += myCoursesBtn_Click;
            // 
            // buttonSearchCourses
            // 
            buttonSearchCourses.Location = new Point(27, 137);
            buttonSearchCourses.Name = "buttonSearchCourses";
            buttonSearchCourses.Size = new Size(251, 72);
            buttonSearchCourses.TabIndex = 1;
            buttonSearchCourses.Text = "Search Courses";
            buttonSearchCourses.UseVisualStyleBackColor = true;
            buttonSearchCourses.Click += searchBtn_Click;
            // 
            // buttonShoppingCart
            // 
            buttonShoppingCart.Location = new Point(27, 215);
            buttonShoppingCart.Name = "buttonShoppingCart";
            buttonShoppingCart.Size = new Size(251, 72);
            buttonShoppingCart.TabIndex = 2;
            buttonShoppingCart.Text = "Shopping Cart";
            buttonShoppingCart.UseVisualStyleBackColor = true;
            buttonShoppingCart.Click += cartBtn_Click;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(tabPageMyCourses);
            tabControl1.Controls.Add(tabPageSearch);
            tabControl1.Controls.Add(tabPageCart);
            tabControl1.Location = new Point(333, 137);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(817, 782);
            tabControl1.TabIndex = 6;
            // 
            // tabPageMyCourses
            // 
            tabPageMyCourses.Controls.Add(listBox1);
            tabPageMyCourses.Location = new Point(34, 4);
            tabPageMyCourses.Name = "tabPageMyCourses";
            tabPageMyCourses.Size = new Size(779, 774);
            tabPageMyCourses.TabIndex = 0;
            tabPageMyCourses.Text = "My Courses";
            tabPageMyCourses.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Items.AddRange(new object[] { "" });
            listBox1.Location = new Point(0, 0);
            listBox1.Margin = new Padding(6, 7, 6, 7);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(784, 779);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPageSearch
            // 
            tabPageSearch.Controls.Add(searchButton);
            tabPageSearch.Controls.Add(searchTextBox);
            tabPageSearch.Controls.Add(searchListBox);
            tabPageSearch.Location = new Point(34, 4);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Size = new Size(779, 774);
            tabPageSearch.TabIndex = 1;
            tabPageSearch.Text = "Search Courses";
            tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.Silver;
            searchButton.FlatAppearance.BorderColor = Color.Silver;
            searchButton.Location = new Point(509, 22);
            searchButton.Margin = new Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(107, 38);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(99, 18);
            searchTextBox.Margin = new Padding(4, 5, 4, 5);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(291, 31);
            searchTextBox.TabIndex = 1;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // searchListBox
            // 
            searchListBox.FormattingEnabled = true;
            searchListBox.ItemHeight = 25;
            searchListBox.Location = new Point(4, 72);
            searchListBox.Margin = new Padding(4, 5, 4, 5);
            searchListBox.Name = "searchListBox";
            searchListBox.Size = new Size(767, 679);
            searchListBox.TabIndex = 0;
            searchListBox.SelectedIndexChanged += searchListBox_SelectedIndexChanged;
            // 
            // tabPageCart
            // 
            tabPageCart.Controls.Add(shoppingCartList);
            tabPageCart.Location = new Point(34, 4);
            tabPageCart.Name = "tabPageCart";
            tabPageCart.Size = new Size(779, 774);
            tabPageCart.TabIndex = 2;
            tabPageCart.Text = "Shopping Cart";
            tabPageCart.UseVisualStyleBackColor = true;
            // 
            // shoppingCartList
            // 
            shoppingCartList.FormattingEnabled = true;
            shoppingCartList.ItemHeight = 25;
            shoppingCartList.Location = new Point(4, 5);
            shoppingCartList.Margin = new Padding(4, 5, 4, 5);
            shoppingCartList.Name = "shoppingCartList";
            shoppingCartList.Size = new Size(763, 754);
            shoppingCartList.TabIndex = 0;
            // 
            // comboBoxSemester
            // 
            comboBoxSemester.FormattingEnabled = true;
            comboBoxSemester.Location = new Point(467, 53);
            comboBoxSemester.Name = "comboBoxSemester";
            comboBoxSemester.Size = new Size(187, 33);
            comboBoxSemester.TabIndex = 7;
            comboBoxSemester.Text = "Semester";
            comboBoxSemester.SelectedIndexChanged += comboBoxSemester_SelectedIndexChanged;
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(663, 53);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(187, 33);
            comboBoxYear.TabIndex = 8;
            comboBoxYear.Text = "Year";
            comboBoxYear.SelectedIndexChanged += comboBoxYear_SelectedIndexChanged;
            // 
            // addToCart
            // 
            addToCart.Location = new Point(27, 548);
            addToCart.Name = "addToCart";
            addToCart.Size = new Size(251, 72);
            addToCart.TabIndex = 9;
            addToCart.Text = "Add to Cart";
            addToCart.UseVisualStyleBackColor = true;
            addToCart.Click += button1_Click;
            // 
            // applyFilter
            // 
            applyFilter.Location = new Point(881, 52);
            applyFilter.Name = "applyFilter";
            applyFilter.Size = new Size(139, 40);
            applyFilter.TabIndex = 10;
            applyFilter.Text = "Apply";
            applyFilter.UseVisualStyleBackColor = true;
            applyFilter.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 933);
            Controls.Add(applyFilter);
            Controls.Add(addToCart);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxSemester);
            Controls.Add(tabControl1);
            Controls.Add(buttonShoppingCart);
            Controls.Add(buttonSearchCourses);
            Controls.Add(buttonMyCourses);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageMyCourses.ResumeLayout(false);
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
    }
}