import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects needing to check for a valid Date. */
export class DatedBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DatedBaseModel$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DatedBaseModel";
	

    constructor() {
        super();
        this.type = "DatedBaseModel";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DatedBaseModel, _data);
            this.type = obj.type ?? "DatedBaseModel";
        }
    }


    static override fromJS(data: any): DatedBaseModel {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DatedBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "DatedBaseModel";
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
