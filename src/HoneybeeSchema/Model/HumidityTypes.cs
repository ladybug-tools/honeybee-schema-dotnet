/* 
 * Honeybee Energy Simulation Parameter Schema
 *
 * This is the documentation for Honeybee energy simulation parameter schema.
 *
 * The version of the OpenAPI document: 1.38.1
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
    /// An enumeration.
    /// </summary>
    /// <value>An enumeration.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum HumidityTypes
    {
        /// <summary>
        /// Enum Wetbulb for value: Wetbulb
        /// </summary>
        [EnumMember(Value = "Wetbulb")]
        Wetbulb = 1,

        /// <summary>
        /// Enum Dewpoint for value: Dewpoint
        /// </summary>
        [EnumMember(Value = "Dewpoint")]
        Dewpoint = 2,

        /// <summary>
        /// Enum HumidityRatio for value: HumidityRatio
        /// </summary>
        [EnumMember(Value = "HumidityRatio")]
        HumidityRatio = 3,

        /// <summary>
        /// Enum Enthalpy for value: Enthalpy
        /// </summary>
        [EnumMember(Value = "Enthalpy")]
        Enthalpy = 4

    }

}
