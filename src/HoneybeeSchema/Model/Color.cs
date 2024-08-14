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
    /// A RGB color.
    /// </summary>
    [Summary(@"A RGB color.")]
    [System.Serializable]
    [DataContract(Name = "Color")]
    public partial class Color : OpenAPIGenBaseModel, System.IEquatable<Color>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Color" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Color() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Color";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Color" /> class.
        /// </summary>
        /// <param name="r">Value for red channel.</param>
        /// <param name="g">Value for green channel.</param>
        /// <param name="b">Value for blue channel.</param>
        /// <param name="a">Value for the alpha channel, which defines the opacity as a number between 0 (fully transparent) and 255 (fully opaque).</param>
        public Color
        (
            int r, int g, int b, int a = 255
        ) : base()
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;

            // Set readonly properties with defaultValue
            this.Type = "Color";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Color))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Value for red channel.
        /// </summary>
        [Summary(@"Value for red channel.")]
        [Required]
        [Range(0, 255)]
        [DataMember(Name = "r", IsRequired = true)]
        public int R { get; set; }

        /// <summary>
        /// Value for green channel.
        /// </summary>
        [Summary(@"Value for green channel.")]
        [Required]
        [Range(0, 255)]
        [DataMember(Name = "g", IsRequired = true)]
        public int G { get; set; }

        /// <summary>
        /// Value for blue channel.
        /// </summary>
        [Summary(@"Value for blue channel.")]
        [Required]
        [Range(0, 255)]
        [DataMember(Name = "b", IsRequired = true)]
        public int B { get; set; }

        /// <summary>
        /// Value for the alpha channel, which defines the opacity as a number between 0 (fully transparent) and 255 (fully opaque).
        /// </summary>
        [Summary(@"Value for the alpha channel, which defines the opacity as a number between 0 (fully transparent) and 255 (fully opaque).")]
        [Range(0, 255)]
        [DataMember(Name = "a")]
        public int A { get; set; } = 255;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Color";
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
            sb.Append("Color:\n");
            sb.Append("  R: ").Append(this.R).Append("\n");
            sb.Append("  G: ").Append(this.G).Append("\n");
            sb.Append("  B: ").Append(this.B).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  A: ").Append(this.A).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Color object</returns>
        public static Color FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Color>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Color object</returns>
        public virtual Color DuplicateColor()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateColor();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Color);
        }


        /// <summary>
        /// Returns true if Color instances are equal
        /// </summary>
        /// <param name="input">Instance of Color to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Color input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.R, input.R) && 
                    Extension.Equals(this.G, input.G) && 
                    Extension.Equals(this.B, input.B) && 
                    Extension.Equals(this.A, input.A);
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
                if (this.R != null)
                    hashCode = hashCode * 59 + this.R.GetHashCode();
                if (this.G != null)
                    hashCode = hashCode * 59 + this.G.GetHashCode();
                if (this.B != null)
                    hashCode = hashCode * 59 + this.B.GetHashCode();
                if (this.A != null)
                    hashCode = hashCode * 59 + this.A.GetHashCode();
                return hashCode;
            }
        }


    }
}
