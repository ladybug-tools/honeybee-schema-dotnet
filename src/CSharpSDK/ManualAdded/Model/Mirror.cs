namespace HoneybeeSchema
{
    public partial class Mirror
    {

        public override bool CalVisualValues()
        {
            this.Reflectance = RadianceVisualCalculator.AvgReflectance(this.RReflectance, this.GReflectance, this.BReflectance, 0.7);
            this.Transmittance = -999;
            this.Emittance = -999;
            
            return true;
        }
    }
}
