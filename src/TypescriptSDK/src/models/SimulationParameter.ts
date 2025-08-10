import { IsString, IsOptional, Matches, IsInstance, ValidateNested, IsInt, Min, Max, IsNumber, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "SimulationParameter";
	
    @IsInstance(SimulationOutput)
    @Type(() => SimulationOutput)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "output" })
    /** A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them. */
    output?: SimulationOutput;
	
    @IsInstance(RunPeriod)
    @Type(() => RunPeriod)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "run_period" })
    /** A RunPeriod to describe the time period over which to run the simulation. */
    runPeriod?: RunPeriod;
	
    @IsInt()
    @IsOptional()
    @Min(1)
    @Max(60)
    @Expose({ name: "timestep" })
    /** An integer for the number of timesteps per hour at which the energy calculation will be run. */
    timestep: number = 6;
	
    @IsInstance(SimulationControl)
    @Type(() => SimulationControl)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "simulation_control" })
    /** A SimulationControl object that describes which types of calculations to run. */
    simulationControl?: SimulationControl;
	
    @IsInstance(ShadowCalculation)
    @Type(() => ShadowCalculation)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "shadow_calculation" })
    /** A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation. */
    shadowCalculation?: ShadowCalculation;
	
    @IsInstance(SizingParameter)
    @Type(() => SizingParameter)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "sizing_parameter" })
    /** A SizingParameter object with criteria for sizing the heating and cooling system. */
    sizingParameter?: SizingParameter;
	
    @IsNumber()
    @IsOptional()
    @Min(-360)
    @Max(360)
    @Expose({ name: "north_angle" })
    /** A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference. */
    northAngle: number = 0;
	
    @IsEnum(TerrianTypes)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "terrain_type" })
    /** Text for the terrain in which the model sits. This is used to determine the wind profile over the height of the rooms. */
    terrainType: TerrianTypes = TerrianTypes.City;
	

    constructor() {
        super();
        this.type = "SimulationParameter";
        this.timestep = 6;
        this.northAngle = 0;
        this.terrainType = TerrianTypes.City;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(SimulationParameter, _data);
            this.type = obj.type ?? "SimulationParameter";
            this.output = obj.output;
            this.runPeriod = obj.runPeriod;
            this.timestep = obj.timestep ?? 6;
            this.simulationControl = obj.simulationControl;
            this.shadowCalculation = obj.shadowCalculation;
            this.sizingParameter = obj.sizingParameter;
            this.northAngle = obj.northAngle ?? 0;
            this.terrainType = obj.terrainType ?? TerrianTypes.City;
        }
    }


    static override fromJS(data: any): SimulationParameter {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SimulationParameter();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "SimulationParameter";
        data["output"] = this.output;
        data["run_period"] = this.runPeriod;
        data["timestep"] = this.timestep ?? 6;
        data["simulation_control"] = this.simulationControl;
        data["shadow_calculation"] = this.shadowCalculation;
        data["sizing_parameter"] = this.sizingParameter;
        data["north_angle"] = this.northAngle ?? 0;
        data["terrain_type"] = this.terrainType ?? TerrianTypes.City;
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
