/* 
 * Honeybee Energy Simulation Parameter Schema
 *
 * This is the documentation for Honeybee energy simulation parameter schema.
 *
 * The version of the OpenAPI document: 1.25.0
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
    /// Lists the outputs to report from the simulation and their format.
    /// </summary>
    [DataContract]
    public partial class SimulationOutput :  IEquatable<SimulationOutput>, IValidatableObject
    {

        /// <summary>
        /// Defines ReportingFrequency
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReportingFrequencyEnum
        {
            /// <summary>
            /// Enum Timestep for value: Timestep
            /// </summary>
            [EnumMember(Value = "Timestep")]
            Timestep = 1,

            /// <summary>
            /// Enum Hourly for value: Hourly
            /// </summary>
            [EnumMember(Value = "Hourly")]
            Hourly = 2,

            /// <summary>
            /// Enum Daily for value: Daily
            /// </summary>
            [EnumMember(Value = "Daily")]
            Daily = 3,

            /// <summary>
            /// Enum Monthly for value: Monthly
            /// </summary>
            [EnumMember(Value = "Monthly")]
            Monthly = 4,

            /// <summary>
            /// Enum Annual for value: Annual
            /// </summary>
            [EnumMember(Value = "Annual")]
            Annual = 5

        }

        /// <summary>
        /// Gets or Sets ReportingFrequency
        /// </summary>
        [DataMember(Name="reporting_frequency", EmitDefaultValue=false)]
        public ReportingFrequencyEnum? ReportingFrequency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationOutput" /> class.
        /// </summary>
        /// <param name="reportingFrequency">reportingFrequency (default to ReportingFrequencyEnum.Hourly).</param>
        /// <param name="includeSqlite">Boolean to note whether a SQLite report should be requested from the simulation. (default to true).</param>
        /// <param name="includeHtml">Boolean to note whether an HTML report should be requested from the simulation. (default to false).</param>
        /// <param name="outputs">A list of EnergyPlus output names as strings, which are requested from the simulation..</param>
        /// <param name="summaryReports">A list of EnergyPlus summary report names as strings..</param>
        public SimulationOutput
        (
            // Required parameters
            ReportingFrequencyEnum? reportingFrequency = ReportingFrequencyEnum.Hourly, bool includeSqlite = true, bool includeHtml = false, List<string> outputs= default, List<string> summaryReports= default// Optional parameters
        )// BaseClass
        {
            // use default value if no "reportingFrequency" provided
            if (reportingFrequency == null)
            {
                this.ReportingFrequency = ReportingFrequencyEnum.Hourly;
            }
            else
            {
                this.ReportingFrequency = reportingFrequency;
            }
            // use default value if no "includeSqlite" provided
            if (includeSqlite == null)
            {
                this.IncludeSqlite = true;
            }
            else
            {
                this.IncludeSqlite = includeSqlite;
            }
            // use default value if no "includeHtml" provided
            if (includeHtml == null)
            {
                this.IncludeHtml = false;
            }
            else
            {
                this.IncludeHtml = includeHtml;
            }
            this.Outputs = outputs;
            this.SummaryReports = summaryReports;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty("type")]
        public string Type { get; private set; } = "SimulationOutput"; 


        /// <summary>
        /// Boolean to note whether a SQLite report should be requested from the simulation.
        /// </summary>
        /// <value>Boolean to note whether a SQLite report should be requested from the simulation.</value>
        [DataMember(Name="include_sqlite", EmitDefaultValue=false)]
        [JsonProperty("include_sqlite")]
        public bool IncludeSqlite { get; set; }

        /// <summary>
        /// Boolean to note whether an HTML report should be requested from the simulation.
        /// </summary>
        /// <value>Boolean to note whether an HTML report should be requested from the simulation.</value>
        [DataMember(Name="include_html", EmitDefaultValue=false)]
        [JsonProperty("include_html")]
        public bool IncludeHtml { get; set; }

        /// <summary>
        /// A list of EnergyPlus output names as strings, which are requested from the simulation.
        /// </summary>
        /// <value>A list of EnergyPlus output names as strings, which are requested from the simulation.</value>
        [DataMember(Name="outputs", EmitDefaultValue=false)]
        [JsonProperty("outputs")]
        public List<string> Outputs { get; set; }

        /// <summary>
        /// A list of EnergyPlus summary report names as strings.
        /// </summary>
        /// <value>A list of EnergyPlus summary report names as strings.</value>
        [DataMember(Name="summary_reports", EmitDefaultValue=false)]
        [JsonProperty("summary_reports")]
        public List<string> SummaryReports { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimulationOutput {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ReportingFrequency: ").Append(ReportingFrequency).Append("\n");
            sb.Append("  IncludeSqlite: ").Append(IncludeSqlite).Append("\n");
            sb.Append("  IncludeHtml: ").Append(IncludeHtml).Append("\n");
            sb.Append("  Outputs: ").Append(Outputs).Append("\n");
            sb.Append("  SummaryReports: ").Append(SummaryReports).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AnyOfJsonConverter());
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SimulationOutput object</returns>
        public static SimulationOutput FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SimulationOutput>(json, new AnyOfJsonConverter());
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SimulationOutput);
        }

        /// <summary>
        /// Returns true if SimulationOutput instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulationOutput to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulationOutput input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.ReportingFrequency == input.ReportingFrequency ||
                    (this.ReportingFrequency != null &&
                    this.ReportingFrequency.Equals(input.ReportingFrequency))
                ) && 
                (
                    this.IncludeSqlite == input.IncludeSqlite ||
                    (this.IncludeSqlite != null &&
                    this.IncludeSqlite.Equals(input.IncludeSqlite))
                ) && 
                (
                    this.IncludeHtml == input.IncludeHtml ||
                    (this.IncludeHtml != null &&
                    this.IncludeHtml.Equals(input.IncludeHtml))
                ) && 
                (
                    this.Outputs == input.Outputs ||
                    this.Outputs != null &&
                    input.Outputs != null &&
                    this.Outputs.SequenceEqual(input.Outputs)
                ) && 
                (
                    this.SummaryReports == input.SummaryReports ||
                    this.SummaryReports != null &&
                    input.SummaryReports != null &&
                    this.SummaryReports.SequenceEqual(input.SummaryReports)
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
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.ReportingFrequency != null)
                    hashCode = hashCode * 59 + this.ReportingFrequency.GetHashCode();
                if (this.IncludeSqlite != null)
                    hashCode = hashCode * 59 + this.IncludeSqlite.GetHashCode();
                if (this.IncludeHtml != null)
                    hashCode = hashCode * 59 + this.IncludeHtml.GetHashCode();
                if (this.Outputs != null)
                    hashCode = hashCode * 59 + this.Outputs.GetHashCode();
                if (this.SummaryReports != null)
                    hashCode = hashCode * 59 + this.SummaryReports.GetHashCode();
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
            // Type (string) pattern
            Regex regexType = new Regex(@"^SimulationOutput$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
