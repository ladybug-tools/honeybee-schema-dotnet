
namespace HoneybeeSchema.Energy
{
    public partial interface IIDdEnergyBaseModel: IIDdBase
    {
        // string Identifier { get; set;}
        // string DisplayName { get; set; }
    } 

    public partial interface ILoad: IIDdEnergyBaseModel{}
    public partial interface IMaterial: IIDdEnergyBaseModel{}

}


namespace HoneybeeSchema
{
    public partial class IDdEnergyBaseModel: Energy.IIDdEnergyBaseModel{}
    
}