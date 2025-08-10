import { IsString, IsDefined, Matches, MinLength, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects requiring a valid Radiance identifier. */
export class IDdRadianceBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @Expose({ name: "identifier" })
    /** Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^IDdRadianceBaseModel$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "IDdRadianceBaseModel";
	

    constructor() {
        super();
        this.type = "IDdRadianceBaseModel";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(IDdRadianceBaseModel, _data);
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
            this.type = obj.type ?? "IDdRadianceBaseModel";
        }
    }


    static override fromJS(data: any): IDdRadianceBaseModel {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new IDdRadianceBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
        data["type"] = this.type ?? "IDdRadianceBaseModel";
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
