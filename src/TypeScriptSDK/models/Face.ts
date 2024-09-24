import { IsInstance, ValidateNested, IsDefined, IsEnum, IsString, IsOptional, Matches, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { Adiabatic } from "./Adiabatic";
import { Aperture } from "./Aperture";
import { Door } from "./Door";
import { Face3D } from "./Face3D";
import { FacePropertiesAbridged } from "./FacePropertiesAbridged";
import { FaceType } from "./FaceType";
import { Ground } from "./Ground";
import { IDdBaseModel } from "./IDdBaseModel";
import { OtherSideTemperature } from "./OtherSideTemperature";
import { Outdoors } from "./Outdoors";
import { Shade } from "./Shade";
import { Surface } from "./Surface";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Face extends IDdBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsEnum(FaceType)
    @Type(() => String)
    @IsDefined()
    face_type!: FaceType;
	
    @IsDefined()
    @Transform(({ value }) => {
      const item = value;
      if (item.type === 'Ground') return Ground.fromJS(item);
      else if (item.type === 'Outdoors') return Outdoors.fromJS(item);
      else if (item.type === 'Adiabatic') return Adiabatic.fromJS(item);
      else if (item.type === 'Surface') return Surface.fromJS(item);
      else if (item.type === 'OtherSideTemperature') return OtherSideTemperature.fromJS(item);
      else return item;
    })
    boundary_condition!: (Ground | Outdoors | Adiabatic | Surface | OtherSideTemperature);
	
    @IsInstance(FacePropertiesAbridged)
    @Type(() => FacePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: FacePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Face$/)
    type?: string;
	
    @IsArray()
    @IsInstance(Aperture, { each: true })
    @Type(() => Aperture)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. */
    apertures?: Aperture [];
	
    @IsArray()
    @IsInstance(Door, { each: true })
    @Type(() => Door)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. */
    doors?: Door [];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object. */
    indoor_shades?: Shade [];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
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
            const obj = plainToClass(Face, _data, { enableImplicitConversion: true });
            this.geometry = obj.geometry;
            this.face_type = obj.face_type;
            this.boundary_condition = obj.boundary_condition;
            this.properties = obj.properties;
            this.type = obj.type;
            this.apertures = obj.apertures;
            this.doors = obj.doors;
            this.indoor_shades = obj.indoor_shades;
            this.outdoor_shades = obj.outdoor_shades;
        }
    }


    static override fromJS(data: any): Face {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Face();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["face_type"] = this.face_type;
        data["boundary_condition"] = this.boundary_condition;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["apertures"] = this.apertures;
        data["doors"] = this.doors;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
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

