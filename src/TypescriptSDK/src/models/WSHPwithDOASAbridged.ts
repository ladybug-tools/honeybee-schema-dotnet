import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { WSHPwithDOASEquipmentType } from "./WSHPwithDOASEquipmentType";

/** Water Source Heat Pump (WSHP) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a chilled water cooling coil and a hot water heating coil except when the\nground source heat pump (GSHP) option is selected. In this case, the ventilation\nair temperature is maintained by a two-speed direct expansion (DX) cooling coil\nand a single-speed DX heating coil with backup electrical resistance heat.\n\nEach room/zone also receives its own Water Source Heat Pump (WSHP), which meets\nthe heating and cooling loads of the space. All WSHPs are connected to the\nsame water condenser loop, which has its temperature maintained by the\nequipment_type (eg. Boiler with Cooling Tower). */
export class WSHPwithDOASAbridged extends IDdEnergyBaseModel {
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
    @Matches(/^WSHPwithDOASAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WSHPwithDOASAbridged";
	
    @IsEnum(WSHPwithDOASEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the WSHPwithDOASEquipmentType enumeration. */
    equipmentType: WSHPwithDOASEquipmentType = WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.demandControlledVentilation = false;
        this.type = "WSHPwithDOASAbridged";
        this.equipmentType = WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WSHPwithDOASAbridged, _data);
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.doasAvailabilitySchedule = obj.doasAvailabilitySchedule;
            this.type = obj.type ?? "WSHPwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): WSHPwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WSHPwithDOASAbridged();
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
        data["type"] = this.type ?? "WSHPwithDOASAbridged";
        data["equipment_type"] = this.equipmentType ?? WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
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
