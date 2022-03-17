using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    public partial class OpaqueConstructionAbridged
    {
        public double RValue { get; private set; }
        public double UValue { get; private set; }
        public double RFactor { get; private set; }
        public double UFactor { get; private set; }
        public double SolarTransmittance => 0;
        public double SHGC => 0;
        public double VisibleTransmittance => 0;
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

            ConstrucitonThermalCalculator.CalOpaqueValues(mats, out var rv, out var rf);
            this.RValue = rv;
            this.RFactor = rf;

            this.UValue = 1 / this.RValue;
            this.UFactor = 1 / this.RFactor;
            return true;

        }

        public Energy.IConstruction GenReversedConstruction()
        {
            var obj = this.DuplicateOpaqueConstructionAbridged();
            obj.Identifier = $"{obj.Identifier}_Rev";
            obj.Materials.Reverse();
            return obj;
        }

    }

}
;