/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
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
    /// A set of constructions for different surface types and boundary conditions.
    /// </summary>
    [Summary(@"A set of constructions for different surface types and boundary conditions.")]
    [Serializable]
    [DataContract(Name = "ConstructionSetAbridged")]
    public partial class ConstructionSetAbridged : IDdEnergyBaseModel, IEquatable<ConstructionSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConstructionSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ConstructionSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="wallSet">A WallConstructionSetAbridged object for this ConstructionSet.</param>
        /// <param name="floorSet">A FloorConstructionSetAbridged object for this ConstructionSet.</param>
        /// <param name="roofCeilingSet">A RoofCeilingConstructionSetAbridged object for this ConstructionSet.</param>
        /// <param name="apertureSet">A ApertureConstructionSetAbridged object for this ConstructionSet.</param>
        /// <param name="doorSet">A DoorConstructionSetAbridged object for this ConstructionSet.</param>
        /// <param name="shadeConstruction">The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.</param>
        /// <param name="airBoundaryConstruction">The identifier of an AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type.</param>
        public ConstructionSetAbridged
        (
            string identifier, string displayName = default, object userData = default, WallConstructionSetAbridged wallSet = default, FloorConstructionSetAbridged floorSet = default, RoofCeilingConstructionSetAbridged roofCeilingSet = default, ApertureConstructionSetAbridged apertureSet = default, DoorConstructionSetAbridged doorSet = default, string shadeConstruction = default, string airBoundaryConstruction = default
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
            this.Type = "ConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A WallConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        [Summary(@"A WallConstructionSetAbridged object for this ConstructionSet.")]
        [DataMember(Name = "wall_set")]
        public WallConstructionSetAbridged WallSet { get; set; }

        /// <summary>
        /// A FloorConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        [Summary(@"A FloorConstructionSetAbridged object for this ConstructionSet.")]
        [DataMember(Name = "floor_set")]
        public FloorConstructionSetAbridged FloorSet { get; set; }

        /// <summary>
        /// A RoofCeilingConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        [Summary(@"A RoofCeilingConstructionSetAbridged object for this ConstructionSet.")]
        [DataMember(Name = "roof_ceiling_set")]
        public RoofCeilingConstructionSetAbridged RoofCeilingSet { get; set; }

        /// <summary>
        /// A ApertureConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        [Summary(@"A ApertureConstructionSetAbridged object for this ConstructionSet.")]
        [DataMember(Name = "aperture_set")]
        public ApertureConstructionSetAbridged ApertureSet { get; set; }

        /// <summary>
        /// A DoorConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        [Summary(@"A DoorConstructionSetAbridged object for this ConstructionSet.")]
        [DataMember(Name = "door_set")]
        public DoorConstructionSetAbridged DoorSet { get; set; }

        /// <summary>
        /// The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.
        /// </summary>
        [Summary(@"The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "shade_construction")]
        public string ShadeConstruction { get; set; }

        /// <summary>
        /// The identifier of an AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type.
        /// </summary>
        [Summary(@"The identifier of an AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "air_boundary_construction")]
        public string AirBoundaryConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ConstructionSetAbridged";
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
            sb.Append("ConstructionSetAbridged:\n");
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
        /// <returns>ConstructionSetAbridged object</returns>
        public static ConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ConstructionSetAbridged object</returns>
        public virtual ConstructionSetAbridged DuplicateConstructionSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateConstructionSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ConstructionSetAbridged);
        }


        /// <summary>
        /// Returns true if ConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConstructionSetAbridged input)
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
