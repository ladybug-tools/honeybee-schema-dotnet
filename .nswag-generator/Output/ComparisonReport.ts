import { IsString, IsOptional, IsArray, ValidateNested, validate, ValidationError } from 'class-validator';
import { ChangedObject } from "./ChangedObject";
import { DeletedObject } from "./DeletedObject";
import { AddedObject } from "./AddedObject";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

export class ComparisonReport extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change. */
    changed_objects?: ChangedObject [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model. */
    deleted_objects?: DeletedObject [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of AddedObject definitions for each top-level object that has been added in the process of going from the base model to the new model. */
    added_objects?: AddedObject [];
	

    constructor() {
        super();
        this.type = "ComparisonReport";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ComparisonReport";
            this.changed_objects = _data["changed_objects"];
            this.deleted_objects = _data["deleted_objects"];
            this.added_objects = _data["added_objects"];
        }
    }


    static override fromJS(data: any): ComparisonReport {
        data = typeof data === 'object' ? data : {};

        let result = new ComparisonReport();
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
        data["changed_objects"] = this.changed_objects;
        data["deleted_objects"] = this.deleted_objects;
        data["added_objects"] = this.added_objects;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
