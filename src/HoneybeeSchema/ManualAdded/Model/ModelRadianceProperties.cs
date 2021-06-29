
using System.Collections.Generic;

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
        public IEnumerable<Radiance.IModifier> ModifierList => this.Modifiers?.OfType<Radiance.IModifier>();
        public IEnumerable<Radiance.IBuildingModifierSet> ModifierSetList => this.ModifierSets?.OfType<Radiance.IBuildingModifierSet>();

        public void MergeWith(ModelRadianceProperties other)
        {
			if (other == null) return;
			this.AddModifiers(other.ModifierList);
			this.AddModifierSets(other.ModifierSetList);
		}
	}

}
