﻿import { IsEnum, ValidateNested, IsOptional, IsNumber, IsBoolean, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { WSHPwithDOASEquipmentType } from "./WSHPwithDOASEquipmentType";

/** Water Source Heat Pump (WSHP) with DOAS HVAC system.

All rooms/zones in the system are connected to a Dedicated Outdoor Air System
(DOAS) that supplies a constant volume of ventilation air at the same temperature
to all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)
to 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air
when outdoor conditions are warmer). The ventilation air temperature is maintained
by a chilled water cooling coil and a hot water heating coil except when the
ground source heat pump (GSHP) option is selected. In this case, the ventilation
air temperature is maintained by a two-speed direct expansion (DX) cooling coil
and a single-speed DX heating coil with backup electrical resistance heat.

Each room/zone also receives its own Water Source Heat Pump (WSHP), which meets
the heating and cooling loads of the space. All WSHPs are connected to the
same water condenser loop, which has its temperature maintained by the
equipment_type (eg. Boiler with Cooling Tower). */
export class WSHPwithDOASAbridged extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latent_heat_recovery?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demand_controlled_ventilation?: boolean;
	
    @IsString()
    @IsOptional()
    /** An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on. */
    doas_availability_schedule?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(WSHPwithDOASEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the WSHPwithDOASEquipmentType enumeration. */
    equipment_type?: WSHPwithDOASEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "WSHPwithDOASAbridged";
        this.equipment_type = WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.sensible_heat_recovery = _data["sensible_heat_recovery"] !== undefined ? _data["sensible_heat_recovery"] : 0;
            this.latent_heat_recovery = _data["latent_heat_recovery"] !== undefined ? _data["latent_heat_recovery"] : 0;
            this.demand_controlled_ventilation = _data["demand_controlled_ventilation"] !== undefined ? _data["demand_controlled_ventilation"] : false;
            this.doas_availability_schedule = _data["doas_availability_schedule"];
            this.type = _data["type"] !== undefined ? _data["type"] : "WSHPwithDOASAbridged";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
        }
    }


    static override fromJS(data: any): WSHPwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new WSHPwithDOASAbridged();
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
        data["equipment_type"] = this.equipment_type;
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
