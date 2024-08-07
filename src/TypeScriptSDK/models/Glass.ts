import { IsOptional, IsArray, ValidateNested, IsNumber, IsString, validate, ValidationError } from 'class-validator';
import { Plastic } from "./Plastic";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { Void } from "./Void";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";

/** Radiance glass material. */
export class Glass extends ModifierBase {
    @IsOptional()
    /** Material modifier. */
    modifier?: Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. */
    dependencies?: None [];
	
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
            this.modifier = _data["modifier"] !== undefined ? _data["modifier"] : new Void();
            this.dependencies = _data["dependencies"];
            this.r_transmissivity = _data["r_transmissivity"] !== undefined ? _data["r_transmissivity"] : 0;
            this.g_transmissivity = _data["g_transmissivity"] !== undefined ? _data["g_transmissivity"] : 0;
            this.b_transmissivity = _data["b_transmissivity"] !== undefined ? _data["b_transmissivity"] : 0;
            this.refraction_index = _data["refraction_index"] !== undefined ? _data["refraction_index"] : 1.52;
            this.type = _data["type"] !== undefined ? _data["type"] : "Glass";
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
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
