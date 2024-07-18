using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TemplateModels
{
    public enum TargetLanguage
    {
        CSharp,
        TypeScript
    }

    internal class Helper
    {
        /// <summary>
        /// Get all related type, this is useful for Array or List with its ElementType and GenericArguments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Type> GetTypes(Type type)
        {
            var tps = new List<Type>();
            if (!type.IsGenericType) // non-List
            {
                // array
                if (type.IsArray)
                {
                    var elemType = type.GetElementType();
                    tps.Add(elemType);
                }
                else
                {
                    tps.Add(type);
                }

            }

            tps.AddRange(type.GetGenericArguments().SelectMany(_ => GetTypes(_)));
            tps = tps?.Distinct()?.ToList();
            return tps;

        }

        public static string GetCheckTypeName(Type type)
        {
            if (!type.IsGenericType) // non-List
            {
                // array
                if (type.IsArray)
                {
                    var elemType = type.GetElementType();
                    return $"{CheckTypeName(elemType.Name)}[]";
                }
                else
                {
                    return CheckTypeName(type.Name);
                }

            }

            string typeName = type.GetGenericTypeDefinition().Name;
            // Remove the generic arity from the type name
            typeName = typeName.Substring(0, typeName.IndexOf('`'));
            typeName = CheckTypeName(typeName);

            string[] typeArguments = type.GetGenericArguments()
                                          .Select(_ => GetCheckTypeName(_))
                                          .Select(_ => CheckTypeName(_))
                                          .ToArray();

            return $"{typeName}<{string.Join(", ", typeArguments)}>";
        }

        private static string CheckTypeName(string typeName)
        {
            if (TypeMapper.TryGetValue(typeName, out var t))
                return t;
            return typeName;
        }

        public static TargetLanguage Language { get; set; } = TargetLanguage.CSharp;

        private static Dictionary<string, string> TypeMapper
        {
            get
            {
                switch (Language)
                {
                    case TargetLanguage.CSharp:
                        return CsTypeMapper;
                    case TargetLanguage.TypeScript:
                        return TsTypeMapper;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static Dictionary<string, string> CsTypeMapper
            = new Dictionary<string, string> {
                { "Boolean", "bool" },
                { "Char", "char" },
                { "Decimal", "decimal" },
                { "Double", "double" },
                { "Int32", "int" },
                { "Int64", "long" },
                { "Object", "object" },
                { "String", "string" },
                { "Single", "float" },
                { "Void", "void" }
            };

        private static Dictionary<string, string> TsTypeMapper
            = new Dictionary<string, string> {
                { "Boolean", "boolean" },
                { "Char", "string" },
                { "Decimal", "number" },
                { "Double", "number" },
                { "Int32", "number" },
                { "Int64", "number" },
                { "Object", "any" },
                { "String", "string" },
                { "Single", "number" },
                { "Void", "void" },
                { "Task", "Promise" },
                { "Dictionary", "Map" },
                { "List", "Array" },
                { "DateTime", "Date" }
            };



        public static string GetMethodSummary(string assemblyPath, string typeName, string methodName)
        {
            // Load the assembly
            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            // Get the type
            Type type = assembly.GetType(typeName);

            // Get the method info
            //MethodInfo methodInfo = type.GetMethod(methodName);

            // Construct the member name to search in the XML file
            string memberName = $"M:{type.FullName}.{methodName}";

            // Load the XML documentation
            string xmlPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf(".")) + ".xml";
            XDocument xmlDoc = XDocument.Load(xmlPath);

            // Query the XML for the summary of the method
            var summary = xmlDoc.Descendants("member")
                                .FirstOrDefault(m => m.Attribute("name").Value.Equals(memberName))
                                ?.Element("summary")?.Value.Trim();

            return summary;
        }

        public static string CheckTypeScriptTypeName(string typeName)
        {
            if (TsTypeMapper.TryGetValue(typeName, out var t))
                return t;
            return typeName;
        }




    }
}
