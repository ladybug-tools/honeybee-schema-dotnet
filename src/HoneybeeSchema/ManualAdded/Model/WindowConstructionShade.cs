namespace HoneybeeSchema
{
    public partial class WindowConstructionShade
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
            this.RValue = this.WindowConstruction.RValue;
            this.RFactor = this.WindowConstruction.RFactor;
            // U value
            this.UValue = this.WindowConstruction.UValue;
            this.UFactor = this.WindowConstruction.UFactor;

            //SHGC, solarT, visT
            this.SHGC = this.WindowConstruction.SHGC;
            this.SolarTransmittance = this.WindowConstruction.SolarTransmittance;
            this.VisibleTransmittance = this.WindowConstruction.VisibleTransmittance;
            return true;
        }

        public Energy.IConstruction GenReversedConstruction() => null;
    }
}
;