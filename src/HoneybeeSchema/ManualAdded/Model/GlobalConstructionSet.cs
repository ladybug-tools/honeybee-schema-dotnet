
namespace HoneybeeSchema
{
    partial class GlobalConstructionSet
	{
		private static GlobalConstructionSet _default;

		public static GlobalConstructionSet Default
		{
			get 
			{
				if (_default == null)
				{
					_default = GlobalConstructionSet.FromJson(_defaultString);
				}

				return _default; 
			}
		}


		private static string _defaultString = Resource.GlobalConstructionSet;
	}
}
