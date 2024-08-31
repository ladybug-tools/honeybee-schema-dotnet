using System.Collections.Generic;
using System.Linq;

namespace SchemaGenerator;

public class Mapper
{
    public List<MapperItem> Classes { get; set; }
    public List<MapperItem> Enums { get; set; }
    public List<MapperItem> All {  get; set; }

    public Mapper(List<MapperItem> classes , List<MapperItem> enums)
    {
        Classes = classes ?? new List<MapperItem>();
        Enums = enums ?? new List<MapperItem>();
        All = Classes.Concat(Enums)?.ToList();
    }

    public void Merge(Mapper mapper)
    {
        Classes = Classes ?? new List<MapperItem>();
        Enums = Enums ?? new List<MapperItem>();

        if (mapper == null)
            return;

        if (mapper.Classes != null)
            Classes.AddRange(mapper?.Classes);
        if (mapper.Enums != null)
            Enums.AddRange(mapper?.Enums);
        All = Classes.Concat(Enums)?.ToList();
    }

    public string TryGetModule(string name)
    {
        return this.All?.FirstOrDefault(x => x.Name == name)?.Module;
    }
}
public class MapperItem
{
    public string Name { get; set; }
    public string Module { get; set; }
    public MapperItem(string name, string module)
    {
        Name = name;
        Module = module;
    }

    public override string ToString()
    {
        return $"{Name}:{Module}";
    }
}