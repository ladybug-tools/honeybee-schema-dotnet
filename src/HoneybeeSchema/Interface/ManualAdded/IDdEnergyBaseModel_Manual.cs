
namespace HoneybeeSchema.Energy
{
    public partial interface IIDdEnergyBaseModel: IIDdBase
    {
        // string Identifier { get; set;}
        // string DisplayName { get; set; }
    } 

    public partial interface ILoad: IIDdEnergyBaseModel{}
    public partial interface IMaterial: IIDdEnergyBaseModel{}
    public partial interface IConstruction : IIDdEnergyBaseModel { }
    public partial interface IProgramtype : IIDdEnergyBaseModel {}
    public partial interface IHvac : IIDdEnergyBaseModel { }
    public partial interface IBuildingConstructionset : IIDdEnergyBaseModel { }

}


namespace HoneybeeSchema
{
    public partial class IDdEnergyBaseModel: Energy.IIDdEnergyBaseModel{}
    
}