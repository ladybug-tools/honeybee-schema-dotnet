import { IsEnum, ValidateNested, IsDefined, IsNumber, IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { HumidityTypes } from "./HumidityTypes";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify humidity conditions on a design day. */
export class HumidityCondition extends _OpenAPIGenBaseModel {
    @IsEnum(HumidityTypes)
    @ValidateNested()
    @IsDefined()
    humidity_type!: HumidityTypes;
	
    @IsNumber()
    @IsDefined()
    /** The value correcponding to the humidity_type. */
    humidity_value!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Barometric air pressure on the design day [Pa]. */
    barometric_pressure?: number;
	
    @IsOptional()
    /** Boolean to indicate rain on the design day. */
    rain?: boolean;
	
    @IsOptional()
    /** Boolean to indicate snow on the ground during the design day. */
    snow_on_ground?: boolean;
	

    constructor() {
        super();
        this.type = "HumidityCondition";
        this.barometric_pressure = 101325;
        this.rain = False;
        this.snow_on_ground = False;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.humidity_type = _data["humidity_type"];
            this.humidity_value = _data["humidity_value"];
            this.type = _data["type"] !== undefined ? _data["type"] : "HumidityCondition";
            this.barometric_pressure = _data["barometric_pressure"] !== undefined ? _data["barometric_pressure"] : 101325;
            this.rain = _data["rain"] !== undefined ? _data["rain"] : False;
            this.snow_on_ground = _data["snow_on_ground"] !== undefined ? _data["snow_on_ground"] : False;
        }
    }


    static override fromJS(data: any): HumidityCondition {
        data = typeof data === 'object' ? data : {};

        let result = new HumidityCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["humidity_type"] = this.humidity_type;
        data["humidity_value"] = this.humidity_value;
        data["type"] = this.type;
        data["barometric_pressure"] = this.barometric_pressure;
        data["rain"] = this.rain;
        data["snow_on_ground"] = this.snow_on_ground;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
