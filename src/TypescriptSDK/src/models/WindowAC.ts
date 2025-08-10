import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { WindowACEquipmentType } from "./WindowACEquipmentType";

/** Window Air Conditioning cooling system (with optional heating).\n\nEach room/zone will receive its own Packaged Terminal Air Conditioner (PTAC)\nwith properties set to reflect a typical window air conditioning (AC) unit.\nNo ventilation air is supplied by the unit and the cooling coil within the\nunit is a single-speed direct expansion (DX) cooling coil. Heating loads\ncan be met with various options, including several types of baseboards,\na furnace, or gas unit heaters. */
export class WindowAC extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowAC$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WindowAC";
	
    @IsEnum(WindowACEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the WindowACEquipmentType enumeration. */
    equipmentType: WindowACEquipmentType = WindowACEquipmentType.WindowAC_ElectricBaseboard;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "WindowAC";
        this.equipmentType = WindowACEquipmentType.WindowAC_ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WindowAC, _data);
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
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
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
