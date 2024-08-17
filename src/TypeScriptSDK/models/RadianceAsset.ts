import { IsString, IsOptional, IsArray, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";
import { SensorGrid } from "./SensorGrid";
import { View } from "./View";

/** Hidden base class for all Radiance Assets. */
export class RadianceAsset extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    /** Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model. */
    room_identifier?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation. */
    light_path?: string [] [];
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "_RadianceAsset";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.room_identifier = _data["room_identifier"];
            this.light_path = _data["light_path"];
            this.type = _data["type"] !== undefined ? _data["type"] : "_RadianceAsset";
        }
    }


    static override fromJS(data: any): RadianceAsset {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "View") {
            let result = new View();
            result.init(data);
            return result;
        }
        if (data["type"] === "SensorGrid") {
            let result = new SensorGrid();
            result.init(data);
            return result;
        }
        let result = new RadianceAsset();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["room_identifier"] = this.room_identifier;
        data["light_path"] = this.light_path;
        data["type"] = this.type;
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
