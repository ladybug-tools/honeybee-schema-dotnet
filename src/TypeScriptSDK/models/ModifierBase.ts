import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

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
