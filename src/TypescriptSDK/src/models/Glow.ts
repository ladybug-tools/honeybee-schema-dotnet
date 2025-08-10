import { IsOptional, IsArray, IsNumber, Min, Max, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
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
    @Expose({ name: "r_emittance" })
    /** A value between 0 and 1 for the red channel of the modifier. */
    rEmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "g_emittance" })
    /** A value between 0 and 1 for the green channel of the modifier. */
    gEmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "b_emittance" })
    /** A value between 0 and 1 for the blue channel of the modifier. */
    bEmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "max_radius" })
    /** Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination. */
    maxRadius: number = 0;
	
    @IsString()
    @IsOptional()
    @Matches(/^Glow$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Glow";
	

    constructor() {
        super();
        this.modifier = new Void();
        this.rEmittance = 0;
        this.gEmittance = 0;
        this.bEmittance = 0;
        this.maxRadius = 0;
        this.type = "Glow";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Glow, _data);
        }
    }


    static override fromJS(data: any): Glow {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Glow();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["modifier"] = this.modifier ?? new Void();
        data["dependencies"] = this.dependencies;
        data["r_emittance"] = this.rEmittance ?? 0;
        data["g_emittance"] = this.gEmittance ?? 0;
        data["b_emittance"] = this.bEmittance ?? 0;
        data["max_radius"] = this.maxRadius ?? 0;
        data["type"] = this.type ?? "Glow";
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
