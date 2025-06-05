import { IsString, IsDefined, IsOptional, IsArray, IsNumber, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "bsdf_data" })
    /** A string with the contents of the BSDF XML file. */
    bsdfData!: string;
	
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
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    @Expose({ name: "up_orientation" })
    /** Vector as sequence that sets the hemisphere that the BSDF material faces. */
    upOrientation: number[] = [0.01, 0.01, 1];
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "thickness" })
    /** Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative). */
    thickness: number = 0;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "function_file" })
    /** Optional input for function file. Using ""."" will ensure that BSDF data is written to the root of wherever a given study is run. */
    functionFile: string = ".";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "transform" })
    /** Optional transform input to scale the thickness and reorient the up vector. */
    transform?: string;
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    @Expose({ name: "front_diffuse_reflectance" })
    /** Optional additional front diffuse reflectance as sequence of three RGB numbers. */
    frontDiffuseReflectance?: number[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    @Expose({ name: "back_diffuse_reflectance" })
    /** Optional additional back diffuse reflectance as sequence of three RGB numbers. */
    backDiffuseReflectance?: number[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    @Expose({ name: "diffuse_transmittance" })
    /** Optional additional diffuse transmittance as sequence of three RGB numbers. */
    diffuseTransmittance?: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^BSDF$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "BSDF";
	

    constructor() {
        super();
        this.modifier = new Void();
        this.upOrientation = [0.01, 0.01, 1];
        this.thickness = 0;
        this.functionFile = ".";
        this.type = "BSDF";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(BSDF, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.bsdfData = obj.bsdfData;
            this.modifier = obj.modifier ?? new Void();
            this.dependencies = obj.dependencies;
            this.upOrientation = obj.upOrientation ?? [0.01, 0.01, 1];
            this.thickness = obj.thickness ?? 0;
            this.functionFile = obj.functionFile ?? ".";
            this.transform = obj.transform;
            this.frontDiffuseReflectance = obj.frontDiffuseReflectance;
            this.backDiffuseReflectance = obj.backDiffuseReflectance;
            this.diffuseTransmittance = obj.diffuseTransmittance;
            this.type = obj.type ?? "BSDF";
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
        data["bsdf_data"] = this.bsdfData;
        data["modifier"] = this.modifier ?? new Void();
        data["dependencies"] = this.dependencies;
        data["up_orientation"] = this.upOrientation ?? [0.01, 0.01, 1];
        data["thickness"] = this.thickness ?? 0;
        data["function_file"] = this.functionFile ?? ".";
        data["transform"] = this.transform;
        data["front_diffuse_reflectance"] = this.frontDiffuseReflectance;
        data["back_diffuse_reflectance"] = this.backDiffuseReflectance;
        data["diffuse_transmittance"] = this.diffuseTransmittance;
        data["type"] = this.type ?? "BSDF";
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
