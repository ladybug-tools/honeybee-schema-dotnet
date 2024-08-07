import { IsString, IsOptional, IsArray, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { RadianceSubFaceStateAbridged } from "./RadianceSubFaceStateAbridged";
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";

/** Radiance Properties for Honeybee Aperture Abridged. */
export class ApertureRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** An optional string to note the dynamic group '             'to which the Aperture is a part of. Apertures sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Aperture is assumed to be static. (default: None). */
    dynamic_group_identifier?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of abridged states (default: None). */
    states?: RadianceSubFaceStateAbridged [];
	

    constructor() {
        super();
        this.type = "ApertureRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ApertureRadiancePropertiesAbridged";
            this.dynamic_group_identifier = _data["dynamic_group_identifier"];
            this.states = _data["states"];
        }
    }


    static override fromJS(data: any): ApertureRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ApertureRadiancePropertiesAbridged();
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
        data["dynamic_group_identifier"] = this.dynamic_group_identifier;
        data["states"] = this.states;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
