using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Xml.Linq;

namespace MileStone_3
{
    public partial class RegisterFan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string user = username.Text;
            string pass = password.Text;
            string name1 = name.Text;
            string nid=nationalid.Text;
            int phone1 = Int32.Parse(phone.Text);
            string birth =birthdate.Text;
            string adress1 = adress.Text;



            SqlCommand checkuser = new SqlCommand("SELECT dbo.checkuserName(@username)", conn);
            checkuser.CommandType = CommandType.Text;
            checkuser.Parameters.AddWithValue("@username", user);
            conn.Open();
            var rdr = checkuser.ExecuteScalar();
            if (rdr.Equals(true))
            {
                SqlCommand addfan = new SqlCommand("addFan", conn);
                addfan.CommandType = CommandType.StoredProcedure;
                addfan.Parameters.Add(new SqlParameter("@name", name1));
                addfan.Parameters.Add(new SqlParameter("@username",user));
                addfan.Parameters.Add(new SqlParameter("@password", pass));
                addfan.Parameters.Add(new SqlParameter("@national_id", nid));
                addfan.Parameters.Add(new SqlParameter("@birth_date", Convert.ToDateTime(birth)));
                addfan.Parameters.Add(new SqlParameter("@adress",adress1));
                addfan.Parameters.Add(new SqlParameter("@phone_number",phone1));

                try
                {
                    addfan.ExecuteNonQuery();
                    Response.Redirect("Login.aspx?Message=Registered successfully");
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 2627:
                            msg.Text = "National Id already registred";
                            loginalert.Style.Add("display", "block"); ; break;
                        default: throw;
                    }
                }
                finally
                {
                    conn.Close();
                }
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