import { IsEnum, ValidateNested, IsOptional, IsNumber, IsBoolean, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { FCUwithDOASEquipmentType } from "./FCUwithDOASEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Fan Coil Unit (FCU) with DOAS HVAC system.

All rooms/zones in the system are connected to a Dedicated Outdoor Air System
(DOAS) that supplies a constant volume of ventilation air at the same temperature
to all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)
to 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air
when outdoor conditions are warmer). The ventilation air temperature is maintained
by a chilled water cooling coil and a heating coil. The heating coil is a hot
water coil except when electric baseboards or gas heaters are specified, in
which case the heating coil is a single-speed direct expansion (DX) heat pump
with a backup electrical resistance coil.

Each room/zone also receives its own Fan Coil Unit (FCU), which meets the heating
and cooling loads of the space. The cooling coil in the FCU is always chilled
water cooling coil, which is connected to a chilled water loop operating
at 6.7C (44F). The heating coil is a hot water coil except when when electric
baseboards or gas heaters are specified. Hot water temperature is 82C (180F) for
boiler/district heating and 49C (120F) when ASHP is used.

The FCU with DOAS template is relatively close in performance to active chilled
beams (ACBs). When using this template to represent ACBs, care must be taken
to ensure that the DOAS ventilation air requirement is sufficient to extract
the heating cooling from the ACB. If so, then this FCUwithDOAS template can be
used but with the energy use of the FCU fans ignored. */
export class FCUwithDOASAbridged extends IDdEnergyBaseModel {
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
	
    @IsEnum(FCUwithDOASEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration. */
    equipment_type?: FCUwithDOASEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "FCUwithDOASAbridged";
        this.equipment_type = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.sensible_heat_recovery = _data["sensible_heat_recovery"] !== undefined ? _data["sensible_heat_recovery"] : 0;
            this.latent_heat_recovery = _data["latent_heat_recovery"] !== undefined ? _data["latent_heat_recovery"] : 0;
            this.demand_controlled_ventilation = _data["demand_controlled_ventilation"] !== undefined ? _data["demand_controlled_ventilation"] : false;
            this.doas_availability_schedule = _data["doas_availability_schedule"];
            this.type = _data["type"] !== undefined ? _data["type"] : "FCUwithDOASAbridged";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
        }
    }


    static override fromJS(data: any): FCUwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new FCUwithDOASAbridged();
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
