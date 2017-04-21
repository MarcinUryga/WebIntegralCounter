using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebCounter1
{
    public class TrapezoidMethod : CountIntegralTemplate
    {
        public TrapezoidMethod(double xOd, double xDo, bool checkBox, double dokladnosc, int liczbaPrzedzialow) : base(xOd, xDo, checkBox, dokladnosc, liczbaPrzedzialow) {}

        private double TrapezoidPattern(double a, double b, double h)
        {
            return (a + b) * h / 2;
        }

        public override double CountIntegral()
        {
            double wynik = 0;
            for (double i = XOd; i < XDo; i += Dokladnosc)
            {
                wynik += TrapezoidPattern(Math.Sin(i), Math.Sin(i + Dokladnosc), Dokladnosc);
            }

            return wynik;
        }

        public override double CountIntegralParallel()
        {
            double[] wynik = new double[LiczbaPrzedzialow];

            Parallel.For(0, LiczbaPrzedzialow, (int x) =>
            {
                wynik[x] = 0;
                for (double c = XOd + (x * (XDo - XOd) / LiczbaPrzedzialow);
                c <= XOd + (x * (XDo - XOd) / LiczbaPrzedzialow) + ((XDo - XOd) / LiczbaPrzedzialow);
                c = c + Dokladnosc)
                {
                    wynik[x] += TrapezoidPattern(Math.Sin(c), Math.Sin(c + Dokladnosc), Dokladnosc);
                }
            });
            return wynik.Sum();
        }

    }
}