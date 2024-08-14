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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "ChangedObject")]
    public partial class ChangedObject : OpenAPIGenBaseModel, System.IEquatable<ChangedObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedObject" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChangedObject() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ChangedObject";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedObject" /> class.
        /// </summary>
        /// <param name="elementType">Text for the type of object that has been changed.</param>
        /// <param name="elementId">Text string for the unique object ID that has changed.</param>
        /// <param name="geometryChanged">A boolean to note whether the geometry of the object has changed (True) or not (False). For the case of a Room, any change in the geometry of child Faces, Apertures or Doors will cause this property to be True. Note that this property is only True if the change in geometry produces a visible change greater than the base model tolerance. So converting the model between different unit systems, removing colinear vertices, or doing other transformations that are common for export to simulation engines will not trigger this property to become True.</param>
        /// <param name="geometry">A list of DisplayFace3D dictionaries for the new, changed geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. Note that this attribute is always included in the ChangedObject, even when geometry_changed is False.</param>
        /// <param name="elementName">Text string for the display name of the object that has changed.</param>
        /// <param name="energyChanged">A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed.</param>
        /// <param name="radianceChanged">A boolean to note whether the radiance properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the radiance property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed.</param>
        /// <param name="existingGeometry">A list of DisplayFace3D dictionaries for the existing (base) geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. This attribute is optional and will NOT be output if geometry_changed is False.</param>
        public ChangedObject
        (
            GeometryObjectTypes elementType, string elementId, bool geometryChanged, List<object> geometry, string elementName = default, bool energyChanged = false, bool radianceChanged = false, List<object> existingGeometry = default
        ) : base()
        {
            this.ElementType = elementType;
            this.ElementId = elementId ?? throw new System.ArgumentNullException("elementId is a required property for ChangedObject and cannot be null");
            this.GeometryChanged = geometryChanged;
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for ChangedObject and cannot be null");
            this.ElementName = elementName;
            this.EnergyChanged = energyChanged;
            this.RadianceChanged = radianceChanged;
            this.ExistingGeometry = existingGeometry;

            // Set readonly properties with defaultValue
            this.Type = "ChangedObject";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ChangedObject))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the type of object that has been changed.
        /// </summary>
        [Summary(@"Text for the type of object that has been changed.")]
        [Required]
        [DataMember(Name = "element_type", IsRequired = true)]
        public GeometryObjectTypes ElementType { get; set; }

        /// <summary>
        /// Text string for the unique object ID that has changed.
        /// </summary>
        [Summary(@"Text string for the unique object ID that has changed.")]
        [Required]
        [RegularExpression(@"^[^,;!\n\t]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "element_id", IsRequired = true)]
        public string ElementId { get; set; }

        /// <summary>
        /// A boolean to note whether the geometry of the object has changed (True) or not (False). For the case of a Room, any change in the geometry of child Faces, Apertures or Doors will cause this property to be True. Note that this property is only True if the change in geometry produces a visible change greater than the base model tolerance. So converting the model between different unit systems, removing colinear vertices, or doing other transformations that are common for export to simulation engines will not trigger this property to become True.
        /// </summary>
        [Summary(@"A boolean to note whether the geometry of the object has changed (True) or not (False). For the case of a Room, any change in the geometry of child Faces, Apertures or Doors will cause this property to be True. Note that this property is only True if the change in geometry produces a visible change greater than the base model tolerance. So converting the model between different unit systems, removing colinear vertices, or doing other transformations that are common for export to simulation engines will not trigger this property to become True.")]
        [Required]
        [DataMember(Name = "geometry_changed", IsRequired = true)]
        public bool GeometryChanged { get; set; }

        /// <summary>
        /// A list of DisplayFace3D dictionaries for the new, changed geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. Note that this attribute is always included in the ChangedObject, even when geometry_changed is False.
        /// </summary>
        [Summary(@"A list of DisplayFace3D dictionaries for the new, changed geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. Note that this attribute is always included in the ChangedObject, even when geometry_changed is False.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)]
        public List<object> Geometry { get; set; }

        /// <summary>
        /// Text string for the display name of the object that has changed.
        /// </summary>
        [Summary(@"Text string for the display name of the object that has changed.")]
        [DataMember(Name = "element_name")]
        public string ElementName { get; set; }

        /// <summary>
        /// A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed.
        /// </summary>
        [Summary(@"A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed.")]
        [DataMember(Name = "energy_changed")]
        public bool EnergyChanged { get; set; } = false;

        /// <summary>
        /// A boolean to note whether the radiance properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the radiance property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed.
        /// </summary>
        [Summary(@"A boolean to note whether the radiance properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the radiance property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed.")]
        [DataMember(Name = "radiance_changed")]
        public bool RadianceChanged { get; set; } = false;

        /// <summary>
        /// A list of DisplayFace3D dictionaries for the existing (base) geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. This attribute is optional and will NOT be output if geometry_changed is False.
        /// </summary>
        [Summary(@"A list of DisplayFace3D dictionaries for the existing (base) geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. This attribute is optional and will NOT be output if geometry_changed is False.")]
        [DataMember(Name = "existing_geometry")]
        public List<object> ExistingGeometry { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ChangedObject";
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
            sb.Append("ChangedObject:\n");
            sb.Append("  ElementType: ").Append(this.ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(this.ElementId).Append("\n");
            sb.Append("  GeometryChanged: ").Append(this.GeometryChanged).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ElementName: ").Append(this.ElementName).Append("\n");
            sb.Append("  EnergyChanged: ").Append(this.EnergyChanged).Append("\n");
            sb.Append("  RadianceChanged: ").Append(this.RadianceChanged).Append("\n");
            sb.Append("  ExistingGeometry: ").Append(this.ExistingGeometry).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ChangedObject object</returns>
        public static ChangedObject FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ChangedObject>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ChangedObject object</returns>
        public virtual ChangedObject DuplicateChangedObject()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateChangedObject();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ChangedObject);
        }


        /// <summary>
        /// Returns true if ChangedObject instances are equal
        /// </summary>
        /// <param name="input">Instance of ChangedObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChangedObject input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ElementType, input.ElementType) && 
                    Extension.Equals(this.ElementId, input.ElementId) && 
                    Extension.Equals(this.GeometryChanged, input.GeometryChanged) && 
                    Extension.AllEquals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.ElementName, input.ElementName) && 
                    Extension.Equals(this.EnergyChanged, input.EnergyChanged) && 
                    Extension.Equals(this.RadianceChanged, input.RadianceChanged) && 
                    Extension.AllEquals(this.ExistingGeometry, input.ExistingGeometry);
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
                if (this.ElementType != null)
                    hashCode = hashCode * 59 + this.ElementType.GetHashCode();
                if (this.ElementId != null)
                    hashCode = hashCode * 59 + this.ElementId.GetHashCode();
                if (this.GeometryChanged != null)
                    hashCode = hashCode * 59 + this.GeometryChanged.GetHashCode();
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.ElementName != null)
                    hashCode = hashCode * 59 + this.ElementName.GetHashCode();
                if (this.EnergyChanged != null)
                    hashCode = hashCode * 59 + this.EnergyChanged.GetHashCode();
                if (this.RadianceChanged != null)
                    hashCode = hashCode * 59 + this.RadianceChanged.GetHashCode();
                if (this.ExistingGeometry != null)
                    hashCode = hashCode * 59 + this.ExistingGeometry.GetHashCode();
                return hashCode;
            }
        }


    }
}
