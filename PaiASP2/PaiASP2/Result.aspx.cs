using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaiASP2
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["start"].ToString() + " " + Session["end"].ToString() + " " + Session["limit"].ToString() + " " + Session["maxThreads"].ToString();
        }
    }
}