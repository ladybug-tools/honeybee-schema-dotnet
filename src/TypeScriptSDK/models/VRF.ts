import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { VRFEquipmentType } from "./VRFEquipmentType";

/** Variable Refrigerant Flow (VRF) heating/cooling system (with no ventilation).

Each room/zone receives its own Variable Refrigerant Flow (VRF) terminal,
which meets the heating and cooling loads of the space. All room/zone terminals
are connected to the same outdoor unit, meaning that either all rooms must be
in cooling or heating mode together. */
export class VRF extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(VRFEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the VRFEquipmentType enumeration. */
    equipment_type?: VRFEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "VRF";
        this.equipment_type = VRFEquipmentType.VRF;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "VRF";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : VRFEquipmentType.VRF;
        }
    }


    static override fromJS(data: any): VRF {
        data = typeof data === 'object' ? data : {};

        let result = new VRF();
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
