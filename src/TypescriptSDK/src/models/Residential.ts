import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ResidentialEquipmentType } from "./ResidentialEquipmentType";
import { Vintages } from "./Vintages";

/** Residential Air Conditioning, Heat Pump or Furnace system.\n\nResidential HVAC systems are intended primarily for single-family homes and\ninclude a wide variety of options. In all cases, each room/zone will receive\nits own air loop WITHOUT an outdoor air inlet (air is simply being recirculated\nthrough the loop). Residential air conditioning (AC) systems are modeled\nusing a unitary system with a single-speed direct expansion (DX) cooling\ncoil in the loop. Residential heat pump (HP) systems use a single-speed DX\nheating coil in the unitary system and the residential furnace option uses\na gas coil in the unitary system. In all cases, the properties of these coils\nare set to reflect a typical residential system. */
export class Residential extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^Residential$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Residential";
	
    @IsEnum(ResidentialEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the ResidentialEquipmentType enumeration. */
    equipmentType: ResidentialEquipmentType = ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "Residential";
        this.equipmentType = ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Residential, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "Residential";
            this.equipmentType = obj.equipmentType ?? ResidentialEquipmentType.ResidentialAC_ElectricBaseboard;
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
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
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
