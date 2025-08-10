import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify wind conditions on a design day. */
export class WindCondition extends _OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(40)
    @Expose({ name: "wind_speed" })
    /** Wind speed on the design day [m/s]. */
    windSpeed!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^WindCondition$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WindCondition";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(360)
    @Expose({ name: "wind_direction" })
    /** Wind direction on the design day [degrees]. */
    windDirection: number = 0;
	

    constructor() {
        super();
        this.type = "WindCondition";
        this.windDirection = 0;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WindCondition, _data);
            this.windSpeed = obj.windSpeed;
            this.type = obj.type ?? "WindCondition";
            this.windDirection = obj.windDirection ?? 0;
        }
    }


    static override fromJS(data: any): WindCondition {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WindCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["wind_speed"] = this.windSpeed;
        data["type"] = this.type ?? "WindCondition";
        data["wind_direction"] = this.windDirection ?? 0;
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
