
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

		public void MergeWith(ModelProperties other)
        {
			if (other == null) return;
			this.Energy = this.Energy ?? new ModelEnergyProperties();
			this.Radiance = this.Radiance ?? new ModelRadianceProperties();
			this.Energy.MergeWith(other.Energy);
			this.Radiance.MergeWith(other.Radiance);
        }
	}
}
