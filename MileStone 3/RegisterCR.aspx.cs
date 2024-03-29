﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

namespace MileStone_3
{
    public partial class RegisterCR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int temp = clubname.Items.Count;
                for (int i = temp - 1; i >= 1; i--)
                {
                    clubname.Items.RemoveAt(i);
                }

                string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand availableclubs = new SqlCommand("SELECT name FROM Club WHERE id NOT IN(SELECT club_id FROM ClubRepresentative);", conn);
                availableclubs.CommandType = CommandType.Text;


                conn.Open();
                SqlDataReader rdr = availableclubs.ExecuteReader();
                while (rdr.Read())
                {
                    ListItem club = new ListItem(rdr[0].ToString());
                    clubname.Items.Add(club);
                }
                conn.Close();
            }
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string user = username.Text;
            string pass = password.Text;
            string name1 = name.Text;
            string club = clubname.SelectedValue;
            if (club== "Choose Club")
            {
                msg.Text = "Choose a club to represent ";
                loginalert.Style.Add("display", "block");
                return;
            }

            SqlCommand checkuser = new SqlCommand("SELECT dbo.checkuserName(@username)", conn);
            checkuser.CommandType = CommandType.Text;
            checkuser.Parameters.AddWithValue("@username", user);
            conn.Open();
            var rdr = checkuser.ExecuteScalar();
            if (rdr.Equals(true))
            {
                SqlCommand registercr = new SqlCommand("addRepresentative", conn);
                registercr.CommandType = CommandType.StoredProcedure;
                registercr.Parameters.Add(new SqlParameter("@name", name1));
                registercr.Parameters.Add(new SqlParameter("@club", club));
                registercr.Parameters.Add(new SqlParameter("@username", user));
                registercr.Parameters.Add(new SqlParameter("@password", pass));
                registercr.ExecuteNonQuery();
                conn.Close();
                Response.Redirect($"Login.aspx?Message=Registered as {club} representative successfully");
            }
            else
            {
                msg.Text = "Username is taken by someone else ";
                loginalert.Style.Add("display", "block");
                conn.Close();
            }
        }
    }
}