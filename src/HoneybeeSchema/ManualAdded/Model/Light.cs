namespace HoneybeeSchema
{
    public partial class Light
    {
        public double Reflectance { get; private set; }
        public double Transmittance { get; private set; }
        public double Emittance { get; private set; }

        public bool CalVisualValues()
        {
            this.Reflectance = -999;
            this.Transmittance = -999;
            this.Emittance = (this.BEmittance + this.GEmittance + this.REmittance) / 3;
            return true;
        }
    }
}
