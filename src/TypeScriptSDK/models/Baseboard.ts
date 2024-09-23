import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { BaseboardEquipmentType } from "./BaseboardEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Baseboard heating system.\n\nBaseboard systems are intended for spaces only requiring heating and\nno ventilation or cooling. Each room/zone will get its own baseboard\nheating unit that satisfies the heating load. */
export class Baseboard extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    @Matches(/^Baseboard$/)
    type?: string;
	
    @IsEnum(BaseboardEquipmentType)
    @Type(() => String)
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
            const obj = plainToClass(Baseboard, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
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
        data["vintage"] = this.vintage;
        data["type"] = this.type;
        data["equipment_type"] = this.equipment_type;
        data = super.toJSON(data);
        return instanceToPlain(data);
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

