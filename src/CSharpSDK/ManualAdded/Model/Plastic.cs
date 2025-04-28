namespace HoneybeeSchema
{
    public partial class Plastic
    {
        public override bool CalVisualValues()
        {
            this.Reflectance = RadianceVisualCalculator.AvgReflectance(this.RReflectance, this.GReflectance, this.BReflectance, this.Specularity);
            this.Transmittance = -999;
            this.Emittance = -999;
            return true;
        }
    }
}
