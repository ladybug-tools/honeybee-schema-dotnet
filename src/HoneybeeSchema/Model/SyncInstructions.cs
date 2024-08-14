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
    [DataContract(Name = "SyncInstructions")]
    public partial class SyncInstructions : OpenAPIGenBaseModel, System.IEquatable<SyncInstructions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyncInstructions" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SyncInstructions() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SyncInstructions";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SyncInstructions" /> class.
        /// </summary>
        /// <param name="changedObjects">A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model.</param>
        /// <param name="deletedObjects">A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model.</param>
        /// <param name="addedObjects">A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model.</param>
        public SyncInstructions
        (
            List<ChangedInstruction> changedObjects = default, List<DeletedInstruction> deletedObjects = default, List<AddedInstruction> addedObjects = default
        ) : base()
        {
            this.ChangedObjects = changedObjects;
            this.DeletedObjects = deletedObjects;
            this.AddedObjects = addedObjects;

            // Set readonly properties with defaultValue
            this.Type = "SyncInstructions";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SyncInstructions))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model.
        /// </summary>
        [Summary(@"A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model.")]
        [DataMember(Name = "changed_objects")]
        public List<ChangedInstruction> ChangedObjects { get; set; }

        /// <summary>
        /// A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model.
        /// </summary>
        [Summary(@"A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model.")]
        [DataMember(Name = "deleted_objects")]
        public List<DeletedInstruction> DeletedObjects { get; set; }

        /// <summary>
        /// A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model.
        /// </summary>
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
                    Extension.AllEquals(this.ChangedObjects, input.ChangedObjects) && 
                    Extension.AllEquals(this.DeletedObjects, input.DeletedObjects) && 
                    Extension.AllEquals(this.AddedObjects, input.AddedObjects);
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
                if (this.ChangedObjects != null)
                    hashCode = hashCode * 59 + this.ChangedObjects.GetHashCode();
                if (this.DeletedObjects != null)
                    hashCode = hashCode * 59 + this.DeletedObjects.GetHashCode();
                if (this.AddedObjects != null)
                    hashCode = hashCode * 59 + this.AddedObjects.GetHashCode();
                return hashCode;
            }
        }


    }
}
