import { IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { EnergyBaseModel } from "./EnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class IDdEnergyBaseModel extends EnergyBaseModel {
    @IsOptional()
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    user_data?: Object;
	
    @IsString()
    @IsOptional()
    @Matches(/^IDdEnergyBaseModel$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdEnergyBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(IDdEnergyBaseModel, _data);
            this.user_data = obj.user_data;
            this.type = obj.type;
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
        data["user_data"] = this.user_data;
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

