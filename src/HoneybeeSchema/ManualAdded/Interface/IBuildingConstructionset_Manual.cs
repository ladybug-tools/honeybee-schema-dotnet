namespace HoneybeeSchema.Radiance
{
	public partial interface IBuildingModifierSet:  IModifierset{}
}

//Classes implemented this interface:
namespace HoneybeeSchema
{
	public partial class ModifierSet: HoneybeeSchema.Radiance.IBuildingModifierSet { }
	public partial class ModifierSetAbridged : HoneybeeSchema.Radiance.IBuildingModifierSet { }
	
}
