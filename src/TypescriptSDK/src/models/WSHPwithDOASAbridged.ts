import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DOASBase } from "./_DOASBase";
import { Vintages } from "./Vintages";
import { WSHPwithDOASEquipmentType } from "./WSHPwithDOASEquipmentType";

/** Water Source Heat Pump (WSHP) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a chilled water cooling coil and a hot water heating coil except when the\nground source heat pump (GSHP) option is selected. In this case, the ventilation\nair temperature is maintained by a two-speed direct expansion (DX) cooling coil\nand a single-speed DX heating coil with backup electrical resistance heat.\n\nEach room/zone also receives its own Water Source Heat Pump (WSHP), which meets\nthe heating and cooling loads of the space. All WSHPs are connected to the\nsame water condenser loop, which has its temperature maintained by the\nequipment_type (eg. Boiler with Cooling Tower). */
export class WSHPwithDOASAbridged extends _DOASBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("WSHPwithDOASAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "WSHPwithDOASAbridged";
	
    @Type(() => String)
    @IsEnum(WSHPwithDOASEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the WSHPwithDOASEquipmentType enumeration. */
    equipmentType: WSHPwithDOASEquipmentType = WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
	

    constructor() {
        super();
        this.type = "WSHPwithDOASAbridged";
        this.equipmentType = WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WSHPwithDOASAbridged, _data);
            this.type = obj.type ?? "WSHPwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? WSHPwithDOASEquipmentType.DOAS_WSHP_FluidCooler_Boiler;
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
