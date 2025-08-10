import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Abridged Radiance Properties for Honeybee Room. */
export class RoomRadiancePropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RoomRadiancePropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RoomRadiancePropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier_set" })
    /** An identifier for a unique Room-Assigned ModifierSet (default: None). */
    modifierSet?: string;
	

    constructor() {
        super();
        this.type = "RoomRadiancePropertiesAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoomRadiancePropertiesAbridged, _data);
        }
    }


    static override fromJS(data: any): RoomRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoomRadiancePropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoomRadiancePropertiesAbridged";
        data["modifier_set"] = this.modifierSet;
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
