
namespace HoneybeeSchema.Energy
{
    public partial interface IIDdBaseModel
    {
        string Identifier { get; set;}
        string DisplayName { get; set; }
        object UserData { get; set; }
    } 

    
}

namespace HoneybeeSchema
{
    public partial class IDdBaseModel: Energy.IIDdBaseModel{}
}