
namespace HoneybeeSchema
{
    public interface IHoneybeeObject
    {
        string ToString(bool detailed);
        string ToJson();
        HoneybeeObject Duplicate();
    } 

    
}

