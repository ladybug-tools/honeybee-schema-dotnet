import { IsString, IsOptional, IsArray, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { AddedInstruction } from "./AddedInstruction";
import { ChangedInstruction } from "./ChangedInstruction";
import { DeletedInstruction } from "./DeletedInstruction";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

export class SyncInstructions extends OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model. */
    changed_objects?: ChangedInstruction [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model. */
    deleted_objects?: DeletedInstruction [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model. */
    added_objects?: AddedInstruction [];
	

    constructor() {
        super();
        this.type = "SyncInstructions";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "SyncInstructions";
            this.changed_objects = _data["changed_objects"];
            this.deleted_objects = _data["deleted_objects"];
            this.added_objects = _data["added_objects"];
        }
    }


    static override fromJS(data: any): SyncInstructions {
        data = typeof data === 'object' ? data : {};

        let result = new SyncInstructions();
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
