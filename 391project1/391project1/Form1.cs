using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection.PortableExecutable;
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
            SqlConnection con =
                new SqlConnection(
                    "Data Source = localhost; Initial Catalog = MacewanDatabase; Integrated Security = True; MultipleActiveResultSets = true; ");
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

        private void fillYearBox()
        {
            SqlConnection con =
                new SqlConnection(
                    "Data Source = localhost; Initial Catalog = MacewanDatabase; Integrated Security = True; MultipleActiveResultSets = true; ");
            SqlCommand SelectCommand = new SqlCommand("SELECT distinct year FROM section ORDER BY year DESC;", con);
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
                SqlConnection con =
                    new SqlConnection(
                        "Data Source = localhost; Initial Catalog = MacewanDatabase; Integrated Security = True; MultipleActiveResultSets = true; ");
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
                        course.Add(myreader[0].ToString() + " | " + myreader[1].ToString() + " | " +
                                   myreader[2].ToString() + " | " + myreader[3].ToString());
                    }

                    foreach (var item in course)
                    {
                        listBox1.Items.Add(item);
                    }

                    con.Close();
                }
                else
                {
                    MessageBox.Show("select a semester and a year");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void showCurrentCart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                           "Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    using (SqlCommand SelectCommand = new SqlCommand("showMyCart", con))
                    {
                        SelectCommand.CommandType = CommandType.StoredProcedure;
                        SelectCommand.Parameters.AddWithValue("@studentID",
                            UserLogin.GlobalVariables.userID.ToString());
                        con.Open();

                        using (SqlDataReader myreader = SelectCommand.ExecuteReader())
                        {
                            // Clear the shopping cart list
                            shoppingCartList.Items.Clear();

                            // Read and add each course
                            while (myreader.Read())
                            {
                                string courseEntry = myreader[0].ToString() + " " +
                                                     myreader[1].ToString() + " " +
                                                     myreader[2].ToString() + " " +
                                                     myreader[3].ToString();
                                shoppingCartList.Items.Add(courseEntry);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void fillSearch(string semester, string year, string courseIdPattern)
        {
            try
            {
                using (SqlConnection con =
                       new SqlConnection(
                           "Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("viewAvailableCourses", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@courseIDPattern",
                            string.IsNullOrEmpty(courseIdPattern) ? (object)DBNull.Value : courseIdPattern);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> courseDetails = new List<string>();
                            while (reader.Read())
                            {
                                /* string courseDetail = $"{reader["courseID"].ToString().Trim()}: " +
                                                      $"{reader["courseName"].ToString().Trim()} " +
                                                      $"({reader["sectionID"].ToString().Trim()}) " +
                                                      $"\t{reader["semester"].ToString().Trim()} " +
                                                      $"{reader["year"].ToString().Trim()}" +
                                                      $"\tCapacity: {reader["capacity"].ToString().Trim()}, " +
                                                      $"\tEnrolled: {reader["enrolledCount"].ToString().Trim()}"; */
                                string courseDetail = $"{reader["courseID"].ToString().Trim()} " +
                                                      $"| {reader["courseName"].ToString().Trim()} " +
                                                      $"| {reader["sectionID"].ToString().Trim()} " +
                                                      $"| {reader["semester"].ToString().Trim()} " +
                                                      $"| {reader["year"].ToString().Trim()} " +
                                                      $"| {reader["capacity"].ToString().Trim()} " +
                                                      $"| {reader["enrolledCount"].ToString().Trim()}";

                                courseDetails.Add(courseDetail);
                            }

                            searchListBox.Items.Clear();
                            foreach (var detail in courseDetails)
                            {
                                searchListBox.Items.Add(detail);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL error: {ex.Message}");
            }
        }

        /* private void AddCourseToCart(string courseID, string sectionID)
           {
               try
               {
                   using (SqlConnection con = new SqlConnection("Your_Connection_String"))
                   {
                       using (SqlCommand cmd = new SqlCommand("addToCart", con))
                       {
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID);
                           cmd.Parameters.AddWithValue("@courseID", courseID);
                           cmd.Parameters.AddWithValue("@sectionID", sectionID);

                           con.Open();
                           cmd.ExecuteNonQuery();
                       }
                   }
                   MessageBox.Show("Course added to cart successfully.");
               }
               catch (Exception ex)
               {
                   MessageBox.Show($"An error occurred while adding to cart: {ex.Message}");
               }
           } */

        private void addCourseToCart(string studentID, string courseID, string sectionID, string semester, string year)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                           "Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    using (SqlCommand cmd = new SqlCommand("addToCart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@courseID", courseID);
                        cmd.Parameters.AddWithValue("@sectionID", sectionID);
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.Parameters.AddWithValue("@year", year);

                        con.Open();
                        cmd.ExecuteNonQuery(); // Executes synchronously
                    }
                } // Using block ensures that connection is closed properly

                MessageBox.Show("Course added to cart successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the course to cart: {ex.Message}");
            }
        }


        private void button1_Click(object sender, EventArgs e) // Add to cart button
        {
            Debug.WriteLine($"Selected Item: {searchListBox.SelectedItem}");

            if (searchListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a course to add.");
                return;
            }

            string selectedCourse = searchListBox.SelectedItem.ToString();
            string[] components = selectedCourse.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToArray();
            
            if (components.Length >= 6)
            {
                string courseID = components[0];
                string sectionID = components[2];
                string semester = components[3];
                string year = components[4];

                Debug.WriteLine("CourseID: " + courseID);
                Debug.WriteLine("SectionID: " + sectionID);
                Debug.WriteLine("Semester: " + semester);
                Debug.WriteLine("Year: " + year);

                string studentID = UserLogin.GlobalVariables.userID.ToString();
                addCourseToCart(studentID, courseID, sectionID, semester, year);
            }
            else
            {
                MessageBox.Show(
                    "Invalid course format selected. Please ensure the course information is in the expected format.");
            }
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

        private string fillListQuery =
            "SELECT courseID, sectionID, semester, year, capacity, instructorID, day from section";

        private void button1_Click_1(object sender, EventArgs e) //apply filter button
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
            if (comboBoxSemester.SelectedIndex != -1 && comboBoxYear.SelectedIndex != -1)
            {
                string semester = comboBoxSemester.SelectedItem.ToString().Trim();
                string year = comboBoxYear.SelectedItem.ToString().Trim();
                string courseIdPattern = searchTextBox.Text.Length > 0 ? searchTextBox.Text.Trim() : null;

                searchListBox.Items.Clear();
                fillSearch(semester, year, courseIdPattern);
            }
            else
            {
                MessageBox.Show("Please select both a semester and a year before searching.");
            }
        }


        private void searchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = searchListBox.SelectedItem.ToString();
            if (curItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Attempt to add this course to your cart?", "",
                    MessageBoxButtons.YesNo);

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
                        string query = "SELECT timeSlot.timeSlotID FROM timeSlot WHERE timeSlot.day = '" + splitStr[5] +
                                       "' AND timeSlot.startTime = '" + splitStr[8] + "' AND timeSlot.endTime = '" +
                                       splitStr[9] + "'";
                        string timeID = getTimeSlotID(query);
                        if (timeID == "-1")
                        {
                            // couldnt find slot
                            return;
                        }

                        // run q on cart
                        query = "SELECT * FROM cart WHERE cart.timeSlotID = '" + timeID + "' AND cart.year = '" +
                                splitStr[11] + "' AND cart.semester = '" + splitStr[10] + "' AND cart.studentID = '" +
                                UserLogin.GlobalVariables.userID.ToString() + "'";

                        // if not zero results, run stored proc to add this class to cart
                        if (!checkCart(query))
                        {
                            // cant add to cart, display message
                            MessageBox.Show("Class could not be added to cart.");
                        }
                        else
                        {
                            // add checking prereqs????? 

                            addCourseToCart(splitStr[0], splitStr[1], splitStr[2], splitStr[10], splitStr[11]);
                        }
                    }
                }
                else if (dialogResult == DialogResult.No) return;
            }
            else return;
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

        private void enrollStudentIntoCourse(string studentID, string courseID, string sectionID, string semester, string year)
        {
            try
            {
                Debug.WriteLine($"Student ID: {studentID}");
                Debug.WriteLine($"Course ID: {courseID}");
                Debug.WriteLine($"Section ID: {sectionID}");
                Debug.WriteLine($"Semester: {semester}");
                Debug.WriteLine($"Year: {year}");

                // Time conflicts
                string timeSlotQuery = $"SELECT timeSlotID FROM section WHERE courseID = '{courseID}' AND sectionID = '{sectionID}'";
                string newTimeSlotID = getTimeSlotID(timeSlotQuery);
                if (HasTimeSlotConflict(studentID, newTimeSlotID, semester, year))
                {
                    MessageBox.Show("Cannot enroll in this course due to a schedule conflict.");
                    return;
                }

                ListCoursePrerequisites(courseID);
                List<string> prerequisiteCourseIDs = GetPrerequisiteCourseIDs(courseID);

                bool hasCompletedAllPrerequisites = true;
                foreach (string prereqCourseID in prerequisiteCourseIDs)
                {
                    if (!HasStudentCompletedCourse(studentID, prereqCourseID))
                    {
                        Debug.WriteLine($"Student has not completed prerequisite course: {prereqCourseID}");
                        hasCompletedAllPrerequisites = false;
                        break;
                    }
                }

                if (!hasCompletedAllPrerequisites)
                {
                    MessageBox.Show("Student has not completed all prerequisite courses.");
                    return;
                }

                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    // Check prerequisites
                    using (SqlCommand checkPrereqCmd = new SqlCommand("CheckPrerequisites", con))
                    {
                        checkPrereqCmd.CommandType = CommandType.StoredProcedure;
                        checkPrereqCmd.Parameters.AddWithValue("@studentID", studentID);
                        checkPrereqCmd.Parameters.AddWithValue("@courseID", courseID);
                        SqlParameter prerequisiteMetParam = new SqlParameter("@prerequisiteMet", SqlDbType.Bit);
                        prerequisiteMetParam.Direction = ParameterDirection.Output;
                        checkPrereqCmd.Parameters.Add(prerequisiteMetParam);

                        con.Open();
                        checkPrereqCmd.ExecuteNonQuery();

                        // Check if prerequisites are met
                        bool prerequisiteMet = (bool)checkPrereqCmd.Parameters["@prerequisiteMet"].Value;

                        if (!prerequisiteMet)
                        {
                            Debug.WriteLine($"Prerequisites for CourseID: {courseID}");
                            ListCoursePrerequisites(courseID);
                            
                            MessageBox.Show("You do not have the required prerequisites to enroll in this course.");
                            return;
                        }
                    }

                    string query = "INSERT INTO [dbo].[takes] ([studentID], [courseID], [sectionID], [semester], [year], [grade], [active]) " +
                                   "VALUES (@studentID, @courseID, @sectionID, @semester, @year, NULL, 'ACTIVE')";
                    using (SqlCommand enrollCmd = new SqlCommand(query, con))
                    {
                        enrollCmd.Parameters.AddWithValue("@studentID", studentID);
                        enrollCmd.Parameters.AddWithValue("@courseID", courseID.Trim().Replace("\u00A0", " "));
                        enrollCmd.Parameters.AddWithValue("@sectionID", sectionID);
                        enrollCmd.Parameters.AddWithValue("@semester", semester);
                        enrollCmd.Parameters.AddWithValue("@year", year);

                        enrollCmd.ExecuteNonQuery();
                    }
                }

                // Remove the course from the cart
                RemoveCourseFromCart(studentID, courseID, sectionID, semester, year);

                MessageBox.Show("Student enrolled successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while enrolling the student: {ex.Message}");
            }
        }

        private List<string> GetPrerequisiteCourseIDs(string courseID)
        {
            List<string> prerequisiteCourseIDs = new List<string>();

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();
                    string query = "SELECT prereqID FROM prereq WHERE courseID = @courseID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseID", courseID.Trim().Replace("\u00A0", " "));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string prereqID = reader["prereqID"].ToString().Trim();
                                prerequisiteCourseIDs.Add(prereqID);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Exception: {ex.Message}");
                MessageBox.Show($"An error occurred while retrieving prerequisite course IDs: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                MessageBox.Show($"An unexpected error occurred while retrieving prerequisite course IDs: {ex.Message}");
            }

            return prerequisiteCourseIDs;
        }


        private void ListCoursePrerequisites(string courseID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT prereqID FROM prereq WHERE courseID = @courseID", con))
                    {
                        cmd.Parameters.AddWithValue("@courseID", courseID.Trim().Replace("\u00A0", " "));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string prerequisite = reader.GetString(0).Trim(); // Assuming prereqID is also nchar(10)
                                    Debug.WriteLine($"Prerequisite: {prerequisite}");
                                }
                            }
                            else
                            {
                                Debug.WriteLine("No prerequisites found.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Exception occurred while listing course prerequisites: {ex.Message}");
                MessageBox.Show($"An error occurred while listing course prerequisites: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while listing course prerequisites: {ex.Message}");
                MessageBox.Show($"An unexpected error occurred while listing course prerequisites: {ex.Message}");
            }
        }

        private bool HasStudentCompletedCourse(string studentID, string courseID)
        {
            bool hasCompleted = false;

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();
                    string query = "SELECT COUNT(1) FROM takes WHERE studentID = @studentID AND courseID = @courseID AND grade IS NOT NULL"; 

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@courseID", courseID.Trim().Replace("\u00A0", " "));

                        int count = (int)cmd.ExecuteScalar();
                        hasCompleted = count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Exception: {ex.Message}");
                MessageBox.Show($"An error occurred while checking course completion: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                MessageBox.Show($"An unexpected error occurred while checking course completion: {ex.Message}");
            }

            return hasCompleted;
        }

        private bool HasTimeSlotConflict(string studentID, string newTimeSlotID, string semester, string year)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    con.Open();

                    // Check for conflict in currently enrolled courses
                    string queryEnrolled = @"
                SELECT COUNT(1)
                FROM takes
                INNER JOIN section ON takes.courseID = section.courseID AND takes.sectionID = section.sectionID
                WHERE takes.studentID = @studentID
                AND section.timeSlotID = @timeSlotID
                AND takes.semester = @semester
                AND takes.year = @year";

                    using (SqlCommand cmdEnrolled = new SqlCommand(queryEnrolled, con))
                    {
                        cmdEnrolled.Parameters.AddWithValue("@studentID", studentID);
                        cmdEnrolled.Parameters.AddWithValue("@timeSlotID", newTimeSlotID);
                        cmdEnrolled.Parameters.AddWithValue("@semester", semester);
                        cmdEnrolled.Parameters.AddWithValue("@year", year);

                        int countEnrolled = (int)cmdEnrolled.ExecuteScalar();
                        if (countEnrolled > 0)
                        {
                            return true; // Conflict found in enrolled courses
                        }
                    }

                    // Check for conflict in the course cart
                    string queryCart = @"
                SELECT COUNT(1)
                FROM cart
                INNER JOIN section ON cart.courseID = section.courseID AND cart.sectionID = section.sectionID
                WHERE cart.studentID = @studentID
                AND section.timeSlotID = @timeSlotID
                AND cart.semester = @semester
                AND cart.year = @year";

                    using (SqlCommand cmdCart = new SqlCommand(queryCart, con))
                    {
                        cmdCart.Parameters.AddWithValue("@studentID", studentID);
                        cmdCart.Parameters.AddWithValue("@timeSlotID", newTimeSlotID);
                        cmdCart.Parameters.AddWithValue("@semester", semester);
                        cmdCart.Parameters.AddWithValue("@year", year);

                        int countCart = (int)cmdCart.ExecuteScalar();
                        if (countCart > 0)
                        {
                            return true; // Conflict found in the course cart
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Exception: {ex.Message}");
                MessageBox.Show($"An error occurred while checking for time slot conflicts: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                MessageBox.Show($"An unexpected error occurred while checking for time slot conflicts: {ex.Message}");
            }

            return false; // No conflict found
        }



        private void RemoveCourseFromCart(string studentID, string courseID, string sectionID, string semester, string year)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=MacewanDatabase; Integrated Security=True; MultipleActiveResultSets=true;"))
                {
                    using (SqlCommand cmd = new SqlCommand("removeFromCart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@courseID", courseID);
                        cmd.Parameters.AddWithValue("@sectionID", sectionID);
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.Parameters.AddWithValue("@year", year);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while removing the course from cart: {ex.Message}");
            }
        }


        private void showCourseInfo()
        {

            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course from the list.");
                return;
            }

            try
            {
                string selectedCourseInfo = listBox1.SelectedItem.ToString();
                string[] parts = selectedCourseInfo.Split('|');

                if (parts.Length < 4)
                {
                    MessageBox.Show("Unexpected format");
                }

                string courseID = parts[0].Trim();
                string sectionID = parts[1].Trim();
                string semester = parts[2].Trim();
                string year = parts[3].Trim();

                List<string> course1 = new List<string>();
                List<string> course2 = new List<string>();
                List<string> course3 = new List<string>();

                using (SqlConnection con = new SqlConnection(
                           "Data Source = localhost; Initial Catalog = MacewanDatabase; Integrated Security = True; MultipleActiveResultSets = true; "))
                {
                    using (SqlCommand SelectCommand = new SqlCommand("getCourseInfo", con))
                    {
                        SelectCommand.CommandType = CommandType.StoredProcedure;
                        SelectCommand.Parameters.AddWithValue("@semester", semester);
                        SelectCommand.Parameters.AddWithValue("@year", year);
                        SelectCommand.Parameters.AddWithValue("@courseID", courseID);
                        SelectCommand.Parameters.AddWithValue("@sectionID", sectionID);
                        con.Open();

                        using (SqlDataReader myreader = SelectCommand.ExecuteReader())
                        {
                            if (!myreader.HasRows)
                            {
                                MessageBox.Show("No course info");
                                return;
                            }

                            // Clear previous courses
                            courseInfoListBox.Items.Clear();
                            while (myreader.Read())
                            {
                                if (myreader.FieldCount < 9)
                                {
                                    MessageBox.Show("Data received does not match the expected format");
                                    return;
                                }
                                /*course1.Add(myreader[0].ToString() + "     " + myreader[1].ToString() + "     Enrolled: " + myreader[2].ToString() + " Capacity:     " + myreader[3].ToString());
                                course2.Add("Day: " + myreader[4].ToString() + "     Start Time: " + myreader[5].ToString() + "     End Time: " + myreader[6].ToString());
                                course3.Add("Instructor Name: " + myreader[7].ToString() + " " + myreader[8].ToString()); */

                                string courseDetail =
                                    $"{myreader.GetString(0)} | Enrolled: {myreader.GetString(2)} | Capacity: {myreader.GetString(3)}";
                                courseInfoListBox.Items.Add(courseDetail);
                                string timeDetail =
                                    $"Day: {myreader.GetString(4)} | Start Time: {myreader.GetTimeSpan(5)} | End Time: {myreader.GetTimeSpan(6)}";
                                courseInfoListBox.Items.Add(timeDetail);
                                string instructorDetail =
                                    $"Instructor Name: {myreader.GetString(7)} {myreader.GetString(8)}";
                                courseInfoListBox.Items.Add(instructorDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while showing course info: {ex.Message}");
            }
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

        private void shoppingCartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnrollButton_Click_1(object sender, EventArgs e)
        {
            foreach (var item in shoppingCartList.Items)
            {
                string selectedCourse = item.ToString();
                Debug.WriteLine($"Selected Course: {selectedCourse}");

                string[] components = selectedCourse.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .ToArray();

                Debug.WriteLine($"Number of components: {components.Length}");

                if (components.Length >= 4)
                {
                    string courseID = components[0];
                    string sectionID = components[1];
                    string semester = components[2];
                    string year = components[3];

                    Debug.WriteLine($"Course ID: {courseID}");
                    Debug.WriteLine($"Section ID: {sectionID}");
                    Debug.WriteLine($"Semester: {semester}");
                    Debug.WriteLine($"Year: {year}");

                    string studentID = UserLogin.GlobalVariables.userID.ToString();
                    enrollStudentIntoCourse(studentID, courseID, sectionID, semester, year);
                }
                else
                {
                    MessageBox.Show(
                        "Invalid course format selected. Please ensure the course information is in the expected format.");
                }
                showCurrentCourses();
            }
        }

        private void RemoveFromCart_Click(object sender, EventArgs e)
        {
            if (shoppingCartList.SelectedItem != null)
            {
                try
                {
                    string selectedCourse = shoppingCartList.SelectedItem.ToString();
                    string[] components = selectedCourse.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => p.Trim())
                        .ToArray();
                    
                    if (components.Length >= 4)
                    {
                        string studentID = UserLogin.GlobalVariables.userID.ToString();
                        string courseID = components[0];
                        string sectionID = components[1];
                        string semester = components[2];
                        string year = components[3];

                        RemoveCourseFromCart(studentID, courseID, sectionID, semester, year);
                        shoppingCartList.Items.Remove(selectedCourse);

                        MessageBox.Show("Course removed from cart successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Invalid course format selected.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the course from the cart: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to remove from the cart.");
            }
        }
    }
}

