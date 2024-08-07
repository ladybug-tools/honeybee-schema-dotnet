import { IsOptional, IsArray, ValidateNested, IsNumber, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { Void } from "./Void";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";

/** Radiance Light material. */
export class Light extends ModifierBase {
    @IsOptional()
    /** Material modifier. */
    modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. */
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) [];
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the red channel of the modifier. */
    r_emittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the green channel of the modifier. */
    g_emittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the blue channel of the modifier. */
    b_emittance?: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.modifier = new Void();
        this.r_emittance = 0;
        this.g_emittance = 0;
        this.b_emittance = 0;
        this.type = "Light";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.modifier = _data["modifier"] !== undefined ? _data["modifier"] : new Void();
            this.dependencies = _data["dependencies"];
            this.r_emittance = _data["r_emittance"] !== undefined ? _data["r_emittance"] : 0;
            this.g_emittance = _data["g_emittance"] !== undefined ? _data["g_emittance"] : 0;
            this.b_emittance = _data["b_emittance"] !== undefined ? _data["b_emittance"] : 0;
            this.type = _data["type"] !== undefined ? _data["type"] : "Light";
        }
    }


    static override fromJS(data: any): Light {
        data = typeof data === 'object' ? data : {};

        let result = new Light();
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
        data["r_emittance"] = this.r_emittance;
        data["g_emittance"] = this.g_emittance;
        data["b_emittance"] = this.b_emittance;
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
