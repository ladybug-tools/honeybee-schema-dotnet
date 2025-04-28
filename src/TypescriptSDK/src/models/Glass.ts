import { IsOptional, IsArray, IsNumber, Min, Max, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
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
    dependencies?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror)[];
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A value between 0 and 1 for the red channel transmissivity. */
    r_transmissivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A value between 0 and 1 for the green channel transmissivity. */
    g_transmissivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A value between 0 and 1 for the blue channel transmissivity. */
    b_transmissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE. */
    refraction_index?: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^Glass$/)
    /** Type */
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
            const obj = plainToClass(Glass, _data, { enableImplicitConversion: true });
            this.modifier = obj.modifier;
            this.dependencies = obj.dependencies;
            this.r_transmissivity = obj.r_transmissivity;
            this.g_transmissivity = obj.g_transmissivity;
            this.b_transmissivity = obj.b_transmissivity;
            this.refraction_index = obj.refraction_index;
            this.type = obj.type;
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
        data["modifier"] = this.modifier;
        data["dependencies"] = this.dependencies;
        data["r_transmissivity"] = this.r_transmissivity;
        data["g_transmissivity"] = this.g_transmissivity;
        data["b_transmissivity"] = this.b_transmissivity;
        data["refraction_index"] = this.refraction_index;
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

