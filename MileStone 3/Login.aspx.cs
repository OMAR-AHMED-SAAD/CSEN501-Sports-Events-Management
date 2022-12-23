using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MileStone_3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

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
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.VarChar,50);
            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();

            if(success.Value.ToString()=="1")
            {
                // Response.Write("Hello");
                if (type.Value.ToString() == "SystemAdmin")
                {
                    Response.Redirect("SystemAdmin.aspx");
                }

                else if (type.Value.ToString() == "ClubRepresentative")
                    Response.Redirect("ClubRepresentative.aspx");

                else if (type.Value.ToString() == "Fan")
                    Response.Redirect("Fan.aspx");

                else if (type.Value.ToString() == "SportsAssociationManager")
                    Response.Redirect("SportsAssociationManager.aspx");

                else if (type.Value.ToString() == "StadiumManager")
                    Response.Redirect("StadiumManager.aspx");
            }
            else
            {
                Response.Write("Invalid username or password");
            }

            
        }
    }
}