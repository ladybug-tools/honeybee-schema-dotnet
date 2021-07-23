namespace HoneybeeSchema
{
    public partial class EnergyWindowMaterialSimpleGlazSys
    {
        private const double _film_resistance = 1/23.0 + 1/8.0;
        public double Emissivity => 0.84;
        public double RValue => (1 / this.UFactor) - _film_resistance;

        public double UValue => 1 / this.RValue;
        public double RFactor => 1 / this.UFactor;
    }
}
