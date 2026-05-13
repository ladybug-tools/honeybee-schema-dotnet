import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DOASBase } from "./_DOASBase";
import { FCUwithDOASEquipmentType } from "./FCUwithDOASEquipmentType";
import { Vintages } from "./Vintages";

/** Fan Coil Unit (FCU) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a chilled water cooling coil and a heating coil. The heating coil is a hot\nwater coil except when electric baseboards or gas heaters are specified, in\nwhich case the heating coil is a single-speed direct expansion (DX) heat pump\nwith a backup electrical resistance coil.\n\nEach room/zone also receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.\n\nThe FCU with DOAS template is relatively close in performance to active chilled\nbeams (ACBs). When using this template to represent ACBs, care must be taken\nto ensure that the DOAS ventilation air requirement is sufficient to extract\nthe heating cooling from the ACB. If so, then this FCUwithDOAS template can be\nused but with the energy use of the FCU fans ignored. */
export class FCUwithDOASAbridged extends _DOASBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("FCUwithDOASAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "FCUwithDOASAbridged";
	
    @Type(() => String)
    @IsEnum(FCUwithDOASEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration. */
    equipmentType: FCUwithDOASEquipmentType = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
	

    constructor() {
        super();
        this.type = "FCUwithDOASAbridged";
        this.equipmentType = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(FCUwithDOASAbridged, _data);
            this.type = obj.type ?? "FCUwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.doasAvailabilitySchedule = obj.doasAvailabilitySchedule;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["type"] = this.type ?? "FCUwithDOASAbridged";
        data["equipment_type"] = this.equipmentType ?? FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;
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
