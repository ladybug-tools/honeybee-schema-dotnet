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
    [DataContract(Name = "View")]
    public partial class View : RadianceAsset, System.IEquatable<View>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="View" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected View() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "View";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="View" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="position">The view position (-vp) as an array of (x, y, z) values.This is the focal point of a perspective view or the center of a parallel projection.</param>
        /// <param name="direction">The view direction (-vd) as an array of (x, y, z) values.The length of this vector indicates the focal distance as needed by the pixel depth of field (-pd) in rpict.</param>
        /// <param name="upVector">The view up (-vu) vector as an array of (x, y, z) values.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="roomIdentifier">Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.</param>
        /// <param name="lightPath">Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.</param>
        /// <param name="viewType">ViewType</param>
        /// <param name="hSize">A number for the horizontal field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates.</param>
        /// <param name="vSize">A number for the vertical field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates.</param>
        /// <param name="shift">The view shift (-vs). This is the amount the actual image will be shifted to the right of the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well.</param>
        /// <param name="lift">The view lift (-vl). This is the amount the actual image will be lifted up from the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well.</param>
        /// <param name="foreClip">View fore clip (-vo) at a distance from the view point.The plane will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with fore_clip radius. Objects in front of this imaginary surface will not be visible.</param>
        /// <param name="aftClip">View aft clip (-va) at a distance from the view point.Like the view fore plane, it will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with radius val.</param>
        /// <param name="groupIdentifier">An optional string to note the view group '             'to which the sensor is a part of. Views sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None).</param>
        public View
        (
            string identifier, List<double> position, List<double> direction, List<double> upVector, string displayName = default, string roomIdentifier = default, List<List<string>> lightPath = default, ViewType viewType = ViewType.V, double hSize = 60D, double vSize = 60D, double shift = default, double lift = default, double foreClip = default, double aftClip = default, string groupIdentifier = default
        ) : base(identifier: identifier, displayName: displayName, roomIdentifier: roomIdentifier, lightPath: lightPath)
        {
            this.Position = position ?? throw new System.ArgumentNullException("position is a required property for View and cannot be null");
            this.Direction = direction ?? throw new System.ArgumentNullException("direction is a required property for View and cannot be null");
            this.UpVector = upVector ?? throw new System.ArgumentNullException("upVector is a required property for View and cannot be null");
            this.ViewType = viewType;
            this.HSize = hSize;
            this.VSize = vSize;
            this.Shift = shift;
            this.Lift = lift;
            this.ForeClip = foreClip;
            this.AftClip = aftClip;
            this.GroupIdentifier = groupIdentifier;

            // Set readonly properties with defaultValue
            this.Type = "View";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(View))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The view position (-vp) as an array of (x, y, z) values.This is the focal point of a perspective view or the center of a parallel projection.
        /// </summary>
        [Summary(@"The view position (-vp) as an array of (x, y, z) values.This is the focal point of a perspective view or the center of a parallel projection.")]
        [Required]
        [DataMember(Name = "position", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("position")] // For System.Text.Json
        public List<double> Position { get; set; }

        /// <summary>
        /// The view direction (-vd) as an array of (x, y, z) values.The length of this vector indicates the focal distance as needed by the pixel depth of field (-pd) in rpict.
        /// </summary>
        [Summary(@"The view direction (-vd) as an array of (x, y, z) values.The length of this vector indicates the focal distance as needed by the pixel depth of field (-pd) in rpict.")]
        [Required]
        [DataMember(Name = "direction", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("direction")] // For System.Text.Json
        public List<double> Direction { get; set; }

        /// <summary>
        /// The view up (-vu) vector as an array of (x, y, z) values.
        /// </summary>
        [Summary(@"The view up (-vu) vector as an array of (x, y, z) values.")]
        [Required]
        [DataMember(Name = "up_vector", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("up_vector")] // For System.Text.Json
        public List<double> UpVector { get; set; }

        /// <summary>
        /// ViewType
        /// </summary>
        [Summary(@"ViewType")]
        [DataMember(Name = "view_type")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("view_type")] // For System.Text.Json
        public ViewType ViewType { get; set; } = ViewType.V;

        /// <summary>
        /// A number for the horizontal field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates.
        /// </summary>
        [Summary(@"A number for the horizontal field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates.")]
        [DataMember(Name = "h_size")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("h_size")] // For System.Text.Json
        public double HSize { get; set; } = 60D;

        /// <summary>
        /// A number for the vertical field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates.
        /// </summary>
        [Summary(@"A number for the vertical field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates.")]
        [DataMember(Name = "v_size")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("v_size")] // For System.Text.Json
        public double VSize { get; set; } = 60D;

        /// <summary>
        /// The view shift (-vs). This is the amount the actual image will be shifted to the right of the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well.
        /// </summary>
        [Summary(@"The view shift (-vs). This is the amount the actual image will be shifted to the right of the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well.")]
        [DataMember(Name = "shift")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("shift")] // For System.Text.Json
        public double Shift { get; set; }

        /// <summary>
        /// The view lift (-vl). This is the amount the actual image will be lifted up from the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well.
        /// </summary>
        [Summary(@"The view lift (-vl). This is the amount the actual image will be lifted up from the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well.")]
        [DataMember(Name = "lift")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("lift")] // For System.Text.Json
        public double Lift { get; set; }

        /// <summary>
        /// View fore clip (-vo) at a distance from the view point.The plane will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with fore_clip radius. Objects in front of this imaginary surface will not be visible.
        /// </summary>
        [Summary(@"View fore clip (-vo) at a distance from the view point.The plane will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with fore_clip radius. Objects in front of this imaginary surface will not be visible.")]
        [DataMember(Name = "fore_clip")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("fore_clip")] // For System.Text.Json
        public double ForeClip { get; set; }

        /// <summary>
        /// View aft clip (-va) at a distance from the view point.Like the view fore plane, it will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with radius val.
        /// </summary>
        [Summary(@"View aft clip (-va) at a distance from the view point.Like the view fore plane, it will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with radius val.")]
        [DataMember(Name = "aft_clip")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("aft_clip")] // For System.Text.Json
        public double AftClip { get; set; }

        /// <summary>
        /// An optional string to note the view group '             'to which the sensor is a part of. Views sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None).
        /// </summary>
        [Summary(@"An optional string to note the view group '             'to which the sensor is a part of. Views sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None).")]
        [DataMember(Name = "group_identifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("group_identifier")] // For System.Text.Json
        public string GroupIdentifier { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "View";
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
            sb.Append("View:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Position: ").Append(this.Position).Append("\n");
            sb.Append("  Direction: ").Append(this.Direction).Append("\n");
            sb.Append("  UpVector: ").Append(this.UpVector).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  RoomIdentifier: ").Append(this.RoomIdentifier).Append("\n");
            sb.Append("  LightPath: ").Append(this.LightPath).Append("\n");
            sb.Append("  ViewType: ").Append(this.ViewType).Append("\n");
            sb.Append("  HSize: ").Append(this.HSize).Append("\n");
            sb.Append("  VSize: ").Append(this.VSize).Append("\n");
            sb.Append("  Shift: ").Append(this.Shift).Append("\n");
            sb.Append("  Lift: ").Append(this.Lift).Append("\n");
            sb.Append("  ForeClip: ").Append(this.ForeClip).Append("\n");
            sb.Append("  AftClip: ").Append(this.AftClip).Append("\n");
            sb.Append("  GroupIdentifier: ").Append(this.GroupIdentifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>View object</returns>
        public static View FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<View>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>View object</returns>
        public virtual View DuplicateView()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadianceAsset</returns>
        public override RadianceAsset DuplicateRadianceAsset()
        {
            return DuplicateView();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as View);
        }


        /// <summary>
        /// Returns true if View instances are equal
        /// </summary>
        /// <param name="input">Instance of View to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(View input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Position, input.Position) && 
                    Extension.AllEquals(this.Direction, input.Direction) && 
                    Extension.AllEquals(this.UpVector, input.UpVector) && 
                    Extension.Equals(this.ViewType, input.ViewType) && 
                    Extension.Equals(this.HSize, input.HSize) && 
                    Extension.Equals(this.VSize, input.VSize) && 
                    Extension.Equals(this.Shift, input.Shift) && 
                    Extension.Equals(this.Lift, input.Lift) && 
                    Extension.Equals(this.ForeClip, input.ForeClip) && 
                    Extension.Equals(this.AftClip, input.AftClip) && 
                    Extension.Equals(this.GroupIdentifier, input.GroupIdentifier);
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
                if (this.Position != null)
                    hashCode = hashCode * 59 + this.Position.GetHashCode();
                if (this.Direction != null)
                    hashCode = hashCode * 59 + this.Direction.GetHashCode();
                if (this.UpVector != null)
                    hashCode = hashCode * 59 + this.UpVector.GetHashCode();
                if (this.ViewType != null)
                    hashCode = hashCode * 59 + this.ViewType.GetHashCode();
                if (this.HSize != null)
                    hashCode = hashCode * 59 + this.HSize.GetHashCode();
                if (this.VSize != null)
                    hashCode = hashCode * 59 + this.VSize.GetHashCode();
                if (this.Shift != null)
                    hashCode = hashCode * 59 + this.Shift.GetHashCode();
                if (this.Lift != null)
                    hashCode = hashCode * 59 + this.Lift.GetHashCode();
                if (this.ForeClip != null)
                    hashCode = hashCode * 59 + this.ForeClip.GetHashCode();
                if (this.AftClip != null)
                    hashCode = hashCode * 59 + this.AftClip.GetHashCode();
                if (this.GroupIdentifier != null)
                    hashCode = hashCode * 59 + this.GroupIdentifier.GetHashCode();
                return hashCode;
            }
        }


    }
}
