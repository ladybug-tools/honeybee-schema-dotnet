import { IsString, IsDefined, IsOptional, IsArray, IsNumber, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { Glass } from "./Glass.ts";
import { Glow } from "./Glow.ts";
import { Light } from "./Light.ts";
import { Metal } from "./Metal.ts";
import { Mirror } from "./Mirror.ts";
import { ModifierBase } from "./ModifierBase.ts";
import { Plastic } from "./Plastic.ts";
import { Trans } from "./Trans.ts";
import { Void } from "./Void.ts";

/** Radiance BSDF (Bidirectional Scattering Distribution Function) material. */
export class BSDF extends ModifierBase {
    @IsString()
    @IsDefined()
    /** A string with the contents of the BSDF XML file. */
    bsdf_data!: string;
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'Plastic') return Plastic.fromJS(item);
      else if (item?.type === 'Glass') return Glass.fromJS(item);
      else if (item?.type === 'BSDF') return BSDF.fromJS(item);
      else if (item?.type === 'Glow') return Glow.fromJS(item);
      else if (item?.type === 'Light') return Light.fromJS(item);
      else if (item?.type === 'Trans') return Trans.fromJS(item);
      else if (item?.type === 'Metal') return Metal.fromJS(item);
      else if (item?.type === 'Void') return Void.fromJS(item);
      else if (item?.type === 'Mirror') return Mirror.fromJS(item);
      else return item;
    })
    /** Material modifier. */
    modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	
    @IsArray()
    @IsOptional()
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'Plastic') return Plastic.fromJS(item);
      else if (item?.type === 'Glass') return Glass.fromJS(item);
      else if (item?.type === 'BSDF') return BSDF.fromJS(item);
      else if (item?.type === 'Glow') return Glow.fromJS(item);
      else if (item?.type === 'Light') return Light.fromJS(item);
      else if (item?.type === 'Trans') return Trans.fromJS(item);
      else if (item?.type === 'Metal') return Metal.fromJS(item);
      else if (item?.type === 'Void') return Void.fromJS(item);
      else if (item?.type === 'Mirror') return Mirror.fromJS(item);
      else return item;
    }))
    /** List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. */
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    /** Vector as sequence that sets the hemisphere that the BSDF material faces. */
    up_orientation?: number [];
	
    @IsNumber()
    @IsOptional()
    /** Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative). */
    thickness?: number;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Optional input for function file. Using ""."" will ensure that BSDF data is written to the root of wherever a given study is run. */
    function_file?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Optional transform input to scale the thickness and reorient the up vector. */
    transform?: string;
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    /** Optional additional front diffuse reflectance as sequence of three RGB numbers. */
    front_diffuse_reflectance?: number [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    /** Optional additional back diffuse reflectance as sequence of three RGB numbers. */
    back_diffuse_reflectance?: number [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    /** Optional additional diffuse transmittance as sequence of three RGB numbers. */
    diffuse_transmittance?: number [];
	
    @IsString()
    @IsOptional()
    @Matches(/^BSDF$/)
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
            const obj = plainToClass(BSDF, _data, { enableImplicitConversion: true });
            this.bsdf_data = obj.bsdf_data;
            this.modifier = obj.modifier;
            this.dependencies = obj.dependencies;
            this.up_orientation = obj.up_orientation;
            this.thickness = obj.thickness;
            this.function_file = obj.function_file;
            this.transform = obj.transform;
            this.front_diffuse_reflectance = obj.front_diffuse_reflectance;
            this.back_diffuse_reflectance = obj.back_diffuse_reflectance;
            this.diffuse_transmittance = obj.diffuse_transmittance;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): BSDF {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new BSDF();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
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
        data = super.toJSON(data);
        return instanceToPlain(data);
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

