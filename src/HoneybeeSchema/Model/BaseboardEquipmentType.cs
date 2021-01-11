/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
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
        /// Enum ElectricBaseboard for value: ElectricBaseboard
        /// </summary>
        [EnumMember(Value = "ElectricBaseboard")]
        ElectricBaseboard = 1,

        /// <summary>
        /// Enum BoilerBaseboard for value: BoilerBaseboard
        /// </summary>
        [EnumMember(Value = "BoilerBaseboard")]
        BoilerBaseboard = 2,

        /// <summary>
        /// Enum ASHPBaseboard for value: ASHPBaseboard
        /// </summary>
        [EnumMember(Value = "ASHPBaseboard")]
        ASHPBaseboard = 3,

        /// <summary>
        /// Enum DHWBaseboard for value: DHWBaseboard
        /// </summary>
        [EnumMember(Value = "DHWBaseboard")]
        DHWBaseboard = 4

    }

}
