import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Base class for Dedicated Outdoor Air System (DOAS) HVACs.\n\nDOAS systems separate minimum ventilation supply from the satisfaction of heating\n+ cooling demand. Ventilation air tends to be supplied at neutral temperatures\n(close to room air temperature) and heating / cooling loads are met with additional\npieces of zone equipment (eg. Fan Coil Units (FCUs)).\n\nBecause DOAS systems only have to cool down and re-heat the minimum ventilation air,\nthey tend to use less energy than all-air systems. They also tend to use less energy\nto distribute heating + cooling by pumping around hot/cold water or refrigerant\ninstead of blowing hot/cold air. However, they do not provide as good of control\nover humidity and so they may not be appropriate for rooms with high latent loads\nlike auditoriums, kitchens, laundromats, etc. */
export class _DOASBase extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latent_heat_recovery?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demand_controlled_ventilation?: boolean;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on. */
    doas_availability_schedule?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^_DOASBase$/)
    type?: string;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "_DOASBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_DOASBase, _data);
            this.vintage = obj.vintage;
            this.sensible_heat_recovery = obj.sensible_heat_recovery;
            this.latent_heat_recovery = obj.latent_heat_recovery;
            this.demand_controlled_ventilation = obj.demand_controlled_ventilation;
            this.doas_availability_schedule = obj.doas_availability_schedule;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _DOASBase {
        data = typeof data === 'object' ? data : {};

        let result = new _DOASBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["vintage"] = this.vintage;
        data["sensible_heat_recovery"] = this.sensible_heat_recovery;
        data["latent_heat_recovery"] = this.latent_heat_recovery;
        data["demand_controlled_ventilation"] = this.demand_controlled_ventilation;
        data["doas_availability_schedule"] = this.doas_availability_schedule;
        data["type"] = this.type;
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
