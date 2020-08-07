/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.36.0
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
    
    public enum PVAVEquipmentType
    {
        /// <summary>
        /// Enum Gasboilerreheat for value: PVAV with gas boiler reheat
        /// </summary>
        [EnumMember(Value = "PVAV with gas boiler reheat")]
        Gasboilerreheat = 1,

        /// <summary>
        /// Enum Centralairsourceheatpumpreheat for value: PVAV with central air source heat pump reheat
        /// </summary>
        [EnumMember(Value = "PVAV with central air source heat pump reheat")]
        Centralairsourceheatpumpreheat = 2,

        /// <summary>
        /// Enum Districthotwaterreheat for value: PVAV with district hot water reheat
        /// </summary>
        [EnumMember(Value = "PVAV with district hot water reheat")]
        Districthotwaterreheat = 3,

        /// <summary>
        /// Enum PFPboxes for value: PVAV with PFP boxes
        /// </summary>
        [EnumMember(Value = "PVAV with PFP boxes")]
        PFPboxes = 4,

        /// <summary>
        /// Enum Gasheatwithelectricreheat for value: PVAV with gas heat with electric reheat
        /// </summary>
        [EnumMember(Value = "PVAV with gas heat with electric reheat")]
        Gasheatwithelectricreheat = 5

    }

}