import { IsString, IsDefined, Matches, MinLength, MaxLength, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class IDdBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @MaxLength(100)
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters. */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    /** Display name of the object with no character restrictions. */
    display_name?: string;
	
    @IsOptional()
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    user_data?: Object;
	
    @IsString()
    @IsOptional()
    @Matches(/^IDdBaseModel$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(IDdBaseModel, _data);
            this.identifier = obj.identifier;
            this.display_name = obj.display_name;
            this.user_data = obj.user_data;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): IDdBaseModel {
        data = typeof data === 'object' ? data : {};

        let result = new IDdBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["identifier"] = this.identifier;
        data["display_name"] = this.display_name;
        data["user_data"] = this.user_data;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
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
