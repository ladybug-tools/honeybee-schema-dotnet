//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace TemplateModels;

//public class MethodTemplateModel
//{
//    public bool HasReturn { get; set; }
//    public string ReturnTypeName { get; set; }
//    public string ReturnDoc {  get; set; }

//    public bool NeedReturnTypeConverter {  get; set; }
//    //public string ReturnTypeConverter { get; set; }

//    public string MethodName { get; set; }
//    public List<ParamTemplateModel> Params { get; set; }
//    public string Document {  get; set; }
//    public List<string> SchemaTypes { get; set; }

//    public MethodTemplateModel(MethodInfo methodInfo, MethodDoc document = default)
//    {
      
//        var returnParam = methodInfo.ReturnParameter;
//        ReturnTypeName = Helper.GetCheckTypeName(returnParam.ParameterType);
//        HasReturn = !string.IsNullOrEmpty(ReturnTypeName) && returnParam.ParameterType != typeof(void);
//        NeedReturnTypeConverter = ReturnTypeName.StartsWith("Map<");

//        MethodName = methodInfo.Name;
//        Params = methodInfo.GetParameters().Select(_ => new ParamTemplateModel(_, document?.Params?.GetValueOrDefault(_.Name))).ToList();

//        Document = document?.Summary;
//        ReturnDoc = document?.Returns;

//        SchemaTypes = Params?.SelectMany(_ => _.SchemaTypes)?.ToList() ?? new List<string>();

//        if (HasReturn)
//        {
//            var thisAssembly = typeof(MethodTemplateModel).Assembly;
//            var tps = Helper.GetTypes(returnParam.ParameterType).Where(_ => _.Assembly == thisAssembly).Select(t => t.Name).ToList();
//            SchemaTypes.AddRange(tps);
//        }
//        SchemaTypes = SchemaTypes?.Distinct()?.ToList();
//    }

//}
