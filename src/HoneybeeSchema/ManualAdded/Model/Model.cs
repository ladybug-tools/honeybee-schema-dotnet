using System.Collections.Generic;
using System.Runtime.Serialization;
using HoneybeeSchema.Energy;

namespace HoneybeeSchema
{
    public partial class Model
    {
        /// <summary>
        /// Text string for the current version of the schema.
        /// </summary>
        /// <value>Text string for the current version of the schema.</value>
        [DataMember(Name = "version", EmitDefaultValue = true)]
        public string Version { get; set; } = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public void AddConstructionSets(List<IBuildingConstructionset> constructionsets)
        {
            this.Properties.Energy.AddConstructionSets(constructionsets);
        }

        public void AddProgramTypes(List<IProgramtype> programtypes)
        {
            this.Properties.Energy.AddProgramTypes(programtypes);
        }

        public void AddHVACs(List<IHvac> havcs)
        {
            this.Properties.Energy.AddHVACs(havcs);
        }


        public void AddMaterials( List<IMaterial> materials)
        {
            this.Properties.Energy.AddMaterials(materials);
        }

        public void AddConstructions(List<IConstruction> constructions)
        {
            this.Properties.Energy.AddConstructions(constructions);
        }

        public void AddSchedules(List<IDdEnergyBaseModel> schedules)
        {
            this.Properties.Energy.AddSchedules(schedules);
        }

        public void AddScheduleTypeLimits(List<ScheduleTypeLimit> scheduleTypeLimits)
        {
            this.Properties.Energy.AddScheduleTypeLimits(scheduleTypeLimits);
        }

        public void AddModifiers(List<ModifierBase> modifiers)
        {
            this.Properties.Radiance.AddModifiers(modifiers);
        }

        public void AddModifierSets(List<IDdRadianceBaseModel> modifierSets)
        {
            this.Properties.Radiance.AddModifierSets(modifierSets);
        }
    }
}
