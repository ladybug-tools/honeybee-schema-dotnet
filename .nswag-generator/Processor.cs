using System;
using System.Text.RegularExpressions;

namespace SchemaGenerator
{
    internal static class Processor
    {
        public static string ProcessCSharp(string code)
        {

            // add extern alias LBTNewtonsoft;
            string pattern = @"(?m)^(namespace\s)";
            string replacement = @"extern alias LBTNewtonsoft;"+Environment.NewLine+ "$1";
            code = Regex.Replace(code, pattern, replacement);

            // add  using LBTNewtonsoft = LBTNewtonsoft.Newtonsoft;
            pattern = @"(using System = global::System;)(?m)";
            replacement = @"$1" + Environment.NewLine + "    using LBTNewtonsoft = LBTNewtonsoft.Newtonsoft;";
            code = Regex.Replace(code, pattern, replacement);

            // replace  Newtonsoft.Json. with LBTNewtonsoft.Json.;
            pattern = @"Newtonsoft.Json.";
            replacement = @"LBTNewtonsoft.Json.";
            code = Regex.Replace(code, pattern, replacement);


            // add override to public string ObjType { get; set; }
            pattern = @"public string ObjType { get; set; }";
            replacement = @"public override string ObjType { get; set; }";
            code = Regex.Replace(code, pattern, replacement);
            return code;
        }

        public static string ProcessTypeScript(string code)
        {

            // Regex pattern to match classes that extend BaseObject and have the objType declaration.
            //string pattern = @"(export class (\w+) extends [\s\S]*{[\s\S]*) (readonly type)\?: (string);";
            string pattern = @"(export class (\w+) extends [\w\s]*{[^}]*)(readonly type)\?: (string);";
            code = Regex.Replace(code, pattern, match =>
            {
                string className = match.Groups[2].Value; // This captures the class name.
                return $"{match.Groups[1].Value}{match.Groups[3].Value}: {match.Groups[4].Value} = \"{className}\";";
            });

            
            return code;
        }
    }
}
