using System;
using System.Collections.Generic;

namespace HoneybeeSchema
{
    //https://github.com/ladybug-tools/honeybee-energy/blob/e8ee6e5cd325f88d4ba67ca0e4bc910f479fe332/honeybee_energy/material/gas.py
    public class GasUValueCalculator
    {
        //private static EnergyWindowMaterialGas _gas;
        private GasType _gasType;
        protected double _thickness;
        public static GasUValueCalculator Instance { get; } = new GasUValueCalculator();

        public double CalUValue(GasType gasType, double thickness, double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
                double t_kelvin = 273.15, double pressure = 101325)
        {
            _gasType = gasType;
            _thickness = thickness;
            return CalConvectiveConductance(delta_t, height, t_kelvin, pressure) + CalRadiativeConductance(emissivity_1, emissivity_2, t_kelvin);
        }
        public double CalUValueAtAngle(GasType gasType, double thickness, double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84,
                        double height = 1.0, double angle = 90, double t_kelvin = 273.15, double pressure = 101325)
        {
            _gasType = gasType;
            _thickness = thickness;
            return CalConvectiveConductanceAtAngle(delta_t, height, angle, t_kelvin, pressure) +
            CalRadiativeConductance(emissivity_1, emissivity_2, t_kelvin);
        }

        protected double CalConvectiveConductance(double delta_t = 15, double height = 1.0,
                              double t_kelvin = 273.15, double pressure = 101325)
        {
            var nu = CalNusselt(delta_t, height, t_kelvin, pressure);
            var c = CalConductivity(t_kelvin);
            return nu * c / _thickness;
        }
        protected double CalConvectiveConductanceAtAngle(double delta_t = 15, double height = 1.0, double angle = 90,
                                       double t_kelvin = 273.15, double pressure = 101325)
        {
            return CalNusseltAtAngle(delta_t, height, angle, t_kelvin, pressure) *
            (CalConductivity(t_kelvin) / _thickness);
        }
        protected double CalRadiativeConductance(double emissivity_1 = 0.84, double emissivity_2 = 0.84,
                             double t_kelvin = 273.15)
        {
            return (4 * 5.6697e-8) * Math.Pow(((1 / emissivity_1) + (1 / emissivity_2) - 1), -1)
            * Math.Pow(t_kelvin, 3);
        }

        private double CalNusselt(double delta_t = 15, double height = 1.0, double t_kelvin = 273.15, double pressure = 101325)
        {
            var rayleigh = Rayleigh(delta_t, t_kelvin, pressure);
            var n_u1 = 0.0;
            if (rayleigh > 50000)
            {
                n_u1 = 0.0673838 * Math.Pow(rayleigh, (1 / 3.0));
            }
            else if (rayleigh > 10000)
            {
                n_u1 = 0.028154 * Math.Pow(rayleigh, 0.4134);
            }
            else
            {
                n_u1 = 1 + 1.7596678e-10 * Math.Pow(rayleigh, 2.2984755);
            }
            var n_u2 = 0.242 * Math.Pow((rayleigh * (_thickness / height)), 0.272);
            return Math.Max(n_u1, n_u2);
        }

        private double CalNusseltAtAngle(double delta_t = 15, double height = 1.0, double angle = 90, double t_kelvin = 273.15, double pressure = 101325)
        {
            var rayleigh = Rayleigh(delta_t, t_kelvin, pressure);

            if (angle < 60)
            {
                var cos_a = Math.Cos(ToRadians(angle));
                var sin_a_18 = Math.Sin(1.8 * ToRadians(angle));
                var term_1 = Dot_x(1 - (1708 / (rayleigh * cos_a)));
                var term_2 = 1 - ((1708 * Math.Pow(sin_a_18, 1.6)) / (rayleigh * cos_a));
                var term_3 = Dot_x(Math.Pow(((rayleigh * cos_a) / 5830), (1 / 3.0)) - 1);
                return 1 + (1.44 * term_1 * term_2) + term_3;
            }
            else if (angle < 90)
            {
                var g = 0.5 / Math.Pow((1 + Math.Pow((rayleigh / 3160), 20.6)), 0.1);
                var n_u1 = Math.Pow((1 + Math.Pow(((0.0936 * Math.Pow(rayleigh, 0.314)) / (1 + g)), 7)), (1 / 7.0));
                var n_u2 = (0.104 + (0.175 / (_thickness / height))) * Math.Pow(rayleigh, 0.283);
                var n_u_60 = Math.Max(n_u1, n_u2);
                var n_u_90 = CalNusselt(delta_t, height, t_kelvin, pressure);
                return (n_u_60 + n_u_90) / 2;
            }
            else if (angle == 90)
            {
                return CalNusselt(delta_t, height, t_kelvin, pressure);
            }
            else
            {
                var n_u_90 = CalNusselt(delta_t, height, t_kelvin, pressure);
                return 1 + ((n_u_90 - 1) * Math.Sin(ToRadians(angle)));
            }

            double ToRadians(double a) => Math.PI / 180 * a;
            double Dot_x(double x) => (x + Math.Abs(x)) / 2;
        }
        private double Rayleigh(double delta_t = 15, double t_kelvin = 273.15, double pressure = 101325)
        {
            var airDensity = CalDensity(t_kelvin, pressure);
            var airSpecificHeat = CalSpecificHeat(t_kelvin);
            var airViscosity = CalViscosity(t_kelvin);
            var airConductivity = CalConductivity(t_kelvin);

            var _ray_numerator = Math.Pow(airDensity, 2) *
                Math.Pow(_thickness, 3) * 9.81 * airSpecificHeat * delta_t;

            var _ray_denominator = t_kelvin * airViscosity * airConductivity;
            return _ray_numerator / _ray_denominator;
        }

        private double CalDensity(double t_kelvin, double pressure = 101325)
        {
            return (pressure * MolecularWeight * 0.001) / (8.314 * t_kelvin);
        }


        //https://github.com/ladybug-tools/honeybee-energy/blob/e8ee6e5cd325f88d4ba67ca0e4bc910f479fe332/honeybee_energy/material/gas.py#L23
        public static Dictionary<GasType, (double, double, double)> CONDUCTIVITYCURVES = new Dictionary<GasType, (double, double, double)>() {
            { GasType.Air, (0.002873, 0.0000776, 0.0)},
            { GasType.Argon,  (0.002285, 0.00005149, 0.0)},
            { GasType.Krypton,  (0.0009443, 0.00002826, 0.0)},
            { GasType.Xenon,  (0.0004538, 0.00001723, 0.0) }
        };

        public static Dictionary<GasType, (double, double, double)> VISCOSITYCURVES = new Dictionary<GasType, (double, double, double)>() {
            { GasType.Air, (0.00000372, 0.00000005, 0.0)},
            { GasType.Argon,  (0.00000338, 0.00000006, 0.0)},
            { GasType.Krypton,  (0.00000221, 0.00000008, 0.0)},
            { GasType.Xenon,  (0.00000107, 0.00000007, 0.0) }
        };

        public static Dictionary<GasType, (double, double, double)> SPECIFICHEATCURVES = new Dictionary<GasType, (double, double, double)>() {
            { GasType.Air, (1002.73699951, 0.012324, 0.0)},
            { GasType.Argon,  (521.92852783, 0.0, 0.0)},
            { GasType.Krypton,  (248.09069824, 0.0, 0.0)},
            { GasType.Xenon,  (158.33970642, 0.0, 0.0) }
        };

        public static Dictionary<GasType, double> MOLECULARWEIGHTS = new Dictionary<GasType, double>() {
            { GasType.Air, 28.97},
            { GasType.Argon,  39.948},
            { GasType.Krypton,  83.8},
            { GasType.Xenon,  131.3}
        };

        protected virtual double MolecularWeight => MOLECULARWEIGHTS[_gasType];
        protected virtual double CalConductivity(double t_kelvin) => CalCoeffPropery(CONDUCTIVITYCURVES, t_kelvin);
        protected virtual double CalViscosity(double t_kelvin) => CalCoeffPropery(VISCOSITYCURVES, t_kelvin);
        protected virtual double CalSpecificHeat(double t_kelvin) => CalCoeffPropery(SPECIFICHEATCURVES, t_kelvin);
        private double CalCoeffPropery(Dictionary<GasType, (double, double, double)> dic, double t_kelvin)
        {
            return dic[_gasType].Item1 + dic[_gasType].Item2 * t_kelvin + dic[_gasType].Item3 * t_kelvin * t_kelvin;
        }
    }
    public class GasCustomUValueCalculator : GasUValueCalculator
    {
        private EnergyWindowMaterialGasCustom _gas;
        public static GasCustomUValueCalculator Instance { get; } = new GasCustomUValueCalculator();
        public double CalUValue(EnergyWindowMaterialGasCustom gas, double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
                double t_kelvin = 273.15, double pressure = 101325)
        {
            _gas = gas;
            _thickness = gas.Thickness;
            return CalConvectiveConductance(delta_t, height, t_kelvin, pressure) + CalRadiativeConductance(emissivity_1, emissivity_2, t_kelvin);
        }
        protected override double MolecularWeight => _gas.MolecularWeight;
        protected override double CalConductivity(double t_kelvin)
        {
            return _gas.ConductivityCoeffA + _gas.ConductivityCoeffB * t_kelvin +
            _gas.ConductivityCoeffC * t_kelvin * t_kelvin;
        }
        protected override double CalViscosity(double t_kelvin)
        {
            return _gas.ViscosityCoeffA + _gas.ViscosityCoeffB * t_kelvin +
            _gas.ViscosityCoeffC * t_kelvin * t_kelvin;
        }
        protected override double CalSpecificHeat(double t_kelvin)
        {
            return _gas.SpecificHeatCoeffA + _gas.SpecificHeatCoeffB * t_kelvin +
             _gas.SpecificHeatCoeffC * t_kelvin * t_kelvin;
        }

    }

    public class GasMixUValueCalculator : GasUValueCalculator
    {
        private EnergyWindowMaterialGasMixture _gas;
        public static GasMixUValueCalculator Instance { get; } = new GasMixUValueCalculator();


        public double CalUValue(EnergyWindowMaterialGasMixture gas, double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
                double t_kelvin = 273.15, double pressure = 101325)
        {
           
            _gas = gas;
            _thickness = gas.Thickness;
            var cc = CalConvectiveConductance(delta_t, height, t_kelvin, pressure);
            var rc = CalRadiativeConductance(emissivity_1, emissivity_2, t_kelvin);
            return cc + rc;
        }

     
        protected override double MolecularWeight
        {
            get
            {
                var count = _gas.GasTypes.Count;
                var total = 0.0;
                for (int i = 0; i < count; i++)
                {
                    var v = MOLECULARWEIGHTS[_gas.GasTypes[i]];
                    total += v * _gas.GasFractions[i];
                }
                return total;
            }
        }
        protected override double CalConductivity(double t_kelvin) => Weighted_avg_coeff_property(CONDUCTIVITYCURVES, t_kelvin);
        protected override double CalViscosity(double t_kelvin) => Weighted_avg_coeff_property(VISCOSITYCURVES, t_kelvin);
        protected override double CalSpecificHeat(double t_kelvin) => Weighted_avg_coeff_property(SPECIFICHEATCURVES, t_kelvin);

        private double Weighted_avg_coeff_property(Dictionary<GasType, (double, double, double)> dic, double t_kelvin)
        {
            var count = _gas.GasTypes.Count;
            var total = 0.0;
            for (int i = 0; i < count; i++)
            {
                var _gasType = _gas.GasTypes[i];
                var percent = _gas.GasFractions[i];
                var v = dic[_gasType].Item1 + dic[_gasType].Item2 * t_kelvin + dic[_gasType].Item3 * t_kelvin * t_kelvin;
                total += v * percent;
            }
            return total;
        }

    }

}
