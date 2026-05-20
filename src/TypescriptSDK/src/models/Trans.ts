import { IsNumber, IsOptional, Min, Max, IsString, Equals, IsArray, IsDefined, Matches, MinLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { Plastic } from "./Plastic";
import { Void } from "./Void";

/** Radiance Translucent material. */
export class Trans {
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "transmitted_diff" })
    /** The fraction of transmitted light that is transmitted diffusely in a scattering fashion. */
    transmittedDiff: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "transmitted_spec" })
    /** The fraction of transmitted light that is not diffusely scattered. */
    transmittedSpec: number = 0;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("Trans")
    @Expose({ name: "type" })
    /** type */
    type: string = "Trans";
	
    @IsOptional()
    @Expose({ name: "modifier" })
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
    modifier: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) = new Void();
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "dependencies" })
    @Transform(({ value }) => value?.map((item: any) => {
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
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror)[];
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "r_reflectance" })
    /** A value between 0 and 1 for the red channel reflectance. */
    rReflectance: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "g_reflectance" })
    /** A value between 0 and 1 for the green channel reflectance. */
    gReflectance: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "b_reflectance" })
    /** A value between 0 and 1 for the blue channel reflectance. */
    bReflectance: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "specularity" })
    /** A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials. */
    specularity: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "roughness" })
    /** A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic. */
    roughness: number = 0;
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @Expose({ name: "identifier" })
    /** Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. */
    identifier!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	

    constructor() {
        this.transmittedDiff = 0;
        this.transmittedSpec = 0;
        this.type = "Trans";
        this.modifier = new Void();
        this.rReflectance = 0;
        this.gReflectance = 0;
        this.bReflectance = 0;
        this.specularity = 0;
        this.roughness = 0;
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Trans, _data);
            this.transmittedDiff = obj.transmittedDiff ?? 0;
            this.transmittedSpec = obj.transmittedSpec ?? 0;
            this.type = obj.type ?? "Trans";
            this.modifier = obj.modifier ?? new Void();
            this.dependencies = obj.dependencies;
            this.rReflectance = obj.rReflectance ?? 0;
            this.gReflectance = obj.gReflectance ?? 0;
            this.bReflectance = obj.bReflectance ?? 0;
            this.specularity = obj.specularity ?? 0;
            this.roughness = obj.roughness ?? 0;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): Trans {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Trans();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["transmitted_diff"] = this.transmittedDiff ?? 0;
        data["transmitted_spec"] = this.transmittedSpec ?? 0;
        data["type"] = this.type ?? "Trans";
        data["modifier"] = this.modifier ?? new Void();
        data["dependencies"] = this.dependencies;
        data["r_reflectance"] = this.rReflectance ?? 0;
        data["g_reflectance"] = this.gReflectance ?? 0;
        data["b_reflectance"] = this.bReflectance ?? 0;
        data["specularity"] = this.specularity ?? 0;
        data["roughness"] = this.roughness ?? 0;
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
        return instanceToPlain(data, { exposeUnsetFields: false });
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
