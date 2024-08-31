﻿import { IsString, IsDefined, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects requiring a valid Radiance identifier. */
export class IDdRadianceBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    /** Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    /** Display name of the object with no character restrictions. */
    display_name?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdRadianceBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(IDdRadianceBaseModel, _data);
            this.identifier = obj.identifier;
            this.display_name = obj.display_name;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): IDdRadianceBaseModel {
        data = typeof data === 'object' ? data : {};

        let result = new IDdRadianceBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["identifier"] = this.identifier;
        data["display_name"] = this.display_name;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
