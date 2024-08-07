import { IsOptional, IsString, validate, ValidationError } from 'class-validator';
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { Void } from "./Void";
import { Mirror } from "./Mirror";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Set containing radiance modifiers needed for a model's roofs. */
export class RoofCeilingModifierSet extends _OpenAPIGenBaseModel {
    @IsOptional()
    /** A radiance modifier object for faces with an Outdoors boundary condition. */
    exterior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A radiance modifier object for faces with a boundary condition other than Outdoors. */
    interior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "RoofCeilingModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.exterior_modifier = _data["exterior_modifier"];
            this.interior_modifier = _data["interior_modifier"];
            this.type = _data["type"] !== undefined ? _data["type"] : "RoofCeilingModifierSet";
        }
    }


    static override fromJS(data: any): RoofCeilingModifierSet {
        data = typeof data === 'object' ? data : {};

        let result = new RoofCeilingModifierSet();
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
        data["type"] = this.type;
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
