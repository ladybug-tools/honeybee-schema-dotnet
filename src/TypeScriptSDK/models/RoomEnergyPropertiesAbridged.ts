import { IsString, IsOptional, IsInstance, ValidateNested, IsArray, validate, ValidationError } from 'class-validator';
import { PeopleAbridged } from "./PeopleAbridged";
import { LightingAbridged } from "./LightingAbridged";
import { ElectricEquipmentAbridged } from "./ElectricEquipmentAbridged";
import { GasEquipmentAbridged } from "./GasEquipmentAbridged";
import { ServiceHotWaterAbridged } from "./ServiceHotWaterAbridged";
import { InfiltrationAbridged } from "./InfiltrationAbridged";
import { VentilationAbridged } from "./VentilationAbridged";
import { SetpointAbridged } from "./SetpointAbridged";
import { DaylightingControl } from "./DaylightingControl";
import { VentilationControlAbridged } from "./VentilationControlAbridged";
import { VentilationFan } from "./VentilationFan";
import { InternalMassAbridged } from "./InternalMassAbridged";
import { ProcessAbridged } from "./ProcessAbridged";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class RoomEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a ConstructionSet to specify all default constructions for the Faces, Apertures, and Doors of the Room. If None, the Room will use the Model global_construction_set. */
    construction_set?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a ProgramType to specify all default schedules and loads for the Room. If None, the Room will have no loads or setpoints. */
    program_type?: string;
	
    @IsString()
    @IsOptional()
    /** An optional identifier of a HVAC system (such as an IdealAirSystem) that specifies how the Room is conditioned. If None, it will be assumed that the Room is not conditioned. */
    hvac?: string;
	
    @IsString()
    @IsOptional()
    /** An optional identifier of a Service Hot Water (SHW) system that specifies how the hot water load of the Room is met. If None, the hot water load will be met with a generic system that only measures thermal loadand does not account for system efficiencies. */
    shw?: string;
	
    @IsInstance(PeopleAbridged)
    @ValidateNested()
    @IsOptional()
    /** People object to describe the occupancy of the Room. */
    people?: PeopleAbridged;
	
    @IsInstance(LightingAbridged)
    @ValidateNested()
    @IsOptional()
    /** Lighting object to describe the lighting usage of the Room. */
    lighting?: LightingAbridged;
	
    @IsInstance(ElectricEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    /** ElectricEquipment object to describe the electric equipment usage. */
    electric_equipment?: ElectricEquipmentAbridged;
	
    @IsInstance(GasEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    /** GasEquipment object to describe the gas equipment usage. */
    gas_equipment?: GasEquipmentAbridged;
	
    @IsInstance(ServiceHotWaterAbridged)
    @ValidateNested()
    @IsOptional()
    /** ServiceHotWater object to describe the hot water usage. */
    service_hot_water?: ServiceHotWaterAbridged;
	
    @IsInstance(InfiltrationAbridged)
    @ValidateNested()
    @IsOptional()
    /** Infiltration object to to describe the outdoor air leakage. */
    infiltration?: InfiltrationAbridged;
	
    @IsInstance(VentilationAbridged)
    @ValidateNested()
    @IsOptional()
    /** Ventilation object for the minimum outdoor air requirement. */
    ventilation?: VentilationAbridged;
	
    @IsInstance(SetpointAbridged)
    @ValidateNested()
    @IsOptional()
    /** Setpoint object for the temperature setpoints of the Room. */
    setpoint?: SetpointAbridged;
	
    @IsInstance(DaylightingControl)
    @ValidateNested()
    @IsOptional()
    /** An optional DaylightingControl object to dictate the dimming of lights. If None, the lighting will respond only to the schedule and not the daylight conditions within the room. */
    daylighting_control?: DaylightingControl;
	
    @IsInstance(VentilationControlAbridged)
    @ValidateNested()
    @IsOptional()
    /** An optional VentilationControl object to dictate the opening of windows. If None, the windows will never open. */
    window_vent_control?: VentilationControlAbridged;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of VentilationFan objects for fans within the room. Note that these fans are not connected to the heating or cooling system and are meant to represent the intentional circulation of unconditioned outdoor air for the purposes of keeping a space cooler, drier or free of indoor pollutants (as in the case of kitchen or bathroom exhaust fans). For the specification of mechanical ventilation of conditioned outdoor air, the Room.ventilation property should be used and the Room should be given a HVAC that can meet this specification. */
    fans?: VentilationFan [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of of InternalMass objects for thermal mass exposed to Room air. Note that internal masses assigned this way cannot "see" solar radiation that may potentially hit them and, as such, caution should be taken when using this component with internal mass objects that are not always in shade. Masses are factored into the the thermal calculations of the Room by undergoing heat transfer with the indoor air. */
    internal_masses?: InternalMassAbridged [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of of Process objects for process loads within the room. These can represent kilns, manufacturing equipment, and various industrial processes. They can also be used to represent wood burning fireplaces or certain pieces of equipment to be separated from the other end uses. */
    process_loads?: ProcessAbridged [];
	

    constructor() {
        super();
        this.type = "RoomEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "RoomEnergyPropertiesAbridged";
            this.construction_set = _data["construction_set"];
            this.program_type = _data["program_type"];
            this.hvac = _data["hvac"];
            this.shw = _data["shw"];
            this.people = _data["people"];
            this.lighting = _data["lighting"];
            this.electric_equipment = _data["electric_equipment"];
            this.gas_equipment = _data["gas_equipment"];
            this.service_hot_water = _data["service_hot_water"];
            this.infiltration = _data["infiltration"];
            this.ventilation = _data["ventilation"];
            this.setpoint = _data["setpoint"];
            this.daylighting_control = _data["daylighting_control"];
            this.window_vent_control = _data["window_vent_control"];
            this.fans = _data["fans"];
            this.internal_masses = _data["internal_masses"];
            this.process_loads = _data["process_loads"];
        }
    }


    static override fromJS(data: any): RoomEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new RoomEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["construction_set"] = this.construction_set;
        data["program_type"] = this.program_type;
        data["hvac"] = this.hvac;
        data["shw"] = this.shw;
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electric_equipment;
        data["gas_equipment"] = this.gas_equipment;
        data["service_hot_water"] = this.service_hot_water;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
        data["daylighting_control"] = this.daylighting_control;
        data["window_vent_control"] = this.window_vent_control;
        data["fans"] = this.fans;
        data["internal_masses"] = this.internal_masses;
        data["process_loads"] = this.process_loads;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
