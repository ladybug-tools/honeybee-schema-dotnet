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
    
    public enum FCUwithDOASEquipmentType
    {
        /// <summary>
        /// Enum ChillerBoiler for value: DOAS_FCU_Chiller_Boiler
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_Chiller_Boiler")]
        DOAS_FCU_Chiller_Boiler = 1,

        /// <summary>
        /// Enum ChillerASHP for value: DOAS_FCU_Chiller_ASHP
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_Chiller_ASHP")]
        DOAS_FCU_Chiller_ASHP = 2,

        /// <summary>
        /// Enum ChillerDHW for value: DOAS_FCU_Chiller_DHW
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_Chiller_DHW")]
        DOAS_FCU_Chiller_DHW = 3,

        /// <summary>
        /// Enum ChillerElectricBaseboard for value: DOAS_FCU_Chiller_ElectricBaseboard
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_Chiller_ElectricBaseboard")]
        DOAS_FCU_Chiller_ElectricBaseboard = 4,

        /// <summary>
        /// Enum ChillerGasHeaters for value: DOAS_FCU_Chiller_GasHeaters
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_Chiller_GasHeaters")]
        DOAS_FCU_Chiller_GasHeaters = 5,

        /// <summary>
        /// Enum Chiller for value: DOAS_FCU_Chiller
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_Chiller")]
        DOAS_FCU_Chiller = 6,

        /// <summary>
        /// Enum ACChillerBoiler for value: DOAS_FCU_ACChiller_Boiler
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_ACChiller_Boiler")]
        DOAS_FCU_ACChiller_Boiler = 7,

        /// <summary>
        /// Enum ACChillerASHP for value: DOAS_FCU_ACChiller_ASHP
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_ACChiller_ASHP")]
        DOAS_FCU_ACChiller_ASHP = 8,

        /// <summary>
        /// Enum ACChillerDHW for value: DOAS_FCU_ACChiller_DHW
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_ACChiller_DHW")]
        DOAS_FCU_ACChiller_DHW = 9,

        /// <summary>
        /// Enum ACChillerElectricBaseboard for value: DOAS_FCU_ACChiller_ElectricBaseboard
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_ACChiller_ElectricBaseboard")]
        DOAS_FCU_ACChiller_ElectricBaseboard = 10,

        /// <summary>
        /// Enum ACChillerGasHeaters for value: DOAS_FCU_ACChiller_GasHeaters
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_ACChiller_GasHeaters")]
        DOAS_FCU_ACChiller_GasHeaters = 11,

        /// <summary>
        /// Enum ACChiller for value: DOAS_FCU_ACChiller
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_ACChiller")]
        DOAS_FCU_ACChiller = 12,

        /// <summary>
        /// Enum DCWBoiler for value: DOAS_FCU_DCW_Boiler
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_DCW_Boiler")]
        DOAS_FCU_DCW_Boiler = 13,

        /// <summary>
        /// Enum DCWASHP for value: DOAS_FCU_DCW_ASHP
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_DCW_ASHP")]
        DOAS_FCU_DCW_ASHP = 14,

        /// <summary>
        /// Enum DCWDHW for value: DOAS_FCU_DCW_DHW
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_DCW_DHW")]
        DOAS_FCU_DCW_DHW = 15,

        /// <summary>
        /// Enum DCWElectricBaseboard for value: DOAS_FCU_DCW_ElectricBaseboard
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_DCW_ElectricBaseboard")]
        DOAS_FCU_DCW_ElectricBaseboard = 16,

        /// <summary>
        /// Enum DCWGasHeaters for value: DOAS_FCU_DCW_GasHeaters
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_DCW_GasHeaters")]
        DOAS_FCU_DCW_GasHeaters = 17,

        /// <summary>
        /// Enum DCW for value: DOAS_FCU_DCW
        /// </summary>
        [EnumMember(Value = "DOAS_FCU_DCW")]
        DOAS_FCU_DCW = 18

    }

}
