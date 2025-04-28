extern alias LBTNewtonSoft; using System;

namespace HoneybeeSchema
{
    public class RadianceVisualCalculator
    {
        public static double AvgReflectance(double r, double g, double b, double specularity)
        {
            return (0.265 * r + 0.670 * g + 0.065 * b) * (1 - specularity) + specularity;
        }
        public static double AvgTransmissivity(Glass g)
        {
            return 0.265 * g.RTransmissivity + 0.670 * g.GTransmissivity + 0.065 * g.BTransmissivity;
        }
        public static double TransmittanceFromTransmissivity(double Tn)
        {
            if (Tn == 0) return 0;
            Func<double, double> fn = (x) => TransmissivityfromTransmittance(x) - Tn;
            return Secant(0.01, 1, fn, 0.01);
        }
        public static double TransmissivityfromTransmittance(double TVis)
        {
            return (Math.Sqrt(0.8402528435 + 0.0072522239 * TVis * TVis) - 0.9166530661) / 0.0036261119 / TVis;
        }
        static double Secant(double a, double b, Func<double, double> fn, double epsilon)
        {
            var f1 = fn(a);
            if (Math.Abs(f1) <= epsilon)
                return a;
            var f2 = fn(b);
            if (Math.Abs(f2) <= epsilon)
                return b;

            for (int i = 0; i < 100; i++)
            {
                var slope = (f2 - f1) / (b - a);
                var c = b - f2 / slope;
                var f3 = fn(c);
                if (Math.Abs(f3) <= epsilon)
                    return c;
                a = b;
                b = c;
                f1 = f2;
                f2 = f3;
            }
            return 0;
        }

    }

}
;