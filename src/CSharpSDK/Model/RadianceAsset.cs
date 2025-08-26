/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    /// <summary>
    /// Hidden base class for all Radiance Assets.
    /// </summary>
    [Summary(@"Hidden base class for all Radiance Assets.")]
    [System.Serializable]
    [DataContract(Name = "_RadianceAsset")]
    public partial class RadianceAsset : IDdRadianceBaseModel, System.IEquatable<RadianceAsset>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceAsset" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected RadianceAsset() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_RadianceAsset";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceAsset" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="roomIdentifier">Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.</param>
        /// <param name="lightPath">Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.</param>
        public RadianceAsset
        (
            string identifier, string displayName = default, string roomIdentifier = default, List<List<string>> lightPath = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.RoomIdentifier = roomIdentifier;
            this.LightPath = lightPath;

            // Set readonly properties with defaultValue
            this.Type = "_RadianceAsset";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RadianceAsset))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.
        /// </summary>
        [Summary(@"Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.")]
        [RegularExpression(@"^[.A-Za-z0-9_-]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "room_identifier")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("room_identifier")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string RoomIdentifier { get; set; }

        /// <summary>
        /// Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.
        /// </summary>
        [Summary(@"Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.")]
        [DataMember(Name = "light_path")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("light_path")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public List<List<string>> LightPath { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RadianceAsset";
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
            sb.Append("RadianceAsset:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  RoomIdentifier: ").Append(this.RoomIdentifier).Append("\n");
            sb.Append("  LightPath: ").Append(this.LightPath).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RadianceAsset object</returns>
        public static RadianceAsset FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RadianceAsset>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadianceAsset object</returns>
        public virtual RadianceAsset DuplicateRadianceAsset()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdRadianceBaseModel</returns>
        public override IDdRadianceBaseModel DuplicateIDdRadianceBaseModel()
        {
            return DuplicateRadianceAsset();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RadianceAsset);
        }


        /// <summary>
        /// Returns true if RadianceAsset instances are equal
        /// </summary>
        /// <param name="input">Instance of RadianceAsset to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RadianceAsset input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.RoomIdentifier, input.RoomIdentifier) && 
                    Extension.AllEquals(this.LightPath, input.LightPath);
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
                if (this.RoomIdentifier != null)
                    hashCode = hashCode * 59 + this.RoomIdentifier.GetHashCode();
                if (this.LightPath != null)
                    hashCode = hashCode * 59 + this.LightPath.GetHashCode();
                return hashCode;
            }
        }


    }
}
