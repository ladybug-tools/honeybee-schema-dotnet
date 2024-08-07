import { IsInstance, ValidateNested, IsDefined, IsEnum, IsString, IsOptional, IsArray, validate, ValidationError } from 'class-validator';
import { Face3D } from "./Face3D";
import { FaceType } from "./FaceType";
import { Ground } from "./Ground";
import { Outdoors } from "./Outdoors";
import { Adiabatic } from "./Adiabatic";
import { Surface } from "./Surface";
import { OtherSideTemperature } from "./OtherSideTemperature";
import { FacePropertiesAbridged } from "./FacePropertiesAbridged";
import { Aperture } from "./Aperture";
import { Door } from "./Door";
import { Shade } from "./Shade";
import { IDdBaseModel } from "./IDdBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Face extends IDdBaseModel {
    @IsInstance(Face3D)
    @ValidateNested()
    @IsDefined()
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsEnum(FaceType)
    @ValidateNested()
    @IsDefined()
    face_type!: FaceType;
	
    @IsDefined()
    boundary_condition!: (Ground | Outdoors | Adiabatic | Surface | OtherSideTemperature);
	
    @IsInstance(FacePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: FacePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. */
    apertures?: Aperture [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. */
    doors?: Door [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object. */
    indoor_shades?: Shade [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the exterior side of this object (eg. balcony, overhang). */
    outdoor_shades?: Shade [];
	

    constructor() {
        super();
        this.type = "Face";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.geometry = _data["geometry"];
            this.face_type = _data["face_type"];
            this.boundary_condition = _data["boundary_condition"];
            this.properties = _data["properties"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Face";
            this.apertures = _data["apertures"];
            this.doors = _data["doors"];
            this.indoor_shades = _data["indoor_shades"];
            this.outdoor_shades = _data["outdoor_shades"];
        }
    }


    static override fromJS(data: any): Face {
        data = typeof data === 'object' ? data : {};

        let result = new Face();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["geometry"] = this.geometry;
        data["face_type"] = this.face_type;
        data["boundary_condition"] = this.boundary_condition;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["apertures"] = this.apertures;
        data["doors"] = this.doors;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
