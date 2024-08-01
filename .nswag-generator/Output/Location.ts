import { Autocalculate } from "./Autocalculate";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A Ladybug Location. */
export class Location extends _OpenAPIGenBaseModel {
    type!: string;
    /** Name of the city as a string. */
    city!: string;
    /** Location latitude between -90 and 90 (Default: 0). */
    latitude!: number;
    /** Location longitude between -180 (west) and 180 (east) (Default: 0). */
    longitude!: number;
    /** Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time. */
    time_zone!: Autocalculate | number;
    /** A number for elevation of the location in meters. (Default: 0). */
    elevation!: number;
    /** ID of the location if the location is representing a weather station. */
    station_id!: string;
    /** Source of data (e.g. TMY, TMY3). */
    source!: string;

    static override fromJS(data: any): Location {
        data = typeof data === 'object' ? data : {};


        let result = new Location();
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
        data["city"] = this.city;
        data["latitude"] = this.latitude;
        data["longitude"] = this.longitude;
        data["time_zone"] = this.time_zone;
        data["elevation"] = this.elevation;
        data["station_id"] = this.station_id;
        data["source"] = this.source;
        super.toJSON(data);
        return data;
    }
}
