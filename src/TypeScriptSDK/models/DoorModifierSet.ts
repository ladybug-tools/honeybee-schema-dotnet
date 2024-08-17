﻿import { IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Set containing radiance modifiers needed for a model's Doors. */
export class DoorModifierSet extends OpenAPIGenBaseModel {
    @IsOptional()
    /** A radiance modifier object for faces with an Outdoors boundary condition. */
    exterior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A radiance modifier object for faces with a boundary condition other than Outdoors. */
    interior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A modifier object for glass with a Surface boundary condition. */
    interior_glass_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A modifier object for glass with an Outdoors boundary condition. */
    exterior_glass_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face. */
    overhead_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "DoorModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.exterior_modifier = _data["exterior_modifier"];
            this.interior_modifier = _data["interior_modifier"];
            this.interior_glass_modifier = _data["interior_glass_modifier"];
            this.exterior_glass_modifier = _data["exterior_glass_modifier"];
            this.overhead_modifier = _data["overhead_modifier"];
            this.type = _data["type"] !== undefined ? _data["type"] : "DoorModifierSet";
        }
    }


    static override fromJS(data: any): DoorModifierSet {
        data = typeof data === 'object' ? data : {};

        let result = new DoorModifierSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["exterior_modifier"] = this.exterior_modifier;
        data["interior_modifier"] = this.interior_modifier;
        data["interior_glass_modifier"] = this.interior_glass_modifier;
        data["exterior_glass_modifier"] = this.exterior_glass_modifier;
        data["overhead_modifier"] = this.overhead_modifier;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
