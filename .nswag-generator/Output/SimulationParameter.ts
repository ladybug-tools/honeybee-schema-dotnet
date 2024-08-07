﻿import { IsString, IsOptional, IsInstance, ValidateNested, IsInt, IsNumber, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { RunPeriod } from "./RunPeriod";
import { ShadowCalculation } from "./ShadowCalculation";
import { SimulationControl } from "./SimulationControl";
import { SimulationOutput } from "./SimulationOutput";
import { SizingParameter } from "./SizingParameter";
import { TerrianTypes } from "./TerrianTypes";

/** The complete set of EnergyPlus Simulation Settings. */
export class SimulationParameter extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(SimulationOutput)
    @ValidateNested()
    @IsOptional()
    /** A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them. */
    output?: SimulationOutput;
	
    @IsInstance(RunPeriod)
    @ValidateNested()
    @IsOptional()
    /** A RunPeriod to describe the time period over which to run the simulation. */
    run_period?: RunPeriod;
	
    @IsInt()
    @IsOptional()
    /** An integer for the number of timesteps per hour at which the energy calculation will be run. */
    timestep?: number;
	
    @IsInstance(SimulationControl)
    @ValidateNested()
    @IsOptional()
    /** A SimulationControl object that describes which types of calculations to run. */
    simulation_control?: SimulationControl;
	
    @IsInstance(ShadowCalculation)
    @ValidateNested()
    @IsOptional()
    /** A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation. */
    shadow_calculation?: ShadowCalculation;
	
    @IsInstance(SizingParameter)
    @ValidateNested()
    @IsOptional()
    /** A SizingParameter object with criteria for sizing the heating and cooling system. */
    sizing_parameter?: SizingParameter;
	
    @IsNumber()
    @IsOptional()
    /** A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference. */
    north_angle?: number;
	
    @IsEnum(TerrianTypes)
    @ValidateNested()
    @IsOptional()
    /** Text for the terrain in which the model sits. This is used to determine the wind profile over the height of the rooms. */
    terrain_type?: TerrianTypes;
	

    constructor() {
        super();
        this.type = "SimulationParameter";
        this.timestep = 6;
        this.north_angle = 0;
        this.terrain_type = TerrianTypes.City;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "SimulationParameter";
            this.output = _data["output"];
            this.run_period = _data["run_period"];
            this.timestep = _data["timestep"] !== undefined ? _data["timestep"] : 6;
            this.simulation_control = _data["simulation_control"];
            this.shadow_calculation = _data["shadow_calculation"];
            this.sizing_parameter = _data["sizing_parameter"];
            this.north_angle = _data["north_angle"] !== undefined ? _data["north_angle"] : 0;
            this.terrain_type = _data["terrain_type"] !== undefined ? _data["terrain_type"] : TerrianTypes.City;
        }
    }


    static override fromJS(data: any): SimulationParameter {
        data = typeof data === 'object' ? data : {};

        let result = new SimulationParameter();
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
        data["output"] = this.output;
        data["run_period"] = this.run_period;
        data["timestep"] = this.timestep;
        data["simulation_control"] = this.simulation_control;
        data["shadow_calculation"] = this.shadow_calculation;
        data["sizing_parameter"] = this.sizing_parameter;
        data["north_angle"] = this.north_angle;
        data["terrain_type"] = this.terrain_type;
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
