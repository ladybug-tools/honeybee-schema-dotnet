import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { WSHPEquipmentType } from "./WSHPEquipmentType";

/** Water Source Heat Pump (WSHP) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Water Source Heat Pump (WSHP), which meets\nthe heating and cooling loads of the space. All WSHPs are connected to the\nsame water condenser loop, which has its temperature maintained by the\nequipment_type (eg. Boiler with Cooling Tower). */
export class WSHP extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(WSHPEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the WSHPEquipmentType enumeration. */
    equipment_type?: WSHPEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "WSHP";
        this.equipment_type = WSHPEquipmentType.WSHP_FluidCooler_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "WSHP";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : WSHPEquipmentType.WSHP_FluidCooler_Boiler;
        }
    }


    static override fromJS(data: any): WSHP {
        data = typeof data === 'object' ? data : {};

        let result = new WSHP();
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
