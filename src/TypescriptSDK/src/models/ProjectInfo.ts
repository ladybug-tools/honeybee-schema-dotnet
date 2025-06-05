import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsArray, IsInstance, ValidateNested, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "ProjectInfo";
	
    @IsNumber()
    @IsOptional()
    @Min(-360)
    @Max(360)
    @Expose({ name: "north" })
    /** A number between -360 to 360 where positive values rotate the compass counterclockwise (towards the West) and negative values rotate the compass clockwise (towards the East). */
    north: number = 0;
	
    @IsArray()
    @IsString({ each: true })
    @IsOptional()
    @Expose({ name: "weather_urls" })
    /** A list of URLs to zip files that includes EPW, DDY and STAT files. You can find these URLs from the EPWMAP. The first URL will be used as the primary weather file. */
    weatherUrls?: string[];
	
    @IsInstance(Location)
    @Type(() => Location)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "location" })
    /** Project location. This value is usually generated from the information in the weather files. */
    location?: Location;
	
    @IsEnum(ClimateZones)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "ashrae_climate_zone" })
    /** Project location climate zone. */
    ashraeClimateZone?: ClimateZones;
	
    @IsArray()
    @IsEnum(BuildingTypes, { each: true })
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "building_type" })
    /** A list of building types for the project. The first building type is considered the primary type for the project. */
    buildingType?: BuildingTypes[];
	
    @IsArray()
    @IsEnum(EfficiencyStandards, { each: true })
    @Type(() => String)
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
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ProjectInfo, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
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
