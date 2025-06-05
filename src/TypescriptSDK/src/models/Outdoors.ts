import { IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Autocalculate } from "./Autocalculate";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class Outdoors extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^Outdoors$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Outdoors";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "sun_exposure" })
    /** A boolean noting whether the boundary is exposed to sun. */
    sunExposure: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "wind_exposure" })
    /** A boolean noting whether the boundary is exposed to wind. */
    windExposure: boolean = true;
	
    @IsOptional()
    @Expose({ name: "view_factor" })
    /** A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated. */
    viewFactor: (Autocalculate | number) = new Autocalculate();
	

    constructor() {
        super();
        this.type = "Outdoors";
        this.sunExposure = true;
        this.windExposure = true;
        this.viewFactor = new Autocalculate();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Outdoors, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "Outdoors";
            this.sunExposure = obj.sunExposure ?? true;
            this.windExposure = obj.windExposure ?? true;
            this.viewFactor = obj.viewFactor ?? new Autocalculate();
        }
    }


    static override fromJS(data: any): Outdoors {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Outdoors();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "Outdoors";
        data["sun_exposure"] = this.sunExposure ?? true;
        data["wind_exposure"] = this.windExposure ?? true;
        data["view_factor"] = this.viewFactor ?? new Autocalculate();
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
