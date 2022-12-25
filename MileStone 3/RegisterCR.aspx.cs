using System;
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
            var temp = clubname.Items.Count - 1;
            for (int i=1;i<temp;i++)
            clubname.Items.RemoveAt(i);
           
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand availableclubs = new SqlCommand("SELECT name FROM Club WHERE id NOT IN(SELECT club_id FROM ClubRepresentative);", conn);
            availableclubs.CommandType = CommandType.Text;
           

            conn.Open();
            SqlDataReader rdr = availableclubs.ExecuteReader();
            while (rdr.Read())
            {
                ListItem club= new ListItem( rdr[0].ToString());
                clubname.Items.Add(club);
            }
            conn.Close();
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String user = username.Text;
            String pass = password.Text;
            String name1 = name.Text;
            String club = clubname.Text;


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