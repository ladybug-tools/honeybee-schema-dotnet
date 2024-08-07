import { IsEnum, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { ParentTypes } from "./ParentTypes";

export abstract class ValidationParent {
    @IsEnum(ParentTypes)
    @ValidateNested()
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
            this.parent_type = _data["parent_type"];
            this.id = _data["id"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ValidationParent";
            this.name = _data["name"];
        }
    }


    static fromJS(data: any): ValidationParent {
        data = typeof data === 'object' ? data : {};

        throw new Error("The abstract class 'ValidationParent' cannot be instantiated.");
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
