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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "AddedInstruction")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class AddedInstruction : DiffObjectBase, System.IEquatable<AddedInstruction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddedInstruction" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected AddedInstruction() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "AddedInstruction";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddedInstruction" /> class.
        /// </summary>
        /// <param name="elementType">Text for the type of object that has been changed.</param>
        /// <param name="elementId">Text string for the unique object ID that has changed.</param>
        /// <param name="elementName">Text string for the display name of the object that has changed.</param>
        public AddedInstruction
        (
            GeometryObjectTypes elementType, string elementId, string elementName = default
        ) : base(elementType: elementType, elementId: elementId, elementName: elementName)
        {

            // Set readonly properties with defaultValue
            this.Type = "AddedInstruction";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(AddedInstruction))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "AddedInstruction";
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
            sb.Append("AddedInstruction:\n");
            sb.Append("  ElementType: ").Append(this.ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(this.ElementId).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ElementName: ").Append(this.ElementName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>AddedInstruction object</returns>
        public static AddedInstruction FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<AddedInstruction>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>AddedInstruction object</returns>
        public virtual AddedInstruction DuplicateAddedInstruction()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DiffObjectBase</returns>
        public override DiffObjectBase DuplicateDiffObjectBase()
        {
            return DuplicateAddedInstruction();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as AddedInstruction);
        }


        /// <summary>
        /// Returns true if AddedInstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of AddedInstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddedInstruction input)
        {
            if (input == null)
                return false;
            return base.Equals(input);
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
                return hashCode;
            }
        }


    }
}
