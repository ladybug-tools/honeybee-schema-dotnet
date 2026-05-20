import { IsString, IsOptional, Equals, IsInstance, ValidateNested, IsDefined, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { ElectricEquipmentAbridged } from "./ElectricEquipmentAbridged";
import { GasEquipmentAbridged } from "./GasEquipmentAbridged";
import { InfiltrationAbridged } from "./InfiltrationAbridged";
import { LightingAbridged } from "./LightingAbridged";
import { PeopleAbridged } from "./PeopleAbridged";
import { ServiceHotWaterAbridged } from "./ServiceHotWaterAbridged";
import { SetpointAbridged } from "./SetpointAbridged";
import { VentilationAbridged } from "./VentilationAbridged";

export class ProgramType {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ProgramType")
    @Expose({ name: "type" })
    /** type */
    type: string = "ProgramType";
	
    @Type(() => PeopleAbridged)
    @IsInstance(PeopleAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "people" })
    /** People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. */
    people?: PeopleAbridged;
	
    @Type(() => LightingAbridged)
    @IsInstance(LightingAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "lighting" })
    /** Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. */
    lighting?: LightingAbridged;
	
    @Type(() => ElectricEquipmentAbridged)
    @IsInstance(ElectricEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "electric_equipment" })
    /** ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. */
    electricEquipment?: ElectricEquipmentAbridged;
	
    @Type(() => GasEquipmentAbridged)
    @IsInstance(GasEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "gas_equipment" })
    /** GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. */
    gasEquipment?: GasEquipmentAbridged;
	
    @Type(() => ServiceHotWaterAbridged)
    @IsInstance(ServiceHotWaterAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "service_hot_water" })
    /** ServiceHotWater object to describe the usage of hot water within the program. If None, no hot water will be assumed. */
    serviceHotWater?: ServiceHotWaterAbridged;
	
    @Type(() => InfiltrationAbridged)
    @IsInstance(InfiltrationAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "infiltration" })
    /** Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. */
    infiltration?: InfiltrationAbridged;
	
    @Type(() => VentilationAbridged)
    @IsInstance(VentilationAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "ventilation" })
    /** Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. */
    ventilation?: VentilationAbridged;
	
    @Type(() => SetpointAbridged)
    @IsInstance(SetpointAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "setpoint" })
    /** Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned. */
    setpoint?: SetpointAbridged;
	
    @IsOptional()
    @Expose({ name: "user_data" })
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    userData?: Object;
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "identifier" })
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    identifier!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	

    constructor() {
        this.type = "ProgramType";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ProgramType, _data);
            this.type = obj.type ?? "ProgramType";
            this.people = obj.people;
            this.lighting = obj.lighting;
            this.electricEquipment = obj.electricEquipment;
            this.gasEquipment = obj.gasEquipment;
            this.serviceHotWater = obj.serviceHotWater;
            this.infiltration = obj.infiltration;
            this.ventilation = obj.ventilation;
            this.setpoint = obj.setpoint;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): ProgramType {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ProgramType();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ProgramType";
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electricEquipment;
        data["gas_equipment"] = this.gasEquipment;
        data["service_hot_water"] = this.serviceHotWater;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
        data["user_data"] = this.userData;
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
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
