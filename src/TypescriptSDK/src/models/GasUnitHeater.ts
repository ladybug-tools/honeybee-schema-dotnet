import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _HeatCoolBase } from "./_HeatCoolBase";
import { GasUnitHeaterEquipmentType } from "./GasUnitHeaterEquipmentType";
import { Vintages } from "./Vintages";

/** Gas unit heating system.\n\nGas unit systems are intended for spaces only requiring heating and no\nventilation or cooling. Each room/zone will get its own gaa heating unit\nthat satisfies the heating load. */
export class GasUnitHeater extends _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("GasUnitHeater")
    @Expose({ name: "type" })
    /** type */
    type: string = "GasUnitHeater";
	
    @Type(() => String)
    @IsEnum(GasUnitHeaterEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the GasUnitHeaterEquipmentType enumeration. */
    equipmentType: GasUnitHeaterEquipmentType = GasUnitHeaterEquipmentType.GasHeaters;
	

    constructor() {
        super();
        this.type = "GasUnitHeater";
        this.equipmentType = GasUnitHeaterEquipmentType.GasHeaters;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(GasUnitHeater, _data);
            this.type = obj.type ?? "GasUnitHeater";
            this.equipmentType = obj.equipmentType ?? GasUnitHeaterEquipmentType.GasHeaters;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): GasUnitHeater {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new GasUnitHeater();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "GasUnitHeater";
        data["equipment_type"] = this.equipmentType ?? GasUnitHeaterEquipmentType.GasHeaters;
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
