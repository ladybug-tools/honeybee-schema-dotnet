
using HoneybeeSchema.Energy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
	public static class Extension 
	{
		public static Energy.ILoad Duplicate(this Energy.ILoad load)
		{
			return load.Duplicate() as Energy.ILoad;
		}
		public static Energy.IMaterial Duplicate(this Energy.IMaterial material)
		{
			return material.Duplicate() as Energy.IMaterial;
		}

		public static Energy.IConstruction Duplicate(this Energy.IConstruction construction)
		{
			return construction.Duplicate() as Energy.IConstruction;
		}

		public static Energy.IConstructionset Duplicate(this Energy.IConstructionset constructionSet)
		{
			return constructionSet.Duplicate() as Energy.IConstructionset;
		}

        public static void AddConstructionSet(this ModelEnergyProperties modelEnergyCollection, IBuildingConstructionset constructionset)
        {
            modelEnergyCollection.ConstructionSets = modelEnergyCollection.ConstructionSets ?? new List<AnyOf<ConstructionSetAbridged, ConstructionSet>>();
             
            var exist = modelEnergyCollection.ConstructionSets.OfType<IIDdBase>().Any(_ => _.Identifier == constructionset.Identifier);
            if (exist)
                return;

            switch (constructionset)
            {
                case ConstructionSetAbridged em:
                    modelEnergyCollection.ConstructionSets.Add(em);
                    break;
                case ConstructionSet em:
                    modelEnergyCollection.ConstructionSets.Add(em);
                    break;

                default:
                    throw new ArgumentException($"{constructionset.GetType()}({constructionset.Identifier}) is not added to model");
            }

        }
        public static void AddConstructionSets(this ModelEnergyProperties modelEnergyCollection, IEnumerable<IBuildingConstructionset> constructionsets)
        {
            if (constructionsets == null) return;
            foreach (var item in constructionsets)
            {
                modelEnergyCollection.AddConstructionSet(item);
            }

        }
        public static void AddProgramType(this ModelEnergyProperties modelEnergyCollection, IProgramtype programtype)
        {
            modelEnergyCollection.ProgramTypes = modelEnergyCollection.ProgramTypes ?? new List<AnyOf<ProgramTypeAbridged, ProgramType>>();

            var exist = modelEnergyCollection.ProgramTypes.OfType<IIDdBase>().Any(_ => _.Identifier == programtype.Identifier);
            if (exist)
                return;

            switch (programtype)
            {
                case ProgramType em:
                    modelEnergyCollection.ProgramTypes.Add(em);
                    break;
                case ProgramTypeAbridged em:
                    modelEnergyCollection.ProgramTypes.Add(em);
                    break;

                default:
                    throw new ArgumentException($"{programtype.GetType()}({programtype.Identifier}) is not added to model");
            }

        }

        public static void AddProgramTypes(this ModelEnergyProperties modelEnergyCollection, IEnumerable<IProgramtype> programtypes)
        {
            if (programtypes == null) return;
            foreach (var item in programtypes)
            {
                modelEnergyCollection.AddProgramType(item);
            }

        }
        public static void AddHVAC(this ModelEnergyProperties modelEnergyCollection, IHvac havc)
        {
            modelEnergyCollection.Hvacs = modelEnergyCollection.Hvacs ?? new List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater>>();
            var exist = modelEnergyCollection.Hvacs.OfType<IHvac>().Any(_ => _.Identifier == havc.Identifier);
            if (exist)
                return;

            switch (havc)
            {
                case IdealAirSystemAbridged em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case ForcedAirFurnace em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case PSZ em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case PTAC em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case PVAV em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case VAV em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case FCUwithDOASAbridged em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case VRFwithDOASAbridged em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case WSHPwithDOASAbridged em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case Baseboard em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case EvaporativeCooler em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case FCU em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case GasUnitHeater em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case Residential em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case VRF em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case WSHP em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case WindowAC em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                default:
                    throw new ArgumentException($"{havc.GetType()}({havc.Identifier}) is not added to model");
            }
        }
        public static void AddHVACs(this ModelEnergyProperties modelEnergyCollection, IEnumerable<IHvac> havcs)
        {
            if (havcs == null) return;
            foreach (var item in havcs)
            {
                modelEnergyCollection.AddHVAC(item);
            }

        }

        public static void AddMaterial(this ModelEnergyProperties modelEnergyCollection, IMaterial material)
        {
            modelEnergyCollection.Materials = modelEnergyCollection.Materials ?? new List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyWindowMaterialGas, EnergyWindowMaterialGasCustom, EnergyWindowMaterialGasMixture, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialBlind, EnergyWindowMaterialGlazing, EnergyWindowMaterialShade>>();
            var exist = modelEnergyCollection.Materials.OfType<IMaterial>().Any(_ => _.Identifier == material.Identifier);
            if (exist)
                return;

            switch (material)
            {
                case EnergyMaterial em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyMaterialNoMass em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialBlind em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialGas em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialGasCustom em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialGasMixture em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialGlazing em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialShade em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                case EnergyWindowMaterialSimpleGlazSys em:
                    modelEnergyCollection.Materials.Add(em);
                    break;
                default:
                    throw new ArgumentException($"{material.GetType()}({material.Identifier}) is not added to model");
            }
        }
        public static void AddMaterials(this ModelEnergyProperties modelEnergyCollection, IEnumerable<IMaterial> materials)
        {
            if (materials == null) return;
            foreach (var item in materials)
            {
                modelEnergyCollection.AddMaterial(item);
            }
        }

        public static void AddConstruction(this ModelEnergyProperties modelEnergyCollection, IConstruction construction)
        {
            modelEnergyCollection.Constructions = modelEnergyCollection.Constructions ?? new List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, AirBoundaryConstruction, ShadeConstruction>>();
            var exist = modelEnergyCollection.Constructions.OfType<IConstruction>().Any(_ => _.Identifier == construction.Identifier);
            if (exist)
                return;

            switch (construction)
            {
                case OpaqueConstruction em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;
                case OpaqueConstructionAbridged em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;
                case WindowConstruction em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;
                case WindowConstructionAbridged em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;
                case ShadeConstruction em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;
                case AirBoundaryConstruction em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;
                case AirBoundaryConstructionAbridged em:
                    modelEnergyCollection.Constructions.Add(em);
                    break;

                default:
                    throw new ArgumentException($"{construction.GetType()}({construction.Identifier}) is not added to model");

            }
        }
        public static void AddConstructions(this ModelEnergyProperties modelEnergyCollection, IEnumerable<IConstruction> constructions)
        {
            if (constructions == null) return;
            foreach (var item in constructions)
            {
                modelEnergyCollection.AddConstruction(item);
            }
        }

        public static void AddSchedule(this ModelEnergyProperties modelEnergyCollection, ISchedule schedule)
        {
            modelEnergyCollection.Schedules = modelEnergyCollection.Schedules ?? new List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>>();
            var exist = modelEnergyCollection.Schedules.OfType<IIDdBase>().Any(_ => _.Identifier == schedule.Identifier);
            if (exist)
                return;

            switch (schedule)
            {
                case ScheduleRulesetAbridged em:
                    modelEnergyCollection.Schedules.Add(em);
                    break;
                case ScheduleFixedIntervalAbridged em:
                    modelEnergyCollection.Schedules.Add(em);
                    break;
                case ScheduleRuleset em:
                    modelEnergyCollection.Schedules.Add(em);
                    break;
                case ScheduleFixedInterval em:
                    modelEnergyCollection.Schedules.Add(em);
                    break;

                default:
                    throw new ArgumentException($"{schedule.GetType()}({schedule.Identifier}) is not added to model");

            }
        }
        public static void AddSchedules(this ModelEnergyProperties modelEnergyCollection, IEnumerable<ISchedule> schedules)
        {
            if (schedules == null) return;
            foreach (var item in schedules)
            {
                modelEnergyCollection.AddSchedule(item);
            }
        }

        public static void AddScheduleTypeLimit(this ModelEnergyProperties modelEnergyCollection,  ScheduleTypeLimit scheduleTypeLimit)
        {
            modelEnergyCollection.ScheduleTypeLimits = modelEnergyCollection.ScheduleTypeLimits ?? new List<ScheduleTypeLimit>();
            var exist = modelEnergyCollection.ScheduleTypeLimits.Any(_ => _.Identifier == scheduleTypeLimit.Identifier);
            if (exist)
                return;
            switch (scheduleTypeLimit)
            {
                case ScheduleTypeLimit em:
                    modelEnergyCollection.ScheduleTypeLimits.Add(em);
                    break;

                default:
                    throw new ArgumentException($"{scheduleTypeLimit.GetType()}({scheduleTypeLimit.Identifier}) is not added to model");

            }
        }
        public static void AddScheduleTypeLimits(this ModelEnergyProperties modelEnergyCollection, IEnumerable<ScheduleTypeLimit> scheduleTypeLimits)
        {
            if (scheduleTypeLimits == null) return;
            foreach (var item in scheduleTypeLimits)
            {
                modelEnergyCollection.AddScheduleTypeLimit(item);
            }
        }


        public static void AddModifier(this ModelRadianceProperties modelRadianceCollection, Radiance.IModifier modifier)
        {
            modelRadianceCollection.Modifiers = modelRadianceCollection.Modifiers ?? new List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>>();
            var exist = modelRadianceCollection.Modifiers.OfType<ModifierBase>().Any(_ => _.Identifier == modifier.Identifier);
            if (exist)
                return;
            switch (modifier)
            {
                case Plastic obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case Glass obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case Trans obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case Metal obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case Mirror obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case Glow obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case Light obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                case BSDF obj:
                    modelRadianceCollection.Modifiers.Add(obj);
                    break;
                default:
                    throw new ArgumentException($"{modifier.GetType()}({modifier.Identifier}) is not added to model");
            }

        }
        public static void AddModifiers(this ModelRadianceProperties modelRadianceCollection, IEnumerable<Radiance.IModifier> modifiers)
        {
            if (modifiers == null) return;
            foreach (var item in modifiers)
            {
                modelRadianceCollection.AddModifier(item);
            }
        }

        public static void AddModifierSet(this ModelRadianceProperties modelRadianceCollection, Radiance.IBuildingModifierSet modifierSet)
        {
            modelRadianceCollection.ModifierSets = modelRadianceCollection.ModifierSets ?? new List<AnyOf<ModifierSet, ModifierSetAbridged>>();
            var exist = modelRadianceCollection.ModifierSets.OfType<IDdRadianceBaseModel>().Any(_ => _.Identifier == modifierSet.Identifier);
            if (exist)
                return;
            switch (modifierSet)
            {
                case ModifierSet em:
                    modelRadianceCollection.ModifierSets.Add(em);
                    break;
                case ModifierSetAbridged em:
                    modelRadianceCollection.ModifierSets.Add(em);
                    break;
                default:
                    throw new ArgumentException($"{modifierSet.GetType()}({modifierSet.Identifier}) is not added to model");

            }
        }
        public static void AddModifierSets(this ModelRadianceProperties modelRadianceCollection, IEnumerable<Radiance.IBuildingModifierSet> modifierSets)
        {
            if (modifierSets == null) return;
            foreach (var item in modifierSets)
            {
                modelRadianceCollection.AddModifierSet(item);
            }
        }
    }

}

