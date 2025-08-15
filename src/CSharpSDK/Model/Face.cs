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
    /// Base class for all objects requiring a identifiers acceptable for all engines.
    /// </summary>
    [Summary(@"Base class for all objects requiring a identifiers acceptable for all engines.")]
    [System.Serializable]
    [DataContract(Name = "Face")]
    public partial class Face : IDdBaseModel, System.IEquatable<Face>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Face" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Face() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Face";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Face" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.</param>
        /// <param name="geometry">Planar Face3D for the geometry.</param>
        /// <param name="faceType">FaceType</param>
        /// <param name="boundaryCondition">BoundaryCondition</param>
        /// <param name="properties">Extension properties for particular simulation engines (Radiance, EnergyPlus).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="apertures">Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid.</param>
        /// <param name="doors">Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid.</param>
        /// <param name="indoorShades">Shades assigned to the interior side of this object.</param>
        /// <param name="outdoorShades">Shades assigned to the exterior side of this object (eg. balcony, overhang).</param>
        public Face
        (
            string identifier, Face3D geometry, FaceType faceType, AnyOf<Ground, Outdoors, Adiabatic, Surface, OtherSideTemperature> boundaryCondition, FacePropertiesAbridged properties, string displayName = default, object userData = default, List<Aperture> apertures = default, List<Door> doors = default, List<Shade> indoorShades = default, List<Shade> outdoorShades = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for Face and cannot be null");
            this.FaceType = faceType;
            this.BoundaryCondition = boundaryCondition ?? throw new System.ArgumentNullException("boundaryCondition is a required property for Face and cannot be null");
            this.Properties = properties ?? throw new System.ArgumentNullException("properties is a required property for Face and cannot be null");
            this.Apertures = apertures;
            this.Doors = doors;
            this.IndoorShades = indoorShades;
            this.OutdoorShades = outdoorShades;

            // Set readonly properties with defaultValue
            this.Type = "Face";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Face))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Planar Face3D for the geometry.
        /// </summary>
        [Summary(@"Planar Face3D for the geometry.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Face3D Geometry { get; set; }

        /// <summary>
        /// FaceType
        /// </summary>
        [Summary(@"FaceType")]
        [Required]
        [DataMember(Name = "face_type", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("face_type")] // For System.Text.Json
        public FaceType FaceType { get; set; }

        /// <summary>
        /// BoundaryCondition
        /// </summary>
        [Summary(@"BoundaryCondition")]
        [Required]
        [DataMember(Name = "boundary_condition", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("boundary_condition")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Ground, Outdoors, Adiabatic, Surface, OtherSideTemperature> BoundaryCondition { get; set; }

        /// <summary>
        /// Extension properties for particular simulation engines (Radiance, EnergyPlus).
        /// </summary>
        [Summary(@"Extension properties for particular simulation engines (Radiance, EnergyPlus).")]
        [Required]
        [DataMember(Name = "properties", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("properties")] // For System.Text.Json
        public FacePropertiesAbridged Properties { get; set; }

        /// <summary>
        /// Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid.
        /// </summary>
        [Summary(@"Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid.")]
        [DataMember(Name = "apertures")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("apertures")] // For System.Text.Json
        public List<Aperture> Apertures { get; set; }

        /// <summary>
        /// Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid.
        /// </summary>
        [Summary(@"Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid.")]
        [DataMember(Name = "doors")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("doors")] // For System.Text.Json
        public List<Door> Doors { get; set; }

        /// <summary>
        /// Shades assigned to the interior side of this object.
        /// </summary>
        [Summary(@"Shades assigned to the interior side of this object.")]
        [DataMember(Name = "indoor_shades")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("indoor_shades")] // For System.Text.Json
        public List<Shade> IndoorShades { get; set; }

        /// <summary>
        /// Shades assigned to the exterior side of this object (eg. balcony, overhang).
        /// </summary>
        [Summary(@"Shades assigned to the exterior side of this object (eg. balcony, overhang).")]
        [DataMember(Name = "outdoor_shades")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("outdoor_shades")] // For System.Text.Json
        public List<Shade> OutdoorShades { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Face";
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
            sb.Append("Face:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  FaceType: ").Append(this.FaceType).Append("\n");
            sb.Append("  BoundaryCondition: ").Append(this.BoundaryCondition).Append("\n");
            sb.Append("  Properties: ").Append(this.Properties).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Apertures: ").Append(this.Apertures).Append("\n");
            sb.Append("  Doors: ").Append(this.Doors).Append("\n");
            sb.Append("  IndoorShades: ").Append(this.IndoorShades).Append("\n");
            sb.Append("  OutdoorShades: ").Append(this.OutdoorShades).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Face object</returns>
        public static Face FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Face>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Face object</returns>
        public virtual Face DuplicateFace()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdBaseModel</returns>
        public override IDdBaseModel DuplicateIDdBaseModel()
        {
            return DuplicateFace();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Face);
        }


        /// <summary>
        /// Returns true if Face instances are equal
        /// </summary>
        /// <param name="input">Instance of Face to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Face input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.FaceType, input.FaceType) && 
                    Extension.Equals(this.BoundaryCondition, input.BoundaryCondition) && 
                    Extension.Equals(this.Properties, input.Properties) && 
                    Extension.AllEquals(this.Apertures, input.Apertures) && 
                    Extension.AllEquals(this.Doors, input.Doors) && 
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
                if (this.FaceType != null)
                    hashCode = hashCode * 59 + this.FaceType.GetHashCode();
                if (this.BoundaryCondition != null)
                    hashCode = hashCode * 59 + this.BoundaryCondition.GetHashCode();
                if (this.Properties != null)
                    hashCode = hashCode * 59 + this.Properties.GetHashCode();
                if (this.Apertures != null)
                    hashCode = hashCode * 59 + this.Apertures.GetHashCode();
                if (this.Doors != null)
                    hashCode = hashCode * 59 + this.Doors.GetHashCode();
                if (this.IndoorShades != null)
                    hashCode = hashCode * 59 + this.IndoorShades.GetHashCode();
                if (this.OutdoorShades != null)
                    hashCode = hashCode * 59 + this.OutdoorShades.GetHashCode();
                return hashCode;
            }
        }


    }
}
