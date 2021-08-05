
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
				return _default.DuplicateModelRadianceProperties(); 
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

        public void FillNulls()
        {
			this.Modifiers = this.Modifiers ?? new List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>>();
			this.ModifierSets = this.ModifierSets ?? new List<AnyOf<ModifierSet, ModifierSetAbridged>>();
        }
    }

}
