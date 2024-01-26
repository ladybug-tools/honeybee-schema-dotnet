/* 
 * Honeybee Project Information Schema
 *
 * Documentation for Honeybee project-information schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// A Ladybug Location.
    /// </summary>
    [Summary(@"A Ladybug Location.")]
    [Serializable]
    [DataContract(Name = "Location")]
    public partial class Location : OpenAPIGenBaseModel, IEquatable<Location>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location" /> class.
        /// </summary>
        /// <param name="city">Name of the city as a string. (default to &quot;-&quot;).</param>
        /// <param name="latitude">Location latitude between -90 and 90 (Default: 0). (default to 0D).</param>
        /// <param name="longitude">Location longitude between -180 (west) and 180 (east) (Default: 0). (default to 0D).</param>
        /// <param name="timeZone">Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time..</param>
        /// <param name="elevation">A number for elevation of the location in meters. (Default: 0). (default to 0D).</param>
        /// <param name="stationId">ID of the location if the location is representing a weather station..</param>
        /// <param name="source">Source of data (e.g. TMY, TMY3)..</param>
        public Location
        (
            // Required parameters
           string city = "-", double latitude = 0D, double longitude = 0D, AnyOf<Autocalculate, double> timeZone= default, double elevation = 0D, string stationId= default, string source= default// Optional parameters
        ) : base()// BaseClass
        {
            // use default value if no "city" provided
            this.City = city ?? "-";
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.TimeZone = timeZone;
            this.Elevation = elevation;
            this.StationId = stationId;
            this.Source = source;

            // Set non-required readonly properties with defaultValue
            this.Type = "Location";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Location))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "Location";

        /// <summary>
        /// Name of the city as a string.
        /// </summary>
        /// <value>Name of the city as a string.</value>
        [Summary(@"Name of the city as a string.")]
        [DataMember(Name = "city")]
        public string City { get; set; }  = "-";
        /// <summary>
        /// Location latitude between -90 and 90 (Default: 0).
        /// </summary>
        /// <value>Location latitude between -90 and 90 (Default: 0).</value>
        [Summary(@"Location latitude between -90 and 90 (Default: 0).")]
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }  = 0D;
        /// <summary>
        /// Location longitude between -180 (west) and 180 (east) (Default: 0).
        /// </summary>
        /// <value>Location longitude between -180 (west) and 180 (east) (Default: 0).</value>
        [Summary(@"Location longitude between -180 (west) and 180 (east) (Default: 0).")]
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }  = 0D;
        /// <summary>
        /// Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time.
        /// </summary>
        /// <value>Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time.</value>
        [Summary(@"Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time.")]
        [DataMember(Name = "time_zone")]
        public AnyOf<Autocalculate, double> TimeZone { get; set; } 
        /// <summary>
        /// A number for elevation of the location in meters. (Default: 0).
        /// </summary>
        /// <value>A number for elevation of the location in meters. (Default: 0).</value>
        [Summary(@"A number for elevation of the location in meters. (Default: 0).")]
        [DataMember(Name = "elevation")]
        public double Elevation { get; set; }  = 0D;
        /// <summary>
        /// ID of the location if the location is representing a weather station.
        /// </summary>
        /// <value>ID of the location if the location is representing a weather station.</value>
        [Summary(@"ID of the location if the location is representing a weather station.")]
        [DataMember(Name = "station_id")]
        public string StationId { get; set; } 
        /// <summary>
        /// Source of data (e.g. TMY, TMY3).
        /// </summary>
        /// <value>Source of data (e.g. TMY, TMY3).</value>
        [Summary(@"Source of data (e.g. TMY, TMY3).")]
        [DataMember(Name = "source")]
        public string Source { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Location";
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
            sb.Append("Location:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  City: ").Append(this.City).Append("\n");
            sb.Append("  Latitude: ").Append(this.Latitude).Append("\n");
            sb.Append("  Longitude: ").Append(this.Longitude).Append("\n");
            sb.Append("  TimeZone: ").Append(this.TimeZone).Append("\n");
            sb.Append("  Elevation: ").Append(this.Elevation).Append("\n");
            sb.Append("  StationId: ").Append(this.StationId).Append("\n");
            sb.Append("  Source: ").Append(this.Source).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Location object</returns>
        public static Location FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Location>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Location object</returns>
        public virtual Location DuplicateLocation()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateLocation();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateLocation();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Location);
        }

        /// <summary>
        /// Returns true if Location instances are equal
        /// </summary>
        /// <param name="input">Instance of Location to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Location input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.City, input.City) && 
                    Extension.Equals(this.Latitude, input.Latitude) && 
                    Extension.Equals(this.Longitude, input.Longitude) && 
                    Extension.Equals(this.TimeZone, input.TimeZone) && 
                    Extension.Equals(this.Elevation, input.Elevation) && 
                    Extension.Equals(this.StationId, input.StationId) && 
                    Extension.Equals(this.Source, input.Source);
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
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.Latitude != null)
                    hashCode = hashCode * 59 + this.Latitude.GetHashCode();
                if (this.Longitude != null)
                    hashCode = hashCode * 59 + this.Longitude.GetHashCode();
                if (this.TimeZone != null)
                    hashCode = hashCode * 59 + this.TimeZone.GetHashCode();
                if (this.Elevation != null)
                    hashCode = hashCode * 59 + this.Elevation.GetHashCode();
                if (this.StationId != null)
                    hashCode = hashCode * 59 + this.StationId.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
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
            Regex regexType = new Regex(@"^Location$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
