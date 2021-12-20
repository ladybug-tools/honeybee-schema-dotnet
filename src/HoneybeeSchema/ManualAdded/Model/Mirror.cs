namespace HoneybeeSchema
{
    public partial class Mirror
    {
        public new double Reflectance { get; private set; }
        public double Transmittance { get; private set; }
        public double Emittance { get; private set; }

        public bool CalVisualValues()
        {
            this.Reflectance = RadianceVisualCalculator.AvgReflectance(this.RReflectance, this.GReflectance, this.BReflectance, 0.7);
            this.Transmittance = 0;
            this.Emittance = 0;
            return true;
        }
    }
}
