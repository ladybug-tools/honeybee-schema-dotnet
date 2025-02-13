import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsArray, IsInstance, ValidateNested, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BuildingTypes } from "./BuildingTypes";
import { ClimateZones } from "./ClimateZones";
import { EfficiencyStandards } from "./EfficiencyStandards";
import { Location } from "./Location";

/** Project information. */
export class ProjectInfo extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ProjectInfo$/)
    /** Type */
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(-360)
    @Max(360)
    /** A number between -360 to 360 where positive values rotate the compass counterclockwise (towards the West) and negative values rotate the compass clockwise (towards the East). */
    north?: number;
	
    @IsArray()
    @IsString({ each: true })
    @IsOptional()
    /** A list of URLs to zip files that includes EPW, DDY and STAT files. You can find these URLs from the EPWMAP. The first URL will be used as the primary weather file. */
    weather_urls?: string [];
	
    @IsInstance(Location)
    @Type(() => Location)
    @ValidateNested()
    @IsOptional()
    /** Project location. This value is usually generated from the information in the weather files. */
    location?: Location;
	
    @IsEnum(ClimateZones)
    @Type(() => String)
    @IsOptional()
    /** Project location climate zone. */
    ashrae_climate_zone?: ClimateZones;
	
    @IsArray()
    @IsEnum(BuildingTypes, { each: true })
    @Type(() => String)
    @IsOptional()
    /** A list of building types for the project. The first building type is considered the primary type for the project. */
    building_type?: BuildingTypes [];
	
    @IsArray()
    @IsEnum(EfficiencyStandards, { each: true })
    @Type(() => String)
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
            const obj = plainToClass(ProjectInfo, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.north = obj.north;
            this.weather_urls = obj.weather_urls;
            this.location = obj.location;
            this.ashrae_climate_zone = obj.ashrae_climate_zone;
            this.building_type = obj.building_type;
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
        data["type"] = this.type;
        data["north"] = this.north;
        data["weather_urls"] = this.weather_urls;
        data["location"] = this.location;
        data["ashrae_climate_zone"] = this.ashrae_climate_zone;
        data["building_type"] = this.building_type;
        data["vintage"] = this.vintage;
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

