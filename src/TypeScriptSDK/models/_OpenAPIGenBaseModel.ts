import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';

export abstract class _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** A base class to use when there is no baseclass available to fall on. */
    type?: string;
	

    constructor() {
        this.type = "InvalidType";
    }


    init(_data?: any) {
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "InvalidType";
        }
    }


    static fromJS(data: any): _OpenAPIGenBaseModel {
        data = typeof data === 'object' ? data : {};

        throw new Error("The abstract class '_OpenAPIGenBaseModel' cannot be instantiated.");
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        return data;
    }

}
