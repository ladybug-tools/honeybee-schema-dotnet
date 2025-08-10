import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
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

        if (_data) {
            const obj = deepTransform(EnergyWindowMaterialGasCustom, _data);
            this.conductivityCoeffA = obj.conductivityCoeffA;
            this.viscosityCoeffA = obj.viscosityCoeffA;
            this.specificHeatCoeffA = obj.specificHeatCoeffA;
            this.specificHeatRatio = obj.specificHeatRatio;
            this.molecularWeight = obj.molecularWeight;
            this.type = obj.type ?? "EnergyWindowMaterialGasCustom";
            this.thickness = obj.thickness ?? 0.0125;
            this.conductivityCoeffB = obj.conductivityCoeffB ?? 0;
            this.conductivityCoeffC = obj.conductivityCoeffC ?? 0;
            this.viscosityCoeffB = obj.viscosityCoeffB ?? 0;
            this.viscosityCoeffC = obj.viscosityCoeffC ?? 0;
            this.specificHeatCoeffB = obj.specificHeatCoeffB ?? 0;
            this.specificHeatCoeffC = obj.specificHeatCoeffC ?? 0;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["type"] = this.type ?? "EnergyWindowMaterialGasCustom";
        data["thickness"] = this.thickness ?? 0.0125;
        data["conductivity_coeff_b"] = this.conductivityCoeffB ?? 0;
        data["conductivity_coeff_c"] = this.conductivityCoeffC ?? 0;
        data["viscosity_coeff_b"] = this.viscosityCoeffB ?? 0;
        data["viscosity_coeff_c"] = this.viscosityCoeffC ?? 0;
        data["specific_heat_coeff_b"] = this.specificHeatCoeffB ?? 0;
        data["specific_heat_coeff_c"] = this.specificHeatCoeffC ?? 0;
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
