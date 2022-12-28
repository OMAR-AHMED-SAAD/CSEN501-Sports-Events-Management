using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace MileStone_3
{
    public partial class RegisterSM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var temp = stadiumname.Items.Count;
                for (int i = temp - 1; i >= 1; i--)
                {
                    stadiumname.Items.RemoveAt(i);
                }
                string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand availableclubs = new SqlCommand("SELECT name FROM Stadium WHERE id NOT IN(SELECT stadium_id FROM StadiumManager);", conn);
                availableclubs.CommandType = CommandType.Text;


                conn.Open();
                SqlDataReader rdr = availableclubs.ExecuteReader();
                while (rdr.Read())
                {
                    ListItem Stadium = new ListItem(rdr[0].ToString());
                    stadiumname.Items.Add(Stadium);
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
            string Stadium = stadiumname.SelectedValue;
            if (Stadium == "Choose Stadium")
            {
                msg.Text = "Choose a Stadium to represent ";
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
                SqlCommand registersm = new SqlCommand("addStadiumManager", conn);
                registersm.CommandType = CommandType.StoredProcedure;
                registersm.Parameters.Add(new SqlParameter("@name", name1));
                registersm.Parameters.Add(new SqlParameter("@stadium", Stadium));
                registersm.Parameters.Add(new SqlParameter("@username", user));
                registersm.Parameters.Add(new SqlParameter("@password", pass));
                registersm.ExecuteNonQuery();
                conn.Close();
                Response.Redirect($"Login.aspx?Message=Registered as {Stadium} manager successfully");
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