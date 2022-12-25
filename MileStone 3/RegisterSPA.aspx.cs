using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MileStone_3
{
    public partial class RegisterSPA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String user = username.Text;
            String pass = password.Text;
            String name1 = name.Text;

            
                SqlCommand checkuser = new SqlCommand("SELECT dbo.checkuserName(@username)", conn);
                checkuser.CommandType = CommandType.Text;
                checkuser.Parameters.AddWithValue("@username", user);
                conn.Open();
                var rdr = checkuser.ExecuteScalar();
                if (rdr.Equals(true))
                {
                    SqlCommand registerspa = new SqlCommand("addAssociationManager", conn);
                    registerspa.CommandType = CommandType.StoredProcedure;
                    registerspa.Parameters.Add(new SqlParameter("@name", name1));
                    registerspa.Parameters.Add(new SqlParameter("@username", user));
                    registerspa.Parameters.Add(new SqlParameter("@password", pass));
                    registerspa.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Login.aspx?Message=Registered successfully");
                }
                else {
                    msg.Text = "Username is taken by someone else ";
                    loginalert.Style.Add("display", "block");
                    conn.Close();
                }
            
        }
    }
}