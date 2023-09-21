using System;

namespace HoneybeeSchema
{
    public partial class EnergyWindowMaterialSimpleGlazSys
    {
        //https://github.com/ladybug-tools/honeybee-energy/blob/f76222320811116c01a773b9fda05e26c02da277/honeybee_energy/material/glazing.py#L616-L625
        private double out_film_r => 1 / ((0.025342 * this.UFactor) + 29.163853);

        private double in_film_r => this.UFactor < 5.85 ? 1 / ((0.359073 * Math.Log(UFactor)) + 6.949915) : 1 / ((1.788041 * this.UFactor) - 2.886625);


        public double Emissivity => 0.84;
        public double RValue => (1 / this.UFactor) - out_film_r - in_film_r;

        public double UValue => 1 / this.RValue;
        public double RFactor => 1 / this.UFactor;

        public double SolarTransmittance => CalSolarTransmittance(this.UFactor, this.Shgc);


        //https://github.com/ladybug-tools/honeybee-energy/blob/f76222320811116c01a773b9fda05e26c02da277/honeybee_energy/material/glazing.py#L628-L642
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
            else if (uFactor <= 3.4)
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
