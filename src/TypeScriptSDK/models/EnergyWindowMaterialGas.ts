import { IsString, IsOptional, Matches, IsNumber, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { GasType } from "./GasType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Create single layer of gas in a window construction.\n\nCan be combined with EnergyWindowMaterialGlazing to make multi-pane windows. */
export class EnergyWindowMaterialGas extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGas$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Thickness of the gas layer in meters. Default: 0.0125. */
    thickness?: number;
	
    @IsEnum(GasType)
    @Type(() => String)
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
            const obj = plainToClass(EnergyWindowMaterialGas, _data);
            this.type = obj.type;
            this.thickness = obj.thickness;
            this.gas_type = obj.gas_type;
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
