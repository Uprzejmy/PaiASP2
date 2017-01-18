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
            Label1.Text = Session["start"].ToString() + " " + Session["end"].ToString() + " " + Session["limit"].ToString() + " " + Session["maxThreads"].ToString();

            double start = Double.Parse(Session["start"].ToString());
            double end = Double.Parse(Session["end"].ToString());
            int limit = int.Parse(Session["limit"].ToString());
            int maxThreads = int.Parse(Session["maxThreads"].ToString());

            Label1.Text = Integral(start, end, limit, maxThreads).ToString();
        }

        private double Integral(double start, double end, int limit, int maxThreads)
        {
            double[] result = new double[maxThreads];
            double interval = Math.Abs(end - start) / maxThreads;

            Parallel.For(0, maxThreads, (threadId) =>
            {
                for (double x = threadId * interval; x < (threadId + 1) * interval; x += interval)
                {
                    int hitCounter = 0;
                    for (int i = 0; i < limit; i++)
                    {
                        double randomX = GetRandomDouble(x, x + interval);
                        double randomY = GetRandomDouble(-1.0, 1.0);
                        double sin = Math.Sin(randomX);
                        //sprawdzamy czy liczba jest pod wykresem (trafiła w przedział)
                        if (sin < 0)
                        {
                            if (randomY >= sin && randomY <= 0) hitCounter++;
                        }
                        else
                        {
                            if (randomY <= sin && randomY >= 0) hitCounter++;
                        }
                    }
                    //zapisujemy wynik dla danego wątku
                    result[threadId] = hitCounter;
                }
            });
            //zwracamy obliczoną całkę
            return result.Sum()/(limit*maxThreads);
        }
        
        private double GetRandomDouble(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}