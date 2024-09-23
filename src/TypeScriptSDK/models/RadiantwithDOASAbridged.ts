import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RadiantFaceTypes } from "./RadiantFaceTypes";
import { RadiantwithDOASEquipmentType } from "./RadiantwithDOASEquipmentType";
import { Vintages } from "./Vintages";

/** Low Temperature Radiant with DOAS HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a two-speed direct expansion (DX) cooling coil and a single-speed DX\nheating coil with backup electrical resistance heat.\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range. */
export class RadiantwithDOASAbridged extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latent_heat_recovery?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demand_controlled_ventilation?: boolean;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on. */
    doas_availability_schedule?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^RadiantwithDOASAbridged$/)
    type?: string;
	
    @IsEnum(RadiantwithDOASEquipmentType)
    @Type(() => String)
    @IsOptional()
    /** Text for the specific type of system equipment from the RadiantwithDOASEquipmentType enumeration. */
    equipment_type?: RadiantwithDOASEquipmentType;
	
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
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "RadiantwithDOASAbridged";
        this.equipment_type = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
        this.radiant_face_type = RadiantFaceTypes.Floor;
        this.minimum_operation_time = 1;
        this.switch_over_time = 24;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RadiantwithDOASAbridged, _data);
            this.vintage = obj.vintage;
            this.sensible_heat_recovery = obj.sensible_heat_recovery;
            this.latent_heat_recovery = obj.latent_heat_recovery;
            this.demand_controlled_ventilation = obj.demand_controlled_ventilation;
            this.doas_availability_schedule = obj.doas_availability_schedule;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
            this.radiant_face_type = obj.radiant_face_type;
            this.minimum_operation_time = obj.minimum_operation_time;
            this.switch_over_time = obj.switch_over_time;
        }
    }


    static override fromJS(data: any): RadiantwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new RadiantwithDOASAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage;
        data["sensible_heat_recovery"] = this.sensible_heat_recovery;
        data["latent_heat_recovery"] = this.latent_heat_recovery;
        data["demand_controlled_ventilation"] = this.demand_controlled_ventilation;
        data["doas_availability_schedule"] = this.doas_availability_schedule;
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

