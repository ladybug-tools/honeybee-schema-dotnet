import { IsString, IsOptional, Matches, IsEnum, IsInt, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { CalculationMethod } from "./CalculationMethod";
import { CalculationUpdateMethod } from "./CalculationUpdateMethod";
import { SolarDistribution } from "./SolarDistribution";

/** Used to describe settings for EnergyPlus shadow calculation. */
export class ShadowCalculation extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ShadowCalculation$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadowCalculation";
	
    @IsEnum(SolarDistribution)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "solar_distribution" })
    /** solarDistribution */
    solarDistribution: SolarDistribution = SolarDistribution.FullExteriorWithReflections;
	
    @IsEnum(CalculationMethod)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "calculation_method" })
    /** Text noting whether CPU-based polygon clipping method orGPU-based pixel counting method should be used. For low numbers of shadingsurfaces (less than ~200), PolygonClipping requires less runtime thanPixelCounting. However, PixelCounting runtime scales significantlybetter at higher numbers of shading surfaces. PixelCounting also hasno limitations related to zone concavity when used with any“FullInterior” solar distribution options. */
    calculationMethod: CalculationMethod = CalculationMethod.PolygonClipping;
	
    @IsEnum(CalculationUpdateMethod)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "calculation_update_method" })
    /** Text describing how often the solar and shading calculations are updated with respect to the flow of time in the simulation. */
    calculationUpdateMethod: CalculationUpdateMethod = CalculationUpdateMethod.Periodic;
	
    @IsInt()
    @IsOptional()
    @Min(1)
    @Expose({ name: "calculation_frequency" })
    /** Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used. */
    calculationFrequency: number = 30;
	
    @IsInt()
    @IsOptional()
    @Min(200)
    @Expose({ name: "maximum_figures" })
    /** Number of allowable figures in shadow overlap calculations. */
    maximumFigures: number = 15000;
	

    constructor() {
        super();
        this.type = "ShadowCalculation";
        this.solarDistribution = SolarDistribution.FullExteriorWithReflections;
        this.calculationMethod = CalculationMethod.PolygonClipping;
        this.calculationUpdateMethod = CalculationUpdateMethod.Periodic;
        this.calculationFrequency = 30;
        this.maximumFigures = 15000;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadowCalculation, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.solarDistribution = obj.solarDistribution;
            this.calculationMethod = obj.calculationMethod;
            this.calculationUpdateMethod = obj.calculationUpdateMethod;
            this.calculationFrequency = obj.calculationFrequency;
            this.maximumFigures = obj.maximumFigures;
        }
    }


    static override fromJS(data: any): ShadowCalculation {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadowCalculation();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["solar_distribution"] = this.solarDistribution;
        data["calculation_method"] = this.calculationMethod;
        data["calculation_update_method"] = this.calculationUpdateMethod;
        data["calculation_frequency"] = this.calculationFrequency;
        data["maximum_figures"] = this.maximumFigures;
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
