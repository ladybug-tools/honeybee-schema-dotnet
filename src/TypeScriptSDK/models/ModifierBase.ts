import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { Plastic } from "./Plastic";
import { Trans } from "./Trans";

/** Base class for Radiance Modifiers */
export class ModifierBase extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "ModifierBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ModifierBase";
        }
    }


    static override fromJS(data: any): ModifierBase {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "Mirror") {
            let result = new Mirror();
            result.init(data);
            return result;
        }
        if (data["type"] === "Plastic") {
            let result = new Plastic();
            result.init(data);
            return result;
        }
        if (data["type"] === "Glass") {
            let result = new Glass();
            result.init(data);
            return result;
        }
        if (data["type"] === "BSDF") {
            let result = new BSDF();
            result.init(data);
            return result;
        }
        if (data["type"] === "Glow") {
            let result = new Glow();
            result.init(data);
            return result;
        }
        if (data["type"] === "Light") {
            let result = new Light();
            result.init(data);
            return result;
        }
        if (data["type"] === "Trans") {
            let result = new Trans();
            result.init(data);
            return result;
        }
        if (data["type"] === "Metal") {
            let result = new Metal();
            result.init(data);
            return result;
        }
        let result = new ModifierBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
