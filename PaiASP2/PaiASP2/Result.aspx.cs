using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaiASP2
{
    public partial class Result : System.Web.UI.Page
    {
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Label1.Text = Session["start"].ToString() + " " + Session["end"].ToString() + " " + Session["limit"].ToString() + " " + Session["maxThreads"].ToString();

            double start = Double.Parse(Session["start"].ToString());
            double end = Double.Parse(Session["end"].ToString());
            int limit = int.Parse(Session["limit"].ToString());
            int maxThreads = int.Parse(Session["maxThreads"].ToString());

            Label1.Text = Integral(start, end, limit, maxThreads).ToString();

            Session.RemoveAll();
        }

        private double Integral(double start, double end, int limit, int maxThreads)
        {
            int[] result = new int[maxThreads];
            double interval = (end - start) / maxThreads;

            Parallel.For(0, maxThreads, (threadId) =>
            {
                double randomX, randomY, sin;
                double x1 = start + threadId * interval;
                double x2 = x1 + interval;
                int hitCounter = 0;

                for (int i = 0; i < limit; i++)
                {
                    randomX = GetRandomDouble(x1, x2);
                    randomY = GetRandomDouble(0.0, 1.0);
                    sin = Math.Sin(randomX);

                    if (sin > 0.0)
                    {
                        if (randomY <= sin)
                            hitCounter++;
                    }
                }

                result[threadId] = hitCounter;
            });

            return 1.0 * (end-start) * result.Sum() / (limit*maxThreads);
        }
        
        private double GetRandomDouble(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}