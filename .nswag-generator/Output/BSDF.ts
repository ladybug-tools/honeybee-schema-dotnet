import { IsString, IsDefined, IsOptional, IsArray, ValidateNested, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance BSDF (Bidirectional Scattering Distribution Function) material. */
export class BSDF extends ModifierBase {
    @IsString()
    @IsDefined()
    /** A string with the contents of the BSDF XML file. */
    bsdf_data!: string;
	
    @IsOptional()
    /** Material modifier. */
    modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. */
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Vector as sequence that sets the hemisphere that the BSDF material faces. */
    up_orientation?: number [];
	
    @IsNumber()
    @IsOptional()
    /** Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative). */
    thickness?: number;
	
    @IsString()
    @IsOptional()
    /** Optional input for function file. Using "." will ensure that BSDF data is written to the root of wherever a given study is run. */
    function_file?: string;
	
    @IsString()
    @IsOptional()
    /** Optional transform input to scale the thickness and reorient the up vector. */
    transform?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Optional additional front diffuse reflectance as sequence of three RGB numbers. */
    front_diffuse_reflectance?: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Optional additional back diffuse reflectance as sequence of three RGB numbers. */
    back_diffuse_reflectance?: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Optional additional diffuse transmittance as sequence of three RGB numbers. */
    diffuse_transmittance?: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.modifier = new Void();
        this.up_orientation = [0.01, 0.01, 1];
        this.thickness = 0;
        this.function_file = ".";
        this.type = "BSDF";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.bsdf_data = _data["bsdf_data"];
            this.modifier = _data["modifier"] !== undefined ? _data["modifier"] : new Void();
            this.dependencies = _data["dependencies"];
            this.up_orientation = _data["up_orientation"] !== undefined ? _data["up_orientation"] : [0.01, 0.01, 1];
            this.thickness = _data["thickness"] !== undefined ? _data["thickness"] : 0;
            this.function_file = _data["function_file"] !== undefined ? _data["function_file"] : ".";
            this.transform = _data["transform"];
            this.front_diffuse_reflectance = _data["front_diffuse_reflectance"];
            this.back_diffuse_reflectance = _data["back_diffuse_reflectance"];
            this.diffuse_transmittance = _data["diffuse_transmittance"];
            this.type = _data["type"] !== undefined ? _data["type"] : "BSDF";
        }
    }


    static override fromJS(data: any): BSDF {
        data = typeof data === 'object' ? data : {};

        let result = new BSDF();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["bsdf_data"] = this.bsdf_data;
        data["modifier"] = this.modifier;
        data["dependencies"] = this.dependencies;
        data["up_orientation"] = this.up_orientation;
        data["thickness"] = this.thickness;
        data["function_file"] = this.function_file;
        data["transform"] = this.transform;
        data["front_diffuse_reflectance"] = this.front_diffuse_reflectance;
        data["back_diffuse_reflectance"] = this.back_diffuse_reflectance;
        data["diffuse_transmittance"] = this.diffuse_transmittance;
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
