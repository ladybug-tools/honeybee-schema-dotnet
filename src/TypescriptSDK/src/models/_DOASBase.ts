import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Base class for Dedicated Outdoor Air System (DOAS) HVACs.\n\nDOAS systems separate minimum ventilation supply from the satisfaction of heating\n+ cooling demand. Ventilation air tends to be supplied at neutral temperatures\n(close to room air temperature) and heating / cooling loads are met with additional\npieces of zone equipment (eg. Fan Coil Units (FCUs)).\n\nBecause DOAS systems only have to cool down and re-heat the minimum ventilation air,\nthey tend to use less energy than all-air systems. They also tend to use less energy\nto distribute heating + cooling by pumping around hot/cold water or refrigerant\ninstead of blowing hot/cold air. However, they do not provide as good of control\nover humidity and so they may not be appropriate for rooms with high latent loads\nlike auditoriums, kitchens, laundromats, etc. */
export class _DOASBase extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensibleHeatRecovery: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latentHeatRecovery: number = 0;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "demand_controlled_ventilation" })
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demandControlledVentilation: boolean = false;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "doas_availability_schedule" })
    /** An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on. */
    doasAvailabilitySchedule?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^_DOASBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_DOASBase";
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.demandControlledVentilation = false;
        this.type = "_DOASBase";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(_DOASBase, _data);
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.doasAvailabilitySchedule = obj.doasAvailabilitySchedule;
            this.type = obj.type ?? "_DOASBase";
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): _DOASBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _DOASBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery ?? 0;
        data["latent_heat_recovery"] = this.latentHeatRecovery ?? 0;
        data["demand_controlled_ventilation"] = this.demandControlledVentilation ?? false;
        data["doas_availability_schedule"] = this.doasAvailabilitySchedule;
        data["type"] = this.type ?? "_DOASBase";
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
