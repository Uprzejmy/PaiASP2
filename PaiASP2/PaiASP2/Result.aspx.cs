using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaiASP2
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Visible = true;

            Chart1.Series.Clear();

            Chart1.Titles.Clear();



            Chart1.Titles.Add("Całka sinx");

            Chart1.ChartAreas[0].AxisX.Title = "Oś wartości X";

            Chart1.ChartAreas[0].AxisY.Title = "Oś wartości Y";

            Chart1.ChartAreas[0].AxisY.LineWidth = 5;



            Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;

            Chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            Chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = System.Web.UI.DataVisualization.Charting.ChartDashStyle.Dot;



            Chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            Chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Silver;

            Chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = System.Web.UI.DataVisualization.Charting.ChartDashStyle.Dot;



            


            // Label1.Text = Session["start"].ToString() + " " + Session["end"].ToString() + " " + Session["limit"].ToString();

            double start = Double.Parse(Session["start"].ToString());
            double end = Double.Parse(Session["end"].ToString());
            int limit = int.Parse(Session["limit"].ToString());

            int maxThreads = Environment.ProcessorCount;
            // Label1.Text = maxThreads.ToString();

            Label2.Text = "";

            Label1.Text = Integral(start, end, limit, maxThreads).ToString();

            

            //Session.RemoveAll();
        }

        private double Integral(double start, double end, int limit, int maxThreads)
        {
            int[] result = new int[maxThreads];
            double interval = (end - start) / maxThreads;

            /*
            double[][] data = new double[maxThreads][];
            for (int i = 0; i < maxThreads; i++)
            {
                data[i] = new double[2];
            }
            */

            


            Parallel.For(0, maxThreads, (threadId) =>
            {
                double randomX, randomY, sin;
                double x1 = start + threadId * interval;
                double x2 = x1 + interval;
                int hitCounter = 0;
                // data[threadId][0] = x1;
                // data[threadId][1] = x2;
                Random random = new Random();

                Chart1.Series.Add(threadId.ToString());
                Chart1.Series[threadId.ToString()].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
                Chart1.Series[threadId.ToString()].Color = Color.DarkBlue;
                Chart1.Series[threadId.ToString()].BorderWidth = 2;

                for (double x = x1; x <= x2; x += 0.001)
                {
                    
                }

                for (int i = 0; i < limit; i++)
                {
                    randomX = GetRandomDouble(x1, x2, random);
                    randomY = GetRandomDouble(-1.0, 1.0, random);
                    sin = Math.Sin(randomX);

                    Chart1.Series[threadId.ToString()].Points.AddXY(randomX, randomY);

                    if (sin > 0.0)
                    {
                        if (randomY >= 0.0 && randomY <= sin)
                        {
                            hitCounter++;
                        }
                    }
                    else
                    {
                        if (randomY <= 0.0 && randomY >= sin)
                        {
                            hitCounter++;
                        }
                    }
                }

                // data[threadId][0] = hitCounter;

                result[threadId] = hitCounter;
            });

            /*
            for(int i=0;i<maxThreads;i++)
            {
                Label2.Text += data[i][0] + " , ";
            }
            */
            

            return 2.0 * (end-start) * result.Sum() / (limit*maxThreads);
        }
        
        private double GetRandomDouble(double min, double max, Random random)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}