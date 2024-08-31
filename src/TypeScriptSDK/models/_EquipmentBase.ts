﻿import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class _EquipmentBase extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** Equipment level per floor area as [W/m2]. */
    watts_per_area!: number;
	
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. */
    schedule!: string;
	
    @IsNumber()
    @IsOptional()
    /** Number for the amount of long-wave radiation heat given off by equipment. Default value is 0. */
    radiant_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** Number for the amount of latent heat given off by equipment. Default value is 0. */
    latent_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** Number for the amount of “lost” heat being given off by equipment. The default value is 0. */
    lost_fraction?: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.radiant_fraction = 0;
        this.latent_fraction = 0;
        this.lost_fraction = 0;
        this.type = "_EquipmentBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_EquipmentBase, _data);
            this.watts_per_area = obj.watts_per_area;
            this.schedule = obj.schedule;
            this.radiant_fraction = obj.radiant_fraction;
            this.latent_fraction = obj.latent_fraction;
            this.lost_fraction = obj.lost_fraction;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _EquipmentBase {
        data = typeof data === 'object' ? data : {};

        let result = new _EquipmentBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["watts_per_area"] = this.watts_per_area;
        data["schedule"] = this.schedule;
        data["radiant_fraction"] = this.radiant_fraction;
        data["latent_fraction"] = this.latent_fraction;
        data["lost_fraction"] = this.lost_fraction;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
