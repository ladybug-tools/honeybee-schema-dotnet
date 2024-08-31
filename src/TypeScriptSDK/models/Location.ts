import { IsString, IsOptional, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Autocalculate } from "./Autocalculate";

/** A Ladybug Location. */
export class Location extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Name of the city as a string. */
    city?: string;
	
    @IsNumber()
    @IsOptional()
    /** Location latitude between -90 and 90 (Default: 0). */
    latitude?: number;
	
    @IsNumber()
    @IsOptional()
    /** Location longitude between -180 (west) and 180 (east) (Default: 0). */
    longitude?: number;
	
    @IsOptional()
    /** Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time. */
    time_zone?: (Autocalculate | number);
	
    @IsNumber()
    @IsOptional()
    /** A number for elevation of the location in meters. (Default: 0). */
    elevation?: number;
	
    @IsString()
    @IsOptional()
    /** ID of the location if the location is representing a weather station. */
    station_id?: string;
	
    @IsString()
    @IsOptional()
    /** Source of data (e.g. TMY, TMY3). */
    source?: string;
	

    constructor() {
        super();
        this.type = "Location";
        this.city = "-";
        this.latitude = 0;
        this.longitude = 0;
        this.time_zone = new Autocalculate();
        this.elevation = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Location, _data);
            this.type = obj.type;
            this.city = obj.city;
            this.latitude = obj.latitude;
            this.longitude = obj.longitude;
            this.time_zone = obj.time_zone;
            this.elevation = obj.elevation;
            this.station_id = obj.station_id;
            this.source = obj.source;
        }
    }


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

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
