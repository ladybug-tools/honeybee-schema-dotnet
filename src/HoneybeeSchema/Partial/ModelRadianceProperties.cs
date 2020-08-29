
namespace HoneybeeSchema
{
    partial class ModelRadianceProperties
    {
		private static ModelRadianceProperties _default;

		public static ModelRadianceProperties Default
		{
			get 
			{
				_default = _default ?? Helper.EnergyLibrary.DefaultModelRadianceProperties;
				return _default; 
			}
		}

	}
}
