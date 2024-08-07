import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { Vintages } from "./Vintages";
import { ResidentialEquipmentType } from "./ResidentialEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Residential Air Conditioning, Heat Pump or Furnace system.

Residential HVAC systems are intended primarily for single-family homes and
include a wide variety of options. In all cases, each room/zone will receive
its own air loop WITHOUT an outdoor air inlet (air is simply being recirculated
through the loop). Residential air conditioning (AC) systems are modeled
using a unitary system with a single-speed direct expansion (DX) cooling
coil in the loop. Residential heat pump (HP) systems use a single-speed DX
heating coil in the unitary system and the residential furnace option uses
a gas coil in the unitary system. In all cases, the properties of these coils
are set to reflect a typical residential system. */
export class Residential extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(ResidentialEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the ResidentialEquipmentType enumeration. */
    equipment_type?: ResidentialEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "Residential";
        this.equipment_type = ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "Residential";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
        }
    }


    static override fromJS(data: any): Residential {
        data = typeof data === 'object' ? data : {};

        let result = new Residential();
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
