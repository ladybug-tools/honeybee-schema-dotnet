import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { VAVEquipmentType } from "./VAVEquipmentType";
import { Vintages } from "./Vintages";

/** Variable Air Volume (VAV) HVAC system (aka. System 7 or 8).\n\nAll rooms/zones are connected to a central air loop that is kept at a constant\ncentral temperature of 12.8C (55F). The central temperature is maintained by a\ncooling coil, which runs whenever the combination of return air and fresh outdoor\nair is greater than 12.8C, as well as a heating coil, which runs whenever\nthe combination of return air and fresh outdoor air is less than 12.8C.\n\nEach air terminal for the connected rooms/zones contains its own reheat coil,\nwhich runs whenever the room is not in need of the cooling supplied by the 12.8C\ncentral air.\n\nThe central cooling coil is always a chilled water coil, which is connected to a\nchilled water loop operating at 6.7C (44F). All heating coils are hot water coils\nexcept when Gas Coil equipment_type is used (in which case coils are gas)\nor when Parallel Fan-Powered (PFP) boxes equipment_type is used (in which case\ncoils are electric resistance). Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.\n\nVAV systems are the traditional baseline system for commercial buildings\ntaller than 5 stories or larger than 14,000 m2 (150,000 ft2) of floor area. */
export class VAV extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsEnum(AllAirEconomizerType)
    @Type(() => String)
    @IsOptional()
    /** Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration). */
    economizer_type?: AllAirEconomizerType;
	
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
    @Matches(/^VAV$/)
    type?: string;
	
    @IsEnum(VAVEquipmentType)
    @Type(() => String)
    @IsOptional()
    /** Text for the specific type of system equipment from the VAVEquipmentType enumeration. */
    equipment_type?: VAVEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.economizer_type = AllAirEconomizerType.NoEconomizer;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "VAV";
        this.equipment_type = VAVEquipmentType.VAV_Chiller_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VAV, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.economizer_type = obj.economizer_type;
            this.sensible_heat_recovery = obj.sensible_heat_recovery;
            this.latent_heat_recovery = obj.latent_heat_recovery;
            this.demand_controlled_ventilation = obj.demand_controlled_ventilation;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
        }
    }


    static override fromJS(data: any): VAV {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VAV();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage;
        data["economizer_type"] = this.economizer_type;
        data["sensible_heat_recovery"] = this.sensible_heat_recovery;
        data["latent_heat_recovery"] = this.latent_heat_recovery;
        data["demand_controlled_ventilation"] = this.demand_controlled_ventilation;
        data["type"] = this.type;
        data["equipment_type"] = this.equipment_type;
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

