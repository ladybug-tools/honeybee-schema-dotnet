import { IsString, IsOptional, IsNumber, validate, ValidationError } from 'class-validator';
import { Autocalculate } from "./Autocalculate";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class OtherSideTemperature extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A value in W/m2-K to indicate the combined convective/radiative film coefficient. If equal to 0, then the specified temperature above is equal to the exterior surface temperature. Otherwise, the temperature above is considered the outside air temperature and this coefficient is used to determine the difference between this outside air temperature and the exterior surface temperature. */
    heat_transfer_coefficient?: number;
	
    @IsOptional()
    /** A temperature value in Celsius to note the temperature on the other side of the object. This input can also be an Autocalculate object to signify that the temperature is equal to the outdoor air temperature. */
    temperature?: Autocalculate | number;
	

    constructor() {
        super();
        this.type = "OtherSideTemperature";
        this.heat_transfer_coefficient = 0;
        this.temperature = new Autocalculate();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "OtherSideTemperature";
            this.heat_transfer_coefficient = _data["heat_transfer_coefficient"] !== undefined ? _data["heat_transfer_coefficient"] : 0;
            this.temperature = _data["temperature"] !== undefined ? _data["temperature"] : new Autocalculate();
        }
    }


    static override fromJS(data: any): OtherSideTemperature {
        data = typeof data === 'object' ? data : {};

        let result = new OtherSideTemperature();
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
        data["heat_transfer_coefficient"] = this.heat_transfer_coefficient;
        data["temperature"] = this.temperature;
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
