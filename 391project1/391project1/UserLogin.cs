using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _391project1
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }
        void UserLogin_Load(object sender, EventArgs e)
        {

        }


        public static class GlobalVariables
        {
            public static string userID { get; set; }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var userID = textBox1.Text;
            if (!string.IsNullOrEmpty(userID))
            {
                int check = checkUserId(userID);
                if (check == 1)
                {
                    GlobalVariables.userID = userID;
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User ID not recognized");
                }
            }
        }

        private int checkUserId(string userID)
        {
            int result = -1;
            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = 391project1; Integrated Security = True; MultipleActiveResultSets = true; ");
            SqlCommand SelectCommand = new SqlCommand("checkStudentID", con);
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.AddWithValue("@studentID", userID);
            SqlDataReader myreader;
            con.Open();
            myreader = SelectCommand.ExecuteReader();
            if (myreader.Read())
               {
                if (myreader[0].ToString() == "1")
                {
                    result = 1;
                }
            }
            return result;
        }
    }
}
