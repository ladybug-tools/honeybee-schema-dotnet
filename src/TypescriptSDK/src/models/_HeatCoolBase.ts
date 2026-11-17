import { IsBoolean, IsOptional, IsNumber, Min, Max, IsString, MinLength, MaxLength, Matches, IsEnum, IsDefined, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Vintages } from "./Vintages";

/** Base class for all heating/cooling systems without ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and,\nby default, they cannot meet minimum ventilation requirements. However,\noptional unit ventilators can be included, which provide ventilation through\na balanced intake and exhaust ventilation on a zone-by-zone basis. Unlike a\nDOAS, unit ventilators do not pass the outdoor air through heating or cooling\ncoils to condition it for the space. However, heat recovery effectiveness\ncan be specified, which can temper the air supplied to the zone with exhaust air.\n\nThese systems tend to be used in residential or hospitality settings where\nmeeting minimum ventilation requirements may not be required as the density\nof occupancy is so low that infiltration is enough to meet fresh air needs.\nOr occupancy is so variable that supplying ventilation to each room with\nseparate unit ventilators is a worthwhile approach.\n\nThese systems are also common in warehouse or storage settings where ventilation\nmay not be necessary. */
export class _HeatCoolBase {
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "unit_ventilators" })
    /** Boolean to note whether individual zone ventilators are included with the basic heating and cooling system (True) or the system only performs heating and cooling without any ventilation (False). Unlike a DOAS, unit ventilators do not pass the outdoor air through heating or cooling coils to condition it for the space. However, heat recovery effectiveness can be specified, which can temper the air supplied to the zone by the ventilator with exhaust air. All air flow through this ventilator is always balanced for each zone between supply and exhaust and the total flow rate is determined by checking the ventilation and exhaust requirements of the rooms to which the system is assigned. */
    unitVentilators: boolean = false;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within unit ventilators if specified. */
    sensibleHeatRecovery: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within unit ventilators if specified. */
    latentHeatRecovery: number = 0;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "vent_availability_schedule" })
    /** An optional On/Off discrete schedule to specify when unit ventilators shut off (assuming that the unit_ventilators is True). This will not only reduce heating and cooling load by preventing outdoor air from flowing but will also shut off the fans, which can result in more energy savings when spaces served by the ventilators are completely unoccupied. If None, the unit ventilators will be always on. */
    ventAvailabilitySchedule?: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Matches(/^_HeatCoolBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_HeatCoolBase";
	
    @Type(() => String)
    @IsEnum(Vintages)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsOptional()
    @Expose({ name: "user_data" })
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    userData?: Object;
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "identifier" })
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    identifier!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	

    constructor() {
        this.unitVentilators = false;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.type = "_HeatCoolBase";
        this.vintage = Vintages.ASHRAE_2019;
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(_HeatCoolBase, _data);
            this.unitVentilators = obj.unitVentilators ?? false;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.ventAvailabilitySchedule = obj.ventAvailabilitySchedule;
            this.type = obj.type ?? "_HeatCoolBase";
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): _HeatCoolBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _HeatCoolBase();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["unit_ventilators"] = this.unitVentilators ?? false;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery ?? 0;
        data["latent_heat_recovery"] = this.latentHeatRecovery ?? 0;
        data["vent_availability_schedule"] = this.ventAvailabilitySchedule;
        data["type"] = this.type ?? "_HeatCoolBase";
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["user_data"] = this.userData;
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
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
