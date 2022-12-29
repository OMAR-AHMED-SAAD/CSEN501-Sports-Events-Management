using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Lifetime;

namespace MileStone_3
{
    public partial class StadiumManager : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand mystadium = new SqlCommand("SELECT s.name,s.location,s.capacity FROM StadiumManager sm JOIN Stadium s ON (sm.stadium_id=s.id) WHERE sm.username=@user", conn);
            mystadium.CommandType = CommandType.Text;
            string user = Session["user"].ToString();
            mystadium.Parameters.AddWithValue("@user", user);
            conn.Open();
            SqlDataReader rdr1 = mystadium.ExecuteReader();
            while (rdr1.Read())
            {
                string name = rdr1[0].ToString();
                string location = rdr1[1].ToString();
                string capacity = rdr1[2].ToString();
                stadiumname.Text = name;
                stadiumlocation.Text = location;
                stadiumcapacity.Text = capacity;
            }
            conn.Close();
 
                SqlCommand pendingrequests = new SqlCommand("SELECT * FROM dbo.allPendingRequests2(@user);", conn);
                pendingrequests.CommandType = CommandType.Text;
                pendingrequests.Parameters.AddWithValue("@user", user);
                int i = 1;
                conn.Open();
                SqlDataReader rdr = pendingrequests.ExecuteReader();
                while (rdr.Read())
                {
                    string cr = rdr[0].ToString();
                    string host = rdr[1].ToString();
                    string guest = rdr[2].ToString();
                    string start = rdr[3].ToString();
                    string end = rdr[4].ToString();
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();
                    TableCell td4 = new TableCell();
                    TableCell td5 = new TableCell();
                    TableCell td6 = new TableCell();
                    Button accept = new Button();
                    PlaceHolder ph1 = new PlaceHolder();
                    accept.Click += Accept_Click;
                    accept.ID = i + "acc";
                    td5.ID = i + "accc";
                    accept.Text = "Accept";
                    td5.Controls.Add(ph1);
                    ph1.Controls.Add(accept);
                    Button reject = new Button();
                    reject.ID = i + "rej";
                    td6.ID = i + "rejc";
                    PlaceHolder ph = new PlaceHolder();
                    td6.Controls.Add(ph);
                    reject.Text = "Reject";
                    reject.Click += Reject_Click;
                    ph.Controls.Add(reject);
                    i++;
                    td.Text = cr;
                    td1.Text = host;
                    td2.Text = guest;
                    td3.Text = start;
                    td4.Text = end;
                    tr.Controls.Add(td);
                    tr.Controls.Add(td1);
                    tr.Controls.Add(td2);
                    tr.Controls.Add(td3);
                    tr.Controls.Add(td4);
                    tr.Controls.Add(td5);
                    tr.Controls.Add(td6);
                    pending1.Rows.Add(tr);
                }
                conn.Close();
        }



        protected void allreq_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand allrequests = new SqlCommand("SELECT * FROM dbo.allRequestsfn(@user);", conn);
            allrequests.CommandType = CommandType.Text;
            string user = Session["user"].ToString();
            allrequests.Parameters.AddWithValue("@user", user);
            conn.Open();
            SqlDataReader rdr = allrequests.ExecuteReader();
            while (rdr.Read())
            {
                string cr = rdr[0].ToString();
                string host = rdr[1].ToString();
                string guest = rdr[2].ToString();
                string start = rdr[3].ToString();
                string end = rdr[4].ToString();
                string status = rdr[5].ToString();


                HtmlTableRow tr = new HtmlTableRow();

                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                HtmlTableCell td2 = new HtmlTableCell();
                HtmlTableCell td3 = new HtmlTableCell();
                HtmlTableCell td4 = new HtmlTableCell();
                HtmlTableCell td5 = new HtmlTableCell();

                td.InnerText= cr;
                td1.InnerText = host;
                td2.InnerText = guest;
                td3.InnerText = start;
                td4.InnerText = end;
                td5.InnerText = status;

                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                tr.Controls.Add(td4);
                tr.Controls.Add(td5);
                
                requests.Rows.Add(tr);
            }
            conn.Close();
            
        }

        protected void pendingreq_Click(object sender, EventArgs e)
        {
            pen.Style.Add("display", "block");
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            string bid = b.ID;
            string user = Session["user"].ToString();
            string host = "";
            string guest = "";
            string start = "";
            foreach(TableRow tr in pending1.Rows)
            {
                if (tr.Cells[5].ID != null && (tr.Cells[5].ID.ToString() == (bid + "c")))
                {
                    host = tr.Cells[1].Text;
                    guest = tr.Cells[2].Text;
                    start= tr.Cells[3].Text;
                    break;
                }
            }

            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand acceptproc = new SqlCommand("acceptRequest2",conn);
            acceptproc.CommandType = CommandType.StoredProcedure;
            acceptproc.Parameters.Add(new SqlParameter("@manager_username",user));
            acceptproc.Parameters.Add(new SqlParameter("@host_name", host));
            acceptproc.Parameters.Add(new SqlParameter("@guest_name", guest));
            acceptproc.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));
            SqlParameter success = acceptproc.Parameters.Add("@out", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;
                conn.Open();
                acceptproc.ExecuteNonQuery();
                conn.Close();
            if (success.Value.ToString() == "1")
            {
                Response.Write("Request accepted");
            }
            else
            {
               
                Response.Write("Stadium already hosting another match");
            }
            pen.Style.Add("display", "none");
            

        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            string bid = b.ID;
            string user = Session["user"].ToString();
            string host = "";
            string guest = "";
            string start = "";
            foreach (TableRow tr in pending1.Rows)
            {
                
                if (tr.Cells[6].ID!=null &&(tr.Cells[6].ID.ToString() == (bid+"c")))
                {
                   
                    host = tr.Cells[1].Text;
                    guest = tr.Cells[2].Text;
                    start = tr.Cells[3].Text;
                    break;
                }
            }

            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand rejectproc = new SqlCommand("rejectRequest", conn);
            rejectproc.CommandType = CommandType.StoredProcedure;
            rejectproc.Parameters.Add(new SqlParameter("@manager_username", user));
            rejectproc.Parameters.Add(new SqlParameter("@host_name", host));
            rejectproc.Parameters.Add(new SqlParameter("@guest_name", guest));
            rejectproc.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));
            conn.Open();
            rejectproc.ExecuteNonQuery();
            conn.Close();
            Response.Write("Request rejected");
            pen.Style.Add("display", "none");
           
        }



    }
}