/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

extern alias LBTNewtonSoft; using System;
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
    
    public enum RadiantFaceTypes
    {
        /// <summary>
        /// Enum Floor for value: Floor
        /// </summary>
        [EnumMember(Value = "Floor")]
        Floor = 1,

        /// <summary>
        /// Enum Ceiling for value: Ceiling
        /// </summary>
        [EnumMember(Value = "Ceiling")]
        Ceiling = 2,

        /// <summary>
        /// Enum FloorWithCarpet for value: FloorWithCarpet
        /// </summary>
        [EnumMember(Value = "FloorWithCarpet")]
        FloorWithCarpet = 3,

        /// <summary>
        /// Enum CeilingMetalPanel for value: CeilingMetalPanel
        /// </summary>
        [EnumMember(Value = "CeilingMetalPanel")]
        CeilingMetalPanel = 4,

        /// <summary>
        /// Enum FloorWithHardwood for value: FloorWithHardwood
        /// </summary>
        [EnumMember(Value = "FloorWithHardwood")]
        FloorWithHardwood = 5

    }

}
