﻿import { IsEnum, ValidateNested, IsOptional, IsNumber, IsBoolean, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { PSZEquipmentType } from "./PSZEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Single-Zone (PSZ) HVAC system (aka. System 3 or 4).

Each room/zone receives its own air loop with its own single-speed direct expansion
(DX) cooling coil, which will condition the supply air to a value in between
12.8C (55F) and 50C (122F) depending on the heating/cooling needs of the room/zone.
As long as a Baseboard equipment_type is NOT selected, heating will be supplied
by a heating coil in the air loop. Otherwise, heating is accomplished with
baseboards and the air loop only supplies cooling and ventilation air.
Fans are constant volume.

PSZ systems are the traditional baseline system for commercial buildings
with less than 4 stories or less than 2,300 m2 (25,000 ft2) of floor area.
They are also the default for all retail with less than 3 stories and all public
assembly spaces. */
export class PSZ extends IDdEnergyBaseModel {
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
	
    @IsEnum(PSZEquipmentType)
    @ValidateNested()
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
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.economizer_type = _data["economizer_type"] !== undefined ? _data["economizer_type"] : AllAirEconomizerType.NoEconomizer;
            this.sensible_heat_recovery = _data["sensible_heat_recovery"] !== undefined ? _data["sensible_heat_recovery"] : 0;
            this.latent_heat_recovery = _data["latent_heat_recovery"] !== undefined ? _data["latent_heat_recovery"] : 0;
            this.demand_controlled_ventilation = _data["demand_controlled_ventilation"] !== undefined ? _data["demand_controlled_ventilation"] : false;
            this.type = _data["type"] !== undefined ? _data["type"] : "PSZ";
            this.equipment_type = _data["equipment_type"] !== undefined ? _data["equipment_type"] : PSZEquipmentType.PSZAC_ElectricBaseboard;
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
