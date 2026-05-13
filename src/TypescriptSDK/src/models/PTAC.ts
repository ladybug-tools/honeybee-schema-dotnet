import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _TemplateSystem } from "./_TemplateSystem";
import { PTACEquipmentType } from "./PTACEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Terminal Air Conditioning (PTAC/HP) HVAC system. (aka. System 1 or 2).\n\nEach room/zone receives its own packaged unit that supplies heating, cooling\nand ventilation. Cooling is always done via a single-speed direct expansion (DX)\ncooling coil. Heating can be done via a heating coil in the unit or via an\nexternal baseboard. Fans are constant volume.\n\nPTAC/HP systems are the traditional baseline system for residential buildings. */
export class PTAC extends _TemplateSystem {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("PTAC")
    @Expose({ name: "type" })
    /** type */
    type: string = "PTAC";
	
    @Type(() => String)
    @IsEnum(PTACEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the PTACEquipmentType enumeration. */
    equipmentType: PTACEquipmentType = PTACEquipmentType.PTAC_ElectricBaseboard;
	

    constructor() {
        super();
        this.type = "PTAC";
        this.equipmentType = PTACEquipmentType.PTAC_ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(PTAC, _data);
            this.type = obj.type ?? "PTAC";
            this.equipmentType = obj.equipmentType ?? PTACEquipmentType.PTAC_ElectricBaseboard;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): PTAC {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new PTAC();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "PTAC";
        data["equipment_type"] = this.equipmentType ?? PTACEquipmentType.PTAC_ElectricBaseboard;
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
