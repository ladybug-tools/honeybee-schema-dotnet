﻿using System;
using System.IO;

// project name has to be the format of NameSpace.Handlers. 
// For example: if the name space is "HoneybeeSchema", then project name would be HoneybeeSchema.Handlers.
namespace HoneybeeSchema
{
    public static class Handlers
    {
        /// <summary>
        /// Translate Honeybee Model to HBJson and return the saved file path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string HBModelToJSON(Model model)
        {
            if (model == null) throw new ArgumentNullException("Input model: null is not valid");
            var temp = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".hbjson");
            using (var outputFile = new StreamWriter(temp))
            {
                var json = model.ToJson();
                outputFile.Write(json);
            }
            
            if (!File.Exists(temp)) throw new ArgumentException($"Failed to save the model to {temp}");
            return temp;
        }
    }
}
