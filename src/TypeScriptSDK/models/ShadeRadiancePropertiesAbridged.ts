﻿import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";
import { RadianceShadeStateAbridged } from "./RadianceShadeStateAbridged";

/** Radiance Properties for Honeybee Shade Abridged. */
export class ShadeRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeRadiancePropertiesAbridged$/)
    type?: string;
	
    @IsString()
    @IsOptional()
    /** An optional string to note the dynamic group '             'to which the Shade is a part of. Shades sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Shade is assumed to be static. (default: None). */
    dynamic_group_identifier?: string;
	
    @IsArray()
    @IsInstance(RadianceShadeStateAbridged, { each: true })
    @Type(() => RadianceShadeStateAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of abridged states (default: None). */
    states?: RadianceShadeStateAbridged [];
	

    constructor() {
        super();
        this.type = "ShadeRadiancePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadeRadiancePropertiesAbridged, _data);
            this.type = obj.type;
            this.dynamic_group_identifier = obj.dynamic_group_identifier;
            this.states = obj.states;
        }
    }


    static override fromJS(data: any): ShadeRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ShadeRadiancePropertiesAbridged();
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
