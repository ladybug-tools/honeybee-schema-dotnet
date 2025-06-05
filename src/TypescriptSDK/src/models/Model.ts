import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsArray, IsEnum, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ModelProperties;
	
    @IsString()
    @IsOptional()
    @Matches(/^Model$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Model";
	
    @IsString()
    @IsOptional()
    @Matches(/([0-9]+)\.([0-9]+)\.([0-9]+)/)
    @Expose({ name: "version" })
    /** Text string for the current version of the schema. */
    version: string = "1.59.0";
	
    @IsArray()
    @IsInstance(Room, { each: true })
    @Type(() => Room)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "rooms" })
    /** A list of Rooms in the model. */
    rooms?: Room[];
	
    @IsArray()
    @IsInstance(Face, { each: true })
    @Type(() => Face)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "orphaned_faces" })
    /** A list of Faces in the model that lack a parent Room. Note that orphaned Faces are not acceptable for Models that are to be exported for energy simulation. */
    orphanedFaces?: Face[];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "orphaned_shades" })
    /** A list of Shades in the model that lack a parent. */
    orphanedShades?: Shade[];
	
    @IsArray()
    @IsInstance(Aperture, { each: true })
    @Type(() => Aperture)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "orphaned_apertures" })
    /** A list of Apertures in the model that lack a parent Face. Note that orphaned Apertures are not acceptable for Models that are to be exported for energy simulation. */
    orphanedApertures?: Aperture[];
	
    @IsArray()
    @IsInstance(Door, { each: true })
    @Type(() => Door)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "orphaned_doors" })
    /** A list of Doors in the model that lack a parent Face. Note that orphaned Doors are not acceptable for Models that are to be exported for energy simulation. */
    orphanedDoors?: Door[];
	
    @IsArray()
    @IsInstance(ShadeMesh, { each: true })
    @Type(() => ShadeMesh)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "shade_meshes" })
    /** A list of ShadeMesh in the model. */
    shadeMeshes?: ShadeMesh[];
	
    @IsEnum(Units)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "units" })
    /** Text indicating the units in which the model geometry exists. This is used to scale the geometry to the correct units for simulation engines like EnergyPlus, which requires all geometry be in meters. */
    units: Units = Units.Meters;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "tolerance" })
    /** The maximum difference between x, y, and z values at which vertices are considered equivalent. This value should be in the Model units and it is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in bypassing all checks so it is recommended that this always be a positive number when such checks have not already been performed on a Model. The default of 0.01 is suitable for models in meters. */
    tolerance: number = 0.01;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "angle_tolerance" })
    /** The max angle difference in degrees that vertices are allowed to differ from one another in order to consider them colinear. This value is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in bypassing all checks so it is recommended that this always be a positive number when such checks have not already been performed on a given Model. */
    angleTolerance: number = 1;
	

    constructor() {
        super();
        this.type = "Model";
        this.version = "1.59.0";
        this.units = Units.Meters;
        this.tolerance = 0.01;
        this.angleTolerance = 1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Model, _data, { enableImplicitConversion: true });
            this.properties = obj.properties;
            this.type = obj.type;
            this.version = obj.version;
            this.rooms = obj.rooms;
            this.orphanedFaces = obj.orphanedFaces;
            this.orphanedShades = obj.orphanedShades;
            this.orphanedApertures = obj.orphanedApertures;
            this.orphanedDoors = obj.orphanedDoors;
            this.shadeMeshes = obj.shadeMeshes;
            this.units = obj.units;
            this.tolerance = obj.tolerance;
            this.angleTolerance = obj.angleTolerance;
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
        data["orphaned_faces"] = this.orphanedFaces;
        data["orphaned_shades"] = this.orphanedShades;
        data["orphaned_apertures"] = this.orphanedApertures;
        data["orphaned_doors"] = this.orphanedDoors;
        data["shade_meshes"] = this.shadeMeshes;
        data["units"] = this.units;
        data["tolerance"] = this.tolerance;
        data["angle_tolerance"] = this.angleTolerance;
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
