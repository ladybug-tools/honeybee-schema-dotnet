using System.Linq;

namespace HoneybeeSchema
{
    public partial class BSDF
    {

        public override bool CalVisualValues()
        {
            this.Reflectance = (this.FrontDiffuseReflectance?.FirstOrDefault()).GetValueOrDefault();
            this.Transmittance = (this.DiffuseTransmittance?.FirstOrDefault()).GetValueOrDefault();
            this.Emittance = -999;
            return true;
        }
    }
}
