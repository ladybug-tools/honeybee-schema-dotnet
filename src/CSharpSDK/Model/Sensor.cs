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
    /// A single Radiance of sensors.
    /// </summary>
    [Summary(@"A single Radiance of sensors.")]
    [System.Serializable]
    [DataContract(Name = "Sensor")]
    public partial class Sensor : OpenAPIGenBaseModel, System.IEquatable<Sensor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sensor" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Sensor() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Sensor";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Sensor" /> class.
        /// </summary>
        /// <param name="pos">Position of sensor in space as an array of (x, y, z) values.</param>
        /// <param name="dir">Direction of sensor as an array of (x, y, z) values.</param>
        public Sensor
        (
            List<double> pos, List<double> dir
        ) : base()
        {
            this.Pos = pos ?? throw new System.ArgumentNullException("pos is a required property for Sensor and cannot be null");
            this.Dir = dir ?? throw new System.ArgumentNullException("dir is a required property for Sensor and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "Sensor";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Sensor))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Position of sensor in space as an array of (x, y, z) values.
        /// </summary>
        [Summary(@"Position of sensor in space as an array of (x, y, z) values.")]
        [Required]
        [DataMember(Name = "pos", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("pos")] // For System.Text.Json
        public List<double> Pos { get; set; }

        /// <summary>
        /// Direction of sensor as an array of (x, y, z) values.
        /// </summary>
        [Summary(@"Direction of sensor as an array of (x, y, z) values.")]
        [Required]
        [DataMember(Name = "dir", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dir")] // For System.Text.Json
        public List<double> Dir { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Sensor";
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
            sb.Append("Sensor:\n");
            sb.Append("  Pos: ").Append(this.Pos).Append("\n");
            sb.Append("  Dir: ").Append(this.Dir).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Sensor object</returns>
        public static Sensor FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Sensor>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Sensor object</returns>
        public virtual Sensor DuplicateSensor()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSensor();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Sensor);
        }


        /// <summary>
        /// Returns true if Sensor instances are equal
        /// </summary>
        /// <param name="input">Instance of Sensor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Sensor input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Pos, input.Pos) && 
                    Extension.AllEquals(this.Dir, input.Dir);
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
                if (this.Pos != null)
                    hashCode = hashCode * 59 + this.Pos.GetHashCode();
                if (this.Dir != null)
                    hashCode = hashCode * 59 + this.Dir.GetHashCode();
                return hashCode;
            }
        }


    }
}
