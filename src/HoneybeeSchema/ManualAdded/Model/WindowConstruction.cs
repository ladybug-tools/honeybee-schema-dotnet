using System;
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

        public bool CalThermalValues(ModelEnergyProperties libSource = default)
        {
            // R value,  R factor
            var mats = this.Materials.OfType<Energy.IMaterial>().ToList();
            ConstrucitonThermalCalculator.CalWindowValues(mats, out var rv, out var rf);
            this.RValue = rv;
            this.RFactor = rf;
            // U value
            this.UValue = 1 / this.RValue;
            this.UFactor = 1 / this.RFactor;
            return true;
        }

       
       
    }
}
;