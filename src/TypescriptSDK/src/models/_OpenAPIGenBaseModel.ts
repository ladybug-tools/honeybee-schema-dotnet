import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';

export abstract class _OpenAPIGenBaseModel {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "type" })
    /** A base class to use when there is no baseclass available to fall on. */
    type: string = "InvalidType";
	

    constructor() {
        this.type = "InvalidType";
    }


    init(_data?: any) {

    }


    static fromJS(data: any): _OpenAPIGenBaseModel {
        data = typeof data === 'object' ? data : {};

        throw new Error("The abstract class '_OpenAPIGenBaseModel' cannot be instantiated.");
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "InvalidType";
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
