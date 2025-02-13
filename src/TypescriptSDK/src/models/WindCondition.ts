import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
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
    /** Type */
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
            const obj = plainToClass(WindCondition, _data, { enableImplicitConversion: true });
            this.wind_speed = obj.wind_speed;
            this.type = obj.type;
            this.wind_direction = obj.wind_direction;
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
        data["wind_speed"] = this.wind_speed;
        data["type"] = this.type;
        data["wind_direction"] = this.wind_direction;
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

