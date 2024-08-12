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
    /// A set of constructions for door assemblies.
    /// </summary>
    [Summary(@"A set of constructions for door assemblies.")]
    [Serializable]
    [DataContract(Name = "DoorConstructionSet")]
    public partial class DoorConstructionSet : OpenAPIGenBaseModel, IEquatable<DoorConstructionSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorConstructionSet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DoorConstructionSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DoorConstructionSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorConstructionSet" /> class.
        /// </summary>
        /// <param name="interiorConstruction">An OpaqueConstruction for all opaque doors with a Surface boundary condition.</param>
        /// <param name="exteriorConstruction">An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.</param>
        /// <param name="overheadConstruction">An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.</param>
        /// <param name="exteriorGlassConstruction">A WindowConstruction for all glass doors with an Outdoors boundary condition.</param>
        /// <param name="interiorGlassConstruction">A WindowConstruction for all glass doors with a Surface boundary condition.</param>
        public DoorConstructionSet
        (
            OpaqueConstruction interiorConstruction = default, OpaqueConstruction exteriorConstruction = default, OpaqueConstruction overheadConstruction = default, AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> exteriorGlassConstruction = default, AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> interiorGlassConstruction = default
        ) : base()
        {
            this.InteriorConstruction = interiorConstruction;
            this.ExteriorConstruction = exteriorConstruction;
            this.OverheadConstruction = overheadConstruction;
            this.ExteriorGlassConstruction = exteriorGlassConstruction;
            this.InteriorGlassConstruction = interiorGlassConstruction;

            // Set readonly properties with defaultValue
            this.Type = "DoorConstructionSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorConstructionSet))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// An OpaqueConstruction for all opaque doors with a Surface boundary condition.
        /// </summary>
        [Summary(@"An OpaqueConstruction for all opaque doors with a Surface boundary condition.")]
        [DataMember(Name = "interior_construction")]
        public OpaqueConstruction InteriorConstruction { get; set; }

        /// <summary>
        /// An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.
        /// </summary>
        [Summary(@"An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.")]
        [DataMember(Name = "exterior_construction")]
        public OpaqueConstruction ExteriorConstruction { get; set; }

        /// <summary>
        /// An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.
        /// </summary>
        [Summary(@"An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.")]
        [DataMember(Name = "overhead_construction")]
        public OpaqueConstruction OverheadConstruction { get; set; }

        /// <summary>
        /// A WindowConstruction for all glass doors with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"A WindowConstruction for all glass doors with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_glass_construction")]
        public AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> ExteriorGlassConstruction { get; set; }

        /// <summary>
        /// A WindowConstruction for all glass doors with a Surface boundary condition.
        /// </summary>
        [Summary(@"A WindowConstruction for all glass doors with a Surface boundary condition.")]
        [DataMember(Name = "interior_glass_construction")]
        public AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> InteriorGlassConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorConstructionSet";
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
            sb.Append("DoorConstructionSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  OverheadConstruction: ").Append(this.OverheadConstruction).Append("\n");
            sb.Append("  ExteriorGlassConstruction: ").Append(this.ExteriorGlassConstruction).Append("\n");
            sb.Append("  InteriorGlassConstruction: ").Append(this.InteriorGlassConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorConstructionSet object</returns>
        public static DoorConstructionSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorConstructionSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorConstructionSet object</returns>
        public virtual DoorConstructionSet DuplicateDoorConstructionSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDoorConstructionSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorConstructionSet);
        }


        /// <summary>
        /// Returns true if DoorConstructionSet instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorConstructionSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorConstructionSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.InteriorConstruction, input.InteriorConstruction) && 
                    Extension.Equals(this.ExteriorConstruction, input.ExteriorConstruction) && 
                    Extension.Equals(this.OverheadConstruction, input.OverheadConstruction) && 
                    Extension.Equals(this.ExteriorGlassConstruction, input.ExteriorGlassConstruction) && 
                    Extension.Equals(this.InteriorGlassConstruction, input.InteriorGlassConstruction);
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
                if (this.InteriorConstruction != null)
                    hashCode = hashCode * 59 + this.InteriorConstruction.GetHashCode();
                if (this.ExteriorConstruction != null)
                    hashCode = hashCode * 59 + this.ExteriorConstruction.GetHashCode();
                if (this.OverheadConstruction != null)
                    hashCode = hashCode * 59 + this.OverheadConstruction.GetHashCode();
                if (this.ExteriorGlassConstruction != null)
                    hashCode = hashCode * 59 + this.ExteriorGlassConstruction.GetHashCode();
                if (this.InteriorGlassConstruction != null)
                    hashCode = hashCode * 59 + this.InteriorGlassConstruction.GetHashCode();
                return hashCode;
            }
        }


    }
}
