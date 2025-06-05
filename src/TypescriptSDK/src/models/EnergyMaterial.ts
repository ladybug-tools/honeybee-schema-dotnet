import { IsNumber, IsDefined, Max, Min, IsString, IsOptional, Matches, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Roughness } from "./Roughness";

/** Opaque material representing a layer within an opaque construction. */
export class EnergyMaterial extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Max(3)
    @Expose({ name: "thickness" })
    /** Thickness of the material layer in meters. */
    thickness!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "conductivity" })
    /** Thermal conductivity of the material layer in W/m-K. */
    conductivity!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "density" })
    /** Density of the material layer in kg/m3. */
    density!: number;
	
    @IsNumber()
    @IsDefined()
    @Min(100)
    @Expose({ name: "specific_heat" })
    /** Specific heat of the material layer in J/kg-K. */
    specificHeat!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyMaterial$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyMaterial";
	
    @IsEnum(Roughness)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "roughness" })
    /** roughness */
    roughness: Roughness = Roughness.MediumRough;
	
    @IsNumber()
    @IsOptional()
    @Max(0.99999)
    @Expose({ name: "thermal_absorptance" })
    /** Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9. */
    thermalAbsorptance: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "solar_absorptance" })
    /** Fraction of incident solar radiation absorbed by the material. Default: 0.7. */
    solarAbsorptance: number = 0.7;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "visible_absorptance" })
    /** Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. */
    visibleAbsorptance: number = 0.7;
	

    constructor() {
        super();
        this.type = "EnergyMaterial";
        this.roughness = Roughness.MediumRough;
        this.thermalAbsorptance = 0.9;
        this.solarAbsorptance = 0.7;
        this.visibleAbsorptance = 0.7;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyMaterial, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.thickness = obj.thickness;
            this.conductivity = obj.conductivity;
            this.density = obj.density;
            this.specificHeat = obj.specificHeat;
            this.type = obj.type ?? "EnergyMaterial";
            this.roughness = obj.roughness ?? Roughness.MediumRough;
            this.thermalAbsorptance = obj.thermalAbsorptance ?? 0.9;
            this.solarAbsorptance = obj.solarAbsorptance ?? 0.7;
            this.visibleAbsorptance = obj.visibleAbsorptance ?? 0.7;
        }
    }


    static override fromJS(data: any): EnergyMaterial {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyMaterial();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["thickness"] = this.thickness;
        data["conductivity"] = this.conductivity;
        data["density"] = this.density;
        data["specific_heat"] = this.specificHeat;
        data["type"] = this.type ?? "EnergyMaterial";
        data["roughness"] = this.roughness ?? Roughness.MediumRough;
        data["thermal_absorptance"] = this.thermalAbsorptance ?? 0.9;
        data["solar_absorptance"] = this.solarAbsorptance ?? 0.7;
        data["visible_absorptance"] = this.visibleAbsorptance ?? 0.7;
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
