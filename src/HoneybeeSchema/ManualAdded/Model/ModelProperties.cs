﻿
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

				return _default.DuplicateModelProperties(); 
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

		public void FillNulls()
		{
			this.Energy = this.Energy ?? new ModelEnergyProperties();
			this.Energy.FillNulls();
			this.Radiance = this.Radiance ?? new ModelRadianceProperties();
			this.Radiance.FillNulls();
		}
	}
}
