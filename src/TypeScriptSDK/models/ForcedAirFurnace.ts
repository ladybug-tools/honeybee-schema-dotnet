import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { FurnaceEquipmentType } from "./FurnaceEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Forced Air Furnace HVAC system (aka. System 9 or 10).\n\nForced air furnaces are intended only for spaces only requiring heating and\nventilation. Each room/zone receives its own air loop with its own gas heating\ncoil, which will supply air at a temperature up to 50C (122F) to meet the\nheating needs of the room/zone. Fans are constant volume.\n\nForcedAirFurnace systems are the traditional baseline system for storage\nspaces that only require heating. */
export class ForcedAirFurnace extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(FurnaceEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the FurnaceEquipmentType enumeration. */
    equipment_type?: FurnaceEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "ForcedAirFurnace";
        this.equipment_type = FurnaceEquipmentType.Furnace;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "ForcedAirFurnace";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : FurnaceEquipmentType.Furnace;
        }
    }


    static override fromJS(data: any): ForcedAirFurnace {
        data = typeof data === 'object' ? data : {};

        let result = new ForcedAirFurnace();
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
