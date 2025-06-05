import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RadiantFaceTypes } from "./RadiantFaceTypes";
import { RadiantwithDOASEquipmentType } from "./RadiantwithDOASEquipmentType";
import { Vintages } from "./Vintages";

/** Low Temperature Radiant with DOAS HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a two-speed direct expansion (DX) cooling coil and a single-speed DX\nheating coil with backup electrical resistance heat.\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range. */
export class RadiantwithDOASAbridged extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensibleHeatRecovery: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latentHeatRecovery: number = 0;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "demand_controlled_ventilation" })
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demandControlledVentilation: boolean = false;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "doas_availability_schedule" })
    /** An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on. */
    doasAvailabilitySchedule?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^RadiantwithDOASAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RadiantwithDOASAbridged";
	
    @IsEnum(RadiantwithDOASEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the RadiantwithDOASEquipmentType enumeration. */
    equipmentType: RadiantwithDOASEquipmentType = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
	
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
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.demandControlledVentilation = false;
        this.type = "RadiantwithDOASAbridged";
        this.equipmentType = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
        this.radiantFaceType = RadiantFaceTypes.Floor;
        this.minimumOperationTime = 1;
        this.switchOverTime = 24;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RadiantwithDOASAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.doasAvailabilitySchedule = obj.doasAvailabilitySchedule;
            this.type = obj.type ?? "RadiantwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
            this.radiantFaceType = obj.radiantFaceType ?? RadiantFaceTypes.Floor;
            this.minimumOperationTime = obj.minimumOperationTime ?? 1;
            this.switchOverTime = obj.switchOverTime ?? 24;
        }
    }


    static override fromJS(data: any): RadiantwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RadiantwithDOASAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery ?? 0;
        data["latent_heat_recovery"] = this.latentHeatRecovery ?? 0;
        data["demand_controlled_ventilation"] = this.demandControlledVentilation ?? false;
        data["doas_availability_schedule"] = this.doasAvailabilitySchedule;
        data["type"] = this.type ?? "RadiantwithDOASAbridged";
        data["equipment_type"] = this.equipmentType ?? RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;
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
