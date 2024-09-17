import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";
import { RadianceSubFaceStateAbridged } from "./RadianceSubFaceStateAbridged";

/** Radiance Properties for Honeybee Door Abridged. */
export class DoorRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^DoorRadiancePropertiesAbridged$/)
    type?: string;
	
    @IsString()
    @IsOptional()
    /** An optional string to note the dynamic group '             'to which the Door is a part of. Doors sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Door is assumed to be static. (default: None). */
    dynamic_group_identifier?: string;
	
    @IsArray()
    @IsInstance(RadianceSubFaceStateAbridged, { each: true })
    @Type(() => RadianceSubFaceStateAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of abridged states (default: None). */
    states?: RadianceSubFaceStateAbridged [];
	

    constructor() {
        super();
        this.type = "DoorRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorRadiancePropertiesAbridged, _data);
            this.type = obj.type;
            this.dynamic_group_identifier = obj.dynamic_group_identifier;
            this.states = obj.states;
        }
    }


    static override fromJS(data: any): DoorRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new DoorRadiancePropertiesAbridged();
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
        data = super.toJSON(data);
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
