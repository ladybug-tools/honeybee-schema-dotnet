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
    /// A set of constructions for different surface types and boundary conditions.
    /// </summary>
    [Summary(@"A set of constructions for different surface types and boundary conditions.")]
    [System.Serializable]
    [DataContract(Name = "ConstructionSet")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ConstructionSet : IDdEnergyBaseModel, System.IEquatable<ConstructionSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSet" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ConstructionSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ConstructionSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSet" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="wallSet">A WallConstructionSet object for this ConstructionSet.</param>
        /// <param name="floorSet">A FloorConstructionSet object for this ConstructionSet.</param>
        /// <param name="roofCeilingSet">A RoofCeilingConstructionSet object for this ConstructionSet.</param>
        /// <param name="apertureSet">A ApertureConstructionSet object for this ConstructionSet.</param>
        /// <param name="doorSet">A DoorConstructionSet object for this ConstructionSet.</param>
        /// <param name="shadeConstruction">A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.</param>
        /// <param name="airBoundaryConstruction">An AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type.</param>
        public ConstructionSet
        (
            string identifier, string displayName = default, object userData = default, WallConstructionSet wallSet = default, FloorConstructionSet floorSet = default, RoofCeilingConstructionSet roofCeilingSet = default, ApertureConstructionSet apertureSet = default, DoorConstructionSet doorSet = default, ShadeConstruction shadeConstruction = default, AnyOf<AirBoundaryConstruction, OpaqueConstruction> airBoundaryConstruction = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.WallSet = wallSet;
            this.FloorSet = floorSet;
            this.RoofCeilingSet = roofCeilingSet;
            this.ApertureSet = apertureSet;
            this.DoorSet = doorSet;
            this.ShadeConstruction = shadeConstruction;
            this.AirBoundaryConstruction = airBoundaryConstruction;

            // Set readonly properties with defaultValue
            this.Type = "ConstructionSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ConstructionSet))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A WallConstructionSet object for this ConstructionSet.
        /// </summary>
        [Summary(@"A WallConstructionSet object for this ConstructionSet.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "wall_set")] // For internal Serialization XML/JSON
        [JsonProperty("wall_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("wall_set")] // For System.Text.Json
        public WallConstructionSet WallSet { get; set; }

        /// <summary>
        /// A FloorConstructionSet object for this ConstructionSet.
        /// </summary>
        [Summary(@"A FloorConstructionSet object for this ConstructionSet.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "floor_set")] // For internal Serialization XML/JSON
        [JsonProperty("floor_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("floor_set")] // For System.Text.Json
        public FloorConstructionSet FloorSet { get; set; }

        /// <summary>
        /// A RoofCeilingConstructionSet object for this ConstructionSet.
        /// </summary>
        [Summary(@"A RoofCeilingConstructionSet object for this ConstructionSet.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "roof_ceiling_set")] // For internal Serialization XML/JSON
        [JsonProperty("roof_ceiling_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("roof_ceiling_set")] // For System.Text.Json
        public RoofCeilingConstructionSet RoofCeilingSet { get; set; }

        /// <summary>
        /// A ApertureConstructionSet object for this ConstructionSet.
        /// </summary>
        [Summary(@"A ApertureConstructionSet object for this ConstructionSet.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "aperture_set")] // For internal Serialization XML/JSON
        [JsonProperty("aperture_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("aperture_set")] // For System.Text.Json
        public ApertureConstructionSet ApertureSet { get; set; }

        /// <summary>
        /// A DoorConstructionSet object for this ConstructionSet.
        /// </summary>
        [Summary(@"A DoorConstructionSet object for this ConstructionSet.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "door_set")] // For internal Serialization XML/JSON
        [JsonProperty("door_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("door_set")] // For System.Text.Json
        public DoorConstructionSet DoorSet { get; set; }

        /// <summary>
        /// A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.
        /// </summary>
        [Summary(@"A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "shade_construction")] // For internal Serialization XML/JSON
        [JsonProperty("shade_construction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("shade_construction")] // For System.Text.Json
        public ShadeConstruction ShadeConstruction { get; set; }

        /// <summary>
        /// An AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type.
        /// </summary>
        [Summary(@"An AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "air_boundary_construction")] // For internal Serialization XML/JSON
        [JsonProperty("air_boundary_construction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("air_boundary_construction")] // For System.Text.Json
        public AnyOf<AirBoundaryConstruction, OpaqueConstruction> AirBoundaryConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ConstructionSet";
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
            sb.Append("ConstructionSet:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  WallSet: ").Append(this.WallSet).Append("\n");
            sb.Append("  FloorSet: ").Append(this.FloorSet).Append("\n");
            sb.Append("  RoofCeilingSet: ").Append(this.RoofCeilingSet).Append("\n");
            sb.Append("  ApertureSet: ").Append(this.ApertureSet).Append("\n");
            sb.Append("  DoorSet: ").Append(this.DoorSet).Append("\n");
            sb.Append("  ShadeConstruction: ").Append(this.ShadeConstruction).Append("\n");
            sb.Append("  AirBoundaryConstruction: ").Append(this.AirBoundaryConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ConstructionSet object</returns>
        public static ConstructionSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ConstructionSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ConstructionSet object</returns>
        public virtual ConstructionSet DuplicateConstructionSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateConstructionSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ConstructionSet);
        }


        /// <summary>
        /// Returns true if ConstructionSet instances are equal
        /// </summary>
        /// <param name="input">Instance of ConstructionSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConstructionSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.WallSet, input.WallSet) && 
                    Extension.Equals(this.FloorSet, input.FloorSet) && 
                    Extension.Equals(this.RoofCeilingSet, input.RoofCeilingSet) && 
                    Extension.Equals(this.ApertureSet, input.ApertureSet) && 
                    Extension.Equals(this.DoorSet, input.DoorSet) && 
                    Extension.Equals(this.ShadeConstruction, input.ShadeConstruction) && 
                    Extension.Equals(this.AirBoundaryConstruction, input.AirBoundaryConstruction);
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
                if (this.WallSet != null)
                    hashCode = hashCode * 59 + this.WallSet.GetHashCode();
                if (this.FloorSet != null)
                    hashCode = hashCode * 59 + this.FloorSet.GetHashCode();
                if (this.RoofCeilingSet != null)
                    hashCode = hashCode * 59 + this.RoofCeilingSet.GetHashCode();
                if (this.ApertureSet != null)
                    hashCode = hashCode * 59 + this.ApertureSet.GetHashCode();
                if (this.DoorSet != null)
                    hashCode = hashCode * 59 + this.DoorSet.GetHashCode();
                if (this.ShadeConstruction != null)
                    hashCode = hashCode * 59 + this.ShadeConstruction.GetHashCode();
                if (this.AirBoundaryConstruction != null)
                    hashCode = hashCode * 59 + this.AirBoundaryConstruction.GetHashCode();
                return hashCode;
            }
        }


    }
}
