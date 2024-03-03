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
    
    public enum MountingType
    {
        /// <summary>
        /// Enum FixedOpenRack for value: FixedOpenRack
        /// </summary>
        [EnumMember(Value = "FixedOpenRack")]
        FixedOpenRack = 1,

        /// <summary>
        /// Enum FixedRoofMounted for value: FixedRoofMounted
        /// </summary>
        [EnumMember(Value = "FixedRoofMounted")]
        FixedRoofMounted = 2,

        /// <summary>
        /// Enum OneAxis for value: OneAxis
        /// </summary>
        [EnumMember(Value = "OneAxis")]
        OneAxis = 3,

        /// <summary>
        /// Enum OneAxisBacktracking for value: OneAxisBacktracking
        /// </summary>
        [EnumMember(Value = "OneAxisBacktracking")]
        OneAxisBacktracking = 4,

        /// <summary>
        /// Enum TwoAxis for value: TwoAxis
        /// </summary>
        [EnumMember(Value = "TwoAxis")]
        TwoAxis = 5

    }

}