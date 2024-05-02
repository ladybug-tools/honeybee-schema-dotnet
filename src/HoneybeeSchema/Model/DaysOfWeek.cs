/* 
 * Honeybee Simulation Parameter Schema
 *
 * Documentation for Honeybee simulation-parameter schema
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
    
    public enum DaysOfWeek
    {
        /// <summary>
        /// Enum Sunday for value: Sunday
        /// </summary>
        [EnumMember(Value = "Sunday")]
        Sunday = 1,

        /// <summary>
        /// Enum Monday for value: Monday
        /// </summary>
        [EnumMember(Value = "Monday")]
        Monday = 2,

        /// <summary>
        /// Enum Tuesday for value: Tuesday
        /// </summary>
        [EnumMember(Value = "Tuesday")]
        Tuesday = 3,

        /// <summary>
        /// Enum Wednesday for value: Wednesday
        /// </summary>
        [EnumMember(Value = "Wednesday")]
        Wednesday = 4,

        /// <summary>
        /// Enum Thursday for value: Thursday
        /// </summary>
        [EnumMember(Value = "Thursday")]
        Thursday = 5,

        /// <summary>
        /// Enum Friday for value: Friday
        /// </summary>
        [EnumMember(Value = "Friday")]
        Friday = 6,

        /// <summary>
        /// Enum Saturday for value: Saturday
        /// </summary>
        [EnumMember(Value = "Saturday")]
        Saturday = 7

    }

}
