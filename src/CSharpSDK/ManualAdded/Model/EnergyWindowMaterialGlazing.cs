namespace HoneybeeSchema
{
    public partial class EnergyWindowMaterialGlazing
    {
        public double RValue => this.Thickness / this.Conductivity;

        public double UValue => this.Conductivity / this.Thickness;
    }
}
