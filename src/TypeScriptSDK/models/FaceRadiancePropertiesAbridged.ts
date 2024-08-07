import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";

/** Radiance Properties for Honeybee Face Abridged. */
export class FaceRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "FaceRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "FaceRadiancePropertiesAbridged";
        }
    }


    static override fromJS(data: any): FaceRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new FaceRadiancePropertiesAbridged();
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
