
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

		private static ModelEnergyProperties _userLib;
		public static ModelEnergyProperties UserLib
		{
			get
			{
				_userLib = _userLib ?? Helper.EnergyLibrary.UserEnergyLibrary;
				return _userLib.DuplicateModelEnergyProperties();
			}
		}

		private static ModelEnergyProperties _standardLib;

		public static ModelEnergyProperties StandardLib
		{
			get
			{
				_standardLib = _standardLib ?? Helper.EnergyLibrary.StandardEnergyLibrary;
				return _standardLib;
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
			this.Hvacs = this.Hvacs ?? new List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, RadiantwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater, Radiant>>();
			this.Materials = this.Materials ?? new List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation, EnergyWindowMaterialGlazing, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGas, EnergyWindowMaterialGasMixture, EnergyWindowMaterialGasCustom, EnergyWindowMaterialBlind, EnergyWindowMaterialShade>>();
            this.ProgramTypes = this.ProgramTypes ?? new List<AnyOf<ProgramTypeAbridged, ProgramType>>();
            this.ScheduleTypeLimits = this.ScheduleTypeLimits ?? Default.ScheduleTypeLimits;
            this.Schedules = this.Schedules ?? new List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>>();

        }
    }
}
