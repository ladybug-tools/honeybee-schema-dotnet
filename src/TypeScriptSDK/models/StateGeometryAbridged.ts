import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { Face3D } from "./Face3D";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** A single planar geometry that can be assigned to Radiance states. */
export class StateGeometryAbridged extends IDdRadianceBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    /** A ladybug_geometry Face3D. */
    geometry!: Face3D;
	
    @IsString()
    @IsOptional()
    @Matches(/^StateGeometryAbridged$/)
    type?: string;
	
    @IsString()
    @IsOptional()
    /** A string for a Honeybee Radiance Modifier identifier (default: None). */
    modifier?: string;
	
    @IsString()
    @IsOptional()
    /** A string for Honeybee Radiance Modifier identifiers to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None). */
    modifier_direct?: string;
	

    constructor() {
        super();
        this.type = "StateGeometryAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(StateGeometryAbridged, _data);
            this.geometry = obj.geometry;
            this.type = obj.type;
            this.modifier = obj.modifier;
            this.modifier_direct = obj.modifier_direct;
        }
    }


    static override fromJS(data: any): StateGeometryAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new StateGeometryAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["geometry"] = this.geometry;
        data["type"] = this.type;
        data["modifier"] = this.modifier;
        data["modifier_direct"] = this.modifier_direct;
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
