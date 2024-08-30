import { IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { EnergyBaseModel } from "./EnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class IDdEnergyBaseModel extends EnergyBaseModel {
    @IsOptional()
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    user_data?: Object;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdEnergyBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.user_data = _data["user_data"];
            this.type = _data["type"] !== undefined ? _data["type"] : "IDdEnergyBaseModel";
        }
    }


    static override fromJS(data: any): IDdEnergyBaseModel {
        data = typeof data === 'object' ? data : {};

        let result = new IDdEnergyBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["user_data"] = this.user_data;
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
