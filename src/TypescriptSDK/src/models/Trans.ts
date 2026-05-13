import { IsNumber, IsOptional, Min, Max, IsString, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
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
export class Trans extends Plastic {
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
	

    constructor() {
        super();
        this.transmittedDiff = 0;
        this.transmittedSpec = 0;
        this.type = "Trans";
    }


    override init(_data?: any) {

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


    static override fromJS(data: any): Trans {
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

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["transmitted_diff"] = this.transmittedDiff ?? 0;
        data["transmitted_spec"] = this.transmittedSpec ?? 0;
        data["type"] = this.type ?? "Trans";
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
