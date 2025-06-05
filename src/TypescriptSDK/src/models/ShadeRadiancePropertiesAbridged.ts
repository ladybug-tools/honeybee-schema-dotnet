import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";
import { RadianceShadeStateAbridged } from "./RadianceShadeStateAbridged";

/** Radiance Properties for Honeybee Shade Abridged. */
export class ShadeRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeRadiancePropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadeRadiancePropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "dynamic_group_identifier" })
    /** An optional string to note the dynamic group '             'to which the Shade is a part of. Shades sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Shade is assumed to be static. (default: None). */
    dynamicGroupIdentifier?: string;
	
    @IsArray()
    @IsInstance(RadianceShadeStateAbridged, { each: true })
    @Type(() => RadianceShadeStateAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "states" })
    /** An optional list of abridged states (default: None). */
    states?: RadianceShadeStateAbridged[];
	

    constructor() {
        super();
        this.type = "ShadeRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadeRadiancePropertiesAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "ShadeRadiancePropertiesAbridged";
            this.dynamicGroupIdentifier = obj.dynamicGroupIdentifier;
            this.states = obj.states;
        }
    }


    static override fromJS(data: any): ShadeRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeRadiancePropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ShadeRadiancePropertiesAbridged";
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
