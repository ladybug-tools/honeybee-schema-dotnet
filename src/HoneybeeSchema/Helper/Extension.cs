
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
        public static void AddConstructionSets(this ModelEnergyProperties modelEnergyCollection, List<IBuildingConstructionset> constructionsets)
        {
            foreach (var item in constructionsets)
            {
                modelEnergyCollection.AddConstructionSet(item);
            }

        }
        public static void AddProgramType(this ModelEnergyProperties modelEnergyCollection, IProgramtype programtype)
        {
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

        public static void AddProgramTypes(this ModelEnergyProperties modelEnergyCollection, List<IProgramtype> programtypes)
        {
            foreach (var item in programtypes)
            {
                modelEnergyCollection.AddProgramType(item);
            }

        }
        public static void AddHVAC(this ModelEnergyProperties modelEnergyCollection, IHvac havc)
        {
            modelEnergyCollection.Hvacs = modelEnergyCollection.Hvacs?? new List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOAS, WSHPwithDOAS, VRFwithDOAS, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater>>();
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
                case FCUwithDOAS em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case VRFwithDOAS em:
                    modelEnergyCollection.Hvacs.Add(em);
                    break;
                case WSHPwithDOAS em:
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
        public static void AddHVACs(this ModelEnergyProperties modelEnergyCollection, List<IHvac> havcs)
        {
            foreach (var item in havcs)
            {
                modelEnergyCollection.AddHVAC(item);
            }

        }

        public static void AddMaterial(this ModelEnergyProperties modelEnergyCollection, IMaterial material)
        {
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
        public static void AddMaterials(this ModelEnergyProperties modelEnergyCollection, List<IMaterial> materials)
        {
            foreach (var item in materials)
            {
                modelEnergyCollection.AddMaterial(item);
            }
        }

        public static void AddConstruction(this ModelEnergyProperties modelEnergyCollection, IConstruction construction)
        {
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
        public static void AddConstructions(this ModelEnergyProperties modelEnergyCollection, List<IConstruction> constructions)
        {
            foreach (var item in constructions)
            {
                modelEnergyCollection.AddConstruction(item);
            }
        }

        public static void AddSchedule(this ModelEnergyProperties modelEnergyCollection, IDdEnergyBaseModel schedule)
        {
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
        public static void AddSchedules(this ModelEnergyProperties modelEnergyCollection, List<IDdEnergyBaseModel> schedules)
        {
            foreach (var item in schedules)
            {
                modelEnergyCollection.AddSchedule(item);
            }
        }

        public static void AddScheduleTypeLimit(this ModelEnergyProperties modelEnergyCollection,  ScheduleTypeLimit scheduleTypeLimit)
        {
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
        public static void AddScheduleTypeLimits(this ModelEnergyProperties modelEnergyCollection, List<ScheduleTypeLimit> scheduleTypeLimits)
        {
            foreach (var item in scheduleTypeLimits)
            {
                modelEnergyCollection.AddScheduleTypeLimit(item);
            }
        }


        public static void AddModifier(this ModelRadianceProperties modelRadianceCollection, ModifierBase modifier)
        {
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
        public static void AddModifiers(this ModelRadianceProperties modelRadianceCollection, List<ModifierBase> modifiers)
        {
            foreach (var item in modifiers)
            {
                modelRadianceCollection.AddModifier(item);
            }
        }

        public static void AddModifierSet(this ModelRadianceProperties modelRadianceCollection, IDdRadianceBaseModel modifierSet)
        {
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
        public static void AddModifierSets(this ModelRadianceProperties modelRadianceCollection, List<IDdRadianceBaseModel> modifierSets)
        {
            foreach (var item in modifierSets)
            {
                modelRadianceCollection.AddModifierSet(item);
            }
        }
    }

}

