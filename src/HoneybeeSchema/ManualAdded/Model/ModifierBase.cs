namespace HoneybeeSchema
{
    public partial class ModifierBase
    {
        public double Reflectance { get; protected set; } = -999;
        public double Transmittance { get; protected set; } = -999;
        public double Emittance { get; protected set; } = -999;

        public virtual bool CalVisualValues()
        {
            //do nothing
            return true;
        }
    }
}
