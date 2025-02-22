﻿import { IsEnum, IsOptional, IsString, Matches, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RadiantEquipmentType } from "./RadiantEquipmentType";
import { RadiantFaceTypes } from "./RadiantFaceTypes";
import { Vintages } from "./Vintages";

/** Low temperature radiant HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range. */
export class Radiant extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    @Matches(/^Radiant$/)
    /** Type */
    type?: string;
	
    @IsEnum(RadiantEquipmentType)
    @Type(() => String)
    @IsOptional()
    /** Text for the specific type of system equipment from the RadiantEquipmentType enumeration. */
    equipment_type?: RadiantEquipmentType;
	
    @IsEnum(RadiantFaceTypes)
    @Type(() => String)
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
            const obj = plainToClass(Radiant, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
            this.radiant_face_type = obj.radiant_face_type;
            this.minimum_operation_time = obj.minimum_operation_time;
            this.switch_over_time = obj.switch_over_time;
        }
    }


    static override fromJS(data: any): Radiant {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Radiant();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage;
        data["type"] = this.type;
        data["equipment_type"] = this.equipment_type;
        data["radiant_face_type"] = this.radiant_face_type;
        data["minimum_operation_time"] = this.minimum_operation_time;
        data["switch_over_time"] = this.switch_over_time;
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

