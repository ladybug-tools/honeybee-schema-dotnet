import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DOASBase } from "./_DOASBase";
import { Vintages } from "./Vintages";
import { VRFwithDOASEquipmentType } from "./VRFwithDOASEquipmentType";

/** Variable Refrigerant Flow (VRF) with DOAS HVAC system. All rooms/zones in the system are connected to a Dedicated Outdoor Air System (DOAS) that supplies a constant volume of ventilation air at the same temperature to all rooms/zones. The ventilation air temperature will vary from 21.1C (70F) to 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air when outdoor conditions are warmer). The ventilation air temperature is maintained by a single speed direct expansion (DX) cooling coil along with a single-speed direct expansion (DX) heat pump with a backup electrical resistance coil. Each room/zone also receives its own Variable Refrigerant Flow (VRF) terminal, which meets the heating and cooling loads of the space. All room/zone terminals are connected to the same outdoor unit, meaning that either all rooms must be in cooling or heating mode together. */
export class VRFwithDOASAbridged extends _DOASBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("VRFwithDOASAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "VRFwithDOASAbridged";
	
    @Type(() => String)
    @IsEnum(VRFwithDOASEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the VRFwithDOASEquipmentType enumeration. */
    equipmentType: VRFwithDOASEquipmentType = VRFwithDOASEquipmentType.DOAS_VRF;
	

    constructor() {
        super();
        this.type = "VRFwithDOASAbridged";
        this.equipmentType = VRFwithDOASEquipmentType.DOAS_VRF;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(VRFwithDOASAbridged, _data);
            this.type = obj.type ?? "VRFwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? VRFwithDOASEquipmentType.DOAS_VRF;
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


    static override fromJS(data: any): VRFwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VRFwithDOASAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "VRFwithDOASAbridged";
        data["equipment_type"] = this.equipmentType ?? VRFwithDOASEquipmentType.DOAS_VRF;
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
