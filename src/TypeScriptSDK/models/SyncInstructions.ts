import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel.ts";
import { AddedInstruction } from "./AddedInstruction.ts";
import { ChangedInstruction } from "./ChangedInstruction.ts";
import { DeletedInstruction } from "./DeletedInstruction.ts";

export class SyncInstructions extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SyncInstructions$/)
    type?: string;
	
    @IsArray()
    @IsInstance(ChangedInstruction, { each: true })
    @Type(() => ChangedInstruction)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model. */
    changed_objects?: ChangedInstruction [];
	
    @IsArray()
    @IsInstance(DeletedInstruction, { each: true })
    @Type(() => DeletedInstruction)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model. */
    deleted_objects?: DeletedInstruction [];
	
    @IsArray()
    @IsInstance(AddedInstruction, { each: true })
    @Type(() => AddedInstruction)
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
            const obj = plainToClass(SyncInstructions, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.changed_objects = obj.changed_objects;
            this.deleted_objects = obj.deleted_objects;
            this.added_objects = obj.added_objects;
        }
    }


    static override fromJS(data: any): SyncInstructions {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SyncInstructions();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["changed_objects"] = this.changed_objects;
        data["deleted_objects"] = this.deleted_objects;
        data["added_objects"] = this.added_objects;
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

