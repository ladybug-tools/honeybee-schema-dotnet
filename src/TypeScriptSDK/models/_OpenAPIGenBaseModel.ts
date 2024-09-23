import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';

export abstract class _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** A base class to use when there is no baseclass available to fall on. */
    type?: string;
	

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
        data["type"] = this.type;
        return removeUndefinedProperties(data);
    }

}

function removeUndefinedProperties(obj: any): any {
    if (Array.isArray(obj)) {
        return obj.map(removeUndefinedProperties);
    } else if (obj !== null && typeof obj === 'object') {
        return Object.entries(obj)
        .filter(([_, value]) => value !== undefined)
        .reduce((acc, [key, value]) => {
            acc[key] = removeUndefinedProperties(value);
            return acc;
        }, {} as any);
    }
    return obj;
}
