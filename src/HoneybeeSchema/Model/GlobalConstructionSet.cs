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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [Serializable]
    [DataContract(Name = "GlobalConstructionSet")]
    public partial class GlobalConstructionSet : OpenAPIGenBaseModel, IEquatable<GlobalConstructionSet>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConstructionSet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public GlobalConstructionSet
        (
           // Required parameters
           // Optional parameters
        ) : base()// BaseClass
        {

            // Set non-required readonly properties with defaultValue
            this.Type = "GlobalConstructionSet";
            this.ShadeConstruction = "Generic Shade";
            this.AirBoundaryConstruction = "Generic Air Boundary";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(GlobalConstructionSet))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "GlobalConstructionSet";
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee Energy materials.
        /// </summary>
        /// <value>Global Honeybee Energy materials.</value>
        [DataMember(Name = "materials")]
        public List<AnyOf<EnergyMaterial,EnergyMaterialNoMass,EnergyWindowMaterialGlazing,EnergyWindowMaterialGas>> Materials { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee Energy constructions.
        /// </summary>
        /// <value>Global Honeybee Energy constructions.</value>
        [DataMember(Name = "constructions")]
        public List<AnyOf<OpaqueConstructionAbridged,WindowConstructionAbridged,ShadeConstruction,AirBoundaryConstructionAbridged>> Constructions { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee WallConstructionSet.
        /// </summary>
        /// <value>Global Honeybee WallConstructionSet.</value>
        [DataMember(Name = "wall_set")]
        public WallConstructionSetAbridged WallSet { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee FloorConstructionSet.
        /// </summary>
        /// <value>Global Honeybee FloorConstructionSet.</value>
        [DataMember(Name = "floor_set")]
        public FloorConstructionSetAbridged FloorSet { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee RoofCeilingConstructionSet.
        /// </summary>
        /// <value>Global Honeybee RoofCeilingConstructionSet.</value>
        [DataMember(Name = "roof_ceiling_set")]
        public RoofCeilingConstructionSetAbridged RoofCeilingSet { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee ApertureConstructionSet.
        /// </summary>
        /// <value>Global Honeybee ApertureConstructionSet.</value>
        [DataMember(Name = "aperture_set")]
        public ApertureConstructionSetAbridged ApertureSet { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee DoorConstructionSet.
        /// </summary>
        /// <value>Global Honeybee DoorConstructionSet.</value>
        [DataMember(Name = "door_set")]
        public DoorConstructionSetAbridged DoorSet { get; protected set; } 
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee Construction for Shades.
        /// </summary>
        /// <value>Global Honeybee Construction for Shades.</value>
        [DataMember(Name = "shade_construction")]
        public string ShadeConstruction { get; protected set; }  = "Generic Shade";
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Honeybee Construction for AirBoundary Faces.
        /// </summary>
        /// <value>Global Honeybee Construction for AirBoundary Faces.</value>
        [DataMember(Name = "air_boundary_construction")]
        public string AirBoundaryConstruction { get; protected set; }  = "Generic Air Boundary";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "GlobalConstructionSet";
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
            sb.Append("GlobalConstructionSet:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Materials: ").Append(Materials).Append("\n");
            sb.Append("  Constructions: ").Append(Constructions).Append("\n");
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
        /// <returns>GlobalConstructionSet object</returns>
        public static GlobalConstructionSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<GlobalConstructionSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>GlobalConstructionSet object</returns>
        public virtual GlobalConstructionSet DuplicateGlobalConstructionSet()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateGlobalConstructionSet();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateGlobalConstructionSet();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as GlobalConstructionSet);
        }

        /// <summary>
        /// Returns true if GlobalConstructionSet instances are equal
        /// </summary>
        /// <param name="input">Instance of GlobalConstructionSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GlobalConstructionSet input)
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
                    this.Materials == input.Materials ||
                    Extension.AllEquals(this.Materials, input.Materials)
                ) && base.Equals(input) && 
                (
                    this.Constructions == input.Constructions ||
                    Extension.AllEquals(this.Constructions, input.Constructions)
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
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
                if (this.Constructions != null)
                    hashCode = hashCode * 59 + this.Constructions.GetHashCode();
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
            Regex regexType = new Regex(@"^GlobalConstructionSet$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
