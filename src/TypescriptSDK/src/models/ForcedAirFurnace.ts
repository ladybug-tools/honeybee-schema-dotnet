import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { FurnaceEquipmentType } from "./FurnaceEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Forced Air Furnace HVAC system (aka. System 9 or 10).\n\nForced air furnaces are intended only for spaces only requiring heating and\nventilation. Each room/zone receives its own air loop with its own gas heating\ncoil, which will supply air at a temperature up to 50C (122F) to meet the\nheating needs of the room/zone. Fans are constant volume.\n\nForcedAirFurnace systems are the traditional baseline system for storage\nspaces that only require heating. */
export class ForcedAirFurnace extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^ForcedAirFurnace$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ForcedAirFurnace";
	
    @IsEnum(FurnaceEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the FurnaceEquipmentType enumeration. */
    equipmentType: FurnaceEquipmentType = FurnaceEquipmentType.Furnace;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "ForcedAirFurnace";
        this.equipmentType = FurnaceEquipmentType.Furnace;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ForcedAirFurnace, _data);
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "ForcedAirFurnace";
            this.equipmentType = obj.equipmentType ?? FurnaceEquipmentType.Furnace;
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
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
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
