using System;

namespace HoneybeeSchema
{
    public partial class EnergyWindowMaterialSimpleGlazSys
    {
        private const double _film_resistance = 1 / 23.0 + 1 / 8.0;
        public double Emissivity => 0.84;
        public double RValue => (1 / this.UFactor) - _film_resistance;

        public double UValue => 1 / this.RValue;
        public double RFactor => 1 / this.UFactor;

        public double SolarTransmittance => CalSolarTransmittance(this.UFactor, this.Shgc);

        //https://github.com/ladybug-tools/honeybee-energy/blob/42ce9cffced5eb9c05a7e74183e244b40a326a98/honeybee_energy/material/glazing.py#L579
        public static double CalSolarTransmittance(double uFactor, double shgc)
        {
            var term_1 = 0.0;
            var term_2 = 0.0;
            if (uFactor > 3.4)
            {
                term_1 = shgc < 0.7206 ? 
                    (0.939998 * Math.Pow(shgc, 2)) + (0.20332 * shgc) : 
                    (1.30415 * shgc) - 0.30515;
            }

            if (uFactor < 4.5)
            {
                term_2 = shgc > 0.15 ? 
                    (0.085775 * Math.Pow(shgc, 2)) + (0.963954 * shgc) - 0.084958 : 
                    0.4104 * shgc;
            }

            if (uFactor > 4.5)
            {
                return term_1;
            }
            else if (uFactor < 3.4)
            {
                return term_2;
            }
            else
            {
                var w = (uFactor - 3.4)/1.1;
                return (term_1 * w) + (term_2 * (1 - w));
            }

        }
    }
}
