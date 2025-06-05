import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Create single layer of custom gas. */
export class EnergyWindowMaterialGasCustom extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Expose({ name: "conductivity_coeff_a" })
    /** The A coefficient for gas conductivity in W/(m-K). */
    conductivityCoeffA!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "viscosity_coeff_a" })
    /** The A coefficient for gas viscosity in kg/(m-s). */
    viscosityCoeffA!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "specific_heat_coeff_a" })
    /** The A coefficient for gas specific heat in J/(kg-K). */
    specificHeatCoeffA!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "specific_heat_ratio" })
    /** The specific heat ratio for gas. */
    specificHeatRatio!: number;
	
    @IsNumber()
    @IsDefined()
    @Min(20)
    @Max(200)
    @Expose({ name: "molecular_weight" })
    /** The molecular weight for gas in g/mol. */
    molecularWeight!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGasCustom$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialGasCustom";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "thickness" })
    /** Thickness of the gas layer in meters. Default: 0.0125. */
    thickness: number = 0.0125;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "conductivity_coeff_b" })
    /** The B coefficient for gas conductivity in W/(m-K2). */
    conductivityCoeffB: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "conductivity_coeff_c" })
    /** The C coefficient for gas conductivity in W/(m-K3). */
    conductivityCoeffC: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "viscosity_coeff_b" })
    /** The B coefficient for gas viscosity in kg/(m-s-K). */
    viscosityCoeffB: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "viscosity_coeff_c" })
    /** The C coefficient for gas viscosity in kg/(m-s-K2). */
    viscosityCoeffC: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "specific_heat_coeff_b" })
    /** The B coefficient for gas specific heat in J/(kg-K2). */
    specificHeatCoeffB: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "specific_heat_coeff_c" })
    /** The C coefficient for gas specific heat in J/(kg-K3). */
    specificHeatCoeffC: number = 0;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGasCustom";
        this.thickness = 0.0125;
        this.conductivityCoeffB = 0;
        this.conductivityCoeffC = 0;
        this.viscosityCoeffB = 0;
        this.viscosityCoeffC = 0;
        this.specificHeatCoeffB = 0;
        this.specificHeatCoeffC = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialGasCustom, _data, { enableImplicitConversion: true });
            this.conductivityCoeffA = obj.conductivityCoeffA;
            this.viscosityCoeffA = obj.viscosityCoeffA;
            this.specificHeatCoeffA = obj.specificHeatCoeffA;
            this.specificHeatRatio = obj.specificHeatRatio;
            this.molecularWeight = obj.molecularWeight;
            this.type = obj.type;
            this.thickness = obj.thickness;
            this.conductivityCoeffB = obj.conductivityCoeffB;
            this.conductivityCoeffC = obj.conductivityCoeffC;
            this.viscosityCoeffB = obj.viscosityCoeffB;
            this.viscosityCoeffC = obj.viscosityCoeffC;
            this.specificHeatCoeffB = obj.specificHeatCoeffB;
            this.specificHeatCoeffC = obj.specificHeatCoeffC;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGasCustom {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialGasCustom();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["conductivity_coeff_a"] = this.conductivityCoeffA;
        data["viscosity_coeff_a"] = this.viscosityCoeffA;
        data["specific_heat_coeff_a"] = this.specificHeatCoeffA;
        data["specific_heat_ratio"] = this.specificHeatRatio;
        data["molecular_weight"] = this.molecularWeight;
        data["type"] = this.type;
        data["thickness"] = this.thickness;
        data["conductivity_coeff_b"] = this.conductivityCoeffB;
        data["conductivity_coeff_c"] = this.conductivityCoeffC;
        data["viscosity_coeff_b"] = this.viscosityCoeffB;
        data["viscosity_coeff_c"] = this.viscosityCoeffC;
        data["specific_heat_coeff_b"] = this.specificHeatCoeffB;
        data["specific_heat_coeff_c"] = this.specificHeatCoeffC;
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
