import { IsOptional, IsArray, IsNumber, Min, Max, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance Glow material. */
export class Glow extends ModifierBase {
    @IsOptional()
    /** Material modifier. */
    modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsArray()
    @IsOptional()
    /** List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. */
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) [];
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A value between 0 and 1 for the red channel of the modifier. */
    r_emittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A value between 0 and 1 for the green channel of the modifier. */
    g_emittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A value between 0 and 1 for the blue channel of the modifier. */
    b_emittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination. */
    max_radius?: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^Glow$/)
    type?: string;
	

    constructor() {
        super();
        this.modifier = new Void();
        this.r_emittance = 0;
        this.g_emittance = 0;
        this.b_emittance = 0;
        this.max_radius = 0;
        this.type = "Glow";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Glow, _data);
            this.modifier = obj.modifier;
            this.dependencies = obj.dependencies;
            this.r_emittance = obj.r_emittance;
            this.g_emittance = obj.g_emittance;
            this.b_emittance = obj.b_emittance;
            this.max_radius = obj.max_radius;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): Glow {
        data = typeof data === 'object' ? data : {};

        let result = new Glow();
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
        data["max_radius"] = this.max_radius;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
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
