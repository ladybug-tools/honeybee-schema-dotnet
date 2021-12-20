using System.Linq;

namespace HoneybeeSchema
{
    public partial class BSDF
    {
        public double Reflectance { get; private set; }
        public double Transmittance { get; private set; }
        public double Emittance { get; private set; }

        public bool CalVisualValues()
        {
            this.Reflectance = (this.FrontDiffuseReflectance?.FirstOrDefault()).GetValueOrDefault();
            this.Transmittance = (this.DiffuseTransmittance?.FirstOrDefault()).GetValueOrDefault();
            this.Emittance = -999;
            return true;
        }
    }
}
