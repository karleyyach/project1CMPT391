using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            //fillCourses();
            fillSemBox();
            fillYearBox();
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

        }

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
                    SelectCommand.Parameters.AddWithValue("@active", act);
                    myreader = SelectCommand.ExecuteReader();
                    while (myreader.Read())
                    {
                        course.Add(myreader[0].ToString() + " " + myreader[1].ToString() + " " + myreader[2].ToString() + " " + myreader[3].ToString());
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
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=391project1; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();
                    SqlCommand SelectCommand = new SqlCommand(query, con);
                    using (SqlDataReader myreader = SelectCommand.ExecuteReader())
                    {
                        // Clear the existing items in the ListBox
                        searchListBox.Items.Clear();

                        // Populate the ListBox with data from the SqlDataReader
                        while (myreader.Read())
                        {
                            string item = myreader[0].ToString() + " " + myreader[1].ToString() + " " + myreader[2].ToString() + " " + myreader[3].ToString() + " " + myreader[4].ToString() + " " + myreader[5].ToString() + " " + myreader[6].ToString() + " " + myreader[7].ToString() + " " + myreader[8].ToString() + " " + myreader[9].ToString();
                            searchListBox.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors appropriately
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void addCourseToCart(string courseID, string sectionID, string sem, string year)
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
                con.Open();
                SelectCommand.BeginExecuteNonQuery(); // think this is the right thing to run???????

                con.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors appropriately
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//add to cart button
        {
            string course = listBox1.SelectedItem?.ToString();
            //Debug.WriteLine(course);
            if (course != null)
            {
                string[] components = course.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                MessageBox.Show("Select a course to add");
            }
        }
        private int semIdx = -1;
        private int yrIdx = -1;
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
        private string fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID;";

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

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (semIdx != -1 & yrIdx == -1) // Semester selected & nothing selected
            {
                fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE section.semester = '" + comboBoxSemester.SelectedItem?.ToString() + "'";
                Debug.WriteLine("Semester");
                if (searchTextBox.Text.Length >= 1)
                {
                    Debug.WriteLine("Semester if statement");
                    fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE section.semester = '" + comboBoxSemester.SelectedItem?.ToString() + "' AND course.courseID LIKE '" + searchTextBox.Text + "%'";
                    fillSearch(fillSearchQuery);
                }
            }

            else if (yrIdx != -1 & semIdx == -1) // Year selected & nothing selected
            {
                Debug.WriteLine("Year and nothing");
                fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE section.[year] = '" + comboBoxYear.SelectedItem?.ToString() + "'";
                if (searchTextBox.Text.Length >= 1)
                {
                    Debug.WriteLine("Year and nothing if");
                    fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE course.courseID LIKE '" + searchTextBox.Text + "%' AND section.[year] = '" + comboBoxYear.SelectedItem?.ToString() + "'";
                    fillSearch(fillSearchQuery);
                }

            }

            else if (yrIdx != -1 & semIdx != -1) // Both selected
            {
                Debug.WriteLine("Both");
                fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE section.semester = '" + comboBoxSemester.SelectedItem?.ToString() + "' AND section.[year] = '" + comboBoxYear.SelectedItem?.ToString() + "'";
                if (searchTextBox.Text.Length >= 1)
                {
                    Debug.WriteLine("Both if");
                    fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE section.semester = '" + comboBoxSemester.SelectedItem?.ToString() + "' AND section.[year] = '" + comboBoxYear.SelectedItem?.ToString() + "' AND course.courseID LIKE '" + searchTextBox.Text + "%'";
                    fillSearch(fillSearchQuery);
                }
            }

            else if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                Debug.WriteLine("Nothing entered");
                fillSearch(fillSearchQuery);
            }

            else
            {
                Debug.WriteLine("Just text box");
                fillSearchQuery = "SELECT course.courseID, course.courseName, section.sectionID, instructor.firstName, instructor.lastName, timeSlot.[day], timeSlot.startTime, timeSlot.endTime, section.semester, section.[year] FROM course JOIN section ON course.courseID = section.courseID JOIN instructor ON section.instructorID = instructor.instructorID JOIN timeSlot ON section.timeSlotID = timeSlot.timeSlotID WHERE course.courseID LIKE '" + searchTextBox.Text + "%'";
                fillSearch(fillSearchQuery);
            }
            fillSearch(fillSearchQuery);
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
                        // should have exactly one result. error check later uhhhhhh
                        while (myreader.Read())
                        {
                            string item = myreader[0].ToString();
                            if (item != null) { return item; }
                            else return ( "-1");
                        }
                    }
                    return "-1";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors appropriately
                MessageBox.Show("An error occurred: " + ex.Message);
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
                MessageBox.Show("An error occurred: " + ex.Message);
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
        }
    }
}
