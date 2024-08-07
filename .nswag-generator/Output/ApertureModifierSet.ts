﻿import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Set containing radiance modifiers needed for a model's Apertures. */
export class ApertureModifierSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsOptional()
    /** A modifier object for apertures with an Outdoors boundary condition, False is_operable property, and Wall parent Face. */
    window_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A modifier object for apertures with a Surface boundary condition. */
    interior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A modifier object for apertures with an Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylight_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A modifier object for apertures with an Outdoors boundary condition and a True is_operable property. */
    operable_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	

    constructor() {
        super();
        this.type = "ApertureModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ApertureModifierSet";
            this.window_modifier = _data["window_modifier"];
            this.interior_modifier = _data["interior_modifier"];
            this.skylight_modifier = _data["skylight_modifier"];
            this.operable_modifier = _data["operable_modifier"];
        }
    }


    static override fromJS(data: any): ApertureModifierSet {
        data = typeof data === 'object' ? data : {};

        let result = new ApertureModifierSet();
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
        data["window_modifier"] = this.window_modifier;
        data["interior_modifier"] = this.interior_modifier;
        data["skylight_modifier"] = this.skylight_modifier;
        data["operable_modifier"] = this.operable_modifier;
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
