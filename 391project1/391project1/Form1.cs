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
            courseInfoLabel.Visible = false;
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
            courseInfoLabel.Visible = false;
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
                    course.Add(myreader[0].ToString() + " " + myreader[1].ToString() + " " + myreader[2].ToString() + " " + myreader[3].ToString() + " " + myreader[4].ToString() + " " + myreader[5].ToString() + " " + myreader[6].ToString() + " " + myreader[7].ToString() + " " + myreader[8].ToString() + " " + myreader[9].ToString() + " " + myreader[10].ToString() + " " + myreader[11].ToString());
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

        /*
        private void addCourseToCart(string courseID, string sectionID, string sem, string year)
        {
            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
            SqlCommand SelectCommand = new SqlCommand("", con);
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.AddWithValue("@query", query);
            SqlDataReader myreader;
            con.Open();


            con.Close();
        }
        */

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
            courseInfoLabel.Visible = true;
            showCourseInfo();
        }

        private void showCourseInfo()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
                SqlCommand SelectCommand = new SqlCommand("getCourseInfo", con);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("@studentID", UserLogin.GlobalVariables.userID.ToString());
                SqlDataReader myreader;
                con.Open();
                List<string> course = new List<string>();

                Debug.WriteLine(semIdx + "   " + yrIdx);

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
                            SelectCommand.Parameters.AddWithValue("@year", int.Parse(courseParts[3].Trim()));
                            SelectCommand.Parameters.AddWithValue("@courseID", courseID);
                            SelectCommand.Parameters.AddWithValue("@sectionID", sectionID);


                            myreader = SelectCommand.ExecuteReader();
                            while (myreader.Read())
                            {
                                string courseDetails = $"{courseID} {myreader[0]} {myreader[1]}\n";
                                courseDetails += $"{sectionID} Enrolled: {myreader[2]} Capacity: {myreader[3]}\n";
                                courseDetails += $"Day: {myreader[4]} Start Time: {myreader[5]} End Time: {myreader[6]}\n";
                                courseDetails += $"Instructor: {myreader[7]} {myreader[8]}";
                                course.Add(courseDetails);
                            }
                            courseInfoLabel.Text = course.ToString(); // leave this here or ...?
                        }
                        else
                        {
                            MessageBox.Show("Unable to display results.");
                            courseInfoLabel.Visible = false;
                        }

                        if (course != null)
                        {
                            courseInfoLabel.Text = course.ToString();
                        }
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
    }
}

