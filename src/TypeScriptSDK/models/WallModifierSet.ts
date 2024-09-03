import { IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
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

/** Set containing radiance modifiers needed for a model's Walls. */
export class WallModifierSet extends _OpenAPIGenBaseModel {
    @IsOptional()
    /** A radiance modifier object for faces with an Outdoors boundary condition. */
    exterior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsOptional()
    /** A radiance modifier object for faces with a boundary condition other than Outdoors. */
    interior_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsString()
    @IsOptional()
    @Matches(/^WallModifierSet$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "WallModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WallModifierSet, _data);
            this.exterior_modifier = obj.exterior_modifier;
            this.interior_modifier = obj.interior_modifier;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): WallModifierSet {
        data = typeof data === 'object' ? data : {};

        let result = new WallModifierSet();
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
