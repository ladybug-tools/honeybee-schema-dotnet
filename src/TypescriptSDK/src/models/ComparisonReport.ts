import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { AddedObject } from "./AddedObject";
import { ChangedObject } from "./ChangedObject";
import { DeletedObject } from "./DeletedObject";

export class ComparisonReport extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ComparisonReport$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ComparisonReport";
	
    @IsArray()
    @IsInstance(ChangedObject, { each: true })
    @Type(() => ChangedObject)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "changed_objects" })
    /** A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change. */
    changedObjects?: ChangedObject[];
	
    @IsArray()
    @IsInstance(DeletedObject, { each: true })
    @Type(() => DeletedObject)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "deleted_objects" })
    /** A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model. */
    deletedObjects?: DeletedObject[];
	
    @IsArray()
    @IsInstance(AddedObject, { each: true })
    @Type(() => AddedObject)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "added_objects" })
    /** A list of AddedObject definitions for each top-level object that has been added in the process of going from the base model to the new model. */
    addedObjects?: AddedObject[];
	

    constructor() {
        super();
        this.type = "ComparisonReport";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ComparisonReport, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "ComparisonReport";
            this.changedObjects = obj.changedObjects;
            this.deletedObjects = obj.deletedObjects;
            this.addedObjects = obj.addedObjects;
        }
    }


    static override fromJS(data: any): ComparisonReport {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ComparisonReport();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ComparisonReport";
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
