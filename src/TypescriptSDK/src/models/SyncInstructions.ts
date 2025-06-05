import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { AddedInstruction } from "./AddedInstruction";
import { ChangedInstruction } from "./ChangedInstruction";
import { DeletedInstruction } from "./DeletedInstruction";

export class SyncInstructions extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SyncInstructions$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "SyncInstructions";
	
    @IsArray()
    @IsInstance(ChangedInstruction, { each: true })
    @Type(() => ChangedInstruction)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "changed_objects" })
    /** A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model. */
    changedObjects?: ChangedInstruction[];
	
    @IsArray()
    @IsInstance(DeletedInstruction, { each: true })
    @Type(() => DeletedInstruction)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "deleted_objects" })
    /** A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model. */
    deletedObjects?: DeletedInstruction[];
	
    @IsArray()
    @IsInstance(AddedInstruction, { each: true })
    @Type(() => AddedInstruction)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "added_objects" })
    /** A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model. */
    addedObjects?: AddedInstruction[];
	

    constructor() {
        super();
        this.type = "SyncInstructions";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SyncInstructions, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "SyncInstructions";
            this.changedObjects = obj.changedObjects;
            this.deletedObjects = obj.deletedObjects;
            this.addedObjects = obj.addedObjects;
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
        data["type"] = this.type ?? "SyncInstructions";
        data["changed_objects"] = this.changedObjects;
        data["deleted_objects"] = this.deletedObjects;
        data["added_objects"] = this.addedObjects;
        data = super.toJSON(data);
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
