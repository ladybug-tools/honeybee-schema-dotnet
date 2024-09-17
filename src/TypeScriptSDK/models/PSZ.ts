import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { PSZEquipmentType } from "./PSZEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Single-Zone (PSZ) HVAC system (aka. System 3 or 4).\n\nEach room/zone receives its own air loop with its own single-speed direct expansion\n(DX) cooling coil, which will condition the supply air to a value in between\n12.8C (55F) and 50C (122F) depending on the heating/cooling needs of the room/zone.\nAs long as a Baseboard equipment_type is NOT selected, heating will be supplied\nby a heating coil in the air loop. Otherwise, heating is accomplished with\nbaseboards and the air loop only supplies cooling and ventilation air.\nFans are constant volume.\n\nPSZ systems are the traditional baseline system for commercial buildings\nwith less than 4 stories or less than 2,300 m2 (25,000 ft2) of floor area.\nThey are also the default for all retail with less than 3 stories and all public\nassembly spaces. */
export class PSZ extends IDdEnergyBaseModel {
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
    @Matches(/^PSZ$/)
    type?: string;
	
    @IsEnum(PSZEquipmentType)
    @Type(() => String)
    @IsOptional()
    /** Text for the specific type of system equipment from the PVAVEquipmentType enumeration. */
    equipment_type?: PSZEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.economizer_type = AllAirEconomizerType.NoEconomizer;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "PSZ";
        this.equipment_type = PSZEquipmentType.PSZAC_ElectricBaseboard;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(PSZ, _data);
            this.vintage = obj.vintage;
            this.economizer_type = obj.economizer_type;
            this.sensible_heat_recovery = obj.sensible_heat_recovery;
            this.latent_heat_recovery = obj.latent_heat_recovery;
            this.demand_controlled_ventilation = obj.demand_controlled_ventilation;
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
        }
    }


    static override fromJS(data: any): PSZ {
        data = typeof data === 'object' ? data : {};

        let result = new PSZ();
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
