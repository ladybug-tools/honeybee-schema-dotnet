
namespace HoneybeeSchema
{
    public partial interface IIDdBase: IHoneybeeObject
    {
        string Identifier { get; set;}
        string DisplayName { get; set; }
    } 

}
