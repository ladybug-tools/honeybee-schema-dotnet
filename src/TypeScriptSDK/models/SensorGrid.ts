import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, IsInstance, validate, ValidationError as TsValidationError } from 'class-validator';
import { Face3D } from "./Face3D";
import { Mesh3D } from "./Mesh3D";
import { RadianceAsset } from "./RadianceAsset";
import { Sensor } from "./Sensor";

/** A grid of sensors. */
export class SensorGrid extends RadianceAsset {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of sensors that belong to the grid. */
    sensors!: Sensor [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(Mesh3D)
    @ValidateNested()
    @IsOptional()
    /** An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D. */
    mesh?: Mesh3D;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized. */
    base_geometry?: Face3D [];
	
    @IsString()
    @IsOptional()
    /** An optional string to note the sensor grid group '             'to which the sensor is a part of. Grids sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None). */
    group_identifier?: string;
	

    constructor() {
        super();
        this.type = "SensorGrid";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.sensors = _data["sensors"];
            this.type = _data["type"] !== undefined ? _data["type"] : "SensorGrid";
            this.mesh = _data["mesh"];
            this.base_geometry = _data["base_geometry"];
            this.group_identifier = _data["group_identifier"];
        }
    }


    static override fromJS(data: any): SensorGrid {
        data = typeof data === 'object' ? data : {};

        let result = new SensorGrid();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["sensors"] = this.sensors;
        data["type"] = this.type;
        data["mesh"] = this.mesh;
        data["base_geometry"] = this.base_geometry;
        data["group_identifier"] = this.group_identifier;
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
