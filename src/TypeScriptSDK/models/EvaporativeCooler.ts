import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { EvaporativeCoolerEquipmentType } from "./EvaporativeCoolerEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Direct evaporative cooling systems (with optional heating).\n\nEach room/zone will receive its own air loop sized to meet the sensible load,\nwhich contains an evaporative cooler that directly adds humidity to the room\nair to cool it. The loop contains an outdoor air mixer, which is used whenever\nthe outdoor air has a lower wet bulb temperature than the return air from\nthe room. In the event that the combination of outdoor and room return air\nair is too humid, a backup single-speed direct expansion (DX) cooling coil\nwill be used. Heating loads can be met with various options, including\nseveral types of baseboards, a furnace, or gas unit heaters. */
export class EvaporativeCooler extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    @Matches(/^EvaporativeCooler$/)
    type?: string;
	
    @IsEnum(EvaporativeCoolerEquipmentType)
    @Type(() => String)
    @IsOptional()
    /** Text for the specific type of system equipment from the EvaporativeCoolerEquipmentType enumeration. */
    equipment_type?: EvaporativeCoolerEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "EvaporativeCooler";
        this.equipment_type = EvaporativeCoolerEquipmentType.EvapCoolers_ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EvaporativeCooler, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
        }
    }


    static override fromJS(data: any): EvaporativeCooler {
        data = typeof data === 'object' ? data : {};

        let result = new EvaporativeCooler();
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

