using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MileStone_3
{
    public partial class Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resgisterfan_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterFan.aspx");
        }

        protected void registerstadiummanager_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterSM.aspx");
        }

        protected void registerclubrepresentative_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterCR.aspx");
        }

        protected void registersportsassociationmanager_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterSPA.aspx");
        }
    }
}