import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _HeatCoolBase } from "./_HeatCoolBase";
import { EvaporativeCoolerEquipmentType } from "./EvaporativeCoolerEquipmentType";
import { Vintages } from "./Vintages";

/** Direct evaporative cooling systems (with optional heating).\n\nEach room/zone will receive its own air loop sized to meet the sensible load,\nwhich contains an evaporative cooler that directly adds humidity to the room\nair to cool it. The loop contains an outdoor air mixer, which is used whenever\nthe outdoor air has a lower wet bulb temperature than the return air from\nthe room. In the event that the combination of outdoor and room return air\nair is too humid, a backup single-speed direct expansion (DX) cooling coil\nwill be used. Heating loads can be met with various options, including\nseveral types of baseboards, a furnace, or gas unit heaters. */
export class EvaporativeCooler extends _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("EvaporativeCooler")
    @Expose({ name: "type" })
    /** type */
    type: string = "EvaporativeCooler";
	
    @Type(() => String)
    @IsEnum(EvaporativeCoolerEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the EvaporativeCoolerEquipmentType enumeration. */
    equipmentType: EvaporativeCoolerEquipmentType = EvaporativeCoolerEquipmentType.EvapCoolers_ElectricBaseboard;
	

    constructor() {
        super();
        this.type = "EvaporativeCooler";
        this.equipmentType = EvaporativeCoolerEquipmentType.EvapCoolers_ElectricBaseboard;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(EvaporativeCooler, _data);
            this.type = obj.type ?? "EvaporativeCooler";
            this.equipmentType = obj.equipmentType ?? EvaporativeCoolerEquipmentType.EvapCoolers_ElectricBaseboard;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): EvaporativeCooler {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EvaporativeCooler();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "EvaporativeCooler";
        data["equipment_type"] = this.equipmentType ?? EvaporativeCoolerEquipmentType.EvapCoolers_ElectricBaseboard;
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
