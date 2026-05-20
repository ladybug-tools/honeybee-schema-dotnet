import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Equals, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IsNestedStringArray } from "./../helpers/class-validator";
import { Face3D } from "./Face3D";
import { Mesh3D } from "./Mesh3D";
import { Sensor } from "./Sensor";

/** A grid of sensors. */
export class SensorGrid {
    @IsArray()
    @Type(() => Sensor)
    @IsInstance(Sensor, { each: true })
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "sensors" })
    /** A list of sensors that belong to the grid. */
    sensors!: Sensor[];
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("SensorGrid")
    @Expose({ name: "type" })
    /** type */
    type: string = "SensorGrid";
	
    @Type(() => Mesh3D)
    @IsInstance(Mesh3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "mesh" })
    /** An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D. */
    mesh?: Mesh3D;
	
    @IsArray()
    @Type(() => Face3D)
    @IsInstance(Face3D, { each: true })
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "base_geometry" })
    /** An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized. */
    baseGeometry?: Face3D[];
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "group_identifier" })
    /** An optional string to note the sensor grid group '             'to which the sensor is a part of. Grids sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None). */
    groupIdentifier?: string;
	
    @Type(() => String)
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
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Matches(/^[.A-Za-z0-9_-]+$/)
    @MinLength(1)
    @Expose({ name: "identifier" })
    /** Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. */
    identifier!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	

    constructor() {
        this.type = "SensorGrid";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(SensorGrid, _data);
            this.sensors = obj.sensors;
            this.type = obj.type ?? "SensorGrid";
            this.mesh = obj.mesh;
            this.baseGeometry = obj.baseGeometry;
            this.groupIdentifier = obj.groupIdentifier;
            this.roomIdentifier = obj.roomIdentifier;
            this.lightPath = obj.lightPath;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): SensorGrid {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SensorGrid();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["sensors"] = this.sensors;
        data["type"] = this.type ?? "SensorGrid";
        data["mesh"] = this.mesh;
        data["base_geometry"] = this.baseGeometry;
        data["group_identifier"] = this.groupIdentifier;
        data["room_identifier"] = this.roomIdentifier;
        data["light_path"] = this.lightPath;
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
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
