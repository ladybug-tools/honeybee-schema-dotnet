
namespace HoneybeeSchema
{
    partial class ModelEnergyProperties
    {
		private static ModelEnergyProperties _default;

		public static ModelEnergyProperties Default
		{
			get 
			{
				if (_default == null)
				{
					_default = Helper.EnergyLibrary.DefaultModelEnergyProperties;
				}

				return _default; 
			}
		}

	}
}
