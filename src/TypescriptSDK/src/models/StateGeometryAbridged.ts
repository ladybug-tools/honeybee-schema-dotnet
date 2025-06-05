import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { Face3D } from "./Face3D";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** A single planar geometry that can be assigned to Radiance states. */
export class StateGeometryAbridged extends IDdRadianceBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** A ladybug_geometry Face3D. */
    geometry!: Face3D;
	
    @IsString()
    @IsOptional()
    @Matches(/^StateGeometryAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "StateGeometryAbridged";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier" })
    /** A string for a Honeybee Radiance Modifier identifier (default: None). */
    modifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier_direct" })
    /** A string for Honeybee Radiance Modifier identifiers to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None). */
    modifierDirect?: string;
	

    constructor() {
        super();
        this.type = "StateGeometryAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(StateGeometryAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.geometry = obj.geometry;
            this.type = obj.type ?? "StateGeometryAbridged";
            this.modifier = obj.modifier;
            this.modifierDirect = obj.modifierDirect;
        }
    }


    static override fromJS(data: any): StateGeometryAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new StateGeometryAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["type"] = this.type ?? "StateGeometryAbridged";
        data["modifier"] = this.modifier;
        data["modifier_direct"] = this.modifierDirect;
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
