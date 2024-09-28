import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel.ts";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class VentilationOpening extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationOpening$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number for the fraction of the window area that is operable. */
    fraction_area_operable?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number for the fraction of the distance from the bottom of the window to the top that is operable */
    fraction_height_operable?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number that will be multiplied by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.45, for unobstructed windows WITH insect screens and 0.65 for unobstructed windows WITHOUT insect screens. This value should be lowered if windows are of an awning or casement type and are not allowed to fully open. */
    discharge_coefficient?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation. */
    wind_cross_vent?: boolean;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** An optional number in kg/s-m, at 1 Pa per meter of crack length, used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage closed external window to be 0.00001, and the flow coefficient for a very poor, high-leakage closed external window to be 0.003. */
    flow_coefficient_closed?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.5)
    @Max(1)
    /** An optional dimensionless number between 0.5 and 1 used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured. */
    flow_exponent_closed?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number in kg/m3 indicating the minimum density difference above which two-way flow may occur due to stack effect, required to run an AirflowNetwork simulation. This value is required because the air density difference between two zones (which drives two-way air flow) will tend towards division by zero errors as the air density difference approaches zero. The default of 0.0001 is a typical default value used for AirflowNetwork openings. */
    two_way_threshold?: number;
	

    constructor() {
        super();
        this.type = "VentilationOpening";
        this.fraction_area_operable = 0.5;
        this.fraction_height_operable = 1;
        this.discharge_coefficient = 0.45;
        this.wind_cross_vent = false;
        this.flow_coefficient_closed = 0;
        this.flow_exponent_closed = 0.65;
        this.two_way_threshold = 0.0001;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VentilationOpening, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.fraction_area_operable = obj.fraction_area_operable;
            this.fraction_height_operable = obj.fraction_height_operable;
            this.discharge_coefficient = obj.discharge_coefficient;
            this.wind_cross_vent = obj.wind_cross_vent;
            this.flow_coefficient_closed = obj.flow_coefficient_closed;
            this.flow_exponent_closed = obj.flow_exponent_closed;
            this.two_way_threshold = obj.two_way_threshold;
        }
    }


    static override fromJS(data: any): VentilationOpening {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VentilationOpening();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["fraction_area_operable"] = this.fraction_area_operable;
        data["fraction_height_operable"] = this.fraction_height_operable;
        data["discharge_coefficient"] = this.discharge_coefficient;
        data["wind_cross_vent"] = this.wind_cross_vent;
        data["flow_coefficient_closed"] = this.flow_coefficient_closed;
        data["flow_exponent_closed"] = this.flow_exponent_closed;
        data["two_way_threshold"] = this.two_way_threshold;
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

