import { IsString, IsOptional, Matches, IsEnum, IsArray, IsNumber, Min, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ReportingFrequency } from "./ReportingFrequency";

/** Lists the outputs to report from the simulation and their format. */
export class SimulationOutput extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SimulationOutput$/)
    type?: string;
	
    @IsEnum(ReportingFrequency)
    @Type(() => String)
    @IsOptional()
    reporting_frequency?: ReportingFrequency;
	
    @IsArray()
    @IsString({ each: true })
    @IsOptional()
    /** A list of EnergyPlus output names as strings, which are requested from the simulation. */
    outputs?: string [];
	
    @IsArray()
    @IsString({ each: true })
    @IsOptional()
    /** A list of EnergyPlus summary report names as strings. */
    summary_reports?: string [];
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(10)
    /** A number in degrees Celsius for the difference that the zone conditions must be from the thermostat setpoint in order for the setpoint to be considered unmet. This will affect how unmet hours are reported in the output. ASHRAE 90.1 uses a tolerance of 1.11C, which is equivalent to 1.8F. */
    unmet_setpoint_tolerance?: number;
	

    constructor() {
        super();
        this.type = "SimulationOutput";
        this.reporting_frequency = ReportingFrequency.Hourly;
        this.unmet_setpoint_tolerance = 1.11;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SimulationOutput, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.reporting_frequency = obj.reporting_frequency;
            this.outputs = obj.outputs;
            this.summary_reports = obj.summary_reports;
            this.unmet_setpoint_tolerance = obj.unmet_setpoint_tolerance;
        }
    }


    static override fromJS(data: any): SimulationOutput {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SimulationOutput();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["reporting_frequency"] = this.reporting_frequency;
        data["outputs"] = this.outputs;
        data["summary_reports"] = this.summary_reports;
        data["unmet_setpoint_tolerance"] = this.unmet_setpoint_tolerance;
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

