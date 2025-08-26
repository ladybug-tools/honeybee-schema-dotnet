import { IsOptional, IsArray, IsNumber, Min, Max, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance glass material. */
export class Glass extends ModifierBase {
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
    @Expose({ name: "r_transmissivity" })
    /** A value between 0 and 1 for the red channel transmissivity. */
    rTransmissivity: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "g_transmissivity" })
    /** A value between 0 and 1 for the green channel transmissivity. */
    gTransmissivity: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "b_transmissivity" })
    /** A value between 0 and 1 for the blue channel transmissivity. */
    bTransmissivity: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "refraction_index" })
    /** A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE. */
    refractionIndex: number = 1.52;
	
    @IsString()
    @IsOptional()
    @Matches(/^Glass$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Glass";
	

    constructor() {
        super();
        this.modifier = new Void();
        this.rTransmissivity = 0;
        this.gTransmissivity = 0;
        this.bTransmissivity = 0;
        this.refractionIndex = 1.52;
        this.type = "Glass";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Glass, _data);
            this.modifier = obj.modifier ?? new Void();
            this.dependencies = obj.dependencies;
            this.rTransmissivity = obj.rTransmissivity ?? 0;
            this.gTransmissivity = obj.gTransmissivity ?? 0;
            this.bTransmissivity = obj.bTransmissivity ?? 0;
            this.refractionIndex = obj.refractionIndex ?? 1.52;
            this.type = obj.type ?? "Glass";
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): Glass {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Glass();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["modifier"] = this.modifier ?? new Void();
        data["dependencies"] = this.dependencies;
        data["r_transmissivity"] = this.rTransmissivity ?? 0;
        data["g_transmissivity"] = this.gTransmissivity ?? 0;
        data["b_transmissivity"] = this.bTransmissivity ?? 0;
        data["refraction_index"] = this.refractionIndex ?? 1.52;
        data["type"] = this.type ?? "Glass";
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
