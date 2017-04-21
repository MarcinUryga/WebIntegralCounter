using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebCounter1
{
    internal class SecondMonteCarloMethod : CountIntegralTemplate
    {
        public SecondMonteCarloMethod(double xOd, double xDo, bool checkBox, double dokladnosc, int liczbaPrzedzialow) : base(xOd, xDo, checkBox, dokladnosc, liczbaPrzedzialow)
        {
        }

        private double MonteCarloPattern(double fOdx, double n)
        {
            return fOdx / n;
        }

        public override double CountIntegral()
        {
            double wynik = 0;
            Random rand = new Random();
            double randX;
            Dokladnosc = Math.Pow(Dokladnosc, -1);

            for (int i = 0; i < Dokladnosc; i++)
            {
                randX = rand.NextDouble() * (XDo - XOd) + XOd;
                wynik += MonteCarloPattern(Math.Sin(randX), Dokladnosc);
            }

            wynik = (XDo - XOd) * wynik;

            return wynik;
        }

        public override double CountIntegralParallel()
        {
            double wyn = 0;
            Random rand = new Random();
            double randX;
            Dokladnosc = Math.Pow(Dokladnosc, -1);
            double[] wynik = new double[LiczbaPrzedzialow];

            Parallel.For(0, LiczbaPrzedzialow, (int x) =>
            {
                wynik[x] = 0;
                for (int c = x; c < Dokladnosc / LiczbaPrzedzialow; c++)
                {
                    randX = rand.NextDouble() * (XDo - XOd) + XOd;
                    wynik[x] = MonteCarloPattern(Math.Sin(randX), Dokladnosc);
                }
            });
            wyn = wynik.Sum();
            wyn = (XDo - XOd) * wyn;


            return wyn;
        }
    }
}