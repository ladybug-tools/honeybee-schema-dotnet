/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

extern alias LBTNewtonSoft;
using System;
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
    
    public enum Vintages
    {
        /// <summary>
        /// Enum ASHRAE2019 for value: ASHRAE_2019
        /// </summary>
        [EnumMember(Value = "ASHRAE_2019")]
        ASHRAE_2019 = 1,

        /// <summary>
        /// Enum ASHRAE2016 for value: ASHRAE_2016
        /// </summary>
        [EnumMember(Value = "ASHRAE_2016")]
        ASHRAE_2016 = 2,

        /// <summary>
        /// Enum ASHRAE2013 for value: ASHRAE_2013
        /// </summary>
        [EnumMember(Value = "ASHRAE_2013")]
        ASHRAE_2013 = 3,

        /// <summary>
        /// Enum ASHRAE2010 for value: ASHRAE_2010
        /// </summary>
        [EnumMember(Value = "ASHRAE_2010")]
        ASHRAE_2010 = 4,

        /// <summary>
        /// Enum ASHRAE2007 for value: ASHRAE_2007
        /// </summary>
        [EnumMember(Value = "ASHRAE_2007")]
        ASHRAE_2007 = 5,

        /// <summary>
        /// Enum ASHRAE2004 for value: ASHRAE_2004
        /// </summary>
        [EnumMember(Value = "ASHRAE_2004")]
        ASHRAE_2004 = 6,

        /// <summary>
        /// Enum DOERef19802004 for value: DOE_Ref_1980_2004
        /// </summary>
        [EnumMember(Value = "DOE_Ref_1980_2004")]
        DOE_Ref_1980_2004 = 7,

        /// <summary>
        /// Enum DOERefPre1980 for value: DOE_Ref_Pre_1980
        /// </summary>
        [EnumMember(Value = "DOE_Ref_Pre_1980")]
        DOE_Ref_Pre_1980 = 8

    }

}
