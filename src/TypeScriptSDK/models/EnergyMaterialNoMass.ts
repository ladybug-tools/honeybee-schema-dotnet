import { IsNumber, IsDefined, Min, IsString, IsOptional, Matches, IsEnum, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Roughness } from "./Roughness";

/** No mass opaque material representing a layer within an opaque construction.\n\nUsed when only the thermal resistance (R value) of the material is known. */
export class EnergyMaterialNoMass extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0.001)
    /** The thermal resistance (R-value) of the material layer [m2-K/W]. */
    r_value!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyMaterialNoMass$/)
    type?: string;
	
    @IsEnum(Roughness)
    @Type(() => String)
    @IsOptional()
    roughness?: Roughness;
	
    @IsNumber()
    @IsOptional()
    @Max(0.99999)
    /** Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9. */
    thermal_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Fraction of incident solar radiation absorbed by the material. Default: 0.7. */
    solar_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. */
    visible_absorptance?: number;
	

    constructor() {
        super();
        this.type = "EnergyMaterialNoMass";
        this.roughness = Roughness.MediumRough;
        this.thermal_absorptance = 0.9;
        this.solar_absorptance = 0.7;
        this.visible_absorptance = 0.7;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyMaterialNoMass, _data);
            this.r_value = obj.r_value;
            this.type = obj.type;
            this.roughness = obj.roughness;
            this.thermal_absorptance = obj.thermal_absorptance;
            this.solar_absorptance = obj.solar_absorptance;
            this.visible_absorptance = obj.visible_absorptance;
        }
    }


    static override fromJS(data: any): EnergyMaterialNoMass {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyMaterialNoMass();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["r_value"] = this.r_value;
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
