namespace HoneybeeSchema
{
    public partial class EnergyWindowMaterialGasCustom
    {
        public double RValue => 1 / UValue;

        public double UValue => GasCustomUValueCalculator.Instance.CalUValue(this);
        public double CalUValue(double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
               double t_kelvin = 273.15, double pressure = 101325)
        {
            return GasCustomUValueCalculator.Instance.CalUValue(this, delta_t, emissivity_1, emissivity_2, height, t_kelvin, pressure);
        }

        public double CalUValueAtAngle(double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
             double angle = 90, double t_kelvin = 273.15, double pressure = 101325)
        {
            return GasCustomUValueCalculator.Instance.CalUValueAtAngle(GasType.Air, this.Thickness, delta_t, emissivity_1, emissivity_2, height, angle, t_kelvin, pressure);
        }
    }
}
