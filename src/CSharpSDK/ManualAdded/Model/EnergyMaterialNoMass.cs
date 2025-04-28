namespace HoneybeeSchema
{
    public partial class EnergyMaterialNoMass
    {
        //public double RValue { get; }
        public double UValue => 1 / RValue;
    }
}
