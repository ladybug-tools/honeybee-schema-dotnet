/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
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
    /// A grid of sensors.
    /// </summary>
    [Summary(@"A grid of sensors.")]
    [Serializable]
    [DataContract(Name = "SensorGrid")]
    public partial class SensorGrid : RadianceAsset, IEquatable<SensorGrid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SensorGrid" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SensorGrid() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SensorGrid";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SensorGrid" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="sensors">A list of sensors that belong to the grid.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="roomIdentifier">Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.</param>
        /// <param name="lightPath">Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.</param>
        /// <param name="mesh">An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D.</param>
        /// <param name="baseGeometry">An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized.</param>
        /// <param name="groupIdentifier">An optional string to note the sensor grid group '             'to which the sensor is a part of. Grids sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None).</param>
        public SensorGrid
        (
            string identifier, List<Sensor> sensors, string displayName = default, string roomIdentifier = default, List<List<string>> lightPath = default, Mesh3D mesh = default, List<Face3D> baseGeometry = default, string groupIdentifier = default
        ) : base(identifier: identifier, displayName: displayName, roomIdentifier: roomIdentifier, lightPath: lightPath)
        {
            this.Sensors = sensors ?? throw new ArgumentNullException("sensors is a required property for SensorGrid and cannot be null");
            this.Mesh = mesh;
            this.BaseGeometry = baseGeometry;
            this.GroupIdentifier = groupIdentifier;

            // Set readonly properties with defaultValue
            this.Type = "SensorGrid";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SensorGrid))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of sensors that belong to the grid.
        /// </summary>
        [Summary(@"A list of sensors that belong to the grid.")]
        [Required]
        [DataMember(Name = "sensors", IsRequired = true)]
        public List<Sensor> Sensors { get; set; }

        /// <summary>
        /// An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D.
        /// </summary>
        [Summary(@"An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D.")]
        [DataMember(Name = "mesh")]
        public Mesh3D Mesh { get; set; }

        /// <summary>
        /// An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized.
        /// </summary>
        [Summary(@"An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized.")]
        [DataMember(Name = "base_geometry")]
        public List<Face3D> BaseGeometry { get; set; }

        /// <summary>
        /// An optional string to note the sensor grid group '             'to which the sensor is a part of. Grids sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None).
        /// </summary>
        [Summary(@"An optional string to note the sensor grid group '             'to which the sensor is a part of. Grids sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None).")]
        [DataMember(Name = "group_identifier")]
        public string GroupIdentifier { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SensorGrid";
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
            sb.Append("SensorGrid:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Sensors: ").Append(this.Sensors).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  RoomIdentifier: ").Append(this.RoomIdentifier).Append("\n");
            sb.Append("  LightPath: ").Append(this.LightPath).Append("\n");
            sb.Append("  Mesh: ").Append(this.Mesh).Append("\n");
            sb.Append("  BaseGeometry: ").Append(this.BaseGeometry).Append("\n");
            sb.Append("  GroupIdentifier: ").Append(this.GroupIdentifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SensorGrid object</returns>
        public static SensorGrid FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SensorGrid>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SensorGrid object</returns>
        public virtual SensorGrid DuplicateSensorGrid()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadianceAsset</returns>
        public override RadianceAsset DuplicateRadianceAsset()
        {
            return DuplicateSensorGrid();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SensorGrid);
        }


        /// <summary>
        /// Returns true if SensorGrid instances are equal
        /// </summary>
        /// <param name="input">Instance of SensorGrid to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SensorGrid input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Sensors, input.Sensors) && 
                    Extension.Equals(this.Mesh, input.Mesh) && 
                    Extension.AllEquals(this.BaseGeometry, input.BaseGeometry) && 
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
                if (this.Sensors != null)
                    hashCode = hashCode * 59 + this.Sensors.GetHashCode();
                if (this.Mesh != null)
                    hashCode = hashCode * 59 + this.Mesh.GetHashCode();
                if (this.BaseGeometry != null)
                    hashCode = hashCode * 59 + this.BaseGeometry.GetHashCode();
                if (this.GroupIdentifier != null)
                    hashCode = hashCode * 59 + this.GroupIdentifier.GetHashCode();
                return hashCode;
            }
        }


    }
}
