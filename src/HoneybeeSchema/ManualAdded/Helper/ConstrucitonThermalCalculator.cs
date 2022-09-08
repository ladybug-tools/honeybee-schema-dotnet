using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    public class ConstrucitonThermalCalculator
    {
        private static List<Energy.IMaterial> MaterialList { get; set; }

        public static void CalOpaqueValues(List<Energy.IMaterial> materials, out double RValue, out double RFactor)
        {
            if (materials == null || !materials.Any())
            {
                RValue = -999;
                RFactor = -999;
                return;
            }

            MaterialList = materials;
            RValue = materials.Select(_ => _.RValue).Sum();
            RFactor = RValue + (1 / OutdoorHeatTransferCoeff) + (1 / IndoorHeatTransferCoeff);
        }
        public static void CalWindowValues(List<Energy.IMaterial> materials, out double RValue, out double RFactor, out double solarT, out double SHGC, out double vt)
        {
            if (materials == null || !materials.Any())
            {
                RValue = -999;
                RFactor = -999;
                solarT = -999;
                SHGC = -999;
                vt = -999;
                return;
            }


            MaterialList = materials;

            // ensure all gas type materials are at even layer
            var groups = materials.Select((item, index) => new { Item = item, Index = index }).GroupBy(x => x.Index % 2 == 0);
            var oddLayers = groups.FirstOrDefault(_ => _.Key == false).Select(_ => _.Item);
            var evenLayers = groups.FirstOrDefault(_ => _.Key == true).Select(_ => _.Item);

            var isAllOddLayersGas = oddLayers.All(_ => _ is Energy.IWindowMaterialGas);
            var isAllEvenLayerSolid = evenLayers.All(_ => !(_ is Energy.IWindowMaterialGas));
            var isFirstLayerGas = materials.FirstOrDefault() is Energy.IWindowMaterialGas;
            var isLastLayerGas = materials.LastOrDefault() is Energy.IWindowMaterialGas;

            // invalid construction
            if (!isAllOddLayersGas || !isAllEvenLayerSolid || isFirstLayerGas || isLastLayerGas)
            {
                RValue = -999;
                RFactor = -999;
                solarT = -999;
                SHGC = -999;
                vt = -999;
                return;
            }

            var gaps = materials.OfType<Energy.IWindowMaterialGas>();
            var gapCount = gaps.Count();
            if (gapCount == 0)
            {
                RValue = materials.FirstOrDefault().RValue;
                RFactor = RValue + 1 / Out_h_simple + 1 / In_h_simple;
            }
            else
            {
                Cal_layered_r_value_initial(gapCount, out var r_vals, out var emissivities);
                var rs = Solve_r_value(r_vals, emissivities);
                RValue = rs.Skip(1).Reverse().Skip(1).Sum(); // remove the first and last for R value
                RFactor = rs.Sum();
            }

            var mats = materials;
            //SolarT, SHGC
            if (mats.FirstOrDefault() is EnergyWindowMaterialSimpleGlazSys glz)
            {
                solarT = glz.SolarTransmittance;
                SHGC = glz.Shgc;
                vt = glz.Vt;
            }
            else
            {
                //SolarT
                solarT = CalSolarTrans(mats);

                //VisT
                vt = CalVisTrans(mats);

                //SHGC
                var u_fac = 1 / RFactor;
                var t_sol = solarT;
                Func<double, double> fn = (x) => EnergyWindowMaterialSimpleGlazSys.CalSolarTransmittance(u_fac, x) - t_sol;
                SHGC = Secant(0, 1, fn, 0.01);
            }
        }

        private static double InsideEmissivity => GetMaterialEmissivityBack(MaterialList.LastOrDefault());
        private static double OutsideEmissivity => GetMaterialEmissivity(MaterialList.FirstOrDefault());
        private static double GetMaterialEmissivityBack(Energy.IMaterial material)
        {
            if (material == null) return -999;
            var insideEmissivity = 0.9;
            var insideMaterial = material;

            if (insideMaterial is EnergyWindowMaterialSimpleGlazSys)
                insideEmissivity = 0.84;
            else if (insideMaterial is EnergyWindowMaterialBlind blind)
                insideEmissivity = blind.EmissivityBack;
            else if (insideMaterial is EnergyWindowMaterialGlazing glz)
                insideEmissivity = glz.EmissivityBack;
            else if (insideMaterial is EnergyWindowMaterialShade shd)
                insideEmissivity = shd.Emissivity;
            // opaque
            else if (insideMaterial is EnergyMaterial opq)
                insideEmissivity = opq.ThermalAbsorptance;
            else if (insideMaterial is EnergyMaterialNoMass noMass)
                insideEmissivity = noMass.ThermalAbsorptance;
            return insideEmissivity;
        }

        private static double GetMaterialEmissivity(Energy.IMaterial material)
        {
            if (material == null) return -999;
            var emmiss = 0.9;
            var mat = material;
            if (mat is Energy.IWindowMaterialGlazing glz)
                emmiss = glz.Emissivity;
            else if (mat is Energy.IWindowMaterialShade shd)
                emmiss = shd.Emissivity;
            // opaque
            else if (mat is EnergyMaterial opq)
                emmiss = opq.ThermalAbsorptance;
            else if (mat is EnergyMaterialNoMass noMass)
                emmiss = noMass.ThermalAbsorptance;
            return emmiss;
        }


        #region OpaqueConstruction helpers

        //https://github.com/ladybug-tools/honeybee-energy/blob/e8ee6e5cd325f88d4ba67ca0e4bc910f479fe332/honeybee_energy/construction/_base.py#L162
        private static double OutdoorHeatTransferCoeff => 23;
        private static double IndoorHeatTransferCoeff => 3.6 + (4.4 * InsideEmissivity / 0.84);

        #endregion

        #region WindowConstruction helpers

        //https://github.com/ladybug-tools/honeybee-energy/blob/e8ee6e5cd325f88d4ba67ca0e4bc910f479fe332/honeybee_energy/construction/_base.py#L162
        private static double Out_h_simple => 23;
        private static double In_h_simple => 3.6 + (4.4 * InsideEmissivity / 0.84);

        private static double CalOut_h(double wind_speed = 6.7, double t_kelvin = 273.15)
        {
            var conv_h = 4 + (4 * wind_speed);
            var rad_h = 4 * 5.6697e-8 * OutsideEmissivity * Math.Pow(t_kelvin, 3);
            return conv_h + rad_h;
        }


        private static double CalIn_h(double t_kelvin = 293.15, double delta_t = 15, double height = 1.0, double angle = 90, double pressure = 101325)
        {
            var airDensity = 28.97 * pressure * 0.001 / (8.314 * t_kelvin);
            var airSpecificHeat = 1002.73699951 + 0.012324 * t_kelvin;
            var airViscosity = 0.00000372 + 0.00000005 * t_kelvin;
            var airConductivity = 0.002873 + 0.0000776 * t_kelvin;

            var _ray_numerator = (airDensity * airDensity) *
                Math.Pow(height, 3) * 9.81 * airSpecificHeat * delta_t;

            var _ray_denominator = t_kelvin * airViscosity * airConductivity;
            var _rayleigh_h = Math.Abs(_ray_numerator / _ray_denominator);

            var _sin_a = Math.Sin(Math.PI / 180 * angle);
            var _rayleigh_c = 2.5e5 * Math.Pow((Math.Exp(0.72 * angle) / _sin_a), (1 / 5.0));


            var nusselt = 0.0;
            if (_rayleigh_h < _rayleigh_c)
            {
                nusselt = 0.56 * Math.Pow(_rayleigh_h * _sin_a, (1 / 4.0));
            }
            else
            {
                var nu_1 = 0.56 * Math.Pow((_rayleigh_c * _sin_a), (1 / 4.0));
                var nu_2 = 0.13 * (Math.Pow(_rayleigh_h, (1 / 3.0)) - Math.Pow(_rayleigh_c, (1 / 3.0)));
                nusselt = nu_1 + nu_2;
            }


            var _conv_h = nusselt * (airConductivity / height);
            var _rad_h = 4 * 5.6697e-8 * InsideEmissivity * Math.Pow(t_kelvin, 3);
            return _conv_h + _rad_h;
        }



        //https://github.com/ladybug-tools/honeybee-energy/blob/e8ee6e5cd325f88d4ba67ca0e4bc910f479fe332/honeybee_energy/construction/window.py#L510
        private static void Cal_layered_r_value_initial(int gap_count, out List<double> r_vals, out List<(double back, double front)> emiss, double delta_t_guess = 15,
                                 double avg_t_guess = 273.15, double wind_speed = 6.7)
        {
            r_vals = new List<double>() { 1 / CalOut_h(wind_speed, avg_t_guess - delta_t_guess) };
            emiss = new List<(double back, double front)>();

            var delta_t = delta_t_guess / gap_count;
            var mats = MaterialList.ToList();
            var i = 0;
            foreach (var mat in mats)
            {
                if (mat is Energy.IWindowMaterialGlazing glz)
                {
                    r_vals.Add(glz.RValue);
                    emiss.Add((0.84, 0.84));
                }
                else if (mat is Energy.IWindowMaterialGas gas)  // # gas material
                {
                    var e_front = GetMaterialEmissivity(mats[i + 1]);
                    var e_back = GetMaterialEmissivityBack(mats[i - 1]);
                    var u = gas.CalUValue(delta_t, e_back, e_front, t_kelvin: avg_t_guess);
                    r_vals.Add(1 / u);
                    emiss.Add((e_back, e_front));
                }
                i++;

            }
            r_vals.Add(1 / In_h_simple);

        }

        private static List<double> Cal_layered_r_value(List<double> temperatures, List<double> r_values_init, List<(double back, double front)> emiss,
                       double height = 1.0, double angle = 90.0, double pressure = 101325)
        {
            var r_vals = new List<double>() { r_values_init[0] };
            var mats = MaterialList.ToList();
            var mat_counts = mats.Count;
            for (int i = 0; i < mat_counts; i++)
            {
                var mat = mats[i];
                if (mat is Energy.IWindowMaterialGlazing glz)
                {
                    r_vals.Add(r_values_init[i + 1]);
                }
                else if (mat is Energy.IWindowMaterialGas gas)  // # gas material
                {
                    var delta_t = Math.Abs(temperatures[i + 1] - temperatures[i + 2]);
                    var avg_temp = ((temperatures[i + 1] + temperatures[i + 2]) / 2) + 273.15;
                    var u = gas.CalUValueAtAngle(delta_t, emiss[i].back, emiss[i].front, height, angle, avg_temp, pressure);
                    r_vals.Add(1 / u);

                }
            }
            var tCount = temperatures.Count;
            var delta_t2 = Math.Abs(temperatures[tCount - 1] - temperatures[tCount - 2]);
            var avg_temp2 = ((temperatures[tCount - 1] + temperatures[tCount - 2]) / 2) + 273.15;
            r_vals.Add(1 / CalIn_h(avg_temp2, delta_t2, height, angle, pressure));
            return r_vals;
        }

        private static List<double> Solve_r_value(List<double> r_vals, List<(double back, double front)> emissivities)
        {

            var r_last = 0.0;
            var r_next = r_vals.Sum();

            while (System.Math.Abs(r_next - r_last) > 0.001) //  # 0.001 is the r-value tolerance
            {
                r_last = r_vals.Sum();
                var temperatures = Temperature_profile_from_r_values(r_vals);
                r_vals = Cal_layered_r_value(temperatures, r_vals, emissivities);
                r_next = r_vals.Sum();
            }

            return r_vals;
        }

        private static List<double> Temperature_profile_from_r_values(
            List<double> r_values, double outside_temperature = -18, double inside_temperature = 21)
        {
            //    """Get a list of temperatures at each material boundary between R-values."""
            var r_factor = r_values.Sum();
            var delta_t = inside_temperature - outside_temperature;
            var temperatures = new List<double>() { outside_temperature };

            for (int i = 0; i < r_values.Count; i++)
            {
                temperatures.Add(temperatures[i] + (delta_t * (r_values[i] / r_factor)));
            }

            return temperatures;
        }

        #endregion

        private static double CalSolarTrans(List<Energy.IMaterial> mats)
        {
            if (mats == null || !mats.Any()) return -999;

            var i = 0;
            var trans = 1.0;
            var gap_refs = new List<double>();
            foreach (var item in mats)
            {
                if (item is EnergyWindowMaterialGlazing mat)
                {
                    if (i != 0)
                    {
                        var reff = 0.0;
                        var prev_pane = mats[i - 2] as EnergyWindowMaterialGlazing;
                        var solRefBack = prev_pane.SolarReflectanceBack.Obj;
                        var prev_pane_solRefBack = solRefBack is double sfb ? sfb : 1;
                        var ref_i = mat.SolarReflectance * prev_pane_solRefBack;
                        for (int r = 0; r < 3; r++) //# simulate 3 bounces back and forth
                        {
                            reff += ref_i;
                            ref_i = ref_i * ref_i;
                        }

                        foreach (var prev_ref in gap_refs)
                        {
                            var b_ref_i = mat.SolarReflectance * prev_ref;
                            for (int r = 0; r < 3; r++)  //# simulate 3 bounces back and forth
                            {
                                reff += b_ref_i;
                                b_ref_i = b_ref_i * b_ref_i;
                            }
                        }

                        gap_refs.Add(prev_pane_solRefBack);
                        trans += reff * trans;  //# add the back-reflected portion
                    }
                    trans *= mat.SolarTransmittance;  // pass everything through the glass
                }
                i++;
            }

            return trans;
        }

        private static double CalVisTrans(List<Energy.IMaterial> mats)
        {
            if (mats == null || !mats.Any()) return -999;

            var i = 0;
            var trans = 1.0;
            var gap_refs = new List<double>();
            foreach (var item in mats)
            {
                if (item is EnergyWindowMaterialGlazing mat)
                {
                    if (i != 0)
                    {
                        var reff = 0.0;
                        var prev_pane = mats[i - 2] as EnergyWindowMaterialGlazing;
                        var solRefBack = prev_pane.VisibleReflectanceBack.Obj;
                        var prev_pane_solRefBack = solRefBack is double sfb ? sfb : 1;
                        var ref_i = mat.VisibleReflectance * prev_pane_solRefBack;
                        for (int r = 0; r < 3; r++) //# simulate 3 bounces back and forth
                        {
                            reff += ref_i;
                            ref_i = ref_i * ref_i;
                        }

                        foreach (var prev_ref in gap_refs)
                        {
                            var b_ref_i = mat.VisibleReflectance * prev_ref;
                            for (int r = 0; r < 3; r++)  //# simulate 3 bounces back and forth
                            {
                                reff += b_ref_i;
                                b_ref_i = b_ref_i * b_ref_i;
                            }
                        }

                        gap_refs.Add(prev_pane_solRefBack);
                        trans += reff * trans;  //# add the back-reflected portion
                    }
                    trans *= mat.VisibleTransmittance;  // pass everything through the glass
                }
                i++;
            }

            return trans;
        }

        private static double Secant(double a, double b, Func<double, double> fn, double epsilon)
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