import { IsNumber, IsDefined, IsString, IsOptional, IsEnum, ValidateNested, validate, ValidationError } from 'class-validator';
import { Roughness } from "./Roughness";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Opaque material representing a layer within an opaque construction. */
export class EnergyMaterial extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** Thickness of the material layer in meters. */
    thickness!: number;
	
    @IsNumber()
    @IsDefined()
    /** Thermal conductivity of the material layer in W/m-K. */
    conductivity!: number;
	
    @IsNumber()
    @IsDefined()
    /** Density of the material layer in kg/m3. */
    density!: number;
	
    @IsNumber()
    @IsDefined()
    /** Specific heat of the material layer in J/kg-K. */
    specific_heat!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(Roughness)
    @ValidateNested()
    @IsOptional()
    roughness?: Roughness;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9. */
    thermal_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident solar radiation absorbed by the material. Default: 0.7. */
    solar_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. */
    visible_absorptance?: number;
	

    constructor() {
        super();
        this.type = "EnergyMaterial";
        this.roughness = Roughness.MediumRough;
        this.thermal_absorptance = 0.9;
        this.solar_absorptance = 0.7;
        this.visible_absorptance = 0.7;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.thickness = _data["thickness"];
            this.conductivity = _data["conductivity"];
            this.density = _data["density"];
            this.specific_heat = _data["specific_heat"];
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyMaterial";
            this.roughness = _data["roughness"] !== undefined ? _data["roughness"] : Roughness.MediumRough;
            this.thermal_absorptance = _data["thermal_absorptance"] !== undefined ? _data["thermal_absorptance"] : 0.9;
            this.solar_absorptance = _data["solar_absorptance"] !== undefined ? _data["solar_absorptance"] : 0.7;
            this.visible_absorptance = _data["visible_absorptance"] !== undefined ? _data["visible_absorptance"] : 0.7;
        }
    }


    static override fromJS(data: any): EnergyMaterial {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyMaterial();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["thickness"] = this.thickness;
        data["conductivity"] = this.conductivity;
        data["density"] = this.density;
        data["specific_heat"] = this.specific_heat;
        data["type"] = this.type;
        data["roughness"] = this.roughness;
        data["thermal_absorptance"] = this.thermal_absorptance;
        data["solar_absorptance"] = this.solar_absorptance;
        data["visible_absorptance"] = this.visible_absorptance;
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
