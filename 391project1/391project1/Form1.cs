using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _391project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            courseInfoLabel.Visible = false;
            //fillCourses();
            fillSemBox();
            fillYearBox();
            courseInfoLabel.AutoSize = true;
            courseInfoLabel.MaximumSize = new Size(475, 775);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void myCoursesBtn_Click(object sender, EventArgs e)
        {
            // swaps view in tab page. functions the same as on click for tab control
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            // swap between terms
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            // swaps view in tab page. functions the same as on click for tab control

        }

        private void cartBtn_Click(object sender, EventArgs e)
        {
            // swaps view in tab page. functions the same as on click for tab control
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            courseInfoLabel.Visible = false;
        }
        private int semIdx = -1;
        private int yrIdx = -1;
        private void fillSemBox()
        {
            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
            SqlCommand SelectCommand = new SqlCommand("SELECT distinct semester FROM section", con);
            SqlDataReader myreader;
            con.Open();

            myreader = SelectCommand.ExecuteReader();

            List<String> lstSemesters = new List<String>();
            while (myreader.Read())
            {
                lstSemesters.Add(myreader[0].ToString());

            }
            for (int i = 0; i < lstSemesters.Count; i++)
            {
                comboBoxSemester.Items.Add(lstSemesters[i]);
            }
            con.Close();
        }

        private void fillYearBox()
        {
            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
            SqlCommand SelectCommand = new SqlCommand("SELECT distinct year FROM section", con);
            SqlDataReader myreader;
            con.Open();

            myreader = SelectCommand.ExecuteReader();

            List<String> lstYears = new List<String>();
            while (myreader.Read())
            {
                lstYears.Add(myreader[0].ToString());

            }
            for (int i = 0; i < lstYears.Count; i++)
            {
                comboBoxYear.Items.Add(lstYears[i]);
            }
            con.Close();
        }

        private void showCurrentCourses()
        {
            try
            {
                string act = "active";
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("showMyCourses", con);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID.ToString());
                SqlDataReader myreader;
                con.Open();
                List<string> course = new List<string>();

                Debug.WriteLine(semIdx + "   " + yrIdx);

                if (semIdx != -1 & yrIdx != -1)
                {
                    listBox1.Items.Clear();
                    SelectCommand.Parameters.AddWithValue("@semester", comboBoxSemester.SelectedItem.ToString());
                    SelectCommand.Parameters.AddWithValue("@year", comboBoxYear.SelectedItem.ToString());

                    myreader = SelectCommand.ExecuteReader();
                    while (myreader.Read())
                    {
                        course.Add(myreader[0].ToString() + " | " + myreader[1].ToString() + " | " + myreader[2].ToString() + " | " + myreader[3].ToString());
                    }

                    int i = 0;
                    while (course[i] != null)
                    {
                        listBox1.Items.Add(course[i]);
                        i++;
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("select a semester and a year");
                }
            }
            catch (Exception ex) { }
        }

        private void showCurrentCart()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("showMyCart", con);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID.ToString());
                SqlDataReader myreader;
                List<string> course = new List<string>();

                if (semIdx != -1 & yrIdx != -1)
                {
                    shoppingCartList.Items.Clear();

                    con.Open();
                    myreader = SelectCommand.ExecuteReader();
                    while (myreader.Read())
                    {
                        course.Add(myreader[0].ToString() + " " + myreader[1].ToString() + " " + myreader[2].ToString() + " " + myreader[3].ToString());
                    }
                    int i = 0;
                    while (course[i] != null)
                    {
                        shoppingCartList.Items.Add(course[i]);
                        i++;
                    }

                    con.Close();
                }
            }
            catch (Exception ex) { }
        }

        private void fillSearch(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("viewAvailableCourses", con);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("@query", query);
                SqlDataReader myreader;
                con.Open();
                List<string> course = new List<string>();

                searchListBox.Items.Clear();
                myreader = SelectCommand.ExecuteReader();

                while (myreader.Read())
                {
                    course.Add(myreader[0].ToString() + "   " + myreader[1].ToString() + "  " + myreader[2].ToString() + "  " + myreader[3].ToString() + " " + myreader[4].ToString() + " " + myreader[5].ToString() + "   " + myreader[6].ToString() + "   " + myreader[7].ToString() + "    " + myreader[8].ToString() + "   " + myreader[9].ToString() + "   " + myreader[10].ToString() + " " + myreader[11].ToString());
                }
                int i = 0;
                while (course[i] != null)
                {
                    searchListBox.Items.Add(course[i]);
                    i++;
                }
                con.Close();

            }
            catch (Exception ex) { }
        }

        //string courseID, string sectionID, string sem, string year
        /*
        private void addCourseToCart()
        {
            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
            SqlCommand SelectCommand = new SqlCommand("addToCart", con);
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID);
            SqlDataReader myreader;
            con.Open();

            if(searchListBox.SelectedItem != null)
            {
                string selectedCourse = searchListBox.SelectedItem.ToString();
                string[] courseParts = Regex.Split(selectedCourse, @"\s{2,}");
                Debug.WriteLine(courseParts[0]);
                Debug.WriteLine(courseParts[2]);
                Debug.WriteLine(courseParts[10]);
                Debug.WriteLine(courseParts[11]);

                SelectCommand.Parameters.AddWithValue("@courseID", courseParts[0]);
                SelectCommand.Parameters.AddWithValue("@sectionID", courseParts[2]);
                SelectCommand.Parameters.AddWithValue("@semester", courseParts[10]);
                SelectCommand.Parameters.AddWithValue("@year", courseParts[11]);

                SelectCommand.ExecuteReader();

                con.Close();
            }
            
        }
        */
        private void addCourseToCart(string courseID, string sectionID, string sem, string year, string timeSlot)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("addToCart", con);
                // cart contains studentID, courseID, sectionID, sem, year
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID.ToString());
                SelectCommand.Parameters.AddWithValue("@courseID", courseID);
                SelectCommand.Parameters.AddWithValue("@sectionID", sectionID);
                SelectCommand.Parameters.AddWithValue("@semester", sem);
                SelectCommand.Parameters.AddWithValue("@year", year);
                SelectCommand.Parameters.AddWithValue("@timeslot", timeSlot);
                con.Open();
                SelectCommand.BeginExecuteNonQuery(); // think this is the right thing to run???????
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors appropriately
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private string getTimeSlotID(string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=391project1; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();
                    SqlCommand SelectCommand = new SqlCommand(query, con);
                    using (SqlDataReader myreader = SelectCommand.ExecuteReader())
                    {
                        Debug.WriteLine("***********");

                        // should have exactly one result. error check later uhhhhhh
                        while (myreader.Read())
                        {
                            string item = myreader[0].ToString();
                            Debug.WriteLine("***********" + item);
                            if (item != null) { return item; }
                            else return ("-1");
                        }
                    }
                    return "-1";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors appropriately
                MessageBox.Show("An 3 error occurred: " + ex.Message);
                return ("-1");
            }
        }
        private Boolean checkCart(string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=391project1; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();
                    SqlCommand SelectCommand = new SqlCommand(query, con);
                    using (SqlDataReader myreader = SelectCommand.ExecuteReader())
                    {
                        if (!myreader.Read())
                        {
                            return true; // no results found. can add class
                        }
                        else return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors appropriately
                MessageBox.Show("An 5 error occurred: " + ex.Message);
                return false;
            }

        }

        private string[] formatSearchClick(string[] raw)
        {
            string[] str = new string[11];


            int length = raw.Length;
            Debug.WriteLine("length " + length);

            str[0] = raw[0]; // courseID

            str[11] = raw[raw.Length - 1]; // year
            str[10] = raw[raw.Length - 2]; // sem
            str[9] = raw[raw.Length - 3]; //end
            str[8] = raw[raw.Length - 4]; //start
            str[7] = raw[raw.Length - 5]; //last name
            str[6] = raw[raw.Length - 6]; // first name
            str[5] = raw[raw.Length - 7]; //day
            str[4] = raw[raw.Length - 8]; //cap
            str[3] = raw[raw.Length - 9]; //enrolled
            str[2] = raw[raw.Length - 10]; //section
            str[1] = raw[raw.Length - 11]; // course desc. will only be containing last word, as it is uneeded for my use
            // change later if needed

            return str;
        }
        /*
        private void searchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = searchListBox.SelectedItem.ToString();
            if (curItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Attempt to add this course to your cart?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Debug.WriteLine(curItem);
                    // run queries

                    // first need to split retreived strings to handle each condition properly
                    string[] rawStr = curItem.Split(' ');
                    string[] splitStr = formatSearchClick(rawStr);

                    // check if there is even space
                    if ((Int32.Parse(splitStr[3]) + 1) > Int32.Parse(splitStr[4]))
                    {
                        // no space
                        MessageBox.Show("Selected class has no available space.");
                    }
                    else
                    {
                        // find slot id to match classes in cart
                        string query = "SELECT timeSlot.timeSlotID FROM timeSlot WHERE timeSlot.day = '" + splitStr[5] + "' AND timeSlot.startTime = '" + splitStr[8] + "' AND timeSlot.endTime = '" + splitStr[9] + "'";
                        string timeID = getTimeSlotID(query);
                        if (timeID == "-1")
                        {
                            // couldnt find slot
                            return;
                        }

                        // run q on cart
                        query = "SELECT * FROM cart WHERE cart.timeSlotID = '" + timeID + "' AND cart.year = '" + splitStr[11] + "' AND cart.semester = '" + splitStr[10] + "' AND cart.studentID = '" + UserLogin.GlobalVariables.userID.ToString() + "'";

                        // if not zero results, run stored proc to add this class to cart
                        if (!checkCart(query))
                        {
                            // cant add to cart, display message
                            MessageBox.Show("Class could not be added to cart.");
                        }
                        else
                        {
                            // add checking prereqs????? 

                            addCourseToCart(splitStr[0], splitStr[2], splitStr[10], splitStr[11]);
                        }
                    }
                }
                else if (dialogResult == DialogResult.No) return;
            }
            else return;
        }*/

        private void button1_Click(object sender, EventArgs e)//add to cart button
        {
            string course = listBox1.SelectedItem?.ToString();
            //Debug.WriteLine(course);
            //addCourseToCart();


            string curItem = searchListBox.SelectedItem.ToString();
            string[] splitStr = Regex.Split(curItem, @"\s{2,}");

            if (curItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Attempt to add this course to your cart?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Debug.WriteLine(curItem);
                    // run queries

                    // first need to split retreived strings to handle each condition properly
                    //string[] rawStr = curItem.Split(' ');
                    //string[] splitStr = formatSearchClick(rawStr);

                    // check if there is even space
                    if ((Int32.Parse(splitStr[3].Trim()) + 1) > Int32.Parse(splitStr[4].Trim()))
                    {
                        // no space
                        MessageBox.Show("Selected class has no available space.");
                    }
                    else
                    {
                        Debug.WriteLine("111111111111111111111111111");
                        // find slot id to match classes in cart
                        Debug.WriteLine(splitStr[7].Trim() + "____" + splitStr[8].Trim() + "_____" + splitStr[9].Trim());
                        string query = "SELECT timeSlot.timeSlotID FROM timeSlot WHERE timeSlot.day = '" + splitStr[7].Trim() + "' AND timeSlot.startTime = '" + splitStr[8].Trim() + "'";// AND timeSlot.endTime = '" + splitStr[9].Trim() + "'";
                        string timeID = getTimeSlotID(query);
                        Debug.WriteLine("888888888888888888888");
                        Debug.WriteLine(timeID);
                        if (timeID == "-1")
                        {
                            // couldnt find slot
                            return;
                        }

                        // run q on cart
                        query = "SELECT * FROM cart WHERE cart.timeSlotID = '" + timeID + "' AND cart.year = '" + splitStr[11].Trim() + "' AND cart.semester = '" + splitStr[10].Trim() + "' AND cart.studentID = '" + UserLogin.GlobalVariables.userID.ToString() + "'";
                        Debug.WriteLine("7777777777777777777777777");

                        // if not zero results, run stored proc to add this class to cart
                        if (!checkCart(query))
                        {
                            // cant add to cart, display message
                            MessageBox.Show("Class could not be added to cart.");
                        }
                        else
                        {//timeslotid
                            // add checking prereqs????? 
                            Debug.WriteLine("__" + splitStr[0] + "__" + splitStr[2] + "__" + splitStr[10] + "--" + splitStr[11]);
                            addCourseToCart(splitStr[0].Trim(), splitStr[2].Trim(), splitStr[10].Trim(), splitStr[11].Trim(), timeID);
                        }
                        Debug.WriteLine("44444444444444444444444444");
                    }
                }
                else if (dialogResult == DialogResult.No) return;
            }
            else return;

            shoppingCartList.Items.Clear();
            showCurrentCart();
        }

        private void comboBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedindex
            semIdx = comboBoxSemester.SelectedIndex;
            //Debug.WriteLine(semIdx.ToString());
        }
        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            yrIdx = comboBoxYear.SelectedIndex;
            //Debug.WriteLine(yrIdx.ToString());
        }

        private string fillListQuery = "SELECT courseID, sectionID, semester, year, capacity, instructorID, day from section";
        private void button1_Click_1(object sender, EventArgs e)//apply filter button
        {
            showCurrentCourses();
            showCurrentCart();
        }

        private void tabPageCart_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private string fillSearchQuery = "SELECT * FROM courses_schedule;";
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (yrIdx != -1 & semIdx != -1) // Both selected
            {
                Debug.WriteLine("Semester and year filled");
                fillSearchQuery = "SELECT * FROM courses_schedule WHERE courses_schedule.semester = '" + comboBoxSemester.SelectedItem?.ToString() + "' AND courses_schedule.[year] = '" + comboBoxYear.SelectedItem?.ToString() + "'";
                if (searchTextBox.Text.Length >= 1)
                {
                    Debug.WriteLine("Text Box filled");
                    fillSearchQuery = "SELECT * FROM courses_schedule WHERE courses_schedule.semester = '" + comboBoxSemester.SelectedItem?.ToString() + "' AND courses_schedule.[year] = '" + comboBoxYear.SelectedItem?.ToString() + "' AND courses_schedule.courseID LIKE '" + searchTextBox.Text + "%'";
                    fillSearch(fillSearchQuery);
                    return; // exit
                }
                fillSearch(fillSearchQuery);
                return; // exit
            }

            else if (searchTextBox.Text.Length >= 1 & yrIdx == -1 & semIdx == -1) // Elements in search bar and semester and year are empty
            {
                Debug.WriteLine("Only text box");
                fillSearchQuery = "SELECT * FROM courses_schedule WHERE courses_schedule.courseID LIKE '" + searchTextBox.Text + "%'";
                fillSearch(fillSearchQuery);
                return; // exit
            }

            else
            {
                MessageBox.Show("Select a semester and a year");
                return; // exit
            }
        }

        private void viewCourseButton_Click(object sender, EventArgs e)
        {
            if (yrIdx != -1 & semIdx != -1)
            {
                courseInfoLabel.Visible = true;
                courseInfoListBox.Visible = true;
                closeButton.Visible = true;
                closeButton.BringToFront();
                showCourseInfo();
            }

        }

        private void showCourseInfo()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("getCourseInfo", con);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader myreader;
                con.Open();
                List<string> course1 = new List<string>();
                List<string> course2 = new List<string>();
                List<string> course3 = new List<string>();


                if (semIdx != -1 && yrIdx != -1 && listBox1.SelectedIndex != -1)
                {
                    courseInfoLabel.Text = "";
                    string courseInfo = listBox1.SelectedItem.ToString();
                    string[] courseParts = courseInfo.Split('|');
                    if (courseParts.Length == 4)
                    {
                        string[] idParts = courseParts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (idParts.Length == 2)
                        {
                            string courseID = idParts[0].Trim();
                            string sectionID = idParts[1].Trim();
                            SelectCommand.Parameters.AddWithValue("@semester", courseParts[2].Trim());
                            SelectCommand.Parameters.AddWithValue("@year", courseParts[3].Trim());
                            SelectCommand.Parameters.AddWithValue("@courseID", courseParts[0].Trim());
                            SelectCommand.Parameters.AddWithValue("@sectionID", courseParts[1].Trim());

                            myreader = SelectCommand.ExecuteReader();
                            while (myreader.Read())
                            {
                                course1.Add(myreader[0].ToString() + "     " + myreader[1].ToString() + "     Enrolled: " + myreader[2].ToString() + " Capacity:     " + myreader[3].ToString());
                                course2.Add("Day: " + myreader[4].ToString() + "     Start Time: " + myreader[5].ToString() + "     End Time: " + myreader[6].ToString());
                                course3.Add("Instructor Name: " + myreader[7].ToString() + " " + myreader[8].ToString());
                            }

                            int i = 0;
                            //while (course1[i] != null)
                            //{
                            //Debug.WriteLine(course1[i]);
                            courseInfoListBox.Items.Add(course1[i]);
                            courseInfoListBox.Items.Add(course2[i]);
                            courseInfoListBox.Items.Add(course3[i]);
                            //i++;
                            //}
                            //courseInfoLabel.Text = course.ToString(); // leave this here or ...?
                        }
                        else
                        {
                            MessageBox.Show("Unable to display results.");
                            courseInfoLabel.Visible = false;
                        }

                        //if (course1 != null)
                        //{
                        //    courseInfoLabel.Text = course1.ToString();
                        //}
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select a course to view");
                }
            }
            catch (Exception ex) { }
        }

        private void courseInfoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            courseInfoListBox.Visible = false;
            closeButton.Visible = false;
            courseInfoListBox.Items.Clear();
        }
       

        private void enrollInCourse()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("enrolInSection", con);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID.ToString());
                SqlDataReader myreader;
                con.Open();

                if (shoppingCartList.SelectedIndex != -1)
                {
                    Debug.WriteLine("1111111111111111");
                    string course = shoppingCartList.SelectedItem.ToString();
                    string[] courseParts = Regex.Split(course, @"\s{2,}");
                    SelectCommand.Parameters.AddWithValue("@courseID", courseParts[0]);
                    SelectCommand.Parameters.AddWithValue("@sectionID", courseParts[1]);
                    SelectCommand.Parameters.AddWithValue("@semester", courseParts[2]);
                    SelectCommand.Parameters.AddWithValue("@year", courseParts[3]);
                    myreader = SelectCommand.ExecuteReader();

                    MessageBox.Show("Course added.");
                    con.Close();
                    shoppingCartList.Items.Clear();
                    showCurrentCart();
                    listBox1.Items.Clear();
                    showCurrentCourses();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }

        }

        private void enrollButton_Click_1(object sender, EventArgs e)
        {
            enrollInCourse();
        }
    }
}

