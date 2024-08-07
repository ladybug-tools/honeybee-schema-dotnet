import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError } from 'class-validator';
import { Vintages } from "./Vintages";
import { PTACEquipmentType } from "./PTACEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Packaged Terminal Air Conditioning (PTAC/HP) HVAC system. (aka. System 1 or 2).

Each room/zone receives its own packaged unit that supplies heating, cooling
and ventilation. Cooling is always done via a single-speed direct expansion (DX)
cooling coil. Heating can be done via a heating coil in the unit or via an
external baseboard. Fans are constant volume.

PTAC/HP systems are the traditional baseline system for residential buildings. */
export class PTAC extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(PTACEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the PTACEquipmentType enumeration. */
    equipment_type?: PTACEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "PTAC";
        this.equipment_type = PTACEquipmentType.PTAC_ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "PTAC";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : PTACEquipmentType.PTAC_ElectricBaseboard;
        }
    }


    static override fromJS(data: any): PTAC {
        data = typeof data === 'object' ? data : {};

        let result = new PTAC();
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
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
