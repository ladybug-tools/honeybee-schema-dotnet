import { IsOptional, IsArray, ValidateNested, IsNumber, IsString, validate, ValidationError } from 'class-validator';
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Void } from "./Void";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";

/** Radiance metal material. */
export class Metal extends ModifierBase {
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
    /** A value between 0 and 1 for the red channel reflectance. */
    r_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the green channel reflectance. */
    g_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the blue channel reflectance. */
    b_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the fraction of specularity. Specularity fractions lower than 0.9 are not realistic for metallic materials. */
    specularity?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic. */
    roughness?: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.modifier = new Void();
        this.r_reflectance = 0;
        this.g_reflectance = 0;
        this.b_reflectance = 0;
        this.specularity = 0.9;
        this.roughness = 0;
        this.type = "Metal";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.modifier = _data["modifier"] !== undefined ? _data["modifier"] : new Void();
            this.dependencies = _data["dependencies"];
            this.r_reflectance = _data["r_reflectance"] !== undefined ? _data["r_reflectance"] : 0;
            this.g_reflectance = _data["g_reflectance"] !== undefined ? _data["g_reflectance"] : 0;
            this.b_reflectance = _data["b_reflectance"] !== undefined ? _data["b_reflectance"] : 0;
            this.specularity = _data["specularity"] !== undefined ? _data["specularity"] : 0.9;
            this.roughness = _data["roughness"] !== undefined ? _data["roughness"] : 0;
            this.type = _data["type"] !== undefined ? _data["type"] : "Metal";
        }
    }


    static override fromJS(data: any): Metal {
        data = typeof data === 'object' ? data : {};

        let result = new Metal();
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
        data["r_reflectance"] = this.r_reflectance;
        data["g_reflectance"] = this.g_reflectance;
        data["b_reflectance"] = this.b_reflectance;
        data["specularity"] = this.specularity;
        data["roughness"] = this.roughness;
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
