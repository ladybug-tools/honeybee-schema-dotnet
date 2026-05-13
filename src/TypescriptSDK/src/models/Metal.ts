import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Mirror } from "./Mirror";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";
import { Void } from "./Void";

/** Radiance metal material. */
export class Metal extends Plastic {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("Metal")
    @Expose({ name: "type" })
    /** type */
    type: string = "Metal";
	

    constructor() {
        super();
        this.type = "Metal";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Metal, _data);
            this.type = obj.type ?? "Metal";
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
