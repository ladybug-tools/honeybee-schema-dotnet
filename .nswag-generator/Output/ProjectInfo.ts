import { IsString, IsOptional, IsNumber, IsArray, ValidateNested, IsInstance, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Location } from "./Location";
import { ClimateZones } from "./ClimateZones";
import { BuildingTypes } from "./BuildingTypes";
import { EfficiencyStandards } from "./EfficiencyStandards";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Project information. */
export class ProjectInfo extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A number between -360 to 360 where positive values rotate the compass counterclockwise (towards the West) and negative values rotate the compass clockwise (towards the East). */
    north?: number;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of URLs to zip files that includes EPW, DDY and STAT files. You can find these URLs from the EPWMAP. The first URL will be used as the primary weather file. */
    weather_urls?: string [];
	
    @IsInstance(Location)
    @ValidateNested()
    @IsOptional()
    /** Project location. This value is usually generated from the information in the weather files. */
    location?: Location;
	
    @IsEnum(ClimateZones)
    @ValidateNested()
    @IsOptional()
    /** Project location climate zone. */
    ashrae_climate_zone?: ClimateZones;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of building types for the project. The first building type is considered the primary type for the project. */
    building_type?: BuildingTypes [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of building vintages (e.g. ASHRAE_2019, ASHRAE_2016). */
    vintage?: EfficiencyStandards [];
	

    constructor() {
        super();
        this.type = "ProjectInfo";
        this.north = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ProjectInfo";
            this.north = _data["north"] !== undefined ? _data["north"] : 0;
            this.weather_urls = _data["weather_urls"];
            this.location = _data["location"];
            this.ashrae_climate_zone = _data["ashrae_climate_zone"];
            this.building_type = _data["building_type"];
            this.vintage = _data["vintage"];
        }
    }


    static override fromJS(data: any): ProjectInfo {
        data = typeof data === 'object' ? data : {};

        let result = new ProjectInfo();
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
        data["north"] = this.north;
        data["weather_urls"] = this.weather_urls;
        data["location"] = this.location;
        data["ashrae_climate_zone"] = this.ashrae_climate_zone;
        data["building_type"] = this.building_type;
        data["vintage"] = this.vintage;
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
