import { IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { EnergyBaseModel } from "./EnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class IDdEnergyBaseModel extends EnergyBaseModel {
    @IsOptional()
    @Expose({ name: "user_data" })
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    userData?: Object;
	
    @IsString()
    @IsOptional()
    @Matches(/^IDdEnergyBaseModel$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "IDdEnergyBaseModel";
	

    constructor() {
        super();
        this.type = "IDdEnergyBaseModel";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(IDdEnergyBaseModel, _data);
            this.userData = obj.userData;
            this.type = obj.type ?? "IDdEnergyBaseModel";
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): IDdEnergyBaseModel {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new IDdEnergyBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["user_data"] = this.userData;
        data["type"] = this.type ?? "IDdEnergyBaseModel";
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
