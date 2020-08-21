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
    
    public enum SolarDistribution
    {
        /// <summary>
        /// Enum MinimalShadowing for value: MinimalShadowing
        /// </summary>
        [EnumMember(Value = "MinimalShadowing")]
        MinimalShadowing = 1,

        /// <summary>
        /// Enum FullExterior for value: FullExterior
        /// </summary>
        [EnumMember(Value = "FullExterior")]
        FullExterior = 2,

        /// <summary>
        /// Enum FullInteriorAndExterior for value: FullInteriorAndExterior
        /// </summary>
        [EnumMember(Value = "FullInteriorAndExterior")]
        FullInteriorAndExterior = 3,

        /// <summary>
        /// Enum FullExteriorWithReflections for value: FullExteriorWithReflections
        /// </summary>
        [EnumMember(Value = "FullExteriorWithReflections")]
        FullExteriorWithReflections = 4,

        /// <summary>
        /// Enum FullInteriorAndExteriorWithReflections for value: FullInteriorAndExteriorWithReflections
        /// </summary>
        [EnumMember(Value = "FullInteriorAndExteriorWithReflections")]
        FullInteriorAndExteriorWithReflections = 5

    }

}
