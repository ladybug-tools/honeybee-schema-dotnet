import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsArray, IsEnum, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { Aperture } from "./Aperture";
import { Door } from "./Door";
import { Face } from "./Face";
import { IDdBaseModel } from "./IDdBaseModel";
import { ModelProperties } from "./ModelProperties";
import { Room } from "./Room";
import { Shade } from "./Shade";
import { ShadeMesh } from "./ShadeMesh";
import { Units } from "./Units";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Model extends IDdBaseModel {
    @IsInstance(ModelProperties)
    @Type(() => ModelProperties)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ModelProperties;
	
    @IsString()
    @IsOptional()
    @Matches(/^Model$/)
    /** Type */
    type?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/([0-9]+)\.([0-9]+)\.([0-9]+)/)
    /** Text string for the current version of the schema. */
    version?: string;
	
    @IsArray()
    @IsInstance(Room, { each: true })
    @Type(() => Room)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Rooms in the model. */
    rooms?: Room[];
	
    @IsArray()
    @IsInstance(Face, { each: true })
    @Type(() => Face)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Faces in the model that lack a parent Room. Note that orphaned Faces are not acceptable for Models that are to be exported for energy simulation. */
    orphaned_faces?: Face[];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Shades in the model that lack a parent. */
    orphaned_shades?: Shade[];
	
    @IsArray()
    @IsInstance(Aperture, { each: true })
    @Type(() => Aperture)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Apertures in the model that lack a parent Face. Note that orphaned Apertures are not acceptable for Models that are to be exported for energy simulation. */
    orphaned_apertures?: Aperture[];
	
    @IsArray()
    @IsInstance(Door, { each: true })
    @Type(() => Door)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Doors in the model that lack a parent Face. Note that orphaned Doors are not acceptable for Models that are to be exported for energy simulation. */
    orphaned_doors?: Door[];
	
    @IsArray()
    @IsInstance(ShadeMesh, { each: true })
    @Type(() => ShadeMesh)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ShadeMesh in the model. */
    shade_meshes?: ShadeMesh[];
	
    @IsEnum(Units)
    @Type(() => String)
    @IsOptional()
    /** Text indicating the units in which the model geometry exists. This is used to scale the geometry to the correct units for simulation engines like EnergyPlus, which requires all geometry be in meters. */
    units?: Units;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The maximum difference between x, y, and z values at which vertices are considered equivalent. This value should be in the Model units and it is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in bypassing all checks so it is recommended that this always be a positive number when such checks have not already been performed on a Model. The default of 0.01 is suitable for models in meters. */
    tolerance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The max angle difference in degrees that vertices are allowed to differ from one another in order to consider them colinear. This value is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in bypassing all checks so it is recommended that this always be a positive number when such checks have not already been performed on a given Model. */
    angle_tolerance?: number;
	

    constructor() {
        super();
        this.type = "Model";
        this.version = "1.59.0";
        this.units = Units.Meters;
        this.tolerance = 0.01;
        this.angle_tolerance = 1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Model, _data, { enableImplicitConversion: true });
            this.properties = obj.properties;
            this.type = obj.type;
            this.version = obj.version;
            this.rooms = obj.rooms;
            this.orphaned_faces = obj.orphaned_faces;
            this.orphaned_shades = obj.orphaned_shades;
            this.orphaned_apertures = obj.orphaned_apertures;
            this.orphaned_doors = obj.orphaned_doors;
            this.shade_meshes = obj.shade_meshes;
            this.units = obj.units;
            this.tolerance = obj.tolerance;
            this.angle_tolerance = obj.angle_tolerance;
        }
    }


    static override fromJS(data: any): Model {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Model();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["version"] = this.version;
        data["rooms"] = this.rooms;
        data["orphaned_faces"] = this.orphaned_faces;
        data["orphaned_shades"] = this.orphaned_shades;
        data["orphaned_apertures"] = this.orphaned_apertures;
        data["orphaned_doors"] = this.orphaned_doors;
        data["shade_meshes"] = this.shade_meshes;
        data["units"] = this.units;
        data["tolerance"] = this.tolerance;
        data["angle_tolerance"] = this.angle_tolerance;
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

