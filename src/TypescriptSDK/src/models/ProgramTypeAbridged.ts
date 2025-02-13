import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
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
    /** Type */
    type?: string;
	
    @IsInstance(PeopleAbridged)
    @Type(() => PeopleAbridged)
    @ValidateNested()
    @IsOptional()
    /** People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. */
    people?: PeopleAbridged;
	
    @IsInstance(LightingAbridged)
    @Type(() => LightingAbridged)
    @ValidateNested()
    @IsOptional()
    /** Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. */
    lighting?: LightingAbridged;
	
    @IsInstance(ElectricEquipmentAbridged)
    @Type(() => ElectricEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    /** ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. */
    electric_equipment?: ElectricEquipmentAbridged;
	
    @IsInstance(GasEquipmentAbridged)
    @Type(() => GasEquipmentAbridged)
    @ValidateNested()
    @IsOptional()
    /** GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. */
    gas_equipment?: GasEquipmentAbridged;
	
    @IsInstance(ServiceHotWaterAbridged)
    @Type(() => ServiceHotWaterAbridged)
    @ValidateNested()
    @IsOptional()
    /** ServiceHotWater object to describe the usage of hot water within the program. If None, no hot water will be assumed. */
    service_hot_water?: ServiceHotWaterAbridged;
	
    @IsInstance(InfiltrationAbridged)
    @Type(() => InfiltrationAbridged)
    @ValidateNested()
    @IsOptional()
    /** Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. */
    infiltration?: InfiltrationAbridged;
	
    @IsInstance(VentilationAbridged)
    @Type(() => VentilationAbridged)
    @ValidateNested()
    @IsOptional()
    /** Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. */
    ventilation?: VentilationAbridged;
	
    @IsInstance(SetpointAbridged)
    @Type(() => SetpointAbridged)
    @ValidateNested()
    @IsOptional()
    /** Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned. */
    setpoint?: SetpointAbridged;
	

    constructor() {
        super();
        this.type = "ProgramTypeAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ProgramTypeAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.people = obj.people;
            this.lighting = obj.lighting;
            this.electric_equipment = obj.electric_equipment;
            this.gas_equipment = obj.gas_equipment;
            this.service_hot_water = obj.service_hot_water;
            this.infiltration = obj.infiltration;
            this.ventilation = obj.ventilation;
            this.setpoint = obj.setpoint;
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
        data["type"] = this.type;
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electric_equipment;
        data["gas_equipment"] = this.gas_equipment;
        data["service_hot_water"] = this.service_hot_water;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
        data = super.toJSON(data);
        return instanceToPlain(data);
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

