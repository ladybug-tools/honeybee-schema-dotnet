import { IsString, IsOptional, Matches, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Autocalculate } from "./Autocalculate";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class OtherSideTemperature extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^OtherSideTemperature$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "OtherSideTemperature";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "heat_transfer_coefficient" })
    /** A value in W/m2-K to indicate the combined convective/radiative film coefficient. If equal to 0, then the specified temperature above is equal to the exterior surface temperature. Otherwise, the temperature above is considered the outside air temperature and this coefficient is used to determine the difference between this outside air temperature and the exterior surface temperature. */
    heatTransferCoefficient: number = 0;
	
    @IsOptional()
    @Expose({ name: "temperature" })
    /** A temperature value in Celsius to note the temperature on the other side of the object. This input can also be an Autocalculate object to signify that the temperature is equal to the outdoor air temperature. */
    temperature: (Autocalculate | number) = new Autocalculate();
	

    constructor() {
        super();
        this.type = "OtherSideTemperature";
        this.heatTransferCoefficient = 0;
        this.temperature = new Autocalculate();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(OtherSideTemperature, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.heatTransferCoefficient = obj.heatTransferCoefficient;
            this.temperature = obj.temperature;
        }
    }


    static override fromJS(data: any): OtherSideTemperature {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new OtherSideTemperature();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["heat_transfer_coefficient"] = this.heatTransferCoefficient;
        data["temperature"] = this.temperature;
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
