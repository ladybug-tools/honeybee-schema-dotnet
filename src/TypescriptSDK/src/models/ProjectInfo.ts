import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsArray, IsInstance, ValidateNested, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BuildingTypes } from "./BuildingTypes";
import { ClimateZones } from "./ClimateZones";
import { EfficiencyStandards } from "./EfficiencyStandards";
import { Location } from "./Location";

/** Project information. */
export class ProjectInfo extends _OpenAPIGenBaseModel {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Matches(/^ProjectInfo$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ProjectInfo";
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(-360)
    @Max(360)
    @Expose({ name: "north" })
    /** A number between -360 to 360 where positive values rotate the compass counterclockwise (towards the West) and negative values rotate the compass clockwise (towards the East). */
    north: number = 0;
	
    @IsArray()
    @Type(() => String)
    @IsString({ each: true })
    @IsOptional()
    @Expose({ name: "weather_urls" })
    /** A list of URLs to zip files that includes EPW, DDY and STAT files. You can find these URLs from the EPWMAP. The first URL will be used as the primary weather file. */
    weatherUrls?: string[];
	
    @Type(() => Location)
    @IsInstance(Location)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "location" })
    /** Project location. This value is usually generated from the information in the weather files. */
    location?: Location;
	
    @Type(() => String)
    @IsEnum(ClimateZones)
    @IsOptional()
    @Expose({ name: "ashrae_climate_zone" })
    /** Project location climate zone. */
    ashraeClimateZone?: ClimateZones;
	
    @IsArray()
    @Type(() => String)
    @IsEnum(BuildingTypes, { each: true })
    @IsOptional()
    @Expose({ name: "building_type" })
    /** A list of building types for the project. The first building type is considered the primary type for the project. */
    buildingType?: BuildingTypes[];
	
    @IsArray()
    @Type(() => String)
    @IsEnum(EfficiencyStandards, { each: true })
    @IsOptional()
    @Expose({ name: "vintage" })
    /** A list of building vintages (e.g. ASHRAE_2019, ASHRAE_2016). */
    vintage?: EfficiencyStandards[];
	

    constructor() {
        super();
        this.type = "ProjectInfo";
        this.north = 0;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ProjectInfo, _data);
            this.type = obj.type ?? "ProjectInfo";
            this.north = obj.north ?? 0;
            this.weatherUrls = obj.weatherUrls;
            this.location = obj.location;
            this.ashraeClimateZone = obj.ashraeClimateZone;
            this.buildingType = obj.buildingType;
            this.vintage = obj.vintage;
        }
    }


    static override fromJS(data: any): ProjectInfo {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ProjectInfo();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ProjectInfo";
        data["north"] = this.north ?? 0;
        data["weather_urls"] = this.weatherUrls;
        data["location"] = this.location;
        data["ashrae_climate_zone"] = this.ashraeClimateZone;
        data["building_type"] = this.buildingType;
        data["vintage"] = this.vintage;
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
