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
    /// <summary>
    /// A Ladybug Location.
    /// </summary>
    [Summary(@"A Ladybug Location.")]
    [System.Serializable]
    [DataContract(Name = "Location")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Location : OpenAPIGenBaseModel, System.IEquatable<Location>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Location() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Location";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Location" /> class.
        /// </summary>
        /// <param name="city">Name of the city as a string.</param>
        /// <param name="latitude">Location latitude between -90 and 90 (Default: 0).</param>
        /// <param name="longitude">Location longitude between -180 (west) and 180 (east) (Default: 0).</param>
        /// <param name="timeZone">Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time.</param>
        /// <param name="elevation">A number for elevation of the location in meters. (Default: 0).</param>
        /// <param name="stationId">ID of the location if the location is representing a weather station.</param>
        /// <param name="source">Source of data (e.g. TMY, TMY3).</param>
        public Location
        (
            string city = "-", double latitude = 0D, double longitude = 0D, AnyOf<Autocalculate, int> timeZone = default, double elevation = 0D, string stationId = default, string source = default
        ) : base()
        {
            this.City = city ?? "-";
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.TimeZone = timeZone ?? new Autocalculate();
            this.Elevation = elevation;
            this.StationId = stationId;
            this.Source = source;

            // Set readonly properties with defaultValue
            this.Type = "Location";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Location))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Name of the city as a string.
        /// </summary>
        [Summary(@"Name of the city as a string.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "city")] // For internal Serialization XML/JSON
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("city")] // For System.Text.Json
        public string City { get; set; } = "-";

        /// <summary>
        /// Location latitude between -90 and 90 (Default: 0).
        /// </summary>
        [Summary(@"Location latitude between -90 and 90 (Default: 0).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "latitude")] // For internal Serialization XML/JSON
        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("latitude")] // For System.Text.Json
        public double Latitude { get; set; } = 0D;

        /// <summary>
        /// Location longitude between -180 (west) and 180 (east) (Default: 0).
        /// </summary>
        [Summary(@"Location longitude between -180 (west) and 180 (east) (Default: 0).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "longitude")] // For internal Serialization XML/JSON
        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("longitude")] // For System.Text.Json
        public double Longitude { get; set; } = 0D;

        /// <summary>
        /// Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time.
        /// </summary>
        [Summary(@"Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "time_zone")] // For internal Serialization XML/JSON
        [JsonProperty("time_zone", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("time_zone")] // For System.Text.Json
        public AnyOf<Autocalculate, int> TimeZone { get; set; } = new Autocalculate();

        /// <summary>
        /// A number for elevation of the location in meters. (Default: 0).
        /// </summary>
        [Summary(@"A number for elevation of the location in meters. (Default: 0).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "elevation")] // For internal Serialization XML/JSON
        [JsonProperty("elevation", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("elevation")] // For System.Text.Json
        public double Elevation { get; set; } = 0D;

        /// <summary>
        /// ID of the location if the location is representing a weather station.
        /// </summary>
        [Summary(@"ID of the location if the location is representing a weather station.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "station_id")] // For internal Serialization XML/JSON
        [JsonProperty("station_id", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("station_id")] // For System.Text.Json
        public string StationId { get; set; }

        /// <summary>
        /// Source of data (e.g. TMY, TMY3).
        /// </summary>
        [Summary(@"Source of data (e.g. TMY, TMY3).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "source")] // For internal Serialization XML/JSON
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("source")] // For System.Text.Json
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


    }
}
