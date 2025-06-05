import { IsString, IsOptional, Matches, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Autocalculate } from "./Autocalculate";

/** A Ladybug Location. */
export class Location extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^Location$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Location";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "city" })
    /** Name of the city as a string. */
    city: string = "-";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "latitude" })
    /** Location latitude between -90 and 90 (Default: 0). */
    latitude: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "longitude" })
    /** Location longitude between -180 (west) and 180 (east) (Default: 0). */
    longitude: number = 0;
	
    @IsOptional()
    @Expose({ name: "time_zone" })
    /** Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time. */
    timeZone: (Autocalculate | number) = new Autocalculate();
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "elevation" })
    /** A number for elevation of the location in meters. (Default: 0). */
    elevation: number = 0;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "station_id" })
    /** ID of the location if the location is representing a weather station. */
    stationId?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "source" })
    /** Source of data (e.g. TMY, TMY3). */
    source?: string;
	

    constructor() {
        super();
        this.type = "Location";
        this.city = "-";
        this.latitude = 0;
        this.longitude = 0;
        this.timeZone = new Autocalculate();
        this.elevation = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Location, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "Location";
            this.city = obj.city ?? "-";
            this.latitude = obj.latitude ?? 0;
            this.longitude = obj.longitude ?? 0;
            this.timeZone = obj.timeZone ?? new Autocalculate();
            this.elevation = obj.elevation ?? 0;
            this.stationId = obj.stationId;
            this.source = obj.source;
        }
    }


    static override fromJS(data: any): Location {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Location();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "Location";
        data["city"] = this.city ?? "-";
        data["latitude"] = this.latitude ?? 0;
        data["longitude"] = this.longitude ?? 0;
        data["time_zone"] = this.timeZone ?? new Autocalculate();
        data["elevation"] = this.elevation ?? 0;
        data["station_id"] = this.stationId;
        data["source"] = this.source;
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
