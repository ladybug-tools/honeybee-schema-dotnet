﻿import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { BaseModifierSetAbridged } from "./BaseModifierSetAbridged";

/** Abridged set containing radiance modifiers needed for a model's Doors. */
export class DoorModifierSetAbridged extends BaseModifierSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^DoorModifierSetAbridged$/)
    /** Type */
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of modifier object for glass with a Surface boundary condition. */
    interior_glass_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of modifier object for glass with an Outdoors boundary condition. */
    exterior_glass_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face. */
    overhead_modifier?: string;
	

    constructor() {
        super();
        this.type = "DoorModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorModifierSetAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.interior_glass_modifier = obj.interior_glass_modifier;
            this.exterior_glass_modifier = obj.exterior_glass_modifier;
            this.overhead_modifier = obj.overhead_modifier;
        }
    }


    static override fromJS(data: any): DoorModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DoorModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["interior_glass_modifier"] = this.interior_glass_modifier;
        data["exterior_glass_modifier"] = this.exterior_glass_modifier;
        data["overhead_modifier"] = this.overhead_modifier;
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

