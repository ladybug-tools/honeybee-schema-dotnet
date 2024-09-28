import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel.ts";
import { AddedObject } from "./AddedObject.ts";
import { ChangedObject } from "./ChangedObject.ts";
import { DeletedObject } from "./DeletedObject.ts";

export class ComparisonReport extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ComparisonReport$/)
    type?: string;
	
    @IsArray()
    @IsInstance(ChangedObject, { each: true })
    @Type(() => ChangedObject)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change. */
    changed_objects?: ChangedObject [];
	
    @IsArray()
    @IsInstance(DeletedObject, { each: true })
    @Type(() => DeletedObject)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model. */
    deleted_objects?: DeletedObject [];
	
    @IsArray()
    @IsInstance(AddedObject, { each: true })
    @Type(() => AddedObject)
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
            const obj = plainToClass(ComparisonReport, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.changed_objects = obj.changed_objects;
            this.deleted_objects = obj.deleted_objects;
            this.added_objects = obj.added_objects;
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

