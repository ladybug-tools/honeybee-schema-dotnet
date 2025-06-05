import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";
import { RadianceSubFaceStateAbridged } from "./RadianceSubFaceStateAbridged";

/** Radiance Properties for Honeybee Aperture Abridged. */
export class ApertureRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^ApertureRadiancePropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ApertureRadiancePropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "dynamic_group_identifier" })
    /** An optional string to note the dynamic group '             'to which the Aperture is a part of. Apertures sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Aperture is assumed to be static. (default: None). */
    dynamicGroupIdentifier?: string;
	
    @IsArray()
    @IsInstance(RadianceSubFaceStateAbridged, { each: true })
    @Type(() => RadianceSubFaceStateAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "states" })
    /** An optional list of abridged states (default: None). */
    states?: RadianceSubFaceStateAbridged[];
	

    constructor() {
        super();
        this.type = "ApertureRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ApertureRadiancePropertiesAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "ApertureRadiancePropertiesAbridged";
            this.dynamicGroupIdentifier = obj.dynamicGroupIdentifier;
            this.states = obj.states;
        }
    }


    static override fromJS(data: any): ApertureRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ApertureRadiancePropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ApertureRadiancePropertiesAbridged";
        data["dynamic_group_identifier"] = this.dynamicGroupIdentifier;
        data["states"] = this.states;
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
