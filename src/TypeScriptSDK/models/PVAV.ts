import { IsEnum, ValidateNested, IsOptional, IsNumber, IsBoolean, IsString, validate, ValidationError } from 'class-validator';
import { Vintages } from "./Vintages";
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { PVAVEquipmentType } from "./PVAVEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Packaged Variable Air Volume (PVAV) HVAC system (aka. System 5 or 6).

All rooms/zones are connected to a central air loop that is kept at a constant
central temperature of 12.8C (55F). The central temperature is maintained by a
cooling coil, which runs whenever the combination of return air and fresh outdoor
air is greater than 12.8C, as well as a heating coil, which runs whenever
the combination of return air and fresh outdoor air is less than 12.8C.

Each air terminal for the connected rooms/zones contains its own reheat coil,
which runs whenever the room is not in need of the cooling supplied by the 12.8C
central air.

The central cooling coil is always a two-speed direct expansion (DX) coil.
All heating coils are hot water coils except when Gas Coil equipment_type is
used (in which case the central coil is gas and all reheat is electric)
or when Parallel Fan-Powered (PFP) boxes equipment_type is used (in which case
coils are electric resistance). Hot water temperature is 82C (180F) for
boiler/district heating and 49C (120F) when ASHP is used.

PVAV systems are the traditional baseline system for commercial buildings
with than 4-5 stories or between 2,300 m2 and 14,000 m2 (25,000 ft2 and
150,000 ft2) of floor area. */
export class PVAV extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsEnum(AllAirEconomizerType)
    @ValidateNested()
    @IsOptional()
    /** Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration). */
    economizer_type?: AllAirEconomizerType;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latent_heat_recovery?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demand_controlled_ventilation?: boolean;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(PVAVEquipmentType)
    @ValidateNested()
    @IsOptional()
    /** Text for the specific type of system equipment from the VAVEquipmentType enumeration. */
    equipment_type?: PVAVEquipmentType;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.economizer_type = AllAirEconomizerType.NoEconomizer;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "PVAV";
        this.equipment_type = PVAVEquipmentType.PVAV_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.economizer_type = _data["economizer_type"] !== undefined ? _data["economizer_type"] : AllAirEconomizerType.NoEconomizer;
            this.sensible_heat_recovery = _data["sensible_heat_recovery"] !== undefined ? _data["sensible_heat_recovery"] : 0;
            this.latent_heat_recovery = _data["latent_heat_recovery"] !== undefined ? _data["latent_heat_recovery"] : 0;
            this.demand_controlled_ventilation = _data["demand_controlled_ventilation"] !== undefined ? _data["demand_controlled_ventilation"] : false;
            this.type = _data["type"] !== undefined ? _data["type"] : "PVAV";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : PVAVEquipmentType.PVAV_Boiler;
        }
    }


    static override fromJS(data: any): PVAV {
        data = typeof data === 'object' ? data : {};

        let result = new PVAV();
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
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
