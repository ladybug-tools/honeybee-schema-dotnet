import { IsString, IsOptional, IsNumber, IsEnum, ValidateNested, validate, ValidationError } from 'class-validator';
import { GasType } from "./GasType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Create single layer of gas in a window construction.

Can be combined with EnergyWindowMaterialGlazing to make multi-pane windows. */
export class EnergyWindowMaterialGas extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Thickness of the gas layer in meters. Default: 0.0125. */
    thickness?: number;
	
    @IsEnum(GasType)
    @ValidateNested()
    @IsOptional()
    gas_type?: GasType;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGas";
        this.thickness = 0.0125;
        this.gas_type = GasType.Air;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowMaterialGas";
            this.thickness = _data["thickness"] !== undefined ? _data["thickness"] : 0.0125;
            this.gas_type = _data["gas_type"] !== undefined ? _data["gas_type"] : GasType.Air;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGas {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowMaterialGas();
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
        data["thickness"] = this.thickness;
        data["gas_type"] = this.gas_type;
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
