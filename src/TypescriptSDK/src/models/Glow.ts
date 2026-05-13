import { IsNumber, IsOptional, IsString, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance Glow material. */
export class Glow extends Light {
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Expose({ name: "max_radius" })
    /** Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination. */
    maxRadius: number = 0;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("Glow")
    @Expose({ name: "type" })
    /** type */
    type: string = "Glow";
	

    constructor() {
        super();
        this.maxRadius = 0;
        this.type = "Glow";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Glow, _data);
            this.maxRadius = obj.maxRadius ?? 0;
            this.type = obj.type ?? "Glow";
            this.modifier = obj.modifier ?? new Void();
            this.dependencies = obj.dependencies;
            this.rEmittance = obj.rEmittance ?? 0;
            this.gEmittance = obj.gEmittance ?? 0;
            this.bEmittance = obj.bEmittance ?? 0;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
