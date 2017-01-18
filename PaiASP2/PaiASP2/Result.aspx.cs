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
        double start = 0.0;
        double end = 0.0;
        int limit;
        int maxThreads = 1; //Liczba watkow
        double interval;
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["start"].ToString() + " " + Session["end"].ToString() + " " + Session["limit"].ToString() + " " + Session["maxThreads"].ToString();

            start = Double.Parse(Session["start"].ToString());
            end = Double.Parse(Session["end"].ToString());
            limit = int.Parse(Session["limit"].ToString());
            maxThreads = int.Parse(Session["maxThreads"].ToString());

            interval = Math.Abs(end - start)/maxThreads;

            Label1.Text = Integral(start, end, limit).ToString();
        }

        private double Integral(double start, double end, int limit)
        {
            return GetRandomDouble(start,end);
        }
        
        private double GetRandomDouble(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}