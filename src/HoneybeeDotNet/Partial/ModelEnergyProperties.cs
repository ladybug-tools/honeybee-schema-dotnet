using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneybeeDotNet.Model
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
					var url = @"https://raw.githubusercontent.com/MingboPeng/honeybee-schema/master/honeybee_schema/samples/model_energy_properties_default.json";
					using (System.Net.WebClient wc = new System.Net.WebClient())
					{
						var json = wc.DownloadString(url);
						_default = ModelEnergyProperties.FromJson(json);
					}

				}

				return _default; 
			}
		}

	}
}
