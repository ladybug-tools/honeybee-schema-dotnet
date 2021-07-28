/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
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
    /// A set of constructions for different surface types and boundary conditions.
    /// </summary>
    [Serializable]
    [DataContract(Name = "ConstructionSetAbridged")]
    public partial class ConstructionSetAbridged : IDdEnergyBaseModel, IEquatable<ConstructionSetAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConstructionSetAbridged() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ConstructionSetAbridged";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="wallSet">A WallConstructionSetAbridged object for this ConstructionSet..</param>
        /// <param name="floorSet">A FloorConstructionSetAbridged object for this ConstructionSet..</param>
        /// <param name="roofCeilingSet">A RoofCeilingConstructionSetAbridged object for this ConstructionSet..</param>
        /// <param name="apertureSet">A ApertureConstructionSetAbridged object for this ConstructionSet..</param>
        /// <param name="doorSet">A DoorConstructionSetAbridged object for this ConstructionSet..</param>
        /// <param name="shadeConstruction">The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned..</param>
        /// <param name="airBoundaryConstruction">The identifier of an AirBoundaryConstruction to set the properties of Faces with an AirBoundary type..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public ConstructionSetAbridged
        (
            string identifier, // Required parameters
            string displayName= default, WallConstructionSetAbridged wallSet= default, FloorConstructionSetAbridged floorSet= default, RoofCeilingConstructionSetAbridged roofCeilingSet= default, ApertureConstructionSetAbridged apertureSet= default, DoorConstructionSetAbridged doorSet= default, string shadeConstruction= default, string airBoundaryConstruction= default// Optional parameters
        ) : base(identifier: identifier, displayName: displayName)// BaseClass
        {
            this.WallSet = wallSet;
            this.FloorSet = floorSet;
            this.RoofCeilingSet = roofCeilingSet;
            this.ApertureSet = apertureSet;
            this.DoorSet = doorSet;
            this.ShadeConstruction = shadeConstruction;
            this.AirBoundaryConstruction = airBoundaryConstruction;

            // Set non-required readonly properties with defaultValue
            this.Type = "ConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ConstructionSetAbridged";

        /// <summary>
        /// A WallConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        /// <value>A WallConstructionSetAbridged object for this ConstructionSet.</value>
        [DataMember(Name = "wall_set")]
        public WallConstructionSetAbridged WallSet { get; set; } 
        /// <summary>
        /// A FloorConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        /// <value>A FloorConstructionSetAbridged object for this ConstructionSet.</value>
        [DataMember(Name = "floor_set")]
        public FloorConstructionSetAbridged FloorSet { get; set; } 
        /// <summary>
        /// A RoofCeilingConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        /// <value>A RoofCeilingConstructionSetAbridged object for this ConstructionSet.</value>
        [DataMember(Name = "roof_ceiling_set")]
        public RoofCeilingConstructionSetAbridged RoofCeilingSet { get; set; } 
        /// <summary>
        /// A ApertureConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        /// <value>A ApertureConstructionSetAbridged object for this ConstructionSet.</value>
        [DataMember(Name = "aperture_set")]
        public ApertureConstructionSetAbridged ApertureSet { get; set; } 
        /// <summary>
        /// A DoorConstructionSetAbridged object for this ConstructionSet.
        /// </summary>
        /// <value>A DoorConstructionSetAbridged object for this ConstructionSet.</value>
        [DataMember(Name = "door_set")]
        public DoorConstructionSetAbridged DoorSet { get; set; } 
        /// <summary>
        /// The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.
        /// </summary>
        /// <value>The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned.</value>
        [DataMember(Name = "shade_construction")]
        public string ShadeConstruction { get; set; } 
        /// <summary>
        /// The identifier of an AirBoundaryConstruction to set the properties of Faces with an AirBoundary type.
        /// </summary>
        /// <value>The identifier of an AirBoundaryConstruction to set the properties of Faces with an AirBoundary type.</value>
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
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  WallSet: ").Append(WallSet).Append("\n");
            sb.Append("  FloorSet: ").Append(FloorSet).Append("\n");
            sb.Append("  RoofCeilingSet: ").Append(RoofCeilingSet).Append("\n");
            sb.Append("  ApertureSet: ").Append(ApertureSet).Append("\n");
            sb.Append("  DoorSet: ").Append(DoorSet).Append("\n");
            sb.Append("  ShadeConstruction: ").Append(ShadeConstruction).Append("\n");
            sb.Append("  AirBoundaryConstruction: ").Append(AirBoundaryConstruction).Append("\n");
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
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateConstructionSetAbridged();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
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
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.WallSet == input.WallSet ||
                    (this.WallSet != null &&
                    this.WallSet.Equals(input.WallSet))
                ) && base.Equals(input) && 
                (
                    this.FloorSet == input.FloorSet ||
                    (this.FloorSet != null &&
                    this.FloorSet.Equals(input.FloorSet))
                ) && base.Equals(input) && 
                (
                    this.RoofCeilingSet == input.RoofCeilingSet ||
                    (this.RoofCeilingSet != null &&
                    this.RoofCeilingSet.Equals(input.RoofCeilingSet))
                ) && base.Equals(input) && 
                (
                    this.ApertureSet == input.ApertureSet ||
                    (this.ApertureSet != null &&
                    this.ApertureSet.Equals(input.ApertureSet))
                ) && base.Equals(input) && 
                (
                    this.DoorSet == input.DoorSet ||
                    (this.DoorSet != null &&
                    this.DoorSet.Equals(input.DoorSet))
                ) && base.Equals(input) && 
                (
                    this.ShadeConstruction == input.ShadeConstruction ||
                    (this.ShadeConstruction != null &&
                    this.ShadeConstruction.Equals(input.ShadeConstruction))
                ) && base.Equals(input) && 
                (
                    this.AirBoundaryConstruction == input.AirBoundaryConstruction ||
                    (this.AirBoundaryConstruction != null &&
                    this.AirBoundaryConstruction.Equals(input.AirBoundaryConstruction))
                );
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ConstructionSetAbridged$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // ShadeConstruction (string) maxLength
            if(this.ShadeConstruction != null && this.ShadeConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ShadeConstruction, length must be less than 100.", new [] { "ShadeConstruction" });
            }

            // ShadeConstruction (string) minLength
            if(this.ShadeConstruction != null && this.ShadeConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ShadeConstruction, length must be greater than 1.", new [] { "ShadeConstruction" });
            }
            
            // AirBoundaryConstruction (string) maxLength
            if(this.AirBoundaryConstruction != null && this.AirBoundaryConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AirBoundaryConstruction, length must be less than 100.", new [] { "AirBoundaryConstruction" });
            }

            // AirBoundaryConstruction (string) minLength
            if(this.AirBoundaryConstruction != null && this.AirBoundaryConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AirBoundaryConstruction, length must be greater than 1.", new [] { "AirBoundaryConstruction" });
            }
            
            yield break;
        }
    }
}
