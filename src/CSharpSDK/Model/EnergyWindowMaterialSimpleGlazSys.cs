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
    /// Describe an entire glazing system rather than individual layers.\n\nUsed when only very limited information is available on the glazing layers or when\nspecific performance levels are being targeted.
    /// </summary>
    [Summary(@"Describe an entire glazing system rather than individual layers.\n\nUsed when only very limited information is available on the glazing layers or when\nspecific performance levels are being targeted.")]
    [System.Serializable]
    [DataContract(Name = "EnergyWindowMaterialSimpleGlazSys")]
    public partial class EnergyWindowMaterialSimpleGlazSys : IDdEnergyBaseModel, System.IEquatable<EnergyWindowMaterialSimpleGlazSys>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialSimpleGlazSys" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected EnergyWindowMaterialSimpleGlazSys() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialSimpleGlazSys";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialSimpleGlazSys" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="uFactor">The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted.</param>
        /// <param name="shgc">Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vt">The fraction of visible light falling on the window that makes it through the glass at normal incidence.</param>
        public EnergyWindowMaterialSimpleGlazSys
        (
            string identifier, double uFactor, double shgc, string displayName = default, object userData = default, double vt = 0.54D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.UFactor = uFactor;
            this.Shgc = shgc;
            this.Vt = vt;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialSimpleGlazSys";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialSimpleGlazSys))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted.
        /// </summary>
        [Summary(@"The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted.")]
        [Required]
        [Range(double.MinValue, 12)]
        [DataMember(Name = "u_factor", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("u_factor")] // For System.Text.Json
        public double UFactor { get; set; }

        /// <summary>
        /// Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation.
        /// </summary>
        [Summary(@"Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation.")]
        [Required]
        [DataMember(Name = "shgc", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("shgc")] // For System.Text.Json
        public double Shgc { get; set; }

        /// <summary>
        /// The fraction of visible light falling on the window that makes it through the glass at normal incidence.
        /// </summary>
        [Summary(@"The fraction of visible light falling on the window that makes it through the glass at normal incidence.")]
        [DataMember(Name = "vt")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("vt")] // For System.Text.Json
        public double Vt { get; set; } = 0.54D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialSimpleGlazSys";
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
            sb.Append("EnergyWindowMaterialSimpleGlazSys:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  UFactor: ").Append(this.UFactor).Append("\n");
            sb.Append("  Shgc: ").Append(this.Shgc).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vt: ").Append(this.Vt).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialSimpleGlazSys object</returns>
        public static EnergyWindowMaterialSimpleGlazSys FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialSimpleGlazSys>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialSimpleGlazSys object</returns>
        public virtual EnergyWindowMaterialSimpleGlazSys DuplicateEnergyWindowMaterialSimpleGlazSys()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowMaterialSimpleGlazSys();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialSimpleGlazSys);
        }


        /// <summary>
        /// Returns true if EnergyWindowMaterialSimpleGlazSys instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialSimpleGlazSys to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialSimpleGlazSys input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.UFactor, input.UFactor) && 
                    Extension.Equals(this.Shgc, input.Shgc) && 
                    Extension.Equals(this.Vt, input.Vt);
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
                if (this.UFactor != null)
                    hashCode = hashCode * 59 + this.UFactor.GetHashCode();
                if (this.Shgc != null)
                    hashCode = hashCode * 59 + this.Shgc.GetHashCode();
                if (this.Vt != null)
                    hashCode = hashCode * 59 + this.Vt.GetHashCode();
                return hashCode;
            }
        }


    }
}
