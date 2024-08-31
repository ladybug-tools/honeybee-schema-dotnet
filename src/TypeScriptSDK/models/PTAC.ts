import { IsEnum, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { PTACEquipmentType } from "./PTACEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Terminal Air Conditioning (PTAC/HP) HVAC system. (aka. System 1 or 2).\n\nEach room/zone receives its own packaged unit that supplies heating, cooling\nand ventilation. Cooling is always done via a single-speed direct expansion (DX)\ncooling coil. Heating can be done via a heating coil in the unit or via an\nexternal baseboard. Fans are constant volume.\n\nPTAC/HP systems are the traditional baseline system for residential buildings. */
export class PTAC extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(PTACEquipmentType)
    @Type(() => String)
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
            const obj = plainToClass(PTAC, _data);
            this.vintage = obj.vintage;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
