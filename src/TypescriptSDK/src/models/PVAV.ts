import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _AllAirBase } from "./_AllAirBase";
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { PVAVEquipmentType } from "./PVAVEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Variable Air Volume (PVAV) HVAC system (aka. System 5 or 6).\n\nAll rooms/zones are connected to a central air loop that is kept at a constant\ncentral temperature of 12.8C (55F). The central temperature is maintained by a\ncooling coil, which runs whenever the combination of return air and fresh outdoor\nair is greater than 12.8C, as well as a heating coil, which runs whenever\nthe combination of return air and fresh outdoor air is less than 12.8C.\n\nEach air terminal for the connected rooms/zones contains its own reheat coil,\nwhich runs whenever the room is not in need of the cooling supplied by the 12.8C\ncentral air.\n\nThe central cooling coil is always a two-speed direct expansion (DX) coil.\nAll heating coils are hot water coils except when Gas Coil equipment_type is\nused (in which case the central coil is gas and all reheat is electric)\nor when Parallel Fan-Powered (PFP) boxes equipment_type is used (in which case\ncoils are electric resistance). Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.\n\nPVAV systems are the traditional baseline system for commercial buildings\nwith than 4-5 stories or between 2,300 m2 and 14,000 m2 (25,000 ft2 and\n150,000 ft2) of floor area. */
export class PVAV extends _AllAirBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("PVAV")
    @Expose({ name: "type" })
    /** type */
    type: string = "PVAV";
	
    @Type(() => String)
    @IsEnum(PVAVEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the VAVEquipmentType enumeration. */
    equipmentType: PVAVEquipmentType = PVAVEquipmentType.PVAV_Boiler;
	

    constructor() {
        super();
        this.type = "PVAV";
        this.equipmentType = PVAVEquipmentType.PVAV_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(PVAV, _data);
            this.type = obj.type ?? "PVAV";
            this.equipmentType = obj.equipmentType ?? PVAVEquipmentType.PVAV_Boiler;
            this.economizerType = obj.economizerType ?? AllAirEconomizerType.NoEconomizer;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): PVAV {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new PVAV();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "PVAV";
        data["equipment_type"] = this.equipmentType ?? PVAVEquipmentType.PVAV_Boiler;
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
