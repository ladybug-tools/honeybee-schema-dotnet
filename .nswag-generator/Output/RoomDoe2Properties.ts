import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { Autocalculate } from "./Autocalculate";
import { Face3D } from "./Face3D";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class RoomDoe2Properties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsOptional()
    /** A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP. */
    assigned_flow?: Autocalculate | number;
	
    @IsOptional()
    /** A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP. */
    flow_per_area?: Autocalculate | number;
	
    @IsOptional()
    /** A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP. */
    min_flow_ratio?: Autocalculate | number;
	
    @IsOptional()
    /** A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP. */
    min_flow_per_area?: Autocalculate | number;
	
    @IsOptional()
    /** A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP. */
    hmax_flow_ratio?: Autocalculate | number;
	
    @IsInstance(Face3D)
    @ValidateNested()
    @IsOptional()
    /** An optional horizontal Face3D object, which will be used to set the SPACE polygon during export to INP. If None, the SPACE polygon is auto-calculated from the 3D Room geometry. Specifying a geometry here can help overcome some limitations of this auto-calculation, particularly for cases where the floors of the Room are composed of AirBoundaries. */
    space_polygon_geometry?: Face3D;
	

    constructor() {
        super();
        this.type = "RoomDoe2Properties";
        this.assigned_flow = new Autocalculate();;
        this.flow_per_area = new Autocalculate();;
        this.min_flow_ratio = new Autocalculate();;
        this.min_flow_per_area = new Autocalculate();;
        this.hmax_flow_ratio = new Autocalculate();;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "RoomDoe2Properties";
            this.assigned_flow = _data["assigned_flow"] !== undefined ? _data["assigned_flow"] : new Autocalculate();;
            this.flow_per_area = _data["flow_per_area"] !== undefined ? _data["flow_per_area"] : new Autocalculate();;
            this.min_flow_ratio = _data["min_flow_ratio"] !== undefined ? _data["min_flow_ratio"] : new Autocalculate();;
            this.min_flow_per_area = _data["min_flow_per_area"] !== undefined ? _data["min_flow_per_area"] : new Autocalculate();;
            this.hmax_flow_ratio = _data["hmax_flow_ratio"] !== undefined ? _data["hmax_flow_ratio"] : new Autocalculate();;
            this.space_polygon_geometry = _data["space_polygon_geometry"];
        }
    }


    static override fromJS(data: any): RoomDoe2Properties {
        data = typeof data === 'object' ? data : {};

        let result = new RoomDoe2Properties();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["assigned_flow"] = this.assigned_flow;
        data["flow_per_area"] = this.flow_per_area;
        data["min_flow_ratio"] = this.min_flow_ratio;
        data["min_flow_per_area"] = this.min_flow_per_area;
        data["hmax_flow_ratio"] = this.hmax_flow_ratio;
        data["space_polygon_geometry"] = this.space_polygon_geometry;
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
