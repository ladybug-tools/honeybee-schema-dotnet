import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class VentilationOpening extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationOpening$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "VentilationOpening";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "fraction_area_operable" })
    /** A number for the fraction of the window area that is operable. */
    fractionAreaOperable: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "fraction_height_operable" })
    /** A number for the fraction of the distance from the bottom of the window to the top that is operable */
    fractionHeightOperable: number = 1;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "discharge_coefficient" })
    /** A number that will be multiplied by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.45, for unobstructed windows WITH insect screens and 0.65 for unobstructed windows WITHOUT insect screens. This value should be lowered if windows are of an awning or casement type and are not allowed to fully open. */
    dischargeCoefficient: number = 0.45;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "wind_cross_vent" })
    /** Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation. */
    windCrossVent: boolean = false;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_coefficient_closed" })
    /** An optional number in kg/s-m, at 1 Pa per meter of crack length, used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage closed external window to be 0.00001, and the flow coefficient for a very poor, high-leakage closed external window to be 0.003. */
    flowCoefficientClosed: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0.5)
    @Max(1)
    @Expose({ name: "flow_exponent_closed" })
    /** An optional dimensionless number between 0.5 and 1 used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured. */
    flowExponentClosed: number = 0.65;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "two_way_threshold" })
    /** A number in kg/m3 indicating the minimum density difference above which two-way flow may occur due to stack effect, required to run an AirflowNetwork simulation. This value is required because the air density difference between two zones (which drives two-way air flow) will tend towards division by zero errors as the air density difference approaches zero. The default of 0.0001 is a typical default value used for AirflowNetwork openings. */
    twoWayThreshold: number = 0.0001;
	

    constructor() {
        super();
        this.type = "VentilationOpening";
        this.fractionAreaOperable = 0.5;
        this.fractionHeightOperable = 1;
        this.dischargeCoefficient = 0.45;
        this.windCrossVent = false;
        this.flowCoefficientClosed = 0;
        this.flowExponentClosed = 0.65;
        this.twoWayThreshold = 0.0001;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VentilationOpening, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "VentilationOpening";
            this.fractionAreaOperable = obj.fractionAreaOperable ?? 0.5;
            this.fractionHeightOperable = obj.fractionHeightOperable ?? 1;
            this.dischargeCoefficient = obj.dischargeCoefficient ?? 0.45;
            this.windCrossVent = obj.windCrossVent ?? false;
            this.flowCoefficientClosed = obj.flowCoefficientClosed ?? 0;
            this.flowExponentClosed = obj.flowExponentClosed ?? 0.65;
            this.twoWayThreshold = obj.twoWayThreshold ?? 0.0001;
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
        data["type"] = this.type ?? "VentilationOpening";
        data["fraction_area_operable"] = this.fractionAreaOperable ?? 0.5;
        data["fraction_height_operable"] = this.fractionHeightOperable ?? 1;
        data["discharge_coefficient"] = this.dischargeCoefficient ?? 0.45;
        data["wind_cross_vent"] = this.windCrossVent ?? false;
        data["flow_coefficient_closed"] = this.flowCoefficientClosed ?? 0;
        data["flow_exponent_closed"] = this.flowExponentClosed ?? 0.65;
        data["two_way_threshold"] = this.twoWayThreshold ?? 0.0001;
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
