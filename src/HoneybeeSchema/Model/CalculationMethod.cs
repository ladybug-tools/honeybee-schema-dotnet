/* 
 * Honeybee Simulation Parameter Schema
 *
 * Documentation for Honeybee simulation-parameter schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

extern alias LBTNewtonSoft;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBTNewtonSoft::Newtonsoft.Json;
using LBTNewtonSoft::Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    /// <value>An enumeration.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum CalculationMethod
    {
        /// <summary>
        /// Enum PolygonClipping for value: PolygonClipping
        /// </summary>
        [EnumMember(Value = "PolygonClipping")]
        PolygonClipping = 1,

        /// <summary>
        /// Enum PixelCounting for value: PixelCounting
        /// </summary>
        [EnumMember(Value = "PixelCounting")]
        PixelCounting = 2

    }

}
