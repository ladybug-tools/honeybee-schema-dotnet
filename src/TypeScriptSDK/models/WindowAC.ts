import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { WindowACEquipmentType } from "./WindowACEquipmentType";

/** Window Air Conditioning cooling system (with optional heating).\n\nEach room/zone will receive its own Packaged Terminal Air Conditioner (PTAC)\nwith properties set to reflect a typical window air conditioning (AC) unit.\nNo ventilation air is supplied by the unit and the cooling coil within the\nunit is a single-speed direct expansion (DX) cooling coil. Heating loads\ncan be met with various options, including several types of baseboards,\na furnace, or gas unit heaters. */
export class WindowAC extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(WindowACEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the WindowACEquipmentType enumeration. */
    equipment_type?: WindowACEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "WindowAC";
        this.equipment_type = WindowACEquipmentType.WindowAC_ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "WindowAC";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : WindowACEquipmentType.WindowAC_ElectricBaseboard;
        }
    }


    static override fromJS(data: any): WindowAC {
        data = typeof data === 'object' ? data : {};

        let result = new WindowAC();
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
