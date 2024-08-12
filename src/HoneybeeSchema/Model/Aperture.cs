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
    /// Base class for all objects requiring a identifiers acceptable for all engines.
    /// </summary>
    [Summary(@"Base class for all objects requiring a identifiers acceptable for all engines.")]
    [Serializable]
    [DataContract(Name = "Aperture")]
    public partial class Aperture : IDdBaseModel, IEquatable<Aperture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aperture" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Aperture() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Aperture";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Aperture" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.</param>
        /// <param name="geometry">Planar Face3D for the geometry.</param>
        /// <param name="boundaryCondition">BoundaryCondition</param>
        /// <param name="properties">Extension properties for particular simulation engines (Radiance, EnergyPlus).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="isOperable">Boolean to note whether the Aperture can be opened for ventilation.</param>
        /// <param name="indoorShades">Shades assigned to the interior side of this object (eg. window sill, light shelf).</param>
        /// <param name="outdoorShades">Shades assigned to the exterior side of this object (eg. mullions, louvers).</param>
        public Aperture
        (
            string identifier, Face3D geometry, AnyOf<Outdoors, Surface> boundaryCondition, AperturePropertiesAbridged properties, string displayName = default, object userData = default, bool isOperable = false, List<Shade> indoorShades = default, List<Shade> outdoorShades = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Geometry = geometry ?? throw new ArgumentNullException("geometry is a required property for Aperture and cannot be null");
            this.BoundaryCondition = boundaryCondition ?? throw new ArgumentNullException("boundaryCondition is a required property for Aperture and cannot be null");
            this.Properties = properties ?? throw new ArgumentNullException("properties is a required property for Aperture and cannot be null");
            this.IsOperable = isOperable;
            this.IndoorShades = indoorShades;
            this.OutdoorShades = outdoorShades;

            // Set readonly properties with defaultValue
            this.Type = "Aperture";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Aperture))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Planar Face3D for the geometry.
        /// </summary>
        [Summary(@"Planar Face3D for the geometry.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)]
        public Face3D Geometry { get; set; }

        /// <summary>
        /// BoundaryCondition
        /// </summary>
        [Summary(@"BoundaryCondition")]
        [Required]
        [DataMember(Name = "boundary_condition", IsRequired = true)]
        public AnyOf<Outdoors, Surface> BoundaryCondition { get; set; }

        /// <summary>
        /// Extension properties for particular simulation engines (Radiance, EnergyPlus).
        /// </summary>
        [Summary(@"Extension properties for particular simulation engines (Radiance, EnergyPlus).")]
        [Required]
        [DataMember(Name = "properties", IsRequired = true)]
        public AperturePropertiesAbridged Properties { get; set; }

        /// <summary>
        /// Boolean to note whether the Aperture can be opened for ventilation.
        /// </summary>
        [Summary(@"Boolean to note whether the Aperture can be opened for ventilation.")]
        [DataMember(Name = "is_operable")]
        public bool IsOperable { get; set; } = false;

        /// <summary>
        /// Shades assigned to the interior side of this object (eg. window sill, light shelf).
        /// </summary>
        [Summary(@"Shades assigned to the interior side of this object (eg. window sill, light shelf).")]
        [DataMember(Name = "indoor_shades")]
        public List<Shade> IndoorShades { get; set; }

        /// <summary>
        /// Shades assigned to the exterior side of this object (eg. mullions, louvers).
        /// </summary>
        [Summary(@"Shades assigned to the exterior side of this object (eg. mullions, louvers).")]
        [DataMember(Name = "outdoor_shades")]
        public List<Shade> OutdoorShades { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Aperture";
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
            sb.Append("Aperture:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  BoundaryCondition: ").Append(this.BoundaryCondition).Append("\n");
            sb.Append("  Properties: ").Append(this.Properties).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  IsOperable: ").Append(this.IsOperable).Append("\n");
            sb.Append("  IndoorShades: ").Append(this.IndoorShades).Append("\n");
            sb.Append("  OutdoorShades: ").Append(this.OutdoorShades).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Aperture object</returns>
        public static Aperture FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Aperture>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Aperture object</returns>
        public virtual Aperture DuplicateAperture()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdBaseModel</returns>
        public override IDdBaseModel DuplicateIDdBaseModel()
        {
            return DuplicateAperture();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Aperture);
        }


        /// <summary>
        /// Returns true if Aperture instances are equal
        /// </summary>
        /// <param name="input">Instance of Aperture to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Aperture input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.BoundaryCondition, input.BoundaryCondition) && 
                    Extension.Equals(this.Properties, input.Properties) && 
                    Extension.Equals(this.IsOperable, input.IsOperable) && 
                    Extension.AllEquals(this.IndoorShades, input.IndoorShades) && 
                    Extension.AllEquals(this.OutdoorShades, input.OutdoorShades);
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
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.BoundaryCondition != null)
                    hashCode = hashCode * 59 + this.BoundaryCondition.GetHashCode();
                if (this.Properties != null)
                    hashCode = hashCode * 59 + this.Properties.GetHashCode();
                if (this.IsOperable != null)
                    hashCode = hashCode * 59 + this.IsOperable.GetHashCode();
                if (this.IndoorShades != null)
                    hashCode = hashCode * 59 + this.IndoorShades.GetHashCode();
                if (this.OutdoorShades != null)
                    hashCode = hashCode * 59 + this.OutdoorShades.GetHashCode();
                return hashCode;
            }
        }


    }
}
