import { IsEnum, IsDefined, IsNumber, IsString, IsOptional, Matches, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { HumidityTypes } from "./HumidityTypes";

/** Used to specify humidity conditions on a design day. */
export class HumidityCondition extends _OpenAPIGenBaseModel {
    @IsEnum(HumidityTypes)
    @Type(() => String)
    @IsDefined()
    humidity_type!: HumidityTypes;
	
    @IsNumber()
    @IsDefined()
    /** The value correcponding to the humidity_type. */
    humidity_value!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^HumidityCondition$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(31000)
    @Max(120000)
    /** Barometric air pressure on the design day [Pa]. */
    barometric_pressure?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to indicate rain on the design day. */
    rain?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to indicate snow on the ground during the design day. */
    snow_on_ground?: boolean;
	

    constructor() {
        super();
        this.type = "HumidityCondition";
        this.barometric_pressure = 101325;
        this.rain = false;
        this.snow_on_ground = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(HumidityCondition, _data, { enableImplicitConversion: true });
            this.humidity_type = obj.humidity_type;
            this.humidity_value = obj.humidity_value;
            this.type = obj.type;
            this.barometric_pressure = obj.barometric_pressure;
            this.rain = obj.rain;
            this.snow_on_ground = obj.snow_on_ground;
        }
    }


    static override fromJS(data: any): HumidityCondition {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new HumidityCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["humidity_type"] = this.humidity_type;
        data["humidity_value"] = this.humidity_value;
        data["type"] = this.type;
        data["barometric_pressure"] = this.barometric_pressure;
        data["rain"] = this.rain;
        data["snow_on_ground"] = this.snow_on_ground;
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

