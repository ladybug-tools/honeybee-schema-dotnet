
namespace HoneybeeSchema.Energy
{
	public partial interface IThermalConstruction 
	{
		double RValue { get; }
		double UValue { get; }

		double RFactor { get; }
		double UFactor { get; }

		/// <summary>
		/// Calculate R/U values and R/U Factor, after which you can get values from properties: RValue, UValue, RFactor, UFactor.
		/// </summary>
		/// <param name="libSource">A library source for abridged object to find materials for thermal calculation</param>
		/// <returns></returns>
		bool CalThermalValues(ModelEnergyProperties libSource);
	}
}

//Classes implemented this interface:
namespace HoneybeeSchema
{
	public partial class OpaqueConstruction: HoneybeeSchema.Energy.IThermalConstruction { }
    public partial class OpaqueConstructionAbridged : HoneybeeSchema.Energy.IThermalConstruction { }
    public partial class WindowConstruction : HoneybeeSchema.Energy.IThermalConstruction { }
    public partial class WindowConstructionAbridged : HoneybeeSchema.Energy.IThermalConstruction { }

    public partial class WindowConstructionShade : HoneybeeSchema.Energy.IThermalConstruction { }
    public partial class WindowConstructionShadeAbridged : HoneybeeSchema.Energy.IThermalConstruction { }
}
