import { IsEnum, IsDefined, IsNumber, IsString, IsOptional, Matches, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { HumidityTypes } from "./HumidityTypes";

/** Used to specify humidity conditions on a design day. */
export class HumidityCondition extends _OpenAPIGenBaseModel {
    @IsEnum(HumidityTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "humidity_type" })
    /** humidityType */
    humidityType!: HumidityTypes;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "humidity_value" })
    /** The value correcponding to the humidity_type. */
    humidityValue!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^HumidityCondition$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "HumidityCondition";
	
    @IsNumber()
    @IsOptional()
    @Min(31000)
    @Max(120000)
    @Expose({ name: "barometric_pressure" })
    /** Barometric air pressure on the design day [Pa]. */
    barometricPressure: number = 101325;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "rain" })
    /** Boolean to indicate rain on the design day. */
    rain: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "snow_on_ground" })
    /** Boolean to indicate snow on the ground during the design day. */
    snowOnGround: boolean = false;
	

    constructor() {
        super();
        this.type = "HumidityCondition";
        this.barometricPressure = 101325;
        this.rain = false;
        this.snowOnGround = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(HumidityCondition, _data, { enableImplicitConversion: true });
            this.humidityType = obj.humidityType;
            this.humidityValue = obj.humidityValue;
            this.type = obj.type;
            this.barometricPressure = obj.barometricPressure;
            this.rain = obj.rain;
            this.snowOnGround = obj.snowOnGround;
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
        data["humidity_type"] = this.humidityType;
        data["humidity_value"] = this.humidityValue;
        data["type"] = this.type;
        data["barometric_pressure"] = this.barometricPressure;
        data["rain"] = this.rain;
        data["snow_on_ground"] = this.snowOnGround;
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
