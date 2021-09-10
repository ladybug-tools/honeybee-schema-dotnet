
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
				_default = _default ?? Helper.EnergyLibrary.DefaultModelEnergyProperties;
				return _default.DuplicateModelEnergyProperties(); 
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

        public void FillNulls()
        {

            this.Constructions = this.Constructions ?? new List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, WindowConstructionDynamicAbridged, WindowConstructionDynamic, AirBoundaryConstruction, ShadeConstruction>>();
            this.ConstructionSets = this.ConstructionSets ?? new List<AnyOf<ConstructionSetAbridged, ConstructionSet>>();
            this.Hvacs = this.Hvacs ?? new List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater>>();
            this.Materials = this.Materials ?? new List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyWindowMaterialGas, EnergyWindowMaterialGasCustom, EnergyWindowMaterialGasMixture, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialBlind, EnergyWindowMaterialGlazing, EnergyWindowMaterialShade>>();
            this.ProgramTypes = this.ProgramTypes ?? new List<AnyOf<ProgramTypeAbridged, ProgramType>>();
            this.ScheduleTypeLimits = this.ScheduleTypeLimits ?? Default.ScheduleTypeLimits;
            this.Schedules = this.Schedules ?? new List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>>();

        }
    }
}
