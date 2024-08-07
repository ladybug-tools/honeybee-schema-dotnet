import { IsString, IsOptional, IsNumber, validate, ValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class ElectricLoadCenter extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the load center inverter nominal rated DC-to-AC conversion efficiency. An inverter converts DC power, such as that output by photovoltaic panels, to AC power, such as that distributed by the electrical grid and is available from standard electrical outlets. Inverter efficiency is defined as the inverter rated AC power output divided by its rated DC power output. */
    inverter_efficiency?: number;
	
    @IsNumber()
    @IsOptional()
    /** A positive number (typically greater than 1) for the ratio of the inverter DC rated size to its AC rated size. Typically, inverters are not sized to convert the full DC output under standard test conditions (STC) as such conditions rarely occur in reality and therefore unnecessarily add to the size/cost of the inverter. For a system with a high DC to AC size ratio, during times when the DC power output exceeds the inverter rated DC input size, the inverter limits the power output by increasing the DC operating voltage, which moves the arrays operating point down its current-voltage (I-V) curve. In EnergyPlus, this is accomplished by simply limiting the system output to the AC size as dictated by the ratio. The default value of 1.1 is reasonable for most systems. A typical range is 1.1 to 1.25, although some large-scale systems have ratios of as high as 1.5. The optimal value depends on the system location, array orientation, and module cost. */
    inverter_dc_to_ac_size_ratio?: number;
	

    constructor() {
        super();
        this.type = "ElectricLoadCenter";
        this.inverter_efficiency = 0.96;
        this.inverter_dc_to_ac_size_ratio = 1.1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ElectricLoadCenter";
            this.inverter_efficiency = _data["inverter_efficiency"] !== undefined ? _data["inverter_efficiency"] : 0.96;
            this.inverter_dc_to_ac_size_ratio = _data["inverter_dc_to_ac_size_ratio"] !== undefined ? _data["inverter_dc_to_ac_size_ratio"] : 1.1;
        }
    }


    static override fromJS(data: any): ElectricLoadCenter {
        data = typeof data === 'object' ? data : {};

        let result = new ElectricLoadCenter();
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
        data["inverter_efficiency"] = this.inverter_efficiency;
        data["inverter_dc_to_ac_size_ratio"] = this.inverter_dc_to_ac_size_ratio;
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
