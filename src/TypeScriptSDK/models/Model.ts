import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, IsArray, IsEnum, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { ModelProperties } from "./ModelProperties";
import { Room } from "./Room";
import { Face } from "./Face";
import { Shade } from "./Shade";
import { Aperture } from "./Aperture";
import { Door } from "./Door";
import { ShadeMesh } from "./ShadeMesh";
import { Units } from "./Units";
import { IDdBaseModel } from "./IDdBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Model extends IDdBaseModel {
    @IsInstance(ModelProperties)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ModelProperties;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Text string for the current version of the schema. */
    version?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Rooms in the model. */
    rooms?: Room [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Faces in the model that lack a parent Room. Note that orphaned Faces are not acceptable for Models that are to be exported for energy simulation. */
    orphaned_faces?: Face [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Shades in the model that lack a parent. */
    orphaned_shades?: Shade [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Apertures in the model that lack a parent Face. Note that orphaned Apertures are not acceptable for Models that are to be exported for energy simulation. */
    orphaned_apertures?: Aperture [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of Doors in the model that lack a parent Face. Note that orphaned Doors are not acceptable for Models that are to be exported for energy simulation. */
    orphaned_doors?: Door [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ShadeMesh in the model. */
    shade_meshes?: ShadeMesh [];
	
    @IsEnum(Units)
    @ValidateNested()
    @IsOptional()
    /** Text indicating the units in which the model geometry exists. This is used to scale the geometry to the correct units for simulation engines like EnergyPlus, which requires all geometry be in meters. */
    units?: Units;
	
    @IsNumber()
    @IsOptional()
    /** The maximum difference between x, y, and z values at which vertices are considered equivalent. This value should be in the Model units and it is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in bypassing all checks so it is recommended that this always be a positive number when such checks have not already been performed on a Model. The default of 0.01 is suitable for models in meters. */
    tolerance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The max angle difference in degrees that vertices are allowed to differ from one another in order to consider them colinear. This value is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in bypassing all checks so it is recommended that this always be a positive number when such checks have not already been performed on a given Model. */
    angle_tolerance?: number;
	

    constructor() {
        super();
        this.type = "Model";
        this.version = "1.58.1";
        this.units = Units.Meters;
        this.tolerance = 0.01;
        this.angle_tolerance = 1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.properties = _data["properties"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Model";
            this.version = _data["version"] !== undefined ? _data["version"] : "1.58.1";
            this.rooms = _data["rooms"];
            this.orphaned_faces = _data["orphaned_faces"];
            this.orphaned_shades = _data["orphaned_shades"];
            this.orphaned_apertures = _data["orphaned_apertures"];
            this.orphaned_doors = _data["orphaned_doors"];
            this.shade_meshes = _data["shade_meshes"];
            this.units = _data["units"] !== undefined ? _data["units"] : Units.Meters;
            this.tolerance = _data["tolerance"] !== undefined ? _data["tolerance"] : 0.01;
            this.angle_tolerance = _data["angle_tolerance"] !== undefined ? _data["angle_tolerance"] : 1;
        }
    }


    static override fromJS(data: any): Model {
        data = typeof data === 'object' ? data : {};

        let result = new Model();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

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
