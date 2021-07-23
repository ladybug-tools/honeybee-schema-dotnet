using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    public partial class WindowConstructionAbridged
    {
        public double RValue { get; private set; }
        public double UValue { get; private set; }
        public double RFactor { get; private set; }
        public double UFactor { get; private set; }

        public bool CalThermalValues(ModelEnergyProperties libSource)
        {
            var mats = new List<Energy.IMaterial>();
            foreach (var id in this.Materials)
            {
                var mat = libSource.MaterialList?.FirstOrDefault(m => m.Identifier == id);
                if (mat == null)
                    throw new ArgumentException($"Failed to find the {id} in the library source");
                mats.Add(mat);
            }
       
            // R value,  R factor
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