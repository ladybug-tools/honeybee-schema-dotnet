import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { FCUwithDOASEquipmentType } from "./FCUwithDOASEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Fan Coil Unit (FCU) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a chilled water cooling coil and a heating coil. The heating coil is a hot\nwater coil except when electric baseboards or gas heaters are specified, in\nwhich case the heating coil is a single-speed direct expansion (DX) heat pump\nwith a backup electrical resistance coil.\n\nEach room/zone also receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.\n\nThe FCU with DOAS template is relatively close in performance to active chilled\nbeams (ACBs). When using this template to represent ACBs, care must be taken\nto ensure that the DOAS ventilation air requirement is sufficient to extract\nthe heating cooling from the ACB. If so, then this FCUwithDOAS template can be\nused but with the energy use of the FCU fans ignored. */
export class FCUwithDOASAbridged extends IDdEnergyBaseModel {
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
    @Matches(/^FCUwithDOASAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "FCUwithDOASAbridged";
	
    @IsEnum(FCUwithDOASEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration. */
    equipmentType: FCUwithDOASEquipmentType = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.demandControlledVentilation = false;
        this.type = "FCUwithDOASAbridged";
        this.equipmentType = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(FCUwithDOASAbridged, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery;
            this.latentHeatRecovery = obj.latentHeatRecovery;
            this.demandControlledVentilation = obj.demandControlledVentilation;
            this.doasAvailabilitySchedule = obj.doasAvailabilitySchedule;
            this.type = obj.type;
            this.equipmentType = obj.equipmentType;
        }
    }


    static override fromJS(data: any): FCUwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FCUwithDOASAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery;
        data["latent_heat_recovery"] = this.latentHeatRecovery;
        data["demand_controlled_ventilation"] = this.demandControlledVentilation;
        data["doas_availability_schedule"] = this.doasAvailabilitySchedule;
        data["type"] = this.type;
        data["equipment_type"] = this.equipmentType;
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
