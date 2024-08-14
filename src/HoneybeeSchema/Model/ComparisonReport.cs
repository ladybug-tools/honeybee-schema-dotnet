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
    [DataContract(Name = "ComparisonReport")]
    public partial class ComparisonReport : OpenAPIGenBaseModel, System.IEquatable<ComparisonReport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparisonReport" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ComparisonReport() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ComparisonReport";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparisonReport" /> class.
        /// </summary>
        /// <param name="changedObjects">A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change.</param>
        /// <param name="deletedObjects">A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model.</param>
        /// <param name="addedObjects">A list of AddedObject definitions for each top-level object that has been added in the process of going from the base model to the new model.</param>
        public ComparisonReport
        (
            List<ChangedObject> changedObjects = default, List<DeletedObject> deletedObjects = default, List<AddedObject> addedObjects = default
        ) : base()
        {
            this.ChangedObjects = changedObjects;
            this.DeletedObjects = deletedObjects;
            this.AddedObjects = addedObjects;

            // Set readonly properties with defaultValue
            this.Type = "ComparisonReport";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ComparisonReport))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change.
        /// </summary>
        [Summary(@"A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change.")]
        [DataMember(Name = "changed_objects")]
        public List<ChangedObject> ChangedObjects { get; set; }

        /// <summary>
        /// A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model.
        /// </summary>
        [Summary(@"A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model.")]
        [DataMember(Name = "deleted_objects")]
        public List<DeletedObject> DeletedObjects { get; set; }

        /// <summary>
        /// A list of AddedObject definitions for each top-level object that has been added in the process of going from the base model to the new model.
        /// </summary>
        [Summary(@"A list of AddedObject definitions for each top-level object that has been added in the process of going from the base model to the new model.")]
        [DataMember(Name = "added_objects")]
        public List<AddedObject> AddedObjects { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ComparisonReport";
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
            sb.Append("ComparisonReport:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ChangedObjects: ").Append(this.ChangedObjects).Append("\n");
            sb.Append("  DeletedObjects: ").Append(this.DeletedObjects).Append("\n");
            sb.Append("  AddedObjects: ").Append(this.AddedObjects).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ComparisonReport object</returns>
        public static ComparisonReport FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ComparisonReport>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ComparisonReport object</returns>
        public virtual ComparisonReport DuplicateComparisonReport()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateComparisonReport();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ComparisonReport);
        }


        /// <summary>
        /// Returns true if ComparisonReport instances are equal
        /// </summary>
        /// <param name="input">Instance of ComparisonReport to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ComparisonReport input)
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
