import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects needing to check for a valid Date. */
export class DatedBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DatedBaseModel$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "DatedBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DatedBaseModel, _data);
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): DatedBaseModel {
        data = typeof data === 'object' ? data : {};

        let result = new DatedBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
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

