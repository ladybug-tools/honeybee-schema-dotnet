import { IsString, IsOptional, Matches, MinLength, MaxLength, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IsNestedStringArray } from "./../helpers/class-validator";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** Hidden base class for all Radiance Assets. */
export class _RadianceAsset extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "room_identifier" })
    /** Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model. */
    roomIdentifier?: string;
	
    @IsArray()
    @IsNestedStringArray()
    @IsOptional()
    @Expose({ name: "light_path" })
    /** Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation. */
    lightPath?: string[][];
	
    @IsString()
    @IsOptional()
    @Matches(/^_RadianceAsset$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_RadianceAsset";
	

    constructor() {
        super();
        this.type = "_RadianceAsset";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_RadianceAsset, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.roomIdentifier = obj.roomIdentifier;
            this.lightPath = obj.lightPath;
            this.type = obj.type ?? "_RadianceAsset";
        }
    }


    static override fromJS(data: any): _RadianceAsset {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _RadianceAsset();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["room_identifier"] = this.roomIdentifier;
        data["light_path"] = this.lightPath;
        data["type"] = this.type ?? "_RadianceAsset";
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
