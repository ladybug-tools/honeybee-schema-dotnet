import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Abridged Radiance Properties for Honeybee Room. */
export class RoomRadiancePropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** An identifier for a unique Room-Assigned ModifierSet (default: None). */
    modifier_set?: string;
	

    constructor() {
        super();
        this.type = "RoomRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "RoomRadiancePropertiesAbridged";
            this.modifier_set = _data["modifier_set"];
        }
    }


    static override fromJS(data: any): RoomRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new RoomRadiancePropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["modifier_set"] = this.modifier_set;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
