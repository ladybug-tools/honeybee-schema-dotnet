import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify wind conditions on a design day. */
export class WindCondition extends _OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(40)
    /** Wind speed on the design day [m/s]. */
    wind_speed!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^WindCondition$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(360)
    /** Wind direction on the design day [degrees]. */
    wind_direction?: number;
	

    constructor() {
        super();
        this.type = "WindCondition";
        this.wind_direction = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WindCondition, _data);
            this.wind_speed = obj.wind_speed;
            this.type = obj.type;
            this.wind_direction = obj.wind_direction;
        }
    }


    static override fromJS(data: any): WindCondition {
        data = typeof data === 'object' ? data : {};

        let result = new WindCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["wind_speed"] = this.wind_speed;
        data["type"] = this.type;
        data["wind_direction"] = this.wind_direction;
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
