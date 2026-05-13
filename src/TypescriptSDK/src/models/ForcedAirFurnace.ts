import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _TemplateSystem } from "./_TemplateSystem";
import { FurnaceEquipmentType } from "./FurnaceEquipmentType";
import { Vintages } from "./Vintages";

/** Forced Air Furnace HVAC system (aka. System 9 or 10).\n\nForced air furnaces are intended only for spaces only requiring heating and\nventilation. Each room/zone receives its own air loop with its own gas heating\ncoil, which will supply air at a temperature up to 50C (122F) to meet the\nheating needs of the room/zone. Fans are constant volume.\n\nForcedAirFurnace systems are the traditional baseline system for storage\nspaces that only require heating. */
export class ForcedAirFurnace extends _TemplateSystem {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ForcedAirFurnace")
    @Expose({ name: "type" })
    /** type */
    type: string = "ForcedAirFurnace";
	
    @Type(() => String)
    @IsEnum(FurnaceEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the FurnaceEquipmentType enumeration. */
    equipmentType: FurnaceEquipmentType = FurnaceEquipmentType.Furnace;
	

    constructor() {
        super();
        this.type = "ForcedAirFurnace";
        this.equipmentType = FurnaceEquipmentType.Furnace;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ForcedAirFurnace, _data);
            this.type = obj.type ?? "ForcedAirFurnace";
            this.equipmentType = obj.equipmentType ?? FurnaceEquipmentType.Furnace;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ForcedAirFurnace {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ForcedAirFurnace();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ForcedAirFurnace";
        data["equipment_type"] = this.equipmentType ?? FurnaceEquipmentType.Furnace;
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
