﻿import { IsString, IsOptional, IsEnum, ValidateNested, IsArray, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { ReportingFrequency } from "./ReportingFrequency";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Lists the outputs to report from the simulation and their format. */
export class SimulationOutput extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(ReportingFrequency)
    @ValidateNested()
    @IsOptional()
    reporting_frequency?: ReportingFrequency;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of EnergyPlus output names as strings, which are requested from the simulation. */
    outputs?: string [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of EnergyPlus summary report names as strings. */
    summary_reports?: string [];
	
    @IsNumber()
    @IsOptional()
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
            this.type = _data["type"] !== undefined ? _data["type"] : "SimulationOutput";
            this.reporting_frequency = _data["reporting_frequency"] !== undefined ? _data["reporting_frequency"] : ReportingFrequency.Hourly;
            this.outputs = _data["outputs"];
            this.summary_reports = _data["summary_reports"];
            this.unmet_setpoint_tolerance = _data["unmet_setpoint_tolerance"] !== undefined ? _data["unmet_setpoint_tolerance"] : 1.11;
        }
    }


    static override fromJS(data: any): SimulationOutput {
        data = typeof data === 'object' ? data : {};

        let result = new SimulationOutput();
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
        data["reporting_frequency"] = this.reporting_frequency;
        data["outputs"] = this.outputs;
        data["summary_reports"] = this.summary_reports;
        data["unmet_setpoint_tolerance"] = this.unmet_setpoint_tolerance;
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
