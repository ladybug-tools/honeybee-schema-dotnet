import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { EquipmentBase } from "./EquipmentBase";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class GasEquipmentAbridged extends EquipmentBase {
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "GasEquipmentAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "GasEquipmentAbridged";
        }
    }


    static override fromJS(data: any): GasEquipmentAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new GasEquipmentAbridged();
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
