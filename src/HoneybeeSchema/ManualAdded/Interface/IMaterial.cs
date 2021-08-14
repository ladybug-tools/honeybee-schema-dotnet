
namespace HoneybeeSchema.Energy
{
    public partial interface IMaterial 
	{

		/// <summary>
		/// R-value of the material in [m2-K/W] (excluding air films).
		/// </summary>
		double RValue { get; }
		/// <summary>
		/// U-value of the material [W/m2-K] (excluding air films).
		/// </summary>
		double UValue { get; }

		
	}

	public partial interface IOpaqueMaterial : IMaterial
	{
	}

	public partial interface IWindowMaterialGas : IMaterial
	{
		double CalUValue(double delta_t= 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
				double t_kelvin= 273.15, double pressure = 101325);

		double CalUValueAtAngle(double delta_t = 15, double emissivity_1 = 0.84, double emissivity_2 = 0.84, double height = 1.0,
				double angle = 90, double t_kelvin = 273.15, double pressure = 101325);
		
	}
	
	public partial interface IWindowMaterialGlazing : IMaterial
	{
		double Emissivity { get; }
		//double SolarTransmittance { get; }
	}
	public partial interface IWindowMaterialShade : IMaterial
	{
		double Emissivity { get; }
	}

}

namespace HoneybeeSchema
{
    //Opaque
    public partial class EnergyMaterial : HoneybeeSchema.Energy.IOpaqueMaterial { }
	public partial class EnergyMaterialNoMass : HoneybeeSchema.Energy.IOpaqueMaterial { }

	//Gas
	public partial class EnergyWindowMaterialGas : HoneybeeSchema.Energy.IWindowMaterialGas { }
	public partial class EnergyWindowMaterialGasCustom : HoneybeeSchema.Energy.IWindowMaterialGas { }
	public partial class EnergyWindowMaterialGasMixture : HoneybeeSchema.Energy.IWindowMaterialGas { }

	//Glazing
	public partial class EnergyWindowMaterialGlazing : HoneybeeSchema.Energy.IWindowMaterialGlazing { }
	public partial class EnergyWindowMaterialSimpleGlazSys : HoneybeeSchema.Energy.IWindowMaterialGlazing { }

	//Shade
	public partial class EnergyWindowMaterialBlind : HoneybeeSchema.Energy.IWindowMaterialShade { }
	public partial class EnergyWindowMaterialShade : HoneybeeSchema.Energy.IWindowMaterialShade { }
}
