import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { ElectricEquipmentAbridged } from "./ElectricEquipmentAbridged";
import { GasEquipmentAbridged } from "./GasEquipmentAbridged";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { InfiltrationAbridged } from "./InfiltrationAbridged";
import { LightingAbridged } from "./LightingAbridged";
import { PeopleAbridged } from "./PeopleAbridged";
import { ServiceHotWaterAbridged } from "./ServiceHotWaterAbridged";
import { SetpointAbridged } from "./SetpointAbridged";
import { VentilationAbridged } from "./VentilationAbridged";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ProgramTypeAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ProgramTypeAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ProgramTypeAbridged";
	
    @IsInstance(PeopleAbridged)
    @Type(() => PeopleAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "people" })
    /** People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. */
    people?: PeopleAbridged;
	
    @IsInstance(LightingAbridged)
    @Type(() => LightingAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "lighting" })
    /** Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. */
    lighting?: LightingAbridged;
	
    @IsInstance(ElectricEquipmentAbridged)
    @Type(() => ElectricEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "electric_equipment" })
    /** ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. */
    electricEquipment?: ElectricEquipmentAbridged;
	
    @IsInstance(GasEquipmentAbridged)
    @Type(() => GasEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "gas_equipment" })
    /** GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. */
    gasEquipment?: GasEquipmentAbridged;
	
    @IsInstance(ServiceHotWaterAbridged)
    @Type(() => ServiceHotWaterAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "service_hot_water" })
    /** ServiceHotWater object to describe the usage of hot water within the program. If None, no hot water will be assumed. */
    serviceHotWater?: ServiceHotWaterAbridged;
	
    @IsInstance(InfiltrationAbridged)
    @Type(() => InfiltrationAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "infiltration" })
    /** Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. */
    infiltration?: InfiltrationAbridged;
	
    @IsInstance(VentilationAbridged)
    @Type(() => VentilationAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "ventilation" })
    /** Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. */
    ventilation?: VentilationAbridged;
	
    @IsInstance(SetpointAbridged)
    @Type(() => SetpointAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "setpoint" })
    /** Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned. */
    setpoint?: SetpointAbridged;
	

    constructor() {
        super();
        this.type = "ProgramTypeAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ProgramTypeAbridged, _data);
            this.type = obj.type ?? "ProgramTypeAbridged";
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


    static override fromJS(data: any): ProgramTypeAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ProgramTypeAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ProgramTypeAbridged";
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electricEquipment;
        data["gas_equipment"] = this.gasEquipment;
        data["service_hot_water"] = this.serviceHotWater;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
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
