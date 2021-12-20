namespace HoneybeeSchema
{
    public partial class ModifierBase
    {
        public double Reflectance { get; private set; } = -999;
        public double Transmittance { get; private set; } = -999;
        public double Emittance { get; private set; } = -999;

        public virtual bool CalVisualValues()
        {
            //do nothing
            return true;
        }
    }
}
