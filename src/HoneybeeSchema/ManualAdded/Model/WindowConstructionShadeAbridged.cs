﻿namespace HoneybeeSchema
{
    public partial class WindowConstructionShadeAbridged
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
            this.WindowConstruction.CalThermalValues(libSource);

            this.RValue = this.WindowConstruction.RValue;
            this.RFactor = this.WindowConstruction.RFactor;
            // U value
            this.UValue = this.WindowConstruction.UValue;
            this.UFactor = this.WindowConstruction.UFactor;

            this.SolarTransmittance = this.WindowConstruction.SolarTransmittance;
            this.SHGC = this.WindowConstruction.SHGC;
            this.VisibleTransmittance = this.WindowConstruction.VisibleTransmittance;
            return true;
        }
        public Energy.IConstruction GenReversedConstruction() => this.DuplicateWindowConstructionShadeAbridged();
    }
}
;