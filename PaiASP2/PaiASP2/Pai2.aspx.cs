using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaiASP2
{
    public partial class Pai2 : System.Web.UI.Page
    {
        double start = 0.0;
        double end = 0.0;
        int limit;
        int maxThreads = 1; //Liczba watkow

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            try
            {
                start = double.Parse(TextBox1.Text);
                end = double.Parse(TextBox2.Text);
            }
            catch (Exception)
            {
                Label1.Text = "Zły format danych double (0,0)";
                return;
            }

            try
            {
                maxThreads = int.Parse(TextBox3.Text);
            }
            catch (Exception)
            {
                Label1.Text = "Zły format danych int (0)";
            }

            try
            {
                limit = int.Parse(TextBox4.Text);
            }
            catch (Exception)
            {
                Label1.Text = "Zły format danych int (0)";
            }
            
            Session["start"] = start;
            Session["end"] = end;
            Session["limit"] = limit;
            Session["maxThreads"] = maxThreads;
            Response.Redirect("Result.aspx");
        }
    }
}