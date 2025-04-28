namespace HoneybeeSchema
{
    public partial class Trans
    {
   
        public override bool CalVisualValues()
        {
            this.Reflectance = RadianceVisualCalculator.AvgReflectance(this.RReflectance, this.GReflectance, this.BReflectance, this.Specularity);
            this.Transmittance = (this.TransmittedDiff + this.TransmittedSpec) / 2;
            this.Emittance = -999;
            return true;
        }
    }
}
