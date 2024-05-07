/* 
 * Honeybee Sync Instructions Schema
 *
 * Documentation for Honeybee sync-instructions schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
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
    /// SyncInstructions
    /// </summary>
    [Summary(@"")]
    [Serializable]
    [DataContract(Name = "SyncInstructions")]
    public partial class SyncInstructions : OpenAPIGenBaseModel, IEquatable<SyncInstructions>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyncInstructions" /> class.
        /// </summary>
        /// <param name="changedObjects">A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model..</param>
        /// <param name="deletedObjects">A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model..</param>
        /// <param name="addedObjects">A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model..</param>
        public SyncInstructions
        (
            // Required parameters
           List<ChangedInstruction> changedObjects= default, List<DeletedInstruction> deletedObjects= default, List<AddedInstruction> addedObjects= default// Optional parameters
        ) : base()// BaseClass
        {
            this.ChangedObjects = changedObjects;
            this.DeletedObjects = deletedObjects;
            this.AddedObjects = addedObjects;

            // Set non-required readonly properties with defaultValue
            this.Type = "SyncInstructions";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SyncInstructions))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "SyncInstructions";

        /// <summary>
        /// A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model.
        /// </summary>
        /// <value>A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model.</value>
        [Summary(@"A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model.")]
        [DataMember(Name = "changed_objects")]
        public List<ChangedInstruction> ChangedObjects { get; set; } 
        /// <summary>
        /// A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model.
        /// </summary>
        /// <value>A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model.</value>
        [Summary(@"A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model.")]
        [DataMember(Name = "deleted_objects")]
        public List<DeletedInstruction> DeletedObjects { get; set; } 
        /// <summary>
        /// A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model.
        /// </summary>
        /// <value>A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model.</value>
        [Summary(@"A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model.")]
        [DataMember(Name = "added_objects")]
        public List<AddedInstruction> AddedObjects { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SyncInstructions";
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
            sb.Append("SyncInstructions:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ChangedObjects: ").Append(this.ChangedObjects).Append("\n");
            sb.Append("  DeletedObjects: ").Append(this.DeletedObjects).Append("\n");
            sb.Append("  AddedObjects: ").Append(this.AddedObjects).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SyncInstructions object</returns>
        public static SyncInstructions FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SyncInstructions>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SyncInstructions object</returns>
        public virtual SyncInstructions DuplicateSyncInstructions()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateSyncInstructions();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSyncInstructions();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SyncInstructions);
        }

        /// <summary>
        /// Returns true if SyncInstructions instances are equal
        /// </summary>
        /// <param name="input">Instance of SyncInstructions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SyncInstructions input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                (
                    this.ChangedObjects == input.ChangedObjects ||
                    Extension.AllEquals(this.ChangedObjects, input.ChangedObjects)
                ) && 
                (
                    this.DeletedObjects == input.DeletedObjects ||
                    Extension.AllEquals(this.DeletedObjects, input.DeletedObjects)
                ) && 
                (
                    this.AddedObjects == input.AddedObjects ||
                    Extension.AllEquals(this.AddedObjects, input.AddedObjects)
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
                if (this.ChangedObjects != null)
                    hashCode = hashCode * 59 + this.ChangedObjects.GetHashCode();
                if (this.DeletedObjects != null)
                    hashCode = hashCode * 59 + this.DeletedObjects.GetHashCode();
                if (this.AddedObjects != null)
                    hashCode = hashCode * 59 + this.AddedObjects.GetHashCode();
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
            Regex regexType = new Regex(@"^SyncInstructions$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
