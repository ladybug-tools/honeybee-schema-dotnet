import { IsEnum, IsOptional, IsString, Matches, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RadiantEquipmentType } from "./RadiantEquipmentType";
import { RadiantFaceTypes } from "./RadiantFaceTypes";
import { Vintages } from "./Vintages";

/** Low temperature radiant HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range. */
export class Radiant extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^Radiant$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Radiant";
	
    @IsEnum(RadiantEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the RadiantEquipmentType enumeration. */
    equipmentType: RadiantEquipmentType = RadiantEquipmentType.Radiant_Chiller_Boiler;
	
    @IsEnum(RadiantFaceTypes)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "radiant_face_type" })
    /** Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces. */
    radiantFaceType: RadiantFaceTypes = RadiantFaceTypes.Floor;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "minimum_operation_time" })
    /** A number for the minimum number of hours of operation for the radiant system before it shuts off. */
    minimumOperationTime: number = 1;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "switch_over_time" })
    /** A number for the minimum number of hours for when the system can switch between heating and cooling. */
    switchOverTime: number = 24;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "Radiant";
        this.equipmentType = RadiantEquipmentType.Radiant_Chiller_Boiler;
        this.radiantFaceType = RadiantFaceTypes.Floor;
        this.minimumOperationTime = 1;
        this.switchOverTime = 24;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Radiant, _data);
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "Radiant";
            this.equipmentType = obj.equipmentType ?? RadiantEquipmentType.Radiant_Chiller_Boiler;
            this.radiantFaceType = obj.radiantFaceType ?? RadiantFaceTypes.Floor;
            this.minimumOperationTime = obj.minimumOperationTime ?? 1;
            this.switchOverTime = obj.switchOverTime ?? 24;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["type"] = this.type ?? "Radiant";
        data["equipment_type"] = this.equipmentType ?? RadiantEquipmentType.Radiant_Chiller_Boiler;
        data["radiant_face_type"] = this.radiantFaceType ?? RadiantFaceTypes.Floor;
        data["minimum_operation_time"] = this.minimumOperationTime ?? 1;
        data["switch_over_time"] = this.switchOverTime ?? 24;
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
