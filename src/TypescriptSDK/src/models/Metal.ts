import { IsOptional, IsArray, IsNumber, Min, Max, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance metal material. */
export class Metal extends ModifierBase {
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
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "r_reflectance" })
    /** A value between 0 and 1 for the red channel reflectance. */
    rReflectance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "g_reflectance" })
    /** A value between 0 and 1 for the green channel reflectance. */
    gReflectance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "b_reflectance" })
    /** A value between 0 and 1 for the blue channel reflectance. */
    bReflectance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "specularity" })
    /** A value between 0 and 1 for the fraction of specularity. Specularity fractions lower than 0.9 are not realistic for metallic materials. */
    specularity: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "roughness" })
    /** A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic. */
    roughness: number = 0;
	
    @IsString()
    @IsOptional()
    @Matches(/^Metal$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Metal";
	

    constructor() {
        super();
        this.modifier = new Void();
        this.rReflectance = 0;
        this.gReflectance = 0;
        this.bReflectance = 0;
        this.specularity = 0.9;
        this.roughness = 0;
        this.type = "Metal";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Metal, _data);
        }
    }


    static override fromJS(data: any): Metal {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Metal();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["modifier"] = this.modifier ?? new Void();
        data["dependencies"] = this.dependencies;
        data["r_reflectance"] = this.rReflectance ?? 0;
        data["g_reflectance"] = this.gReflectance ?? 0;
        data["b_reflectance"] = this.bReflectance ?? 0;
        data["specularity"] = this.specularity ?? 0.9;
        data["roughness"] = this.roughness ?? 0;
        data["type"] = this.type ?? "Metal";
        data = super.toJSON(data);
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
