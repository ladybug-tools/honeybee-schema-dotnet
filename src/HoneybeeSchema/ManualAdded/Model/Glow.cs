namespace HoneybeeSchema
{
    public partial class Glow
    {

        public override bool CalVisualValues()
        {
            this.Reflectance = -999;
            this.Transmittance = -999;
            this.Emittance = (this.BEmittance + this.GEmittance + this.REmittance) / 3;
            return true;
        }
    }
}
