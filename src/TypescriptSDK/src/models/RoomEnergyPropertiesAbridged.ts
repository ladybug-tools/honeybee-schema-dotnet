import { IsString, IsOptional, Matches, MinLength, MaxLength, IsInstance, ValidateNested, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { DaylightingControl } from "./DaylightingControl";
import { ElectricEquipmentAbridged } from "./ElectricEquipmentAbridged";
import { GasEquipmentAbridged } from "./GasEquipmentAbridged";
import { InfiltrationAbridged } from "./InfiltrationAbridged";
import { InternalMassAbridged } from "./InternalMassAbridged";
import { LightingAbridged } from "./LightingAbridged";
import { PeopleAbridged } from "./PeopleAbridged";
import { ProcessAbridged } from "./ProcessAbridged";
import { ServiceHotWaterAbridged } from "./ServiceHotWaterAbridged";
import { SetpointAbridged } from "./SetpointAbridged";
import { VentilationAbridged } from "./VentilationAbridged";
import { VentilationControlAbridged } from "./VentilationControlAbridged";
import { VentilationFan } from "./VentilationFan";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class RoomEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RoomEnergyPropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RoomEnergyPropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "construction_set" })
    /** Identifier of a ConstructionSet to specify all default constructions for the Faces, Apertures, and Doors of the Room. If None, the Room will use the Model global_construction_set. */
    constructionSet?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "program_type" })
    /** Identifier of a ProgramType to specify all default schedules and loads for the Room. If None, the Room will have no loads or setpoints. */
    programType?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "hvac" })
    /** An optional identifier of a HVAC system (such as an IdealAirSystem) that specifies how the Room is conditioned. If None, it will be assumed that the Room is not conditioned. */
    hvac?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "shw" })
    /** An optional identifier of a Service Hot Water (SHW) system that specifies how the hot water load of the Room is met. If None, the hot water load will be met with a generic system that only measures thermal loadand does not account for system efficiencies. */
    shw?: string;
	
    @IsInstance(PeopleAbridged)
    @Type(() => PeopleAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "people" })
    /** People object to describe the occupancy of the Room. */
    people?: PeopleAbridged;
	
    @IsInstance(LightingAbridged)
    @Type(() => LightingAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "lighting" })
    /** Lighting object to describe the lighting usage of the Room. */
    lighting?: LightingAbridged;
	
    @IsInstance(ElectricEquipmentAbridged)
    @Type(() => ElectricEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "electric_equipment" })
    /** ElectricEquipment object to describe the electric equipment usage. */
    electricEquipment?: ElectricEquipmentAbridged;
	
    @IsInstance(GasEquipmentAbridged)
    @Type(() => GasEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "gas_equipment" })
    /** GasEquipment object to describe the gas equipment usage. */
    gasEquipment?: GasEquipmentAbridged;
	
    @IsInstance(ServiceHotWaterAbridged)
    @Type(() => ServiceHotWaterAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "service_hot_water" })
    /** ServiceHotWater object to describe the hot water usage. */
    serviceHotWater?: ServiceHotWaterAbridged;
	
    @IsInstance(InfiltrationAbridged)
    @Type(() => InfiltrationAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "infiltration" })
    /** Infiltration object to to describe the outdoor air leakage. */
    infiltration?: InfiltrationAbridged;
	
    @IsInstance(VentilationAbridged)
    @Type(() => VentilationAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "ventilation" })
    /** Ventilation object for the minimum outdoor air requirement. */
    ventilation?: VentilationAbridged;
	
    @IsInstance(SetpointAbridged)
    @Type(() => SetpointAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "setpoint" })
    /** Setpoint object for the temperature setpoints of the Room. */
    setpoint?: SetpointAbridged;
	
    @IsInstance(DaylightingControl)
    @Type(() => DaylightingControl)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "daylighting_control" })
    /** An optional DaylightingControl object to dictate the dimming of lights. If None, the lighting will respond only to the schedule and not the daylight conditions within the room. */
    daylightingControl?: DaylightingControl;
	
    @IsInstance(VentilationControlAbridged)
    @Type(() => VentilationControlAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "window_vent_control" })
    /** An optional VentilationControl object to dictate the opening of windows. If None, the windows will never open. */
    windowVentControl?: VentilationControlAbridged;
	
    @IsArray()
    @IsInstance(VentilationFan, { each: true })
    @Type(() => VentilationFan)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "fans" })
    /** An optional list of VentilationFan objects for fans within the room. Note that these fans are not connected to the heating or cooling system and are meant to represent the intentional circulation of unconditioned outdoor air for the purposes of keeping a space cooler, drier or free of indoor pollutants (as in the case of kitchen or bathroom exhaust fans). For the specification of mechanical ventilation of conditioned outdoor air, the Room.ventilation property should be used and the Room should be given a HVAC that can meet this specification. */
    fans?: VentilationFan[];
	
    @IsArray()
    @IsInstance(InternalMassAbridged, { each: true })
    @Type(() => InternalMassAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "internal_masses" })
    /** An optional list of of InternalMass objects for thermal mass exposed to Room air. Note that internal masses assigned this way cannot ""see"" solar radiation that may potentially hit them and, as such, caution should be taken when using this component with internal mass objects that are not always in shade. Masses are factored into the the thermal calculations of the Room by undergoing heat transfer with the indoor air. */
    internalMasses?: InternalMassAbridged[];
	
    @IsArray()
    @IsInstance(ProcessAbridged, { each: true })
    @Type(() => ProcessAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "process_loads" })
    /** An optional list of of Process objects for process loads within the room. These can represent kilns, manufacturing equipment, and various industrial processes. They can also be used to represent wood burning fireplaces or certain pieces of equipment to be separated from the other end uses. */
    processLoads?: ProcessAbridged[];
	

    constructor() {
        super();
        this.type = "RoomEnergyPropertiesAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoomEnergyPropertiesAbridged, _data);
        }
    }


    static override fromJS(data: any): RoomEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoomEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoomEnergyPropertiesAbridged";
        data["construction_set"] = this.constructionSet;
        data["program_type"] = this.programType;
        data["hvac"] = this.hvac;
        data["shw"] = this.shw;
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electricEquipment;
        data["gas_equipment"] = this.gasEquipment;
        data["service_hot_water"] = this.serviceHotWater;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
        data["daylighting_control"] = this.daylightingControl;
        data["window_vent_control"] = this.windowVentControl;
        data["fans"] = this.fans;
        data["internal_masses"] = this.internalMasses;
        data["process_loads"] = this.processLoads;
        data = super.toJSON(data);
        return instanceToPlain(data, { exposeUnsetFields: false });
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
