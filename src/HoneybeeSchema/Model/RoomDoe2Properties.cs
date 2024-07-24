/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.")]
    [Serializable]
    [DataContract(Name = "RoomDoe2Properties")]
    public partial class RoomDoe2Properties : OpenAPIGenBaseModel, IEquatable<RoomDoe2Properties>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomDoe2Properties" /> class.
        /// </summary>
        /// <param name="assignedFlow">A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP..</param>
        /// <param name="flowPerArea">A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP..</param>
        /// <param name="minFlowRatio">A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP..</param>
        /// <param name="minFlowPerArea">A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP..</param>
        /// <param name="hmaxFlowRatio">A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP..</param>
        /// <param name="spacePolygonGeometry">An optional horizontal Face3D object, which will be used to set the SPACE polygon during export to INP. If None, the SPACE polygon is auto-calculated from the 3D Room geometry. Specifying a geometry here can help overcome some limitations of this auto-calculation, particularly for cases where the floors of the Room are composed of AirBoundaries..</param>
        public RoomDoe2Properties
        (
            // Required parameters
           AnyOf<Autocalculate, double> assignedFlow= default, AnyOf<Autocalculate, double> flowPerArea= default, AnyOf<Autocalculate, double> minFlowRatio= default, AnyOf<Autocalculate, double> minFlowPerArea= default, AnyOf<Autocalculate, double> hmaxFlowRatio= default, Face3D spacePolygonGeometry= default// Optional parameters
        ) : base()// BaseClass
        {
            this.AssignedFlow = assignedFlow;
            this.FlowPerArea = flowPerArea;
            this.MinFlowRatio = minFlowRatio;
            this.MinFlowPerArea = minFlowPerArea;
            this.HmaxFlowRatio = hmaxFlowRatio;
            this.SpacePolygonGeometry = spacePolygonGeometry;

            // Set non-required readonly properties with defaultValue
            this.Type = "RoomDoe2Properties";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoomDoe2Properties))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "RoomDoe2Properties";

        /// <summary>
        /// A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP.
        /// </summary>
        /// <value>A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP.</value>
        [Summary(@"A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP.")]
        [DataMember(Name = "assigned_flow")]
        public AnyOf<Autocalculate, double> AssignedFlow { get; set; } 
        /// <summary>
        /// A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP.
        /// </summary>
        /// <value>A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP.</value>
        [Summary(@"A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP.")]
        [DataMember(Name = "flow_per_area")]
        public AnyOf<Autocalculate, double> FlowPerArea { get; set; } 
        /// <summary>
        /// A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP.
        /// </summary>
        /// <value>A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP.</value>
        [Summary(@"A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP.")]
        [DataMember(Name = "min_flow_ratio")]
        public AnyOf<Autocalculate, double> MinFlowRatio { get; set; } 
        /// <summary>
        /// A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP.
        /// </summary>
        /// <value>A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP.</value>
        [Summary(@"A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP.")]
        [DataMember(Name = "min_flow_per_area")]
        public AnyOf<Autocalculate, double> MinFlowPerArea { get; set; } 
        /// <summary>
        /// A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP.
        /// </summary>
        /// <value>A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP.</value>
        [Summary(@"A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP.")]
        [DataMember(Name = "hmax_flow_ratio")]
        public AnyOf<Autocalculate, double> HmaxFlowRatio { get; set; } 
        /// <summary>
        /// An optional horizontal Face3D object, which will be used to set the SPACE polygon during export to INP. If None, the SPACE polygon is auto-calculated from the 3D Room geometry. Specifying a geometry here can help overcome some limitations of this auto-calculation, particularly for cases where the floors of the Room are composed of AirBoundaries.
        /// </summary>
        /// <value>An optional horizontal Face3D object, which will be used to set the SPACE polygon during export to INP. If None, the SPACE polygon is auto-calculated from the 3D Room geometry. Specifying a geometry here can help overcome some limitations of this auto-calculation, particularly for cases where the floors of the Room are composed of AirBoundaries.</value>
        [Summary(@"An optional horizontal Face3D object, which will be used to set the SPACE polygon during export to INP. If None, the SPACE polygon is auto-calculated from the 3D Room geometry. Specifying a geometry here can help overcome some limitations of this auto-calculation, particularly for cases where the floors of the Room are composed of AirBoundaries.")]
        [DataMember(Name = "space_polygon_geometry")]
        public Face3D SpacePolygonGeometry { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoomDoe2Properties";
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
            sb.Append("RoomDoe2Properties:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  AssignedFlow: ").Append(this.AssignedFlow).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  MinFlowRatio: ").Append(this.MinFlowRatio).Append("\n");
            sb.Append("  MinFlowPerArea: ").Append(this.MinFlowPerArea).Append("\n");
            sb.Append("  HmaxFlowRatio: ").Append(this.HmaxFlowRatio).Append("\n");
            sb.Append("  SpacePolygonGeometry: ").Append(this.SpacePolygonGeometry).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoomDoe2Properties object</returns>
        public static RoomDoe2Properties FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoomDoe2Properties>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoomDoe2Properties object</returns>
        public virtual RoomDoe2Properties DuplicateRoomDoe2Properties()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateRoomDoe2Properties();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRoomDoe2Properties();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoomDoe2Properties);
        }

        /// <summary>
        /// Returns true if RoomDoe2Properties instances are equal
        /// </summary>
        /// <param name="input">Instance of RoomDoe2Properties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoomDoe2Properties input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.AssignedFlow, input.AssignedFlow) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.MinFlowRatio, input.MinFlowRatio) && 
                    Extension.Equals(this.MinFlowPerArea, input.MinFlowPerArea) && 
                    Extension.Equals(this.HmaxFlowRatio, input.HmaxFlowRatio) && 
                    Extension.Equals(this.SpacePolygonGeometry, input.SpacePolygonGeometry);
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
                if (this.AssignedFlow != null)
                    hashCode = hashCode * 59 + this.AssignedFlow.GetHashCode();
                if (this.FlowPerArea != null)
                    hashCode = hashCode * 59 + this.FlowPerArea.GetHashCode();
                if (this.MinFlowRatio != null)
                    hashCode = hashCode * 59 + this.MinFlowRatio.GetHashCode();
                if (this.MinFlowPerArea != null)
                    hashCode = hashCode * 59 + this.MinFlowPerArea.GetHashCode();
                if (this.HmaxFlowRatio != null)
                    hashCode = hashCode * 59 + this.HmaxFlowRatio.GetHashCode();
                if (this.SpacePolygonGeometry != null)
                    hashCode = hashCode * 59 + this.SpacePolygonGeometry.GetHashCode();
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
            Regex regexType = new Regex(@"^RoomDoe2Properties$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
