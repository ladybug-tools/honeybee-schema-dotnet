import { Location } from "./Location";
import { ClimateZones } from "./ClimateZones";
import { BuildingTypes } from "./BuildingTypes";
import { EfficiencyStandards } from "./EfficiencyStandards";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Project information. */
export class ProjectInfo extends _OpenAPIGenBaseModel {
    type!: string;
    /** A number between -360 to 360 where positive values rotate the compass counterclockwise (towards the West) and negative values rotate the compass clockwise (towards the East). */
    north!: number;
    /** A list of URLs to zip files that includes EPW, DDY and STAT files. You can find these URLs from the EPWMAP. The first URL will be used as the primary weather file. */
    weather_urls!: string [];
    /** Project location. This value is usually generated from the information in the weather files. */
    location!: Location;
    /** Project location climate zone. */
    ashrae_climate_zone!: ClimateZones;
    /** A list of building types for the project. The first building type is considered the primary type for the project. */
    building_type!: BuildingTypes [];
    /** A list of building vintages (e.g. ASHRAE_2019, ASHRAE_2016). */
    vintage!: EfficiencyStandards [];

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
}
