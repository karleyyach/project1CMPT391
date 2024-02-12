using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
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
            showCurrentCart();
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
                List<string> course = new List<string>();

                if (semIdx != -1 & yrIdx != -1)
                {
                    listBox1.Items.Clear();
                    SelectCommand.Parameters.AddWithValue("@semester", comboBoxSemester.SelectedItem.ToString());
                    SelectCommand.Parameters.AddWithValue("@year", comboBoxYear.SelectedItem.ToString());
                    SelectCommand.Parameters.AddWithValue("@active", act);
                    con.Open();
                    myreader = SelectCommand.ExecuteReader();
                    while (myreader.Read())
                    {
                        course.Add(myreader[0].ToString() + " " + myreader[1].ToString() + " " + myreader[2].ToString() + " " + myreader[3].ToString());
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        listBox1.Items.Add(course[i]);
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

                cartListBox.Items.Clear();

                con.Open();
                myreader = SelectCommand.ExecuteReader();
                while (myreader.Read())
                {
                    course.Add(myreader[0].ToString() + " " + myreader[1].ToString() + " " + myreader[2].ToString() + " " + myreader[3].ToString());
                }
                for (int i = 0; i < 4; i++)
                {
                    cartListBox.Items.Add(course[i]);
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
            Debug.WriteLine(course);
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
            Debug.WriteLine(semIdx.ToString());
        }
        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            yrIdx = comboBoxYear.SelectedIndex;
            Debug.WriteLine(yrIdx.ToString());
        }

        private string fillListQuery = "SELECT courseID, sectionID, semester, year, capacity, instructorID, day from section";
        private void button1_Click_1(object sender, EventArgs e)//apply filter button
        {
            showCurrentCourses();

            /*
            Debug.WriteLine(" " + semIdx + " " + yrIdx);
            if (semIdx != -1 & yrIdx == -1)
            {
                Debug.WriteLine(comboBoxSemester.SelectedItem?.ToString());
                fillListQuery = "SELECT courseID, sectionID, semester, year, capacity, instructorID, day from section where semester = '" + comboBoxSemester.SelectedItem?.ToString() + "'";
                Debug.WriteLine(fillListQuery);
            }
            if (yrIdx != -1 & semIdx == -1)
            {
                Debug.WriteLine("yrIDX != -1");

                fillListQuery = "SELECT courseID, sectionID, semester, year, capacity, instructorID, day from section where year = '" + comboBoxYear.SelectedItem?.ToString() + "'";
            }
            if (yrIdx != -1 & semIdx != -1)
            {
                Debug.WriteLine("BOTH != -1");

                fillListQuery = "SELECT courseID, sectionID, semester, year, capacity, instructorID, day from section where semester = '" + comboBoxSemester.SelectedItem?.ToString() + "' and year = '" + comboBoxYear.SelectedItem?.ToString() + "'";
            }
            this stuff is all really good but is not for this purpose. may need to reuse later.
            */

        }

        private void tabPageCart_Click(object sender, EventArgs e)
        {

        }

        private void cartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}