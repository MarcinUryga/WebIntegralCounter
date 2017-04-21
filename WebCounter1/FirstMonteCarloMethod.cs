using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebCounter1
{
    internal class FirstMonteCarloMethod : CountIntegralTemplate
    {
        double yOd { get; set; }
        double yDo { get; set; }

        public FirstMonteCarloMethod(double yOd, double yDo, double xOd, double xDo, bool checkBox, double dokladnosc, int liczbaPrzedzialow) : base(xOd, xDo, checkBox, dokladnosc, liczbaPrzedzialow)
        {
            this.yOd = yOd;
            this.yDo = yDo;
        }
        
        private int MonteCarloPattern(double x, double y)
        {
            if (y > 0 && y <= Math.Sin(x))
                return 1;
            else if (y < 0 && y >= Math.Sin(x))
                return -1;
            else
                return 0;
        }

        public override double CountIntegral()
        {
            double wynik = 0;

            Random rand = new Random();
            double randX, randY;
            Dokladnosc = 1000 * Math.Pow(Dokladnosc, -1);
            int countC = 0;
            for (int i = 0; i < 100; i++)
            {
                randX = rand.NextDouble() * (XDo - XOd) + XOd;
                randY = rand.NextDouble() * (yDo - yOd) + yOd;

                countC += MonteCarloPattern(randX, randY);
            }

            wynik = Math.Abs(XDo - XOd) * Math.Abs(yDo - yOd) * (countC / Dokladnosc);

            return wynik;
        }

        public override double CountIntegralParallel()
        {
            double wynik = 0;

            Random rand = new Random();
            double randX, randY;
            Dokladnosc = Math.Pow(Dokladnosc, -1);

            int[] countC = new int[LiczbaPrzedzialow];
            int C = 0;
            Parallel.For(0, LiczbaPrzedzialow, x =>
            {
                countC[x] = 0;
                for (int c = x; c < Dokladnosc / LiczbaPrzedzialow; c++)
                {
                    randX = rand.NextDouble() * (XDo - XOd) + XOd;
                    randY = rand.NextDouble() * (yDo - yOd) + yOd;

                    countC[x] = MonteCarloPattern(randX, randY);
                }
            });
            C = countC.Sum();


            wynik = Math.Abs(XDo - XOd) * Math.Abs(yDo - yOd) * (C / Dokladnosc);

            return wynik;
        }
    }
}