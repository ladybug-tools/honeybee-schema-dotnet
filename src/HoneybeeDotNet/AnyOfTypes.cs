
namespace HoneybeeDotNet.Model
{
    public class AnyOfBoundaryCondition
    {
        private object _instance { get; set; }


        public AnyOfBoundaryCondition() => this._instance = new Outdoors();

        public AnyOfBoundaryCondition(Outdoors Outdoors) => this._instance = Outdoors;
  
        public AnyOfBoundaryCondition(Surface Surface) => this._instance = Surface;

        public string ToJson()
        {
            switch (this._instance)
            {
                case Outdoors o:
                    return o.ToJson();
                case Surface s:
                    return s.ToJson();
                case Ground g:
                    return g.ToJson();
                case Adiabatic a:
                    return a.ToJson();
                default:
                    return new Outdoors().ToJson();
            }
        }
    }

    public class AnyOfOutdoorsSurface: AnyOfBoundaryCondition
    {
    }


    public class AnyOfGroundOutdoorsAdiabaticSurface : AnyOfBoundaryCondition
    {
    }



    public class AnyOfnumberstring 
    {
    }

    public class AnyOfstringnumber 
    {
    }



    public class AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedShadeConstruction
    {
    }

    public class AnyOfEnergyMaterialEnergyMaterialNoMassEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixtureEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialBlindEnergyWindowMaterialGlazingEnergyWindowMaterialShade
    {
    }
    public class AnyOfScheduleRulesetAbridgedScheduleFixedIntervalAbridged
    {
    }


}