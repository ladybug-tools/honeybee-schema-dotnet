import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

/** Used to specify wind conditions on a design day. */
export class WindCondition extends OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    /** Wind speed on the design day [m/s]. */
    wind_speed!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
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
            this.wind_speed = _data["wind_speed"];
            this.type = _data["type"] !== undefined ? _data["type"] : "WindCondition";
            this.wind_direction = _data["wind_direction"] !== undefined ? _data["wind_direction"] : 0;
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
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
