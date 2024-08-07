import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError } from 'class-validator';
import { Vintages } from "./Vintages";
import { BaseboardEquipmentType } from "./BaseboardEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Baseboard heating system.

Baseboard systems are intended for spaces only requiring heating and
no ventilation or cooling. Each room/zone will get its own baseboard
heating unit that satisfies the heating load. */
export class Baseboard extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(BaseboardEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the BaseboardEquipmentType enumeration. */
    equipment_type?: BaseboardEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "Baseboard";
        this.equipment_type = BaseboardEquipmentType.ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "Baseboard";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : BaseboardEquipmentType.ElectricBaseboard;
        }
    }


    static override fromJS(data: any): Baseboard {
        data = typeof data === 'object' ? data : {};

        let result = new Baseboard();
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
