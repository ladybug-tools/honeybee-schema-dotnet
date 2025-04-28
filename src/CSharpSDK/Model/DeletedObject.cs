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
    [DataContract(Name = "DeletedObject")]
    public partial class DeletedObject : OpenAPIGenBaseModel, System.IEquatable<DeletedObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeletedObject" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DeletedObject() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DeletedObject";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeletedObject" /> class.
        /// </summary>
        /// <param name="elementType">Text for the type of object that has been changed.</param>
        /// <param name="elementId">Text string for the unique object ID that has changed.</param>
        /// <param name="geometry">A list of DisplayFace3D dictionaries for the deleted geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been deleted.</param>
        /// <param name="elementName">Text string for the display name of the object that has changed.</param>
        public DeletedObject
        (
            GeometryObjectTypes elementType, string elementId, List<object> geometry, string elementName = default
        ) : base()
        {
            this.ElementType = elementType;
            this.ElementId = elementId ?? throw new System.ArgumentNullException("elementId is a required property for DeletedObject and cannot be null");
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for DeletedObject and cannot be null");
            this.ElementName = elementName;

            // Set readonly properties with defaultValue
            this.Type = "DeletedObject";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DeletedObject))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the type of object that has been changed.
        /// </summary>
        [Summary(@"Text for the type of object that has been changed.")]
        [Required]
        [DataMember(Name = "element_type", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("element_type")] // For System.Text.Json
        public GeometryObjectTypes ElementType { get; set; }

        /// <summary>
        /// Text string for the unique object ID that has changed.
        /// </summary>
        [Summary(@"Text string for the unique object ID that has changed.")]
        [Required]
        [RegularExpression(@"^[^,;!\n\t]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "element_id", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("element_id")] // For System.Text.Json
        public string ElementId { get; set; }

        /// <summary>
        /// A list of DisplayFace3D dictionaries for the deleted geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been deleted.
        /// </summary>
        [Summary(@"A list of DisplayFace3D dictionaries for the deleted geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been deleted.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public List<object> Geometry { get; set; }

        /// <summary>
        /// Text string for the display name of the object that has changed.
        /// </summary>
        [Summary(@"Text string for the display name of the object that has changed.")]
        [DataMember(Name = "element_name")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("element_name")] // For System.Text.Json
        public string ElementName { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DeletedObject";
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
            sb.Append("DeletedObject:\n");
            sb.Append("  ElementType: ").Append(this.ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(this.ElementId).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ElementName: ").Append(this.ElementName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DeletedObject object</returns>
        public static DeletedObject FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DeletedObject>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DeletedObject object</returns>
        public virtual DeletedObject DuplicateDeletedObject()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDeletedObject();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DeletedObject);
        }


        /// <summary>
        /// Returns true if DeletedObject instances are equal
        /// </summary>
        /// <param name="input">Instance of DeletedObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeletedObject input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ElementType, input.ElementType) && 
                    Extension.Equals(this.ElementId, input.ElementId) && 
                    Extension.AllEquals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.ElementName, input.ElementName);
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
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.ElementName != null)
                    hashCode = hashCode * 59 + this.ElementName.GetHashCode();
                return hashCode;
            }
        }


    }
}
