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
    /// Base class for all objects requiring a identifiers acceptable for all engines.
    /// </summary>
    [Summary(@"Base class for all objects requiring a identifiers acceptable for all engines.")]
    [System.Serializable]
    [DataContract(Name = "Room")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Room : IDdBaseModel, System.IEquatable<Room>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Room() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Room";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Room" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.</param>
        /// <param name="faces">Faces that together form the closed volume of a room.</param>
        /// <param name="properties">Extension properties for particular simulation engines (Radiance, EnergyPlus).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="indoorShades">Shades assigned to the interior side of this object (eg. partitions, tables).</param>
        /// <param name="outdoorShades">Shades assigned to the exterior side of this object (eg. trees, landscaping).</param>
        /// <param name="multiplier">An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is multiplied by the multiplier.</param>
        /// <param name="excludeFloorArea">A boolean for whether the Room floor area contributes to Models it is a part of. Note that this will not affect the floor_area property of this Room itself but it will ensure the Room floor area is excluded from any calculations when the Room is part of a Model, including EUI calculations.</param>
        /// <param name="zone">Text string for for the zone identifier to which this Room belongs. Rooms sharing the same zone identifier are considered part of the same zone in a Model. If the zone identifier has not been specified, it will be the same as the Room identifier in the destination engine. Note that this property has no character restrictions.</param>
        /// <param name="story">Text string for the story identifier to which this Room belongs. Rooms sharing the same story identifier are considered part of the same story in a Model. Note that this property has no character restrictions.</param>
        public Room
        (
            string identifier, List<Face> faces, RoomPropertiesAbridged properties, string displayName = default, object userData = default, List<Shade> indoorShades = default, List<Shade> outdoorShades = default, int multiplier = 1, bool excludeFloorArea = false, string zone = default, string story = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Faces = faces ?? throw new System.ArgumentNullException("faces is a required property for Room and cannot be null");
            this.Properties = properties ?? throw new System.ArgumentNullException("properties is a required property for Room and cannot be null");
            this.IndoorShades = indoorShades;
            this.OutdoorShades = outdoorShades;
            this.Multiplier = multiplier;
            this.ExcludeFloorArea = excludeFloorArea;
            this.Zone = zone;
            this.Story = story;

            // Set readonly properties with defaultValue
            this.Type = "Room";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Room))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Faces that together form the closed volume of a room.
        /// </summary>
        [Summary(@"Faces that together form the closed volume of a room.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "faces", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("faces", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("faces")] // For System.Text.Json
        public List<Face> Faces { get; set; }

        /// <summary>
        /// Extension properties for particular simulation engines (Radiance, EnergyPlus).
        /// </summary>
        [Summary(@"Extension properties for particular simulation engines (Radiance, EnergyPlus).")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "properties", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("properties", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("properties")] // For System.Text.Json
        public RoomPropertiesAbridged Properties { get; set; }

        /// <summary>
        /// Shades assigned to the interior side of this object (eg. partitions, tables).
        /// </summary>
        [Summary(@"Shades assigned to the interior side of this object (eg. partitions, tables).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "indoor_shades")] // For internal Serialization XML/JSON
        [JsonProperty("indoor_shades", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("indoor_shades")] // For System.Text.Json
        public List<Shade> IndoorShades { get; set; }

        /// <summary>
        /// Shades assigned to the exterior side of this object (eg. trees, landscaping).
        /// </summary>
        [Summary(@"Shades assigned to the exterior side of this object (eg. trees, landscaping).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "outdoor_shades")] // For internal Serialization XML/JSON
        [JsonProperty("outdoor_shades", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("outdoor_shades")] // For System.Text.Json
        public List<Shade> OutdoorShades { get; set; }

        /// <summary>
        /// An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is multiplied by the multiplier.
        /// </summary>
        [Summary(@"An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is multiplied by the multiplier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(1, int.MaxValue)]
        [DataMember(Name = "multiplier")] // For internal Serialization XML/JSON
        [JsonProperty("multiplier", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("multiplier")] // For System.Text.Json
        public int Multiplier { get; set; } = 1;

        /// <summary>
        /// A boolean for whether the Room floor area contributes to Models it is a part of. Note that this will not affect the floor_area property of this Room itself but it will ensure the Room floor area is excluded from any calculations when the Room is part of a Model, including EUI calculations.
        /// </summary>
        [Summary(@"A boolean for whether the Room floor area contributes to Models it is a part of. Note that this will not affect the floor_area property of this Room itself but it will ensure the Room floor area is excluded from any calculations when the Room is part of a Model, including EUI calculations.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "exclude_floor_area")] // For internal Serialization XML/JSON
        [JsonProperty("exclude_floor_area", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("exclude_floor_area")] // For System.Text.Json
        public bool ExcludeFloorArea { get; set; } = false;

        /// <summary>
        /// Text string for for the zone identifier to which this Room belongs. Rooms sharing the same zone identifier are considered part of the same zone in a Model. If the zone identifier has not been specified, it will be the same as the Room identifier in the destination engine. Note that this property has no character restrictions.
        /// </summary>
        [Summary(@"Text string for for the zone identifier to which this Room belongs. Rooms sharing the same zone identifier are considered part of the same zone in a Model. If the zone identifier has not been specified, it will be the same as the Room identifier in the destination engine. Note that this property has no character restrictions.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "zone")] // For internal Serialization XML/JSON
        [JsonProperty("zone", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("zone")] // For System.Text.Json
        public string Zone { get; set; }

        /// <summary>
        /// Text string for the story identifier to which this Room belongs. Rooms sharing the same story identifier are considered part of the same story in a Model. Note that this property has no character restrictions.
        /// </summary>
        [Summary(@"Text string for the story identifier to which this Room belongs. Rooms sharing the same story identifier are considered part of the same story in a Model. Note that this property has no character restrictions.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "story")] // For internal Serialization XML/JSON
        [JsonProperty("story", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("story")] // For System.Text.Json
        public string Story { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Room";
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
            sb.Append("Room:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Faces: ").Append(this.Faces).Append("\n");
            sb.Append("  Properties: ").Append(this.Properties).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  IndoorShades: ").Append(this.IndoorShades).Append("\n");
            sb.Append("  OutdoorShades: ").Append(this.OutdoorShades).Append("\n");
            sb.Append("  Multiplier: ").Append(this.Multiplier).Append("\n");
            sb.Append("  ExcludeFloorArea: ").Append(this.ExcludeFloorArea).Append("\n");
            sb.Append("  Zone: ").Append(this.Zone).Append("\n");
            sb.Append("  Story: ").Append(this.Story).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Room object</returns>
        public static Room FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Room>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Room object</returns>
        public virtual Room DuplicateRoom()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdBaseModel</returns>
        public override IDdBaseModel DuplicateIDdBaseModel()
        {
            return DuplicateRoom();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Room);
        }


        /// <summary>
        /// Returns true if Room instances are equal
        /// </summary>
        /// <param name="input">Instance of Room to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Room input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Faces, input.Faces) && 
                    Extension.Equals(this.Properties, input.Properties) && 
                    Extension.AllEquals(this.IndoorShades, input.IndoorShades) && 
                    Extension.AllEquals(this.OutdoorShades, input.OutdoorShades) && 
                    Extension.Equals(this.Multiplier, input.Multiplier) && 
                    Extension.Equals(this.ExcludeFloorArea, input.ExcludeFloorArea) && 
                    Extension.Equals(this.Zone, input.Zone) && 
                    Extension.Equals(this.Story, input.Story);
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
                if (this.Faces != null)
                    hashCode = hashCode * 59 + this.Faces.GetHashCode();
                if (this.Properties != null)
                    hashCode = hashCode * 59 + this.Properties.GetHashCode();
                if (this.IndoorShades != null)
                    hashCode = hashCode * 59 + this.IndoorShades.GetHashCode();
                if (this.OutdoorShades != null)
                    hashCode = hashCode * 59 + this.OutdoorShades.GetHashCode();
                if (this.Multiplier != null)
                    hashCode = hashCode * 59 + this.Multiplier.GetHashCode();
                if (this.ExcludeFloorArea != null)
                    hashCode = hashCode * 59 + this.ExcludeFloorArea.GetHashCode();
                if (this.Zone != null)
                    hashCode = hashCode * 59 + this.Zone.GetHashCode();
                if (this.Story != null)
                    hashCode = hashCode * 59 + this.Story.GetHashCode();
                return hashCode;
            }
        }


    }
}
