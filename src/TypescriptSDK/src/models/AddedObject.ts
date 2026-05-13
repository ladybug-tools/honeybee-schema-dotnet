import { IsArray, IsDefined, IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DiffObjectBase } from "./_DiffObjectBase";

export class AddedObject extends _DiffObjectBase {
    @IsArray()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** A list of DisplayFace3D dictionaries for the added geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been added. */
    geometry!: Object[];
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("AddedObject")
    @Expose({ name: "type" })
    /** type */
    type: string = "AddedObject";
	

    constructor() {
        super();
        this.type = "AddedObject";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(AddedObject, _data);
            this.geometry = obj.geometry;
            this.type = obj.type ?? "AddedObject";
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
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
        data["geometry"] = this.geometry;
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
