namespace HoneybeeSchema
{
    public partial class Glass
    {
        public double Reflectance { get; private set; }
        public double Transmittance { get; private set; }
        public double Emittance { get; private set; }

        public bool CalVisualValues()
        {
            var tvis = RadianceVisualCalculator.TransmittanceFromTransmissivity(RadianceVisualCalculator.AvgTransmissivity(this));
            this.Transmittance = tvis;
            var reflt = 1 - tvis;
            this.Reflectance = reflt < 0 ? -999 : reflt;
            this.Emittance = 0;
            return true;
        }
    }
}
