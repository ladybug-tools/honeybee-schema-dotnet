import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _HeatCoolBase } from "./_HeatCoolBase";
import { Vintages } from "./Vintages";
import { WindowACEquipmentType } from "./WindowACEquipmentType";

/** Window Air Conditioning cooling system (with optional heating).\n\nEach room/zone will receive its own Packaged Terminal Air Conditioner (PTAC)\nwith properties set to reflect a typical window air conditioning (AC) unit.\nNo ventilation air is supplied by the unit and the cooling coil within the\nunit is a single-speed direct expansion (DX) cooling coil. Heating loads\ncan be met with various options, including several types of baseboards,\na furnace, or gas unit heaters. */
export class WindowAC extends _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("WindowAC")
    @Expose({ name: "type" })
    /** type */
    type: string = "WindowAC";
	
    @Type(() => String)
    @IsEnum(WindowACEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the WindowACEquipmentType enumeration. */
    equipmentType: WindowACEquipmentType = WindowACEquipmentType.WindowAC_ElectricBaseboard;
	

    constructor() {
        super();
        this.type = "WindowAC";
        this.equipmentType = WindowACEquipmentType.WindowAC_ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WindowAC, _data);
            this.type = obj.type ?? "WindowAC";
            this.equipmentType = obj.equipmentType ?? WindowACEquipmentType.WindowAC_ElectricBaseboard;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): WindowAC {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WindowAC();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "WindowAC";
        data["equipment_type"] = this.equipmentType ?? WindowACEquipmentType.WindowAC_ElectricBaseboard;
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
