import { IsString, IsDefined, Matches, MinLength, MaxLength, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects requiring a valid EnergyPlus identifier. */
export class EnergyBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "identifier" })
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyBaseModel$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyBaseModel";
	

    constructor() {
        super();
        this.type = "EnergyBaseModel";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(EnergyBaseModel, _data);
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
            this.type = obj.type ?? "EnergyBaseModel";
        }
    }


    static override fromJS(data: any): EnergyBaseModel {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
        data["type"] = this.type ?? "EnergyBaseModel";
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
