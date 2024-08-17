import { IsEnum, ValidateNested, IsDefined, IsString, IsArray, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { GeometryObjectTypes } from "./GeometryObjectTypes";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

export class AddedObject extends OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @ValidateNested()
    @IsDefined()
    /** Text for the type of object that has been changed. */
    element_type!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    /** Text string for the unique object ID that has changed. */
    element_id!: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of DisplayFace3D dictionaries for the added geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been added. */
    geometry!: Object [];
	
    @IsString()
    @IsOptional()
    /** Text string for the display name of the object that has changed. */
    element_name?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "AddedObject";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.element_type = _data["element_type"];
            this.element_id = _data["element_id"];
            this.geometry = _data["geometry"];
            this.element_name = _data["element_name"];
            this.type = _data["type"] !== undefined ? _data["type"] : "AddedObject";
        }
    }


    static override fromJS(data: any): AddedObject {
        data = typeof data === 'object' ? data : {};

        let result = new AddedObject();
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
        data["geometry"] = this.geometry;
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
