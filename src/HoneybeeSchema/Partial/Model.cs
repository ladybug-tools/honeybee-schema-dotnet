using System;
using System.Collections.Generic;
using System.Linq;
using HoneybeeSchema.Energy;

namespace HoneybeeSchema
{
    public partial class Model
    {
        public void AddConstructionSets(List<IBuildingConstructionset> constructionsets)
        {
            foreach (var item in constructionsets)
            {
                var exist = this.Properties.Energy.ConstructionSets.Any(_ => (_.Obj as IIDdBase).Identifier == item.Identifier);
                if (exist)
                    return;

                switch (item)
                {
                    case ConstructionSetAbridged em:
                        this.Properties.Energy.ConstructionSets.Add(em);
                        break;
                    case ConstructionSet em:
                        this.Properties.Energy.ConstructionSets.Add(em);
                        break;

                    default:
                        break;
                }
            }
            
        }

        public void AddProgramTypes(List<IProgramtype> programtypes)
        {
            foreach (var item in programtypes)
            {
                var exist = this.Properties.Energy.ProgramTypes.Any(_ => (_.Obj as IIDdBase).Identifier == item.Identifier);
                if (exist)
                    return;

                switch (item)
                {
                    case ProgramType em:
                        this.Properties.Energy.ProgramTypes.Add(em);
                        break;
                    case ProgramTypeAbridged em:
                        this.Properties.Energy.ProgramTypes.Add(em);
                        break;

                    default:
                        break;
                }
            }
            
        }

        public void AddHVACs(List<IHvac> havcs)
        {
            foreach (var item in havcs)
            {
                var exist = this.Properties.Energy.Hvacs.Any(_ => _.Identifier == item.Identifier);
                if (exist)
                    return;

                switch (item)
                {
                    case IdealAirSystemAbridged em:
                        this.Properties.Energy.Hvacs.Add(em);
                        break;

                    default:
                        break;
                }
            }
            
        }


        public void AddMaterials( List<IMaterial> materials)
        {
            foreach (var item in materials)
            {
                var exist = this.Properties.Energy.Materials.Any(_ => (_.Obj as IIDdBase).Identifier == item.Identifier);
                if (exist)
                    continue;

                switch (item)
                {
                    case EnergyMaterial em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyMaterialNoMass em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialBlind em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialGas em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialGasCustom em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialGasMixture em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialGlazing em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialShade em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyWindowMaterialSimpleGlazSys em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    default:
                        break;
                }

            }
        }

        public void AddConstructions(List<IConstruction> constructions)
        {
            foreach (var item in constructions)
            {
                var exist = this.Properties.Energy.Constructions.Any(_ => (_.Obj as IIDdBase).Identifier == item.Identifier);
                if (exist)
                    continue;

                switch (item)
                {
                    case OpaqueConstruction em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                    case OpaqueConstructionAbridged em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                    case WindowConstruction em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                    case WindowConstructionAbridged em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                    case ShadeConstruction em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                    case AirBoundaryConstruction em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                    case AirBoundaryConstructionAbridged em:
                        this.Properties.Energy.Constructions.Add(em);
                        break;
                
                    default:
                        break;
                }
                

            }
        }


    }
}
