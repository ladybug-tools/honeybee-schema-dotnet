
using System.Collections.Generic;
using System.Linq;

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
		public void MergeWith(ModelEnergyProperties other)
        {
			if (other == null) return;
			this.AddMaterials(other.MaterialList);
			this.AddConstructions(other.ConstructionList);
			this.AddConstructionSets(other.ConstructionSetList);
			this.AddHVACs(other.HVACList);
            this.AddSchedules(other.ScheduleList);
            this.AddScheduleTypeLimits(other.ScheduleTypeLimits);
			this.AddProgramTypes(other.ProgramTypeList);
        }
		public IEnumerable<Energy.IMaterial> MaterialList => this.Materials?.OfType<Energy.IMaterial>();
		public IEnumerable<Energy.IConstruction> ConstructionList => this.Constructions?.OfType<Energy.IConstruction>();
        public IEnumerable<Energy.IBuildingConstructionset> ConstructionSetList => ConstructionSets?.OfType<Energy.IBuildingConstructionset>();
        public IEnumerable<Energy.IHvac> HVACList => this.Hvacs?.OfType<Energy.IHvac>();
        public IEnumerable<Energy.ISchedule> ScheduleList => this.Schedules?.OfType<Energy.ISchedule>();
        public IEnumerable<Energy.IProgramtype> ProgramTypeList => this.ProgramTypes?.OfType<Energy.IProgramtype>();


    }
}
