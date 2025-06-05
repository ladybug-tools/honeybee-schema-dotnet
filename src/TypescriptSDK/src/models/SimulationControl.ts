import { IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify which types of calculations to run. */
export class SimulationControl extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SimulationControl$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "SimulationControl";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "do_zone_sizing" })
    /** Boolean for whether the zone sizing calculation should be run. */
    doZoneSizing: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "do_system_sizing" })
    /** Boolean for whether the system sizing calculation should be run. */
    doSystemSizing: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "do_plant_sizing" })
    /** Boolean for whether the plant sizing calculation should be run. */
    doPlantSizing: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "run_for_run_periods" })
    /** Boolean for whether the simulation should be run for the sizing periods. */
    runForRunPeriods: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "run_for_sizing_periods" })
    /** Boolean for whether the simulation should be run for the run periods. */
    runForSizingPeriods: boolean = false;
	

    constructor() {
        super();
        this.type = "SimulationControl";
        this.doZoneSizing = true;
        this.doSystemSizing = true;
        this.doPlantSizing = true;
        this.runForRunPeriods = true;
        this.runForSizingPeriods = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SimulationControl, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.doZoneSizing = obj.doZoneSizing;
            this.doSystemSizing = obj.doSystemSizing;
            this.doPlantSizing = obj.doPlantSizing;
            this.runForRunPeriods = obj.runForRunPeriods;
            this.runForSizingPeriods = obj.runForSizingPeriods;
        }
    }


    static override fromJS(data: any): SimulationControl {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SimulationControl();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["do_zone_sizing"] = this.doZoneSizing;
        data["do_system_sizing"] = this.doSystemSizing;
        data["do_plant_sizing"] = this.doPlantSizing;
        data["run_for_run_periods"] = this.runForRunPeriods;
        data["run_for_sizing_periods"] = this.runForSizingPeriods;
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
