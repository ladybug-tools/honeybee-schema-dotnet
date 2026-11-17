import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _AllAirBase } from "./_AllAirBase";
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { VAVEquipmentType } from "./VAVEquipmentType";
import { Vintages } from "./Vintages";

/** Variable Air Volume (VAV) HVAC system (aka. System 7 or 8). All rooms/zones are connected to a central air loop that is kept at a constant central temperature of 12.8C (55F). The central temperature is maintained by a cooling coil, which runs whenever the combination of return air and fresh outdoor air is greater than 12.8C, as well as a heating coil, which runs whenever the combination of return air and fresh outdoor air is less than 12.8C. Each air terminal for the connected rooms/zones contains its own reheat coil, which runs whenever the room is not in need of the cooling supplied by the 12.8C central air. The central cooling coil is always a chilled water coil, which is connected to a chilled water loop operating at 6.7C (44F). All heating coils are hot water coils except when Gas Coil equipment_type is used (in which case coils are gas) or when Parallel Fan-Powered (PFP) boxes equipment_type is used (in which case coils are electric resistance). Hot water temperature is 82C (180F) for boiler/district heating and 49C (120F) when ASHP is used. VAV systems are the traditional baseline system for commercial buildings taller than 5 stories or larger than 14,000 m2 (150,000 ft2) of floor area. */
export class VAV extends _AllAirBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("VAV")
    @Expose({ name: "type" })
    /** type */
    type: string = "VAV";
	
    @Type(() => String)
    @IsEnum(VAVEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the VAVEquipmentType enumeration. */
    equipmentType: VAVEquipmentType = VAVEquipmentType.VAV_Chiller_Boiler;
	

    constructor() {
        super();
        this.type = "VAV";
        this.equipmentType = VAVEquipmentType.VAV_Chiller_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(VAV, _data);
            this.type = obj.type ?? "VAV";
            this.equipmentType = obj.equipmentType ?? VAVEquipmentType.VAV_Chiller_Boiler;
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


    static override fromJS(data: any): VAV {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VAV();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "VAV";
        data["equipment_type"] = this.equipmentType ?? VAVEquipmentType.VAV_Chiller_Boiler;
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
