import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _HeatCoolBase } from "./_HeatCoolBase";
import { ResidentialEquipmentType } from "./ResidentialEquipmentType";
import { Vintages } from "./Vintages";

/** Residential Air Conditioning, Heat Pump or Furnace system.\n\nResidential HVAC systems are intended primarily for single-family homes and\ninclude a wide variety of options. In all cases, each room/zone will receive\nits own air loop WITHOUT an outdoor air inlet (air is simply being recirculated\nthrough the loop). Residential air conditioning (AC) systems are modeled\nusing a unitary system with a single-speed direct expansion (DX) cooling\ncoil in the loop. Residential heat pump (HP) systems use a single-speed DX\nheating coil in the unitary system and the residential furnace option uses\na gas coil in the unitary system. In all cases, the properties of these coils\nare set to reflect a typical residential system. */
export class Residential extends _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("Residential")
    @Expose({ name: "type" })
    /** type */
    type: string = "Residential";
	
    @Type(() => String)
    @IsEnum(ResidentialEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the ResidentialEquipmentType enumeration. */
    equipmentType: ResidentialEquipmentType = ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
	

    constructor() {
        super();
        this.type = "Residential";
        this.equipmentType = ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Residential, _data);
            this.type = obj.type ?? "Residential";
            this.equipmentType = obj.equipmentType ?? ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): Residential {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Residential();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "Residential";
        data["equipment_type"] = this.equipmentType ?? ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
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
