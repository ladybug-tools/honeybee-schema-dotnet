import { IsString, IsOptional, Equals, IsEnum, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DOASBase } from "./_DOASBase";
import { RadiantFaceTypes } from "./RadiantFaceTypes";
import { RadiantwithDOASEquipmentType } from "./RadiantwithDOASEquipmentType";
import { Vintages } from "./Vintages";

/** Low Temperature Radiant with DOAS HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a two-speed direct expansion (DX) cooling coil and a single-speed DX\nheating coil with backup electrical resistance heat.\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range. */
export class RadiantwithDOASAbridged extends _DOASBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("RadiantwithDOASAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "RadiantwithDOASAbridged";
	
    @Type(() => String)
    @IsEnum(RadiantwithDOASEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the RadiantwithDOASEquipmentType enumeration. */
    equipmentType: RadiantwithDOASEquipmentType = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
	
    @Type(() => String)
    @IsEnum(RadiantFaceTypes)
    @IsOptional()
    @Expose({ name: "radiant_face_type" })
    /** Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces. */
    radiantFaceType: RadiantFaceTypes = RadiantFaceTypes.Floor;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Expose({ name: "minimum_operation_time" })
    /** A number for the minimum number of hours of operation for the radiant system before it shuts off. */
    minimumOperationTime: number = 1;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Expose({ name: "switch_over_time" })
    /** A number for the minimum number of hours for when the system can switch between heating and cooling. */
    switchOverTime: number = 24;
	

    constructor() {
        super();
        this.type = "RadiantwithDOASAbridged";
        this.equipmentType = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
        this.radiantFaceType = RadiantFaceTypes.Floor;
        this.minimumOperationTime = 1;
        this.switchOverTime = 24;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RadiantwithDOASAbridged, _data);
            this.type = obj.type ?? "RadiantwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
            this.radiantFaceType = obj.radiantFaceType ?? RadiantFaceTypes.Floor;
            this.minimumOperationTime = obj.minimumOperationTime ?? 1;
            this.switchOverTime = obj.switchOverTime ?? 24;
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


    static override fromJS(data: any): RadiantwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RadiantwithDOASAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RadiantwithDOASAbridged";
        data["equipment_type"] = this.equipmentType ?? RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
        data["radiant_face_type"] = this.radiantFaceType ?? RadiantFaceTypes.Floor;
        data["minimum_operation_time"] = this.minimumOperationTime ?? 1;
        data["switch_over_time"] = this.switchOverTime ?? 24;
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
