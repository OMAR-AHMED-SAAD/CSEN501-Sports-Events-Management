using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MileStone_3
{
    public partial class SystemAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void clubadd_Click(object sender, EventArgs e)
        {

            string clubname = clubnameadd.Text;
            string clublocation = clublocationadd.Text;

            if(clubname=="" || clublocation == "") {
                Response.Write("Must add a club name and location");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            
            SqlCommand addclubproc = new SqlCommand("addClub", conn);
            addclubproc.CommandType = CommandType.StoredProcedure;
            addclubproc.Parameters.Add(new SqlParameter("@name", clubname));
            addclubproc.Parameters.Add(new SqlParameter("@location", clublocation));
            try
            {

                conn.Open();
                addclubproc.ExecuteNonQuery();
                clubnameadd.Text = "";
                clublocationadd.Text = "";
                Response.Write("Club added successfully");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: Response.Write("Club already exist"); ; break;
                    default: throw;
                }
            }
            finally
            {
                conn.Close();
            }
                
            

        }

        protected void clubdelete_Click(object sender, EventArgs e)
        {
            string clubname = clubnamedelete.Text;

            if (clubname == "" )
            {
                Response.Write("Must add a club name");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

           
            SqlCommand deleteclubproc = new SqlCommand("deleteClub", conn);
            deleteclubproc.CommandType = CommandType.StoredProcedure;
            deleteclubproc.Parameters.Add(new SqlParameter("@name", clubname));
            SqlCommand checkclub = new SqlCommand("checkclubexist", conn);
            checkclub.CommandType = CommandType.StoredProcedure;
            checkclub.Parameters.Add(new SqlParameter("@name", clubname));
            SqlParameter found = checkclub.Parameters.Add("@found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;

            conn.Open();
            checkclub.ExecuteNonQuery();
            conn.Close();

            if (found.Value.ToString() == "1")
            {
                conn.Open();
                deleteclubproc.ExecuteNonQuery();
                conn.Close();
                clubnamedelete.Text = "";
                Response.Write("Club deleted successfully");
            }
            else
            {
                Response.Write("Club does not exist");
            }
        }

        protected void stadiumadd_Click(object sender, EventArgs e)
        {
            string stadiumname = stadiumnameadd.Text;
            string stadiumlocation = stadiumlocationadd.Text;
            string stadiumcapacity = stadiumcapacityadd.Text;
            if(stadiumname=="" || stadiumlocation==""|| stadiumcapacity=="")
            {
                Response.Write("Must add a stadium name,loction and capacity");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand addstadiumproc = new SqlCommand("addstadium", conn);
            addstadiumproc.CommandType = CommandType.StoredProcedure;
            addstadiumproc.Parameters.Add(new SqlParameter("@stadium_name", stadiumname));
            addstadiumproc.Parameters.Add(new SqlParameter("@location", stadiumlocation));
            addstadiumproc.Parameters.Add(new SqlParameter("@capacity", stadiumcapacity));
            try
            {
                conn.Open();
                addstadiumproc.ExecuteNonQuery();
                stadiumnameadd.Text = "";
                stadiumlocationadd.Text = "";
                stadiumcapacityadd.Text = "";
                Response.Write("Stadium added successfully");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: Response.Write("Stadium already exist"); ; break;
                    default: throw;
                }
            }
            finally
            {
                conn.Close();
            }
          
        }

        protected void stadiumdelete_Click(object sender, EventArgs e)
        {

            string stadiumname = stadiumnamedelete.Text;
            if (stadiumname == "" )
            {
                Response.Write("Must add a stadium name");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand deletestadiumproc = new SqlCommand("deletestadium", conn);
            deletestadiumproc.CommandType = CommandType.StoredProcedure;
            deletestadiumproc.Parameters.Add(new SqlParameter("@name", stadiumname));
            SqlCommand checkstadium = new SqlCommand("checkstadium", conn);
            checkstadium.CommandType = CommandType.StoredProcedure;
            checkstadium.Parameters.Add(new SqlParameter("@name", stadiumname));
            SqlParameter found = checkstadium.Parameters.Add("@found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;

            conn.Open();
            checkstadium.ExecuteNonQuery();
            conn.Close();

            if (found.Value.ToString() == "1")
            {
                conn.Open();
                deletestadiumproc.ExecuteNonQuery();
                conn.Close();
                stadiumnamedelete.Text = "";
                Response.Write("Stadium deleted successfully");
            }
            else
            {
                Response.Write("Stadium does not exist");
            }
        }

        protected void blockfan_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string FanID = fannationalid.Text;
            SqlCommand blockfanproc = new SqlCommand("blockFan", conn);
            blockfanproc.CommandType = CommandType.StoredProcedure;
            blockfanproc.Parameters.Add(new SqlParameter("@national_id", FanID));

            SqlCommand checkfanproc = new SqlCommand("checkFan", conn);
            checkfanproc.CommandType = CommandType.StoredProcedure;
            checkfanproc.Parameters.Add(new SqlParameter("@national_id", FanID));
            SqlParameter found = checkfanproc.Parameters.Add("@found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;


            conn.Open();
            checkfanproc.ExecuteNonQuery();
            conn.Close();

            if (found.Value.ToString() == "1")
            {
                conn.Open();
                blockfanproc.ExecuteNonQuery();
                conn.Close();
                fannationalid.Text = "";
                Response.Write("Fan blocked successfully");
            }
            else
            {
                Response.Write("Fan ID does not exist");
            }

        }

    }
}