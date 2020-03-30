using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    public partial class Model
    {
        public void AddEnergyMaterial(List<IEnergyMaterial> materials)
        {
            foreach (var material in materials)
            {
                var exist = this.Properties.Energy.Materials.Any(_ => _ == material);
                if (exist)
                    continue;

                switch (material)
                {
                    case EnergyMaterial em:
                        this.Properties.Energy.Materials.Add(em);
                        break;
                    case EnergyMaterialNoMass em:
                        this.Properties.Energy.Materials.Add(em);
                        break;

                    default:
                        break;
                }

            }
        }

        public void AddEnergyWindowMaterial( List<IEnergyWindowMaterial> materials)
        {
            foreach (var material in materials)
            {
                var exist = this.Properties.Energy.Materials.Any(_ => _ == material);
                if (exist)
                    continue;

                switch (material)
                {

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

        public void AddConstructions( List<OpaqueConstructionAbridged> constructions)
        {
            foreach (var item in constructions)
            {
                var exist = this.Properties.Energy.Constructions.Any(_ => _ == item);
                if (exist)
                    continue;

                this.Properties.Energy.Constructions.Add(item);

            }
        }
        public void AddConstructions( List<WindowConstructionAbridged> constructions)
        {
            foreach (var item in constructions)
            {
                var exist = this.Properties.Energy.Constructions.Any(_ => _ == item);
                if (exist)
                    continue;

                this.Properties.Energy.Constructions.Add(item);

            }
        }

        public void AddConstructions( List<ShadeConstruction> constructions)
        {
            foreach (var item in constructions)
            {
                var exist = this.Properties.Energy.Constructions.Any(_ => _ == item);
                if (exist)
                    continue;

                this.Properties.Energy.Constructions.Add(item);

            }
        }
        public void AddConstructions( List<AirBoundaryConstructionAbridged> constructions)
        {
            foreach (var item in constructions)
            {
                var exist = this.Properties.Energy.Constructions.Any(_ => _ == item);
                if (exist)
                    continue;

                this.Properties.Energy.Constructions.Add(item);

            }
        }

    }
}
