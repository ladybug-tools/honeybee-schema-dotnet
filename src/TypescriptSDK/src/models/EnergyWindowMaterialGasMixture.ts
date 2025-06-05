import { IsArray, IsEnum, IsDefined, IsNumber, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { GasType } from "./GasType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Create a mixture of two to four different gases to fill the panes of multiple\npane windows. */
export class EnergyWindowMaterialGasMixture extends IDdEnergyBaseModel {
    @IsArray()
    @IsEnum(GasType, { each: true })
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "gas_types" })
    /** List of gases in the gas mixture. */
    gasTypes!: GasType[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "gas_fractions" })
    /** A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1. */
    gasFractions!: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGasMixture$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialGasMixture";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "thickness" })
    /** The thickness of the gas mixture layer in meters. */
    thickness: number = 0.0125;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGasMixture";
        this.thickness = 0.0125;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialGasMixture, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.gasTypes = obj.gasTypes;
            this.gasFractions = obj.gasFractions;
            this.type = obj.type ?? "EnergyWindowMaterialGasMixture";
            this.thickness = obj.thickness ?? 0.0125;
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
        data["gas_types"] = this.gasTypes;
        data["gas_fractions"] = this.gasFractions;
        data["type"] = this.type ?? "EnergyWindowMaterialGasMixture";
        data["thickness"] = this.thickness ?? 0.0125;
        data = super.toJSON(data);
        return instanceToPlain(data, { exposeUnsetFields: false });
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
