import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { GasUnitHeaterEquipmentType } from "./GasUnitHeaterEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Gas unit heating system.

Gas unit systems are intended for spaces only requiring heating and no
ventilation or cooling. Each room/zone will get its own gaa heating unit
that satisfies the heating load. */
export class GasUnitHeater extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(GasUnitHeaterEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the GasUnitHeaterEquipmentType enumeration. */
    equipment_type?: GasUnitHeaterEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "GasUnitHeater";
        this.equipment_type = GasUnitHeaterEquipmentType.GasHeaters;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "GasUnitHeater";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : GasUnitHeaterEquipmentType.GasHeaters;
        }
    }


    static override fromJS(data: any): GasUnitHeater {
        data = typeof data === 'object' ? data : {};

        let result = new GasUnitHeater();
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
