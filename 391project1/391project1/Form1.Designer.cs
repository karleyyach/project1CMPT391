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
            searchButton = new Button();
            searchTextBox = new TextBox();
            searchListBox = new ListBox();
            tabPageCart = new TabPage();
            comboBoxSemester = new ComboBox();
            comboBoxYear = new ComboBox();
            addToCart = new Button();
            applyFilter = new Button();
            shoppingCartList = new ListBox();
            tabControl1.SuspendLayout();
            tabPageMyCourses.SuspendLayout();
            tabPageSearch.SuspendLayout();
            tabPageCart.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMyCourses
            // 
            buttonMyCourses.Location = new Point(19, 34);
            buttonMyCourses.Margin = new Padding(2);
            buttonMyCourses.Name = "buttonMyCourses";
            buttonMyCourses.Size = new Size(176, 43);
            buttonMyCourses.TabIndex = 0;
            buttonMyCourses.Text = "My Courses";
            buttonMyCourses.UseVisualStyleBackColor = true;
            buttonMyCourses.Click += myCoursesBtn_Click;
            // 
            // buttonSearchCourses
            // 
            buttonSearchCourses.Location = new Point(19, 82);
            buttonSearchCourses.Margin = new Padding(2);
            buttonSearchCourses.Name = "buttonSearchCourses";
            buttonSearchCourses.Size = new Size(176, 43);
            buttonSearchCourses.TabIndex = 1;
            buttonSearchCourses.Text = "Search Courses";
            buttonSearchCourses.UseVisualStyleBackColor = true;
            buttonSearchCourses.Click += searchBtn_Click;
            // 
            // buttonShoppingCart
            // 
            buttonShoppingCart.Location = new Point(19, 129);
            buttonShoppingCart.Margin = new Padding(2);
            buttonShoppingCart.Name = "buttonShoppingCart";
            buttonShoppingCart.Size = new Size(176, 43);
            buttonShoppingCart.TabIndex = 2;
            buttonShoppingCart.Text = "Shopping Cart";
            buttonShoppingCart.UseVisualStyleBackColor = true;
            buttonShoppingCart.Click += cartBtn_Click;
            // 
            // labelCurrentTerm
            // 
            labelCurrentTerm.AutoSize = true;
            labelCurrentTerm.Location = new Point(233, 34);
            labelCurrentTerm.Margin = new Padding(2, 0, 2, 0);
            labelCurrentTerm.Name = "labelCurrentTerm";
            labelCurrentTerm.Size = new Size(82, 15);
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
            tabControl1.Location = new Point(233, 82);
            tabControl1.Margin = new Padding(2);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(572, 469);
            tabControl1.TabIndex = 6;
            // 
            // tabPageMyCourses
            // 
            tabPageMyCourses.Controls.Add(listBox1);
            tabPageMyCourses.Location = new Point(27, 4);
            tabPageMyCourses.Margin = new Padding(2);
            tabPageMyCourses.Name = "tabPageMyCourses";
            tabPageMyCourses.Size = new Size(541, 461);
            tabPageMyCourses.TabIndex = 0;
            tabPageMyCourses.Text = "My Courses";
            tabPageMyCourses.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "" });
            listBox1.Location = new Point(2, 0);
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(537, 454);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPageSearch
            // 
            tabPageSearch.Controls.Add(searchButton);
            tabPageSearch.Controls.Add(searchTextBox);
            tabPageSearch.Controls.Add(searchListBox);
            tabPageSearch.Location = new Point(27, 4);
            tabPageSearch.Margin = new Padding(2);
            tabPageSearch.Name = "tabPageSearch";
            tabPageSearch.Size = new Size(541, 461);
            tabPageSearch.TabIndex = 1;
            tabPageSearch.Text = "Search Courses";
            tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(362, 16);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(92, 23);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += button1_Click_2;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(100, 16);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(199, 23);
            searchTextBox.TabIndex = 1;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // searchListBox
            // 
            searchListBox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            searchListBox.FormattingEnabled = true;
            searchListBox.HorizontalScrollbar = true;
            searchListBox.Location = new Point(3, 49);
            searchListBox.Name = "searchListBox";
            searchListBox.Size = new Size(535, 407);
            searchListBox.TabIndex = 0;
            searchListBox.SelectedIndexChanged += searchListBox_SelectedIndexChanged;
            // 
            // tabPageCart
            // 
            tabPageCart.Controls.Add(shoppingCartList);
            tabPageCart.Location = new Point(27, 4);
            tabPageCart.Margin = new Padding(2);
            tabPageCart.Name = "tabPageCart";
            tabPageCart.Size = new Size(541, 461);
            tabPageCart.TabIndex = 2;
            tabPageCart.Text = "Shopping Cart";
            tabPageCart.UseVisualStyleBackColor = true;
            // 
            // comboBoxSemester
            // 
            comboBoxSemester.FormattingEnabled = true;
            comboBoxSemester.Location = new Point(327, 32);
            comboBoxSemester.Margin = new Padding(2);
            comboBoxSemester.Name = "comboBoxSemester";
            comboBoxSemester.Size = new Size(132, 23);
            comboBoxSemester.TabIndex = 7;
            comboBoxSemester.Text = "Semester";
            comboBoxSemester.SelectedIndexChanged += comboBoxSemester_SelectedIndexChanged;
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(464, 32);
            comboBoxYear.Margin = new Padding(2);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(132, 23);
            comboBoxYear.TabIndex = 8;
            comboBoxYear.Text = "Year";
            comboBoxYear.SelectedIndexChanged += comboBoxYear_SelectedIndexChanged;
            // 
            // addToCart
            // 
            addToCart.Location = new Point(19, 329);
            addToCart.Margin = new Padding(2);
            addToCart.Name = "addToCart";
            addToCart.Size = new Size(176, 43);
            addToCart.TabIndex = 9;
            addToCart.Text = "Add to Cart";
            addToCart.UseVisualStyleBackColor = true;
            addToCart.Click += button1_Click;
            // 
            // applyFilter
            // 
            applyFilter.Location = new Point(617, 31);
            applyFilter.Margin = new Padding(2);
            applyFilter.Name = "applyFilter";
            applyFilter.Size = new Size(97, 20);
            applyFilter.TabIndex = 10;
            applyFilter.Text = "Apply";
            applyFilter.UseVisualStyleBackColor = true;
            applyFilter.Click += button1_Click_1;
            // 
            // shoppingCartList
            // 
            shoppingCartList.FormattingEnabled = true;
            shoppingCartList.ItemHeight = 15;
            shoppingCartList.Location = new Point(3, 3);
            shoppingCartList.Name = "shoppingCartList";
            shoppingCartList.Size = new Size(535, 454);
            shoppingCartList.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 560);
            Controls.Add(applyFilter);
            Controls.Add(addToCart);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxSemester);
            Controls.Add(tabControl1);
            Controls.Add(labelCurrentTerm);
            Controls.Add(buttonShoppingCart);
            Controls.Add(buttonSearchCourses);
            Controls.Add(buttonMyCourses);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageMyCourses.ResumeLayout(false);
            tabPageSearch.ResumeLayout(false);
            tabPageSearch.PerformLayout();
            tabPageCart.ResumeLayout(false);
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