namespace HoneybeeSchema.Energy
{
	public partial interface IBuildingConstructionset: IConstructionset {}
}

//Classes implemented this interface:
namespace HoneybeeSchema
{
	public partial class ConstructionSet: HoneybeeSchema.Energy.IBuildingConstructionset { }
	public partial class ConstructionSetAbridged: HoneybeeSchema.Energy.IBuildingConstructionset { }
	
}
