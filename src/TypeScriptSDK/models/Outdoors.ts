import { IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Autocalculate } from "./Autocalculate";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class Outdoors extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^Outdoors$/)
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean noting whether the boundary is exposed to sun. */
    sun_exposure?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean noting whether the boundary is exposed to wind. */
    wind_exposure?: boolean;
	
    @IsOptional()
    /** A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated. */
    view_factor?: (Autocalculate | number);
	

    constructor() {
        super();
        this.type = "Outdoors";
        this.sun_exposure = true;
        this.wind_exposure = true;
        this.view_factor = new Autocalculate();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Outdoors, _data);
            this.type = obj.type;
            this.sun_exposure = obj.sun_exposure;
            this.wind_exposure = obj.wind_exposure;
            this.view_factor = obj.view_factor;
        }
    }


    static override fromJS(data: any): Outdoors {
        data = typeof data === 'object' ? data : {};

        let result = new Outdoors();
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
        data["sun_exposure"] = this.sun_exposure;
        data["wind_exposure"] = this.wind_exposure;
        data["view_factor"] = this.view_factor;
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
