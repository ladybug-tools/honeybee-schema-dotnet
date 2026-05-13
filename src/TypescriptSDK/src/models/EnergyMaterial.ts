import { IsNumber, IsDefined, Max, Min, IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Roughness } from "./Roughness";

/** Opaque material representing a layer within an opaque construction. */
export class EnergyMaterial extends IDdEnergyBaseModel {
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Max(3)
    @Expose({ name: "thickness" })
    /** Thickness of the material layer in meters. */
    thickness!: number;
	
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Expose({ name: "conductivity" })
    /** Thermal conductivity of the material layer in W/m-K. */
    conductivity!: number;
	
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Expose({ name: "density" })
    /** Density of the material layer in kg/m3. */
    density!: number;
	
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Min(100)
    @Expose({ name: "specific_heat" })
    /** Specific heat of the material layer in J/kg-K. */
    specificHeat!: number;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("EnergyMaterial")
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyMaterial";
	
    @Type(() => String)
    @IsEnum(Roughness)
    @IsOptional()
    @Expose({ name: "roughness" })
    /** roughness */
    roughness: Roughness = Roughness.MediumRough;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Max(0.99999)
    @Expose({ name: "thermal_absorptance" })
    /** Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9. */
    thermalAbsorptance: number = 0.9;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "solar_absorptance" })
    /** Fraction of incident solar radiation absorbed by the material. Default: 0.7. */
    solarAbsorptance: number = 0.7;
	
    @Type(() => Number)
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

        if (_data) {
            const obj = deepTransform(EnergyMaterial, _data);
            this.thickness = obj.thickness;
            this.conductivity = obj.conductivity;
            this.density = obj.density;
            this.specificHeat = obj.specificHeat;
            this.type = obj.type ?? "EnergyMaterial";
            this.roughness = obj.roughness ?? Roughness.MediumRough;
            this.thermalAbsorptance = obj.thermalAbsorptance ?? 0.9;
            this.solarAbsorptance = obj.solarAbsorptance ?? 0.7;
            this.visibleAbsorptance = obj.visibleAbsorptance ?? 0.7;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
