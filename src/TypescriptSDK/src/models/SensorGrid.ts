import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _RadianceAsset } from "./_RadianceAsset";
import { Face3D } from "./Face3D";
import { Mesh3D } from "./Mesh3D";
import { Sensor } from "./Sensor";

/** A grid of sensors. */
export class SensorGrid extends _RadianceAsset {
    @IsArray()
    @IsInstance(Sensor, { each: true })
    @Type(() => Sensor)
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "sensors" })
    /** A list of sensors that belong to the grid. */
    sensors!: Sensor[];
	
    @IsString()
    @IsOptional()
    @Matches(/^SensorGrid$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "SensorGrid";
	
    @IsInstance(Mesh3D)
    @Type(() => Mesh3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "mesh" })
    /** An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D. */
    mesh?: Mesh3D;
	
    @IsArray()
    @IsInstance(Face3D, { each: true })
    @Type(() => Face3D)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "base_geometry" })
    /** An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized. */
    baseGeometry?: Face3D[];
	
    @IsString()
    @IsOptional()
    @Expose({ name: "group_identifier" })
    /** An optional string to note the sensor grid group '             'to which the sensor is a part of. Grids sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None). */
    groupIdentifier?: string;
	

    constructor() {
        super();
        this.type = "SensorGrid";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SensorGrid, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.sensors = obj.sensors;
            this.type = obj.type ?? "SensorGrid";
            this.mesh = obj.mesh;
            this.baseGeometry = obj.baseGeometry;
            this.groupIdentifier = obj.groupIdentifier;
        }
    }


    static override fromJS(data: any): SensorGrid {
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

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["sensors"] = this.sensors;
        data["type"] = this.type ?? "SensorGrid";
        data["mesh"] = this.mesh;
        data["base_geometry"] = this.baseGeometry;
        data["group_identifier"] = this.groupIdentifier;
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
