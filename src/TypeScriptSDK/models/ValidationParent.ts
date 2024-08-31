﻿import { IsEnum, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { ParentTypes } from "./ParentTypes";

export class ValidationParent {
    @IsEnum(ParentTypes)
    @Type(() => String)
    @IsDefined()
    /** Text for the type of object that the parent is. */
    parent_type!: ParentTypes;
	
    @IsString()
    @IsDefined()
    /** Text string for the unique ID of the parent object. */
    id!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Display name of the parent object. */
    name?: string;
	

    constructor() {
        this.type = "ValidationParent";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(ValidationParent, _data);
            this.parent_type = obj.parent_type;
            this.id = obj.id;
            this.type = obj.type;
            this.name = obj.name;
        }
    }


    static fromJS(data: any): ValidationParent {
        data = typeof data === 'object' ? data : {};

        let result = new ValidationParent();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["parent_type"] = this.parent_type;
        data["id"] = this.id;
        data["type"] = this.type;
        data["name"] = this.name;
        return data;
    }

}
