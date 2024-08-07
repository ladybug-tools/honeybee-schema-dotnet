import { IsString, IsOptional, IsArray, ValidateNested, IsNumber, IsEnum, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { DesignDay } from "./DesignDay";
import { EfficiencyStandards } from "./EfficiencyStandards";
import { ClimateZones } from "./ClimateZones";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify heating and cooling sizing criteria and safety factors. */
export class SizingParameter extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of DesignDays that represent the criteria for which the HVAC systems will be sized. */
    design_days?: DesignDay [];
	
    @IsNumber()
    @IsOptional()
    /** A number that will be multiplied by the peak heating load for each zone in order to size the heating system. */
    heating_factor?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number that will be multiplied by the peak cooling load for each zone in order to size the heating system. */
    cooling_factor?: number;
	
    @IsEnum(EfficiencyStandards)
    @ValidateNested()
    @IsOptional()
    /** Text to specify the efficiency standard, which will automatically set the efficiencies of all HVAC equipment when provided. Note that providing a standard here will cause the OpenStudio translation process to perform an additional sizing calculation with EnergyPlus, which is needed since the default efficiencies of equipment vary depending on their size. THIS WILL SIGNIFICANTLY INCREASE TRANSLATION TIME TO OPENSTUDIO. However, it is often worthwhile when the goal is to match the HVAC specification with a particular standard. */
    efficiency_standard?: EfficiencyStandards;
	
    @IsEnum(ClimateZones)
    @ValidateNested()
    @IsOptional()
    /** Text indicating the ASHRAE climate zone to be used with the efficiency_standard. When unspecified, the climate zone will be inferred from the design days on this sizing parameter object. */
    climate_zone?: ClimateZones;
	
    @IsString()
    @IsOptional()
    /** Text for the building type to be used in the efficiency_standard. If the type is not recognized or is None, it will be assumed that the building is a generic NonResidential. The following have specified systems per the standard:  Residential, NonResidential, MidriseApartment, HighriseApartment, LargeOffice, MediumOffice, SmallOffice, Retail, StripMall, PrimarySchool, SecondarySchool, SmallHotel, LargeHotel, Hospital, Outpatient, Warehouse, SuperMarket, FullServiceRestaurant, QuickServiceRestaurant, Laboratory, Courthouse. */
    building_type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to indicate whether the efficiency standard should trigger an sizing run that sets the efficiencies of all HVAC equipment in the Model (False) or the standard should only be written into the OSM and the sizing run should be bypassed (True). Bypassing the sizing run is useful when you only want to check that the overall HVAC system architecture is correct and you do not want to wait the extra time that it takes to run the sizing calculation. */
    bypass_efficiency_sizing?: boolean;
	

    constructor() {
        super();
        this.type = "SizingParameter";
        this.heating_factor = 1.25;
        this.cooling_factor = 1.15;
        this.bypass_efficiency_sizing = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "SizingParameter";
            this.design_days = _data["design_days"];
            this.heating_factor = _data["heating_factor"] !== undefined ? _data["heating_factor"] : 1.25;
            this.cooling_factor = _data["cooling_factor"] !== undefined ? _data["cooling_factor"] : 1.15;
            this.efficiency_standard = _data["efficiency_standard"];
            this.climate_zone = _data["climate_zone"];
            this.building_type = _data["building_type"];
            this.bypass_efficiency_sizing = _data["bypass_efficiency_sizing"] !== undefined ? _data["bypass_efficiency_sizing"] : false;
        }
    }


    static override fromJS(data: any): SizingParameter {
        data = typeof data === 'object' ? data : {};

        let result = new SizingParameter();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["design_days"] = this.design_days;
        data["heating_factor"] = this.heating_factor;
        data["cooling_factor"] = this.cooling_factor;
        data["efficiency_standard"] = this.efficiency_standard;
        data["climate_zone"] = this.climate_zone;
        data["building_type"] = this.building_type;
        data["bypass_efficiency_sizing"] = this.bypass_efficiency_sizing;
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
