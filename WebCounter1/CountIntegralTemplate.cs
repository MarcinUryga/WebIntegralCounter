using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace WebCounter1
{
    public abstract class CountIntegralTemplate
    {

        double xOd;
        double xDo;
        int liczbaPrzedzialow;
        double dokladnosc;
        private bool checkBox;

        private double integralResult;
        private string time;

        public double XOd
        {
            get
            {
                return xOd;
            }

            set
            {
                xOd = value;
            }
        }

        public double XDo
        {
            get
            {
                return xDo;
            }

            set
            {
                xDo = value;
            }
        }

        public int LiczbaPrzedzialow
        {
            get
            {
                return liczbaPrzedzialow;
            }

            set
            {
                liczbaPrzedzialow = value;
            }
        }

        public double Dokladnosc
        {
            get
            {
                return dokladnosc;
            }

            set
            {
                dokladnosc = value;
            }
        }

        public bool CheckBox
        {
            get
            {
                return checkBox;
            }

            set
            {
                checkBox = value;
            }
        }

        public double IntegralResult
        {
            get
            {
                return integralResult;
            }

            set
            {
                integralResult = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public CountIntegralTemplate(double xOd, double xDo, bool checkBox, double dokladnosc, int liczbaPrzedzialow = 0)
        {
            this.XOd = xOd;
            this.XDo = xDo;
            this.LiczbaPrzedzialow = liczbaPrzedzialow;
            this.CheckBox = checkBox;
            this.Dokladnosc = dokladnosc;
        }

        public abstract double CountIntegral();
        public abstract double CountIntegralParallel();

        public bool CheckParallel()
        {
            if (this.CheckBox)
                return true;
            else return false;
        }

        private void DrawChart(Chart SinusChart)
        {
            SinusChart.Visible = true;
            SinusChart.Series.Clear();
            SinusChart.Titles.Clear();

            SinusChart.Titles.Add("Wykres funkcji trygonometrycznych");
            SinusChart.ChartAreas[0].AxisX.Title = "Oś wartosci X";
            SinusChart.ChartAreas[0].AxisY.Title = "Oś wartosci Y";
            SinusChart.ChartAreas[0].AxisY.LineWidth = 5;

            SinusChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;

            SinusChart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            SinusChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            SinusChart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle =
                System.Web.UI.DataVisualization.Charting.ChartDashStyle.Dot;

            SinusChart.Series.Add("Wykres sinus(x)");

            SinusChart.Series["Wykres sinus(x)"].Color = Color.DarkBlue;
            SinusChart.Series["Wykres sinus(x)"].BorderWidth = 2;

            for (double x = xOd; x <= xDo; x = x + 0.01)
            {
                double y = Math.Sin(x);
                SinusChart.Series["Wykres sinus(x)"].Points.AddXY(x, y);
            }
        }

        public void returnCountIntegralValue(Chart SinusChart)
        {
            DrawChart(SinusChart);
            Stopwatch time = new Stopwatch();
            time.Start();
            if (CheckParallel())
                integralResult = CountIntegralParallel();
            else integralResult = CountIntegral();
            time.Stop();
            Time = time.ElapsedTicks + " timer ticks.";
        }

    }
}