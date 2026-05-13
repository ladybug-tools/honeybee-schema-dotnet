import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _AllAirBase } from "./_AllAirBase";
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { PSZEquipmentType } from "./PSZEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Single-Zone (PSZ) HVAC system (aka. System 3 or 4).\n\nEach room/zone receives its own air loop with its own single-speed direct expansion\n(DX) cooling coil, which will condition the supply air to a value in between\n12.8C (55F) and 50C (122F) depending on the heating/cooling needs of the room/zone.\nAs long as a Baseboard equipment_type is NOT selected, heating will be supplied\nby a heating coil in the air loop. Otherwise, heating is accomplished with\nbaseboards and the air loop only supplies cooling and ventilation air.\nFans are constant volume.\n\nPSZ systems are the traditional baseline system for commercial buildings\nwith less than 4 stories or less than 2,300 m2 (25,000 ft2) of floor area.\nThey are also the default for all retail with less than 3 stories and all public\nassembly spaces. */
export class PSZ extends _AllAirBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("PSZ")
    @Expose({ name: "type" })
    /** type */
    type: string = "PSZ";
	
    @Type(() => String)
    @IsEnum(PSZEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the PVAVEquipmentType enumeration. */
    equipmentType: PSZEquipmentType = PSZEquipmentType.PSZAC_ElectricBaseboard;
	

    constructor() {
        super();
        this.type = "PSZ";
        this.equipmentType = PSZEquipmentType.PSZAC_ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(PSZ, _data);
            this.type = obj.type ?? "PSZ";
            this.equipmentType = obj.equipmentType ?? PSZEquipmentType.PSZAC_ElectricBaseboard;
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


    static override fromJS(data: any): PSZ {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new PSZ();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "PSZ";
        data["equipment_type"] = this.equipmentType ?? PSZEquipmentType.PSZAC_ElectricBaseboard;
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
