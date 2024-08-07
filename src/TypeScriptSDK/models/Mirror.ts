import { IsOptional, IsArray, ValidateNested, IsNumber, IsString, validate, ValidationError } from 'class-validator';
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { Void } from "./Void";
import { ModifierBase } from "./ModifierBase";

/** Radiance mirror material. */
export class Mirror extends ModifierBase {
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
	
    @IsOptional()
    /** An optional material (like the illum type) that may be used to specify a different material to be used for shading non-source rays. If None, this will keep the alternat_material as mirror. If this alternate material is given as Void, then the mirror surface will be invisible. Using Void is only appropriate if the surface hides other (more detailed) geometry with the same overall reflectance. */
    alternate_material?: Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.modifier = new Void();;
        this.r_reflectance = 1;
        this.g_reflectance = 1;
        this.b_reflectance = 1;
        this.type = "Mirror";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.modifier = _data["modifier"] !== undefined ? _data["modifier"] : new Void();;
            this.dependencies = _data["dependencies"];
            this.r_reflectance = _data["r_reflectance"] !== undefined ? _data["r_reflectance"] : 1;
            this.g_reflectance = _data["g_reflectance"] !== undefined ? _data["g_reflectance"] : 1;
            this.b_reflectance = _data["b_reflectance"] !== undefined ? _data["b_reflectance"] : 1;
            this.alternate_material = _data["alternate_material"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Mirror";
        }
    }


    static override fromJS(data: any): Mirror {
        data = typeof data === 'object' ? data : {};

        let result = new Mirror();
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
        data["alternate_material"] = this.alternate_material;
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
