/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.39.1
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
    /// Choices for how the shading device is controlled.
    /// </summary>
    /// <value>Choices for how the shading device is controlled.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum ControlType
    {
        /// <summary>
        /// Enum AlwaysOn for value: AlwaysOn
        /// </summary>
        [EnumMember(Value = "AlwaysOn")]
        AlwaysOn = 1,

        /// <summary>
        /// Enum OnIfHighSolarOnWindow for value: OnIfHighSolarOnWindow
        /// </summary>
        [EnumMember(Value = "OnIfHighSolarOnWindow")]
        OnIfHighSolarOnWindow = 2,

        /// <summary>
        /// Enum OnIfHighHorizontalSolar for value: OnIfHighHorizontalSolar
        /// </summary>
        [EnumMember(Value = "OnIfHighHorizontalSolar")]
        OnIfHighHorizontalSolar = 3,

        /// <summary>
        /// Enum OnIfHighOutdoorAirTemperature for value: OnIfHighOutdoorAirTemperature
        /// </summary>
        [EnumMember(Value = "OnIfHighOutdoorAirTemperature")]
        OnIfHighOutdoorAirTemperature = 4,

        /// <summary>
        /// Enum OnIfHighZoneAirTemperature for value: OnIfHighZoneAirTemperature
        /// </summary>
        [EnumMember(Value = "OnIfHighZoneAirTemperature")]
        OnIfHighZoneAirTemperature = 5,

        /// <summary>
        /// Enum OnIfHighZoneCooling for value: OnIfHighZoneCooling
        /// </summary>
        [EnumMember(Value = "OnIfHighZoneCooling")]
        OnIfHighZoneCooling = 6,

        /// <summary>
        /// Enum OnNightIfLowOutdoorTempAndOffDay for value: OnNightIfLowOutdoorTempAndOffDay
        /// </summary>
        [EnumMember(Value = "OnNightIfLowOutdoorTempAndOffDay")]
        OnNightIfLowOutdoorTempAndOffDay = 7,

        /// <summary>
        /// Enum OnNightIfLowInsideTempAndOffDay for value: OnNightIfLowInsideTempAndOffDay
        /// </summary>
        [EnumMember(Value = "OnNightIfLowInsideTempAndOffDay")]
        OnNightIfLowInsideTempAndOffDay = 8,

        /// <summary>
        /// Enum OnNightIfHeatingAndOffDay for value: OnNightIfHeatingAndOffDay
        /// </summary>
        [EnumMember(Value = "OnNightIfHeatingAndOffDay")]
        OnNightIfHeatingAndOffDay = 9

    }

}
