namespace HoneybeeSchema
{
    public partial class Glass
    {
        public override bool CalVisualValues()
        {
            var tvis = RadianceVisualCalculator.TransmittanceFromTransmissivity(RadianceVisualCalculator.AvgTransmissivity(this));
            this.Transmittance = tvis;
            var reflt = 1 - tvis;
            this.Reflectance = reflt < 0 ? -999 : reflt;
            this.Emittance = -999;
            return true;
        }
    }
}
