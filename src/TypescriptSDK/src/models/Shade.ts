﻿import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { Face3D } from "./Face3D";
import { IDdBaseModel } from "./IDdBaseModel";
import { ShadePropertiesAbridged } from "./ShadePropertiesAbridged";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Shade extends IDdBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsInstance(ShadePropertiesAbridged)
    @Type(() => ShadePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ShadePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Shade$/)
    /** Type */
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. Note that this should always be False for shades assigned to parent objects. */
    is_detached?: boolean;
	

    constructor() {
        super();
        this.type = "Shade";
        this.is_detached = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Shade, _data, { enableImplicitConversion: true });
            this.geometry = obj.geometry;
            this.properties = obj.properties;
            this.type = obj.type;
            this.is_detached = obj.is_detached;
        }
    }


    static override fromJS(data: any): Shade {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Shade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["is_detached"] = this.is_detached;
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

