import { IsOptional, IsArray, IsNumber, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance glass material. */
export class Glass extends ModifierBase {
    @IsOptional()
    /** Material modifier. */
    modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsArray()
    @IsOptional()
    /** List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. */
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) [];
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the red channel transmissivity. */
    r_transmissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the green channel transmissivity. */
    g_transmissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the blue channel transmissivity. */
    b_transmissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE. */
    refraction_index?: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.modifier = new Void();
        this.r_transmissivity = 0;
        this.g_transmissivity = 0;
        this.b_transmissivity = 0;
        this.refraction_index = 1.52;
        this.type = "Glass";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Glass, _data);
            this.modifier = obj.modifier;
            this.dependencies = obj.dependencies;
            this.r_transmissivity = obj.r_transmissivity;
            this.g_transmissivity = obj.g_transmissivity;
            this.b_transmissivity = obj.b_transmissivity;
            this.refraction_index = obj.refraction_index;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): Glass {
        data = typeof data === 'object' ? data : {};

        let result = new Glass();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["modifier"] = this.modifier;
        data["dependencies"] = this.dependencies;
        data["r_transmissivity"] = this.r_transmissivity;
        data["g_transmissivity"] = this.g_transmissivity;
        data["b_transmissivity"] = this.b_transmissivity;
        data["refraction_index"] = this.refraction_index;
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
