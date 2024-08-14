/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
//using System;
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
    /// Used to specify heating and cooling sizing criteria and safety factors.
    /// </summary>
    [Summary(@"Used to specify heating and cooling sizing criteria and safety factors.")]
    [System.Serializable]
    [DataContract(Name = "SizingParameter")]
    public partial class SizingParameter : OpenAPIGenBaseModel, System.IEquatable<SizingParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SizingParameter" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SizingParameter() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SizingParameter";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SizingParameter" /> class.
        /// </summary>
        /// <param name="designDays">A list of DesignDays that represent the criteria for which the HVAC systems will be sized.</param>
        /// <param name="heatingFactor">A number that will be multiplied by the peak heating load for each zone in order to size the heating system.</param>
        /// <param name="coolingFactor">A number that will be multiplied by the peak cooling load for each zone in order to size the heating system.</param>
        /// <param name="efficiencyStandard">Text to specify the efficiency standard, which will automatically set the efficiencies of all HVAC equipment when provided. Note that providing a standard here will cause the OpenStudio translation process to perform an additional sizing calculation with EnergyPlus, which is needed since the default efficiencies of equipment vary depending on their size. THIS WILL SIGNIFICANTLY INCREASE TRANSLATION TIME TO OPENSTUDIO. However, it is often worthwhile when the goal is to match the HVAC specification with a particular standard.</param>
        /// <param name="climateZone">Text indicating the ASHRAE climate zone to be used with the efficiency_standard. When unspecified, the climate zone will be inferred from the design days on this sizing parameter object.</param>
        /// <param name="buildingType">Text for the building type to be used in the efficiency_standard. If the type is not recognized or is None, it will be assumed that the building is a generic NonResidential. The following have specified systems per the standard:  Residential, NonResidential, MidriseApartment, HighriseApartment, LargeOffice, MediumOffice, SmallOffice, Retail, StripMall, PrimarySchool, SecondarySchool, SmallHotel, LargeHotel, Hospital, Outpatient, Warehouse, SuperMarket, FullServiceRestaurant, QuickServiceRestaurant, Laboratory, Courthouse.</param>
        /// <param name="bypassEfficiencySizing">A boolean to indicate whether the efficiency standard should trigger an sizing run that sets the efficiencies of all HVAC equipment in the Model (False) or the standard should only be written into the OSM and the sizing run should be bypassed (True). Bypassing the sizing run is useful when you only want to check that the overall HVAC system architecture is correct and you do not want to wait the extra time that it takes to run the sizing calculation.</param>
        public SizingParameter
        (
            List<DesignDay> designDays = default, double heatingFactor = 1.25D, double coolingFactor = 1.15D, EfficiencyStandards efficiencyStandard = default, ClimateZones climateZone = default, string buildingType = default, bool bypassEfficiencySizing = false
        ) : base()
        {
            this.DesignDays = designDays;
            this.HeatingFactor = heatingFactor;
            this.CoolingFactor = coolingFactor;
            this.EfficiencyStandard = efficiencyStandard;
            this.ClimateZone = climateZone;
            this.BuildingType = buildingType;
            this.BypassEfficiencySizing = bypassEfficiencySizing;

            // Set readonly properties with defaultValue
            this.Type = "SizingParameter";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SizingParameter))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of DesignDays that represent the criteria for which the HVAC systems will be sized.
        /// </summary>
        [Summary(@"A list of DesignDays that represent the criteria for which the HVAC systems will be sized.")]
        [DataMember(Name = "design_days")]
        public List<DesignDay> DesignDays { get; set; }

        /// <summary>
        /// A number that will be multiplied by the peak heating load for each zone in order to size the heating system.
        /// </summary>
        [Summary(@"A number that will be multiplied by the peak heating load for each zone in order to size the heating system.")]
        [DataMember(Name = "heating_factor")]
        public double HeatingFactor { get; set; } = 1.25D;

        /// <summary>
        /// A number that will be multiplied by the peak cooling load for each zone in order to size the heating system.
        /// </summary>
        [Summary(@"A number that will be multiplied by the peak cooling load for each zone in order to size the heating system.")]
        [DataMember(Name = "cooling_factor")]
        public double CoolingFactor { get; set; } = 1.15D;

        /// <summary>
        /// Text to specify the efficiency standard, which will automatically set the efficiencies of all HVAC equipment when provided. Note that providing a standard here will cause the OpenStudio translation process to perform an additional sizing calculation with EnergyPlus, which is needed since the default efficiencies of equipment vary depending on their size. THIS WILL SIGNIFICANTLY INCREASE TRANSLATION TIME TO OPENSTUDIO. However, it is often worthwhile when the goal is to match the HVAC specification with a particular standard.
        /// </summary>
        [Summary(@"Text to specify the efficiency standard, which will automatically set the efficiencies of all HVAC equipment when provided. Note that providing a standard here will cause the OpenStudio translation process to perform an additional sizing calculation with EnergyPlus, which is needed since the default efficiencies of equipment vary depending on their size. THIS WILL SIGNIFICANTLY INCREASE TRANSLATION TIME TO OPENSTUDIO. However, it is often worthwhile when the goal is to match the HVAC specification with a particular standard.")]
        [DataMember(Name = "efficiency_standard")]
        public EfficiencyStandards EfficiencyStandard { get; set; }

        /// <summary>
        /// Text indicating the ASHRAE climate zone to be used with the efficiency_standard. When unspecified, the climate zone will be inferred from the design days on this sizing parameter object.
        /// </summary>
        [Summary(@"Text indicating the ASHRAE climate zone to be used with the efficiency_standard. When unspecified, the climate zone will be inferred from the design days on this sizing parameter object.")]
        [DataMember(Name = "climate_zone")]
        public ClimateZones ClimateZone { get; set; }

        /// <summary>
        /// Text for the building type to be used in the efficiency_standard. If the type is not recognized or is None, it will be assumed that the building is a generic NonResidential. The following have specified systems per the standard:  Residential, NonResidential, MidriseApartment, HighriseApartment, LargeOffice, MediumOffice, SmallOffice, Retail, StripMall, PrimarySchool, SecondarySchool, SmallHotel, LargeHotel, Hospital, Outpatient, Warehouse, SuperMarket, FullServiceRestaurant, QuickServiceRestaurant, Laboratory, Courthouse.
        /// </summary>
        [Summary(@"Text for the building type to be used in the efficiency_standard. If the type is not recognized or is None, it will be assumed that the building is a generic NonResidential. The following have specified systems per the standard:  Residential, NonResidential, MidriseApartment, HighriseApartment, LargeOffice, MediumOffice, SmallOffice, Retail, StripMall, PrimarySchool, SecondarySchool, SmallHotel, LargeHotel, Hospital, Outpatient, Warehouse, SuperMarket, FullServiceRestaurant, QuickServiceRestaurant, Laboratory, Courthouse.")]
        [DataMember(Name = "building_type")]
        public string BuildingType { get; set; }

        /// <summary>
        /// A boolean to indicate whether the efficiency standard should trigger an sizing run that sets the efficiencies of all HVAC equipment in the Model (False) or the standard should only be written into the OSM and the sizing run should be bypassed (True). Bypassing the sizing run is useful when you only want to check that the overall HVAC system architecture is correct and you do not want to wait the extra time that it takes to run the sizing calculation.
        /// </summary>
        [Summary(@"A boolean to indicate whether the efficiency standard should trigger an sizing run that sets the efficiencies of all HVAC equipment in the Model (False) or the standard should only be written into the OSM and the sizing run should be bypassed (True). Bypassing the sizing run is useful when you only want to check that the overall HVAC system architecture is correct and you do not want to wait the extra time that it takes to run the sizing calculation.")]
        [DataMember(Name = "bypass_efficiency_sizing")]
        public bool BypassEfficiencySizing { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SizingParameter";
        }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString(bool detailed)
        {
            if (!detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("SizingParameter:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DesignDays: ").Append(this.DesignDays).Append("\n");
            sb.Append("  HeatingFactor: ").Append(this.HeatingFactor).Append("\n");
            sb.Append("  CoolingFactor: ").Append(this.CoolingFactor).Append("\n");
            sb.Append("  EfficiencyStandard: ").Append(this.EfficiencyStandard).Append("\n");
            sb.Append("  ClimateZone: ").Append(this.ClimateZone).Append("\n");
            sb.Append("  BuildingType: ").Append(this.BuildingType).Append("\n");
            sb.Append("  BypassEfficiencySizing: ").Append(this.BypassEfficiencySizing).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SizingParameter object</returns>
        public static SizingParameter FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SizingParameter>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SizingParameter object</returns>
        public virtual SizingParameter DuplicateSizingParameter()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSizingParameter();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SizingParameter);
        }


        /// <summary>
        /// Returns true if SizingParameter instances are equal
        /// </summary>
        /// <param name="input">Instance of SizingParameter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SizingParameter input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.DesignDays, input.DesignDays) && 
                    Extension.Equals(this.HeatingFactor, input.HeatingFactor) && 
                    Extension.Equals(this.CoolingFactor, input.CoolingFactor) && 
                    Extension.Equals(this.EfficiencyStandard, input.EfficiencyStandard) && 
                    Extension.Equals(this.ClimateZone, input.ClimateZone) && 
                    Extension.Equals(this.BuildingType, input.BuildingType) && 
                    Extension.Equals(this.BypassEfficiencySizing, input.BypassEfficiencySizing);
        }


        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.DesignDays != null)
                    hashCode = hashCode * 59 + this.DesignDays.GetHashCode();
                if (this.HeatingFactor != null)
                    hashCode = hashCode * 59 + this.HeatingFactor.GetHashCode();
                if (this.CoolingFactor != null)
                    hashCode = hashCode * 59 + this.CoolingFactor.GetHashCode();
                if (this.EfficiencyStandard != null)
                    hashCode = hashCode * 59 + this.EfficiencyStandard.GetHashCode();
                if (this.ClimateZone != null)
                    hashCode = hashCode * 59 + this.ClimateZone.GetHashCode();
                if (this.BuildingType != null)
                    hashCode = hashCode * 59 + this.BuildingType.GetHashCode();
                if (this.BypassEfficiencySizing != null)
                    hashCode = hashCode * 59 + this.BypassEfficiencySizing.GetHashCode();
                return hashCode;
            }
        }


    }
}
