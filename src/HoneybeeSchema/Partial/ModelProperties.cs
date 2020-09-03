
namespace HoneybeeSchema
{
    partial class ModelProperties
    {
		private static ModelProperties _default;

		public static ModelProperties Default
		{
			get 
			{
				if (_default == null)
				{
					_default = new ModelProperties(
						Helper.EnergyLibrary.DefaultModelEnergyProperties, 
						Helper.EnergyLibrary.DefaultModelRadianceProperties
						);
				}

				return _default; 
			}
		}

	}
}
