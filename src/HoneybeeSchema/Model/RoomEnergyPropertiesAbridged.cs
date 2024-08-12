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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [Serializable]
    [DataContract(Name = "RoomEnergyPropertiesAbridged")]
    public partial class RoomEnergyPropertiesAbridged : OpenAPIGenBaseModel, IEquatable<RoomEnergyPropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomEnergyPropertiesAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RoomEnergyPropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RoomEnergyPropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomEnergyPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="constructionSet">Identifier of a ConstructionSet to specify all default constructions for the Faces, Apertures, and Doors of the Room. If None, the Room will use the Model global_construction_set.</param>
        /// <param name="programType">Identifier of a ProgramType to specify all default schedules and loads for the Room. If None, the Room will have no loads or setpoints.</param>
        /// <param name="hvac">An optional identifier of a HVAC system (such as an IdealAirSystem) that specifies how the Room is conditioned. If None, it will be assumed that the Room is not conditioned.</param>
        /// <param name="shw">An optional identifier of a Service Hot Water (SHW) system that specifies how the hot water load of the Room is met. If None, the hot water load will be met with a generic system that only measures thermal loadand does not account for system efficiencies.</param>
        /// <param name="people">People object to describe the occupancy of the Room.</param>
        /// <param name="lighting">Lighting object to describe the lighting usage of the Room.</param>
        /// <param name="electricEquipment">ElectricEquipment object to describe the electric equipment usage.</param>
        /// <param name="gasEquipment">GasEquipment object to describe the gas equipment usage.</param>
        /// <param name="serviceHotWater">ServiceHotWater object to describe the hot water usage.</param>
        /// <param name="infiltration">Infiltration object to to describe the outdoor air leakage.</param>
        /// <param name="ventilation">Ventilation object for the minimum outdoor air requirement.</param>
        /// <param name="setpoint">Setpoint object for the temperature setpoints of the Room.</param>
        /// <param name="daylightingControl">An optional DaylightingControl object to dictate the dimming of lights. If None, the lighting will respond only to the schedule and not the daylight conditions within the room.</param>
        /// <param name="windowVentControl">An optional VentilationControl object to dictate the opening of windows. If None, the windows will never open.</param>
        /// <param name="fans">An optional list of VentilationFan objects for fans within the room. Note that these fans are not connected to the heating or cooling system and are meant to represent the intentional circulation of unconditioned outdoor air for the purposes of keeping a space cooler, drier or free of indoor pollutants (as in the case of kitchen or bathroom exhaust fans). For the specification of mechanical ventilation of conditioned outdoor air, the Room.ventilation property should be used and the Room should be given a HVAC that can meet this specification.</param>
        /// <param name="internalMasses">An optional list of of InternalMass objects for thermal mass exposed to Room air. Note that internal masses assigned this way cannot ""see"" solar radiation that may potentially hit them and, as such, caution should be taken when using this component with internal mass objects that are not always in shade. Masses are factored into the the thermal calculations of the Room by undergoing heat transfer with the indoor air.</param>
        /// <param name="processLoads">An optional list of of Process objects for process loads within the room. These can represent kilns, manufacturing equipment, and various industrial processes. They can also be used to represent wood burning fireplaces or certain pieces of equipment to be separated from the other end uses.</param>
        public RoomEnergyPropertiesAbridged
        (
            string constructionSet = default, string programType = default, string hvac = default, string shw = default, PeopleAbridged people = default, LightingAbridged lighting = default, ElectricEquipmentAbridged electricEquipment = default, GasEquipmentAbridged gasEquipment = default, ServiceHotWaterAbridged serviceHotWater = default, InfiltrationAbridged infiltration = default, VentilationAbridged ventilation = default, SetpointAbridged setpoint = default, DaylightingControl daylightingControl = default, VentilationControlAbridged windowVentControl = default, List<VentilationFan> fans = default, List<InternalMassAbridged> internalMasses = default, List<ProcessAbridged> processLoads = default
        ) : base()
        {
            this.ConstructionSet = constructionSet;
            this.ProgramType = programType;
            this.Hvac = hvac;
            this.Shw = shw;
            this.People = people;
            this.Lighting = lighting;
            this.ElectricEquipment = electricEquipment;
            this.GasEquipment = gasEquipment;
            this.ServiceHotWater = serviceHotWater;
            this.Infiltration = infiltration;
            this.Ventilation = ventilation;
            this.Setpoint = setpoint;
            this.DaylightingControl = daylightingControl;
            this.WindowVentControl = windowVentControl;
            this.Fans = fans;
            this.InternalMasses = internalMasses;
            this.ProcessLoads = processLoads;

            // Set readonly properties with defaultValue
            this.Type = "RoomEnergyPropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoomEnergyPropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier of a ConstructionSet to specify all default constructions for the Faces, Apertures, and Doors of the Room. If None, the Room will use the Model global_construction_set.
        /// </summary>
        [Summary(@"Identifier of a ConstructionSet to specify all default constructions for the Faces, Apertures, and Doors of the Room. If None, the Room will use the Model global_construction_set.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "construction_set")]
        public string ConstructionSet { get; set; }

        /// <summary>
        /// Identifier of a ProgramType to specify all default schedules and loads for the Room. If None, the Room will have no loads or setpoints.
        /// </summary>
        [Summary(@"Identifier of a ProgramType to specify all default schedules and loads for the Room. If None, the Room will have no loads or setpoints.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "program_type")]
        public string ProgramType { get; set; }

        /// <summary>
        /// An optional identifier of a HVAC system (such as an IdealAirSystem) that specifies how the Room is conditioned. If None, it will be assumed that the Room is not conditioned.
        /// </summary>
        [Summary(@"An optional identifier of a HVAC system (such as an IdealAirSystem) that specifies how the Room is conditioned. If None, it will be assumed that the Room is not conditioned.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "hvac")]
        public string Hvac { get; set; }

        /// <summary>
        /// An optional identifier of a Service Hot Water (SHW) system that specifies how the hot water load of the Room is met. If None, the hot water load will be met with a generic system that only measures thermal loadand does not account for system efficiencies.
        /// </summary>
        [Summary(@"An optional identifier of a Service Hot Water (SHW) system that specifies how the hot water load of the Room is met. If None, the hot water load will be met with a generic system that only measures thermal loadand does not account for system efficiencies.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "shw")]
        public string Shw { get; set; }

        /// <summary>
        /// People object to describe the occupancy of the Room.
        /// </summary>
        [Summary(@"People object to describe the occupancy of the Room.")]
        [DataMember(Name = "people")]
        public PeopleAbridged People { get; set; }

        /// <summary>
        /// Lighting object to describe the lighting usage of the Room.
        /// </summary>
        [Summary(@"Lighting object to describe the lighting usage of the Room.")]
        [DataMember(Name = "lighting")]
        public LightingAbridged Lighting { get; set; }

        /// <summary>
        /// ElectricEquipment object to describe the electric equipment usage.
        /// </summary>
        [Summary(@"ElectricEquipment object to describe the electric equipment usage.")]
        [DataMember(Name = "electric_equipment")]
        public ElectricEquipmentAbridged ElectricEquipment { get; set; }

        /// <summary>
        /// GasEquipment object to describe the gas equipment usage.
        /// </summary>
        [Summary(@"GasEquipment object to describe the gas equipment usage.")]
        [DataMember(Name = "gas_equipment")]
        public GasEquipmentAbridged GasEquipment { get; set; }

        /// <summary>
        /// ServiceHotWater object to describe the hot water usage.
        /// </summary>
        [Summary(@"ServiceHotWater object to describe the hot water usage.")]
        [DataMember(Name = "service_hot_water")]
        public ServiceHotWaterAbridged ServiceHotWater { get; set; }

        /// <summary>
        /// Infiltration object to to describe the outdoor air leakage.
        /// </summary>
        [Summary(@"Infiltration object to to describe the outdoor air leakage.")]
        [DataMember(Name = "infiltration")]
        public InfiltrationAbridged Infiltration { get; set; }

        /// <summary>
        /// Ventilation object for the minimum outdoor air requirement.
        /// </summary>
        [Summary(@"Ventilation object for the minimum outdoor air requirement.")]
        [DataMember(Name = "ventilation")]
        public VentilationAbridged Ventilation { get; set; }

        /// <summary>
        /// Setpoint object for the temperature setpoints of the Room.
        /// </summary>
        [Summary(@"Setpoint object for the temperature setpoints of the Room.")]
        [DataMember(Name = "setpoint")]
        public SetpointAbridged Setpoint { get; set; }

        /// <summary>
        /// An optional DaylightingControl object to dictate the dimming of lights. If None, the lighting will respond only to the schedule and not the daylight conditions within the room.
        /// </summary>
        [Summary(@"An optional DaylightingControl object to dictate the dimming of lights. If None, the lighting will respond only to the schedule and not the daylight conditions within the room.")]
        [DataMember(Name = "daylighting_control")]
        public DaylightingControl DaylightingControl { get; set; }

        /// <summary>
        /// An optional VentilationControl object to dictate the opening of windows. If None, the windows will never open.
        /// </summary>
        [Summary(@"An optional VentilationControl object to dictate the opening of windows. If None, the windows will never open.")]
        [DataMember(Name = "window_vent_control")]
        public VentilationControlAbridged WindowVentControl { get; set; }

        /// <summary>
        /// An optional list of VentilationFan objects for fans within the room. Note that these fans are not connected to the heating or cooling system and are meant to represent the intentional circulation of unconditioned outdoor air for the purposes of keeping a space cooler, drier or free of indoor pollutants (as in the case of kitchen or bathroom exhaust fans). For the specification of mechanical ventilation of conditioned outdoor air, the Room.ventilation property should be used and the Room should be given a HVAC that can meet this specification.
        /// </summary>
        [Summary(@"An optional list of VentilationFan objects for fans within the room. Note that these fans are not connected to the heating or cooling system and are meant to represent the intentional circulation of unconditioned outdoor air for the purposes of keeping a space cooler, drier or free of indoor pollutants (as in the case of kitchen or bathroom exhaust fans). For the specification of mechanical ventilation of conditioned outdoor air, the Room.ventilation property should be used and the Room should be given a HVAC that can meet this specification.")]
        [DataMember(Name = "fans")]
        public List<VentilationFan> Fans { get; set; }

        /// <summary>
        /// An optional list of of InternalMass objects for thermal mass exposed to Room air. Note that internal masses assigned this way cannot ""see"" solar radiation that may potentially hit them and, as such, caution should be taken when using this component with internal mass objects that are not always in shade. Masses are factored into the the thermal calculations of the Room by undergoing heat transfer with the indoor air.
        /// </summary>
        [Summary(@"An optional list of of InternalMass objects for thermal mass exposed to Room air. Note that internal masses assigned this way cannot ""see"" solar radiation that may potentially hit them and, as such, caution should be taken when using this component with internal mass objects that are not always in shade. Masses are factored into the the thermal calculations of the Room by undergoing heat transfer with the indoor air.")]
        [DataMember(Name = "internal_masses")]
        public List<InternalMassAbridged> InternalMasses { get; set; }

        /// <summary>
        /// An optional list of of Process objects for process loads within the room. These can represent kilns, manufacturing equipment, and various industrial processes. They can also be used to represent wood burning fireplaces or certain pieces of equipment to be separated from the other end uses.
        /// </summary>
        [Summary(@"An optional list of of Process objects for process loads within the room. These can represent kilns, manufacturing equipment, and various industrial processes. They can also be used to represent wood burning fireplaces or certain pieces of equipment to be separated from the other end uses.")]
        [DataMember(Name = "process_loads")]
        public List<ProcessAbridged> ProcessLoads { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoomEnergyPropertiesAbridged";
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
            sb.Append("RoomEnergyPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ConstructionSet: ").Append(this.ConstructionSet).Append("\n");
            sb.Append("  ProgramType: ").Append(this.ProgramType).Append("\n");
            sb.Append("  Hvac: ").Append(this.Hvac).Append("\n");
            sb.Append("  Shw: ").Append(this.Shw).Append("\n");
            sb.Append("  People: ").Append(this.People).Append("\n");
            sb.Append("  Lighting: ").Append(this.Lighting).Append("\n");
            sb.Append("  ElectricEquipment: ").Append(this.ElectricEquipment).Append("\n");
            sb.Append("  GasEquipment: ").Append(this.GasEquipment).Append("\n");
            sb.Append("  ServiceHotWater: ").Append(this.ServiceHotWater).Append("\n");
            sb.Append("  Infiltration: ").Append(this.Infiltration).Append("\n");
            sb.Append("  Ventilation: ").Append(this.Ventilation).Append("\n");
            sb.Append("  Setpoint: ").Append(this.Setpoint).Append("\n");
            sb.Append("  DaylightingControl: ").Append(this.DaylightingControl).Append("\n");
            sb.Append("  WindowVentControl: ").Append(this.WindowVentControl).Append("\n");
            sb.Append("  Fans: ").Append(this.Fans).Append("\n");
            sb.Append("  InternalMasses: ").Append(this.InternalMasses).Append("\n");
            sb.Append("  ProcessLoads: ").Append(this.ProcessLoads).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoomEnergyPropertiesAbridged object</returns>
        public static RoomEnergyPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoomEnergyPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoomEnergyPropertiesAbridged object</returns>
        public virtual RoomEnergyPropertiesAbridged DuplicateRoomEnergyPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRoomEnergyPropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoomEnergyPropertiesAbridged);
        }


        /// <summary>
        /// Returns true if RoomEnergyPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RoomEnergyPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoomEnergyPropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ConstructionSet, input.ConstructionSet) && 
                    Extension.Equals(this.ProgramType, input.ProgramType) && 
                    Extension.Equals(this.Hvac, input.Hvac) && 
                    Extension.Equals(this.Shw, input.Shw) && 
                    Extension.Equals(this.People, input.People) && 
                    Extension.Equals(this.Lighting, input.Lighting) && 
                    Extension.Equals(this.ElectricEquipment, input.ElectricEquipment) && 
                    Extension.Equals(this.GasEquipment, input.GasEquipment) && 
                    Extension.Equals(this.ServiceHotWater, input.ServiceHotWater) && 
                    Extension.Equals(this.Infiltration, input.Infiltration) && 
                    Extension.Equals(this.Ventilation, input.Ventilation) && 
                    Extension.Equals(this.Setpoint, input.Setpoint) && 
                    Extension.Equals(this.DaylightingControl, input.DaylightingControl) && 
                    Extension.Equals(this.WindowVentControl, input.WindowVentControl) && 
                    Extension.AllEquals(this.Fans, input.Fans) && 
                    Extension.AllEquals(this.InternalMasses, input.InternalMasses) && 
                    Extension.AllEquals(this.ProcessLoads, input.ProcessLoads);
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
                if (this.ConstructionSet != null)
                    hashCode = hashCode * 59 + this.ConstructionSet.GetHashCode();
                if (this.ProgramType != null)
                    hashCode = hashCode * 59 + this.ProgramType.GetHashCode();
                if (this.Hvac != null)
                    hashCode = hashCode * 59 + this.Hvac.GetHashCode();
                if (this.Shw != null)
                    hashCode = hashCode * 59 + this.Shw.GetHashCode();
                if (this.People != null)
                    hashCode = hashCode * 59 + this.People.GetHashCode();
                if (this.Lighting != null)
                    hashCode = hashCode * 59 + this.Lighting.GetHashCode();
                if (this.ElectricEquipment != null)
                    hashCode = hashCode * 59 + this.ElectricEquipment.GetHashCode();
                if (this.GasEquipment != null)
                    hashCode = hashCode * 59 + this.GasEquipment.GetHashCode();
                if (this.ServiceHotWater != null)
                    hashCode = hashCode * 59 + this.ServiceHotWater.GetHashCode();
                if (this.Infiltration != null)
                    hashCode = hashCode * 59 + this.Infiltration.GetHashCode();
                if (this.Ventilation != null)
                    hashCode = hashCode * 59 + this.Ventilation.GetHashCode();
                if (this.Setpoint != null)
                    hashCode = hashCode * 59 + this.Setpoint.GetHashCode();
                if (this.DaylightingControl != null)
                    hashCode = hashCode * 59 + this.DaylightingControl.GetHashCode();
                if (this.WindowVentControl != null)
                    hashCode = hashCode * 59 + this.WindowVentControl.GetHashCode();
                if (this.Fans != null)
                    hashCode = hashCode * 59 + this.Fans.GetHashCode();
                if (this.InternalMasses != null)
                    hashCode = hashCode * 59 + this.InternalMasses.GetHashCode();
                if (this.ProcessLoads != null)
                    hashCode = hashCode * 59 + this.ProcessLoads.GetHashCode();
                return hashCode;
            }
        }


    }
}
