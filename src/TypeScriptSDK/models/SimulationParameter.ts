import { IsString, IsOptional, Matches, IsInstance, ValidateNested, IsInt, Min, Max, IsNumber, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
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
    @Matches(/^SimulationParameter$/)
    type?: string;
	
    @IsInstance(SimulationOutput)
    @Type(() => SimulationOutput)
    @ValidateNested()
    @IsOptional()
    /** A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them. */
    output?: SimulationOutput;
	
    @IsInstance(RunPeriod)
    @Type(() => RunPeriod)
    @ValidateNested()
    @IsOptional()
    /** A RunPeriod to describe the time period over which to run the simulation. */
    run_period?: RunPeriod;
	
    @IsInt()
    @IsOptional()
    @Min(1)
    @Max(60)
    /** An integer for the number of timesteps per hour at which the energy calculation will be run. */
    timestep?: number;
	
    @IsInstance(SimulationControl)
    @Type(() => SimulationControl)
    @ValidateNested()
    @IsOptional()
    /** A SimulationControl object that describes which types of calculations to run. */
    simulation_control?: SimulationControl;
	
    @IsInstance(ShadowCalculation)
    @Type(() => ShadowCalculation)
    @ValidateNested()
    @IsOptional()
    /** A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation. */
    shadow_calculation?: ShadowCalculation;
	
    @IsInstance(SizingParameter)
    @Type(() => SizingParameter)
    @ValidateNested()
    @IsOptional()
    /** A SizingParameter object with criteria for sizing the heating and cooling system. */
    sizing_parameter?: SizingParameter;
	
    @IsNumber()
    @IsOptional()
    @Min(-360)
    @Max(360)
    /** A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference. */
    north_angle?: number;
	
    @IsEnum(TerrianTypes)
    @Type(() => String)
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
            const obj = plainToClass(SimulationParameter, _data);
            this.type = obj.type;
            this.output = obj.output;
            this.run_period = obj.run_period;
            this.timestep = obj.timestep;
            this.simulation_control = obj.simulation_control;
            this.shadow_calculation = obj.shadow_calculation;
            this.sizing_parameter = obj.sizing_parameter;
            this.north_angle = obj.north_angle;
            this.terrain_type = obj.terrain_type;
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
