import { IsString, IsOptional, IsEnum, ValidateNested, IsInt, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { CalculationMethod } from "./CalculationMethod";
import { CalculationUpdateMethod } from "./CalculationUpdateMethod";
import { SolarDistribution } from "./SolarDistribution";

/** Used to describe settings for EnergyPlus shadow calculation. */
export class ShadowCalculation extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(SolarDistribution)
    @ValidateNested()
    @IsOptional()
    solar_distribution?: SolarDistribution;
	
    @IsEnum(CalculationMethod)
    @ValidateNested()
    @IsOptional()
    /** Text noting whether CPU-based polygon clipping method orGPU-based pixel counting method should be used. For low numbers of shadingsurfaces (less than ~200), PolygonClipping requires less runtime thanPixelCounting. However, PixelCounting runtime scales significantlybetter at higher numbers of shading surfaces. PixelCounting also hasno limitations related to zone concavity when used with any“FullInterior” solar distribution options. */
    calculation_method?: CalculationMethod;
	
    @IsEnum(CalculationUpdateMethod)
    @ValidateNested()
    @IsOptional()
    /** Text describing how often the solar and shading calculations are updated with respect to the flow of time in the simulation. */
    calculation_update_method?: CalculationUpdateMethod;
	
    @IsInt()
    @IsOptional()
    /** Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used. */
    calculation_frequency?: number;
	
    @IsInt()
    @IsOptional()
    /** Number of allowable figures in shadow overlap calculations. */
    maximum_figures?: number;
	

    constructor() {
        super();
        this.type = "ShadowCalculation";
        this.solar_distribution = SolarDistribution.FullExteriorWithReflections;
        this.calculation_method = CalculationMethod.PolygonClipping;
        this.calculation_update_method = CalculationUpdateMethod.Periodic;
        this.calculation_frequency = 30;
        this.maximum_figures = 15000;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ShadowCalculation";
            this.solar_distribution = _data["solar_distribution"] !== undefined ? _data["solar_distribution"] : SolarDistribution.FullExteriorWithReflections;
            this.calculation_method = _data["calculation_method"] !== undefined ? _data["calculation_method"] : CalculationMethod.PolygonClipping;
            this.calculation_update_method = _data["calculation_update_method"] !== undefined ? _data["calculation_update_method"] : CalculationUpdateMethod.Periodic;
            this.calculation_frequency = _data["calculation_frequency"] !== undefined ? _data["calculation_frequency"] : 30;
            this.maximum_figures = _data["maximum_figures"] !== undefined ? _data["maximum_figures"] : 15000;
        }
    }


    static override fromJS(data: any): ShadowCalculation {
        data = typeof data === 'object' ? data : {};

        let result = new ShadowCalculation();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["solar_distribution"] = this.solar_distribution;
        data["calculation_method"] = this.calculation_method;
        data["calculation_update_method"] = this.calculation_update_method;
        data["calculation_frequency"] = this.calculation_frequency;
        data["maximum_figures"] = this.maximum_figures;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
