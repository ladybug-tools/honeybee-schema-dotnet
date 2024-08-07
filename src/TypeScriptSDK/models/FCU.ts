import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError } from 'class-validator';
import { Vintages } from "./Vintages";
import { FCUEquipmentType } from "./FCUEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Fan Coil Unit (FCU) heating/cooling system (with no ventilation).

Each room/zone receives its own Fan Coil Unit (FCU), which meets the heating
and cooling loads of the space. The cooling coil in the FCU is always chilled
water cooling coil, which is connected to a chilled water loop operating
at 6.7C (44F). The heating coil is a hot water coil except when when electric
baseboards or gas heaters are specified. Hot water temperature is 82C (180F) for
boiler/district heating and 49C (120F) when ASHP is used. */
export class FCU extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(FCUEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the FCUEquipmentType enumeration. */
    equipment_type?: FCUEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "FCU";
        this.equipment_type = FCUEquipmentType.FCU_Chiller_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "FCU";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : FCUEquipmentType.FCU_Chiller_Boiler;
        }
    }


    static override fromJS(data: any): FCU {
        data = typeof data === 'object' ? data : {};

        let result = new FCU();
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
