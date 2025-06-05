import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class of Abridged Radiance Properties. */
export class _PropertiesBaseAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier" })
    /** A string for a Honeybee Radiance Modifier (default: None). */
    modifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier_blk" })
    /** A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None). */
    modifierBlk?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^_PropertiesBaseAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_PropertiesBaseAbridged";
	

    constructor() {
        super();
        this.type = "_PropertiesBaseAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_PropertiesBaseAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.modifier = obj.modifier;
            this.modifierBlk = obj.modifierBlk;
            this.type = obj.type ?? "_PropertiesBaseAbridged";
        }
    }


    static override fromJS(data: any): _PropertiesBaseAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _PropertiesBaseAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["modifier"] = this.modifier;
        data["modifier_blk"] = this.modifierBlk;
        data["type"] = this.type ?? "_PropertiesBaseAbridged";
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
