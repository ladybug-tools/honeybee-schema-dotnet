//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace TemplateModels;

//public class ParamTemplateModel
//{
//    public string TypeName { get; set; }
//    public string Name { get; set; }
//    public bool HasDefaultValue { get; set; }
//    public object DefaultValue { get; set; }

//    public string Document {  get; set; }

//    public List<string> SchemaTypes { get; set; }

//    public ParamTemplateModel(ParameterInfo parameterInfo, string document)
//    {
//        TypeName = Helper.GetCheckTypeName(parameterInfo.ParameterType);
//        Name = parameterInfo.Name;
//        HasDefaultValue = parameterInfo.HasDefaultValue;
//        if (HasDefaultValue)
//            DefaultValue = CheckDefaultValue(parameterInfo.DefaultValue);


//        // check TypeName for null case
//        if (Helper.Language == TargetLanguage.TypeScript)
//        {
//            if (DefaultValue == "null" && TypeName != "object") 
//                TypeName = $"{TypeName} | null";
//        }

//        Document = document;

//        var thisAssembly = typeof(ParamTemplateModel).Assembly;
//        SchemaTypes = 
//            Helper.GetTypes(parameterInfo.ParameterType)
//            .Where(_=>_.Assembly == thisAssembly)
//            .Select(t => t.Name)?
//            .Distinct()?
//            .ToList() ?? new List<string>();
//    }


//    private static object CheckDefaultValue(object dValue)
//    {
//        if (dValue == null)
//        {
//            return "null";
//        }

//        if (dValue is string ss)
//        {
//            dValue = $"\"{ss}\"";
//        }

//        return dValue;
//    }


//}
