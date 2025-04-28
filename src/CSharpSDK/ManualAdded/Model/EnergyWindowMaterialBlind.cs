

namespace HoneybeeSchema
{
    public partial class EnergyWindowMaterialBlind 
    {
        public double RValue => this.SlatThickness / this.SlatConductivity;
        public double UValue => this.SlatConductivity / this.SlatThickness;
    }
}
