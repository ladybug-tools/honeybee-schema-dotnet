import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { GasType } from "./GasType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Create a mixture of two to four different gases to fill the panes of multiple
pane windows. */
export class EnergyWindowMaterialGasMixture extends IDdEnergyBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** List of gases in the gas mixture. */
    gas_types!: GasType [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1. */
    gas_fractions!: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** The thickness of the gas mixture layer in meters. */
    thickness?: number;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGasMixture";
        this.thickness = 0.0125;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.gas_types = _data["gas_types"];
            this.gas_fractions = _data["gas_fractions"];
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowMaterialGasMixture";
            this.thickness = _data["thickness"] !== undefined ? _data["thickness"] : 0.0125;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGasMixture {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowMaterialGasMixture();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["gas_types"] = this.gas_types;
        data["gas_fractions"] = this.gas_fractions;
        data["type"] = this.type;
        data["thickness"] = this.thickness;
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
