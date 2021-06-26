
namespace HoneybeeSchema
{
    partial class GlobalModifierSet
	{
		private static GlobalModifierSet _default;

		public static GlobalModifierSet Default
		{
			get 
			{
				if (_default == null)
				{
					_default = GlobalModifierSet.FromJson(_defaultString);
				}

				return _default; 
			}
		}


		private static string _defaultString = Resource.GlobalModifierSet;
	}
}
