extern alias LBTNewtonSoft; using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    // https://github.com/ladybug-tools/honeybee-energy/blob/master/honeybee_energy/construction/window.py
    public partial class WindowConstruction
    {
        public double RValue { get; private set; }
        public double UValue { get; private set; }
        public double RFactor { get; private set; }
        public double UFactor { get; private set; }
        public double SolarTransmittance { get; private set; }
        public double SHGC { get; private set; }
        public double VisibleTransmittance { get; private set; }
        public bool CalThermalValues(ModelEnergyProperties libSource = default)
        {
            // R value,  R factor
            var mats = this.Materials.OfType<Energy.IMaterial>().ToList();
            ConstrucitonThermalCalculator.CalWindowValues(mats, out var rv, out var rf, out var solarT, out var shgc, out var vt);
            this.RValue = rv;
            this.RFactor = rf;
            // U value
            this.UValue = 1 / this.RValue;
            this.UFactor = 1 / this.RFactor;

            this.SHGC = shgc;
            this.SolarTransmittance = solarT;
            this.VisibleTransmittance = vt;
       
            return true;
        }



        public Energy.IConstruction GenReversedConstruction()
        {
            var obj = this.DuplicateWindowConstruction();
            obj.Identifier = $"{obj.Identifier}_Rev";

            obj.Materials.Reverse();
            // check if the original list is asymmetrical
            if (obj.Materials.SequenceEqual(this.Materials))
                obj.Identifier = this.Identifier;
            return obj;
        }

    }
}
;