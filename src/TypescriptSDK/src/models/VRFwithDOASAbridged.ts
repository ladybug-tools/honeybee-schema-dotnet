import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { VRFwithDOASEquipmentType } from "./VRFwithDOASEquipmentType";

/** Variable Refrigerant Flow (VRF) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a single speed direct expansion (DX) cooling coil along with a single-speed\ndirect expansion (DX) heat pump with a backup electrical resistance coil.\n\nEach room/zone also receives its own Variable Refrigerant Flow (VRF) terminal,\nwhich meets the heating and cooling loads of the space. All room/zone terminals\nare connected to the same outdoor unit, meaning that either all rooms must be\nin cooling or heating mode together. */
export class VRFwithDOASAbridged extends IDdEnergyBaseModel {
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
    @Matches(/^VRFwithDOASAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "VRFwithDOASAbridged";
	
    @IsEnum(VRFwithDOASEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the VRFwithDOASEquipmentType enumeration. */
    equipmentType: VRFwithDOASEquipmentType = VRFwithDOASEquipmentType.DOAS_VRF;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.demandControlledVentilation = false;
        this.type = "VRFwithDOASAbridged";
        this.equipmentType = VRFwithDOASEquipmentType.DOAS_VRF;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VRFwithDOASAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.doasAvailabilitySchedule = obj.doasAvailabilitySchedule;
            this.type = obj.type ?? "VRFwithDOASAbridged";
            this.equipmentType = obj.equipmentType ?? VRFwithDOASEquipmentType.DOAS_VRF;
        }
    }


    static override fromJS(data: any): VRFwithDOASAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VRFwithDOASAbridged();
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
        data["type"] = this.type ?? "VRFwithDOASAbridged";
        data["equipment_type"] = this.equipmentType ?? VRFwithDOASEquipmentType.DOAS_VRF;
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
