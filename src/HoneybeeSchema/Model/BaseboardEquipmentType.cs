/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.38.0
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
    
    public enum BaseboardEquipmentType
    {
        /// <summary>
        /// Enum Electric for value: Baseboard electric
        /// </summary>
        [EnumMember(Value = "Baseboard electric")]
        Electric = 1,

        /// <summary>
        /// Enum Gasboiler for value: Baseboard gas boiler
        /// </summary>
        [EnumMember(Value = "Baseboard gas boiler")]
        Gasboiler = 2,

        /// <summary>
        /// Enum Centralairsourceheatpump for value: Baseboard central air source heat pump
        /// </summary>
        [EnumMember(Value = "Baseboard central air source heat pump")]
        Centralairsourceheatpump = 3,

        /// <summary>
        /// Enum Districthotwater for value: Baseboard district hot water
        /// </summary>
        [EnumMember(Value = "Baseboard district hot water")]
        Districthotwater = 4

    }

}
