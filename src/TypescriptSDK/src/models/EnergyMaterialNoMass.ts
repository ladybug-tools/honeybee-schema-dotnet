import { IsNumber, IsDefined, Min, IsString, IsOptional, Matches, IsEnum, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Roughness } from "./Roughness";

/** No mass opaque material representing a layer within an opaque construction.\n\nUsed when only the thermal resistance (R value) of the material is known. */
export class EnergyMaterialNoMass extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0.001)
    @Expose({ name: "r_value" })
    /** The thermal resistance (R-value) of the material layer [m2-K/W]. */
    rValue!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyMaterialNoMass$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyMaterialNoMass";
	
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
        this.type = "EnergyMaterialNoMass";
        this.roughness = Roughness.MediumRough;
        this.thermalAbsorptance = 0.9;
        this.solarAbsorptance = 0.7;
        this.visibleAbsorptance = 0.7;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyMaterialNoMass, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.rValue = obj.rValue;
            this.type = obj.type ?? "EnergyMaterialNoMass";
            this.roughness = obj.roughness ?? Roughness.MediumRough;
            this.thermalAbsorptance = obj.thermalAbsorptance ?? 0.9;
            this.solarAbsorptance = obj.solarAbsorptance ?? 0.7;
            this.visibleAbsorptance = obj.visibleAbsorptance ?? 0.7;
        }
    }


    static override fromJS(data: any): EnergyMaterialNoMass {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyMaterialNoMass();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["r_value"] = this.rValue;
        data["type"] = this.type ?? "EnergyMaterialNoMass";
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
