import { IsString, IsOptional, Matches, MinLength, MaxLength, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IsNestedStringArray } from "./../helpers/class-validator";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** Hidden base class for all Radiance Assets. */
export class _RadianceAsset extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @MaxLength(100)
    /** Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model. */
    room_identifier?: string;
	
    @IsArray()
    @IsNestedStringArray()
    @IsOptional()
    /** Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[""SouthWindow1""], [""static_apertures"", ""NorthWindow2""]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation. */
    light_path?: string [] [];
	
    @IsString()
    @IsOptional()
    @Matches(/^_RadianceAsset$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "_RadianceAsset";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_RadianceAsset, _data);
            this.room_identifier = obj.room_identifier;
            this.light_path = obj.light_path;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _RadianceAsset {
        data = typeof data === 'object' ? data : {};

        let result = new _RadianceAsset();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["room_identifier"] = this.room_identifier;
        data["light_path"] = this.light_path;
        data["type"] = this.type;
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

