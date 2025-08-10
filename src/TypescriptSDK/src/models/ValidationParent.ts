import { IsEnum, IsDefined, IsString, Matches, MinLength, MaxLength, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { ParentTypes } from "./ParentTypes";

export class ValidationParent {
    @IsEnum(ParentTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "parent_type" })
    /** Text for the type of object that the parent is. */
    parentType!: ParentTypes;
	
    @IsString()
    @IsDefined()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "id" })
    /** Text string for the unique ID of the parent object. */
    id!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^ValidationParent$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ValidationParent";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "name" })
    /** Display name of the parent object. */
    name?: string;
	

    constructor() {
        this.type = "ValidationParent";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ValidationParent, _data);
            this.parentType = obj.parentType;
            this.id = obj.id;
            this.type = obj.type ?? "ValidationParent";
            this.name = obj.name;
        }
    }


    static fromJS(data: any): ValidationParent {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ValidationParent();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["parent_type"] = this.parentType;
        data["id"] = this.id;
        data["type"] = this.type ?? "ValidationParent";
        data["name"] = this.name;
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
