using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Web.Configuration;

namespace MileStone_3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Message"] !=null)
            {
                loginalert.Style.Add("background-color", "#119934");
                msg.Text = Request.QueryString["Message"];
                loginalert.Style.Add("display", "block");
            }
        }

        protected void register(object sender, EventArgs e)
        {
            Response.Redirect("Registeration.aspx");
        }
        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String user = username.Text;
            String pass = password.Text;
            SqlCommand loginproc = new SqlCommand("login", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@username", user));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.VarChar, 50);
            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "1")
            {
                // Response.Write("Hello");
                Session["user"] = user;
                if (type.Value.ToString() == "SystemAdmin")
                {
                    Response.Redirect("SystemAdmin.aspx");
                }

                else if (type.Value.ToString() == "ClubRepresentative")
                    Response.Redirect("ClubRepresentative.aspx");

                else if (type.Value.ToString() == "Fan")
                {
                    SqlCommand checkstatus = new SqlCommand("SELECT status FROM Fan WHERE username=@user ", conn);
                    checkstatus.Parameters.AddWithValue("@user", user);
                    String status = "";
                    conn.Open();
                    SqlDataReader rdr = checkstatus.ExecuteReader();
                    while (rdr.Read())
                    {
                        status = rdr[0].ToString();
                    }
                    conn.Close();
                    if (status == "False")
                    {
                        msg.Text = "You are currently blocked";
                        loginalert.Style.Add("background-color", "##c80000");
                        loginalert.Style.Add("display", "block");
                    }
                    else
                        Response.Redirect("Fan.aspx");
                }

                else if (type.Value.ToString() == "SportsAssociationManager")
                    Response.Redirect("SportsAssociationManager.aspx");

                else if (type.Value.ToString() == "StadiumManager")
                    Response.Redirect("StadiumManager.aspx");
            }
            else
            {
                msg.Text = "Invalid username or password";
                loginalert.Style.Add("background-color", "##c80000");
                loginalert.Style.Add("display", "block");
            }


        }
    }
}
