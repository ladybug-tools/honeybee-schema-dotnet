import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { GasUnitHeaterEquipmentType } from "./GasUnitHeaterEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Gas unit heating system.\n\nGas unit systems are intended for spaces only requiring heating and no\nventilation or cooling. Each room/zone will get its own gaa heating unit\nthat satisfies the heating load. */
export class GasUnitHeater extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^GasUnitHeater$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "GasUnitHeater";
	
    @IsEnum(GasUnitHeaterEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the GasUnitHeaterEquipmentType enumeration. */
    equipmentType: GasUnitHeaterEquipmentType = GasUnitHeaterEquipmentType.GasHeaters;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "GasUnitHeater";
        this.equipmentType = GasUnitHeaterEquipmentType.GasHeaters;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(GasUnitHeater, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "GasUnitHeater";
            this.equipmentType = obj.equipmentType ?? GasUnitHeaterEquipmentType.GasHeaters;
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
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
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
