extern alias LBTNewtonSoft; using System;
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
        public double SolarTransmittance { get; private set; }
        public double SHGC { get; private set; }
        public double VisibleTransmittance { get; private set; }
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
            ConstrucitonThermalCalculator.CalWindowValues(mats, out var rv, out var rf, out var solarT, out var shgc, out var vt);
            this.RValue = rv;
            this.RFactor = rf;

            // U value
            this.UValue = 1 / this.RValue;
            this.UFactor = 1 / this.RFactor;

            this.SHGC = shgc;
            this.SolarTransmittance = solarT;
            this.VisibleTransmittance = vt;
            return rv != -999;

        }


        public Energy.IConstruction GenReversedConstruction()
        {
            var obj = this.DuplicateWindowConstructionAbridged();
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