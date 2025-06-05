import { IsInstance, ValidateNested, IsDefined, IsEnum, IsString, IsOptional, Matches, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "geometry" })
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsEnum(FaceType)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "face_type" })
    /** faceType */
    faceType!: FaceType;
	
    @IsDefined()
    @Expose({ name: "boundary_condition" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'Ground') return Ground.fromJS(item);
      else if (item?.type === 'Outdoors') return Outdoors.fromJS(item);
      else if (item?.type === 'Adiabatic') return Adiabatic.fromJS(item);
      else if (item?.type === 'Surface') return Surface.fromJS(item);
      else if (item?.type === 'OtherSideTemperature') return OtherSideTemperature.fromJS(item);
      else return item;
    })
    /** boundaryCondition */
    boundaryCondition!: (Ground | Outdoors | Adiabatic | Surface | OtherSideTemperature);
	
    @IsInstance(FacePropertiesAbridged)
    @Type(() => FacePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: FacePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Face$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Face";
	
    @IsArray()
    @IsInstance(Aperture, { each: true })
    @Type(() => Aperture)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "apertures" })
    /** Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. */
    apertures?: Aperture[];
	
    @IsArray()
    @IsInstance(Door, { each: true })
    @Type(() => Door)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "doors" })
    /** Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. */
    doors?: Door[];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "indoor_shades" })
    /** Shades assigned to the interior side of this object. */
    indoorShades?: Shade[];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "outdoor_shades" })
    /** Shades assigned to the exterior side of this object (eg. balcony, overhang). */
    outdoorShades?: Shade[];
	

    constructor() {
        super();
        this.type = "Face";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Face, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.geometry = obj.geometry;
            this.faceType = obj.faceType;
            this.boundaryCondition = obj.boundaryCondition;
            this.properties = obj.properties;
            this.type = obj.type ?? "Face";
            this.apertures = obj.apertures;
            this.doors = obj.doors;
            this.indoorShades = obj.indoorShades;
            this.outdoorShades = obj.outdoorShades;
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
        data["face_type"] = this.faceType;
        data["boundary_condition"] = this.boundaryCondition;
        data["properties"] = this.properties;
        data["type"] = this.type ?? "Face";
        data["apertures"] = this.apertures;
        data["doors"] = this.doors;
        data["indoor_shades"] = this.indoorShades;
        data["outdoor_shades"] = this.outdoorShades;
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
