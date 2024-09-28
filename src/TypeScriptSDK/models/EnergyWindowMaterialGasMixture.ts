import { IsArray, IsEnum, IsDefined, IsNumber, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { GasType } from "./GasType.ts";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel.ts";

/** Create a mixture of two to four different gases to fill the panes of multiple\npane windows. */
export class EnergyWindowMaterialGasMixture extends IDdEnergyBaseModel {
    @IsArray()
    @IsEnum(GasType, { each: true })
    @Type(() => String)
    @IsDefined()
    /** List of gases in the gas mixture. */
    gas_types!: GasType [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1. */
    gas_fractions!: number [];
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGasMixture$/)
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
            const obj = plainToClass(EnergyWindowMaterialGasMixture, _data, { enableImplicitConversion: true });
            this.gas_types = obj.gas_types;
            this.gas_fractions = obj.gas_fractions;
            this.type = obj.type;
            this.thickness = obj.thickness;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGasMixture {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialGasMixture();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["gas_types"] = this.gas_types;
        data["gas_fractions"] = this.gas_fractions;
        data["type"] = this.type;
        data["thickness"] = this.thickness;
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

