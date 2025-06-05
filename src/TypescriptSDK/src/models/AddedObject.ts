import { IsEnum, IsDefined, IsString, Matches, MinLength, MaxLength, IsArray, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { GeometryObjectTypes } from "./GeometryObjectTypes";

export class AddedObject extends _OpenAPIGenBaseModel {
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
	
    @IsArray()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** A list of DisplayFace3D dictionaries for the added geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been added. */
    geometry!: Object[];
	
    @IsString()
    @IsOptional()
    @Expose({ name: "element_name" })
    /** Text string for the display name of the object that has changed. */
    elementName?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^AddedObject$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "AddedObject";
	

    constructor() {
        super();
        this.type = "AddedObject";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(AddedObject, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.geometry = obj.geometry;
            this.elementName = obj.elementName;
            this.type = obj.type ?? "AddedObject";
        }
    }


    static override fromJS(data: any): AddedObject {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new AddedObject();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["element_type"] = this.elementType;
        data["element_id"] = this.elementId;
        data["geometry"] = this.geometry;
        data["element_name"] = this.elementName;
        data["type"] = this.type ?? "AddedObject";
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
