using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    public partial class OpaqueConstruction
    {
        public double RValue { get; private set; }
        public double UValue { get; private set; }
        public double RFactor { get; private set; }
        public double UFactor { get; private set; }

        public bool CalThermalValues(ModelEnergyProperties libSource = default)
        {
            // R value,  R factor
            var mats = this.Materials.OfType<Energy.IMaterial>().ToList();
            ConstrucitonThermalCalculator.CalOpaqueValues(mats, out var rv, out var rf);
            this.RValue = rv;
            this.RFactor = rf;

            this.UValue = 1 / this.RValue;
            this.UFactor = 1 / this.RFactor;
            return true;
        }


    }

}
;