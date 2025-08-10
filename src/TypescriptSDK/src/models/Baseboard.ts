import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseboardEquipmentType } from "./BaseboardEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Baseboard heating system.\n\nBaseboard systems are intended for spaces only requiring heating and\nno ventilation or cooling. Each room/zone will get its own baseboard\nheating unit that satisfies the heating load. */
export class Baseboard extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^Baseboard$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Baseboard";
	
    @IsEnum(BaseboardEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the BaseboardEquipmentType enumeration. */
    equipmentType: BaseboardEquipmentType = BaseboardEquipmentType.ElectricBaseboard;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "Baseboard";
        this.equipmentType = BaseboardEquipmentType.ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Baseboard, _data);
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "Baseboard";
            this.equipmentType = obj.equipmentType ?? BaseboardEquipmentType.ElectricBaseboard;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): Baseboard {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Baseboard();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["type"] = this.type ?? "Baseboard";
        data["equipment_type"] = this.equipmentType ?? BaseboardEquipmentType.ElectricBaseboard;
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
