/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.30.2
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.
    /// </summary>
    /// <value>Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum EconomizerType
    {
        /// <summary>
        /// Enum NoEconomizer for value: NoEconomizer
        /// </summary>
        [EnumMember(Value = "NoEconomizer")]
        NoEconomizer = 1,

        /// <summary>
        /// Enum DifferentialDryBulb for value: DifferentialDryBulb
        /// </summary>
        [EnumMember(Value = "DifferentialDryBulb")]
        DifferentialDryBulb = 2,

        /// <summary>
        /// Enum DifferentialEnthalpy for value: DifferentialEnthalpy
        /// </summary>
        [EnumMember(Value = "DifferentialEnthalpy")]
        DifferentialEnthalpy = 3

    }

}