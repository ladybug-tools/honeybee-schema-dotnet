import { IsEnum, ValidateNested, IsOptional, IsString, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RadiantEquipmentType } from "./RadiantEquipmentType";
import { RadiantFaceTypes } from "./RadiantFaceTypes";
import { Vintages } from "./Vintages";

/** Low temperature radiant HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range. */
export class Radiant extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(RadiantEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the RadiantEquipmentType enumeration. */
    equipment_type?: RadiantEquipmentType;
	
    @IsEnum(RadiantFaceTypes)
    @ValidateNested()
    @IsOptional()
    /** Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces. */
    radiant_face_type?: RadiantFaceTypes;
	
    @IsNumber()
    @IsOptional()
    /** A number for the minimum number of hours of operation for the radiant system before it shuts off. */
    minimum_operation_time?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the minimum number of hours for when the system can switch between heating and cooling. */
    switch_over_time?: number;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "Radiant";
        this.equipment_type = RadiantEquipmentType.Radiant_Chiller_Boiler;
        this.radiant_face_type = RadiantFaceTypes.Floor;
        this.minimum_operation_time = 1;
        this.switch_over_time = 24;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "Radiant";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : RadiantEquipmentType.Radiant_Chiller_Boiler;
            this.radiant_face_type = _data["radiant_face_type"] !== undefined ? _data["radiant_face_type"] : RadiantFaceTypes.Floor;
            this.minimum_operation_time = _data["minimum_operation_time"] !== undefined ? _data["minimum_operation_time"] : 1;
            this.switch_over_time = _data["switch_over_time"] !== undefined ? _data["switch_over_time"] : 24;
        }
    }


    static override fromJS(data: any): Radiant {
        data = typeof data === 'object' ? data : {};

        let result = new Radiant();
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
        data["radiant_face_type"] = this.radiant_face_type;
        data["minimum_operation_time"] = this.minimum_operation_time;
        data["switch_over_time"] = this.switch_over_time;
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
