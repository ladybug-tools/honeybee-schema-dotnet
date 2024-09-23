import { IsString, IsDefined, Matches, MinLength, MaxLength, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects requiring a valid EnergyPlus identifier. */
export class EnergyBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    /** Display name of the object with no character restrictions. */
    display_name?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyBaseModel$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "EnergyBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyBaseModel, _data, { enableImplicitConversion: true });
            this.identifier = obj.identifier;
            this.display_name = obj.display_name;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): EnergyBaseModel {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["identifier"] = this.identifier;
        data["display_name"] = this.display_name;
        data["type"] = this.type;
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

