
namespace HoneybeeSchema
{
	public static class Extension 
	{
		public static Energy.ILoad Duplicate(this Energy.ILoad load)
		{
			return load.Duplicate() as Energy.ILoad;
		}
		public static Energy.IMaterial Duplicate(this Energy.IMaterial material)
		{
			return material.Duplicate() as Energy.IMaterial;
		}

		public static Energy.IConstruction Duplicate(this Energy.IConstruction construction)
		{
			return construction.Duplicate() as Energy.IConstruction;
		}

		public static Energy.IConstructionset Duplicate(this Energy.IConstructionset constructionSet)
		{
			return constructionSet.Duplicate() as Energy.IConstructionset;
		}
	}

}

