
namespace HoneybeeSchema
{
    public interface IHoneybeeObject
    {
        string ToString(bool detailed);
        string ToJson(bool indented = false);
        OpenAPIGenBaseModel Duplicate();
    } 

    
}

