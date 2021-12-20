namespace HoneybeeSchema
{
    public partial class Metal
    {
        public double Reflectance { get; private set; }
        public double Transmittance { get; private set; }
        public double Emittance { get; private set; }

        public bool CalVisualValues()
        {
            this.Reflectance = RadianceVisualCalculator.AvgReflectance(this.RReflectance, this.GReflectance, this.BReflectance, this.Specularity);
            this.Transmittance = 0;
            this.Emittance = 0;
            return true;
        }
    }
}
