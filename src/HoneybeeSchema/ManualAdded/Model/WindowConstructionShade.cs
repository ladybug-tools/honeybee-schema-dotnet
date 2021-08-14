namespace HoneybeeSchema
{
    public partial class WindowConstructionShade
    {
        public double RValue { get; private set; }
        public double UValue { get; private set; }
        public double RFactor { get; private set; }
        public double UFactor { get; private set; }
        public double SolarTransmittance => this.WindowConstruction.SolarTransmittance;
        public double SHGC => this.WindowConstruction.SHGC;

        public bool CalThermalValues(ModelEnergyProperties libSource = default)
        {
            this.RValue = this.WindowConstruction.RValue;
            this.RFactor = this.WindowConstruction.RFactor;
            // U value
            this.UValue = this.WindowConstruction.UValue;
            this.UFactor = this.WindowConstruction.UFactor;
            return true;
        }
    }
}
;