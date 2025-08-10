import { IsEnum, IsDefined, IsString, Matches, MinLength, MaxLength, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { GeometryObjectTypes } from "./GeometryObjectTypes";

export class DeletedInstruction extends _OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "element_type" })
    /** Text for the type of object that has been changed. */
    elementType!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "element_id" })
    /** Text string for the unique object ID that has changed. */
    elementId!: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "element_name" })
    /** Text string for the display name of the object that has changed. */
    elementName?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^DeletedInstruction$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DeletedInstruction";
	

    constructor() {
        super();
        this.type = "DeletedInstruction";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DeletedInstruction, _data);
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
            this.type = obj.type ?? "DeletedInstruction";
        }
    }


    static override fromJS(data: any): DeletedInstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DeletedInstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["element_type"] = this.elementType;
        data["element_id"] = this.elementId;
        data["element_name"] = this.elementName;
        data["type"] = this.type ?? "DeletedInstruction";
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
