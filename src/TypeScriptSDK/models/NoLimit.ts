﻿import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class NoLimit extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^NoLimit$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "NoLimit";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(NoLimit, _data);
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): NoLimit {
        data = typeof data === 'object' ? data : {};

        let result = new NoLimit();
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
        data = super.toJSON(data);
        return data;
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
