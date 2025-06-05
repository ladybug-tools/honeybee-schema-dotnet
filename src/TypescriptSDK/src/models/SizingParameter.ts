import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, IsNumber, IsEnum, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ClimateZones } from "./ClimateZones";
import { DesignDay } from "./DesignDay";
import { EfficiencyStandards } from "./EfficiencyStandards";

/** Used to specify heating and cooling sizing criteria and safety factors. */
export class SizingParameter extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SizingParameter$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "SizingParameter";
	
    @IsArray()
    @IsInstance(DesignDay, { each: true })
    @Type(() => DesignDay)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "design_days" })
    /** A list of DesignDays that represent the criteria for which the HVAC systems will be sized. */
    designDays?: DesignDay[];
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "heating_factor" })
    /** A number that will be multiplied by the peak heating load for each zone in order to size the heating system. */
    heatingFactor: number = 1.25;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "cooling_factor" })
    /** A number that will be multiplied by the peak cooling load for each zone in order to size the heating system. */
    coolingFactor: number = 1.15;
	
    @IsEnum(EfficiencyStandards)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "efficiency_standard" })
    /** Text to specify the efficiency standard, which will automatically set the efficiencies of all HVAC equipment when provided. Note that providing a standard here will cause the OpenStudio translation process to perform an additional sizing calculation with EnergyPlus, which is needed since the default efficiencies of equipment vary depending on their size. THIS WILL SIGNIFICANTLY INCREASE TRANSLATION TIME TO OPENSTUDIO. However, it is often worthwhile when the goal is to match the HVAC specification with a particular standard. */
    efficiencyStandard?: EfficiencyStandards;
	
    @IsEnum(ClimateZones)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "climate_zone" })
    /** Text indicating the ASHRAE climate zone to be used with the efficiency_standard. When unspecified, the climate zone will be inferred from the design days on this sizing parameter object. */
    climateZone?: ClimateZones;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "building_type" })
    /** Text for the building type to be used in the efficiency_standard. If the type is not recognized or is None, it will be assumed that the building is a generic NonResidential. The following have specified systems per the standard:  Residential, NonResidential, MidriseApartment, HighriseApartment, LargeOffice, MediumOffice, SmallOffice, Retail, StripMall, PrimarySchool, SecondarySchool, SmallHotel, LargeHotel, Hospital, Outpatient, Warehouse, SuperMarket, FullServiceRestaurant, QuickServiceRestaurant, Laboratory, Courthouse. */
    buildingType?: string;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "bypass_efficiency_sizing" })
    /** A boolean to indicate whether the efficiency standard should trigger an sizing run that sets the efficiencies of all HVAC equipment in the Model (False) or the standard should only be written into the OSM and the sizing run should be bypassed (True). Bypassing the sizing run is useful when you only want to check that the overall HVAC system architecture is correct and you do not want to wait the extra time that it takes to run the sizing calculation. */
    bypassEfficiencySizing: boolean = false;
	

    constructor() {
        super();
        this.type = "SizingParameter";
        this.heatingFactor = 1.25;
        this.coolingFactor = 1.15;
        this.bypassEfficiencySizing = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SizingParameter, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "SizingParameter";
            this.designDays = obj.designDays;
            this.heatingFactor = obj.heatingFactor ?? 1.25;
            this.coolingFactor = obj.coolingFactor ?? 1.15;
            this.efficiencyStandard = obj.efficiencyStandard;
            this.climateZone = obj.climateZone;
            this.buildingType = obj.buildingType;
            this.bypassEfficiencySizing = obj.bypassEfficiencySizing ?? false;
        }
    }


    static override fromJS(data: any): SizingParameter {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SizingParameter();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "SizingParameter";
        data["design_days"] = this.designDays;
        data["heating_factor"] = this.heatingFactor ?? 1.25;
        data["cooling_factor"] = this.coolingFactor ?? 1.15;
        data["efficiency_standard"] = this.efficiencyStandard;
        data["climate_zone"] = this.climateZone;
        data["building_type"] = this.buildingType;
        data["bypass_efficiency_sizing"] = this.bypassEfficiencySizing ?? false;
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
