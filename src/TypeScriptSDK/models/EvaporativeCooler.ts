import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError } from 'class-validator';
import { Vintages } from "./Vintages";
import { EvaporativeCoolerEquipmentType } from "./EvaporativeCoolerEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Direct evaporative cooling systems (with optional heating).

Each room/zone will receive its own air loop sized to meet the sensible load,
which contains an evaporative cooler that directly adds humidity to the room
air to cool it. The loop contains an outdoor air mixer, which is used whenever
the outdoor air has a lower wet bulb temperature than the return air from
the room. In the event that the combination of outdoor and room return air
air is too humid, a backup single-speed direct expansion (DX) cooling coil
will be used. Heating loads can be met with various options, including
several types of baseboards, a furnace, or gas unit heaters. */
export class EvaporativeCooler extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(EvaporativeCoolerEquipmentType)
    @ValidateNested()
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
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "EvaporativeCooler";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : EvaporativeCoolerEquipmentType.EvapCoolers_ElectricBaseboard;
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
