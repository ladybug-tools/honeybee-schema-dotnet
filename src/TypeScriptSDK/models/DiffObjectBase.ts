import { IsEnum, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { GeometryObjectTypes } from "./GeometryObjectTypes";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

export class DiffObjectBase extends OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @ValidateNested()
    @IsDefined()
    /** Text for the type of object that has been changed. */
    element_type!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    /** Text string for the unique object ID that has changed. */
    element_id!: string;
	
    @IsString()
    @IsOptional()
    /** Text string for the display name of the object that has changed. */
    element_name?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "_DiffObjectBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.element_type = _data["element_type"];
            this.element_id = _data["element_id"];
            this.element_name = _data["element_name"];
            this.type = _data["type"] !== undefined ? _data["type"] : "_DiffObjectBase";
        }
    }


    static override fromJS(data: any): DiffObjectBase {
        data = typeof data === 'object' ? data : {};

        let result = new DiffObjectBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["element_type"] = this.element_type;
        data["element_id"] = this.element_id;
        data["element_name"] = this.element_name;
        data["type"] = this.type;
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
