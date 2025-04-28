using System.Collections.Generic;
using System.Runtime.Serialization;
using HoneybeeSchema.Energy;

namespace HoneybeeSchema
{
    public partial class Model
    {
        
        public void AddConstructionSets(IEnumerable<IBuildingConstructionset> constructionsets)
        {
            this.Properties.Energy.AddConstructionSets(constructionsets);
        }

        public void AddProgramTypes(IEnumerable<IProgramtype> programtypes)
        {
            this.Properties.Energy.AddProgramTypes(programtypes);
        }

        public void AddHVACs(IEnumerable<IHvac> havcs)
        {
            this.Properties.Energy.AddHVACs(havcs);
        }


        public void AddMaterials(IEnumerable<IMaterial> materials)
        {
            this.Properties.Energy.AddMaterials(materials);
        }

        public void AddConstructions(IEnumerable<IConstruction> constructions)
        {
            this.Properties.Energy.AddConstructions(constructions);
        }

        public void AddSchedules(IEnumerable<ISchedule> schedules)
        {
            this.Properties.Energy.AddSchedules(schedules);
        }

        public void AddScheduleTypeLimits(IEnumerable<ScheduleTypeLimit> scheduleTypeLimits)
        {
            this.Properties.Energy.AddScheduleTypeLimits(scheduleTypeLimits);
        }

        public void AddModifiers(IEnumerable<Radiance.IModifier> modifiers)
        {
            this.Properties.Radiance.AddModifiers(modifiers);
        }

        public void AddModifierSets(IEnumerable<Radiance.IBuildingModifierSet> modifierSets)
        {
            this.Properties.Radiance.AddModifierSets(modifierSets);
        }

        public void MergeModelProperties(Model other)
        {
            if (other == null) return;
            this.Properties.MergeWith(other.Properties);
        }
    }
}
