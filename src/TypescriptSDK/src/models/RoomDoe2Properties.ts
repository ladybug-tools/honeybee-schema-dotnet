import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Autocalculate } from "./Autocalculate";
import { Face3D } from "./Face3D";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class RoomDoe2Properties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RoomDoe2Properties$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RoomDoe2Properties";
	
    @IsOptional()
    @Expose({ name: "assigned_flow" })
    /** A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP. */
    assignedFlow: (Autocalculate | number) = new Autocalculate();
	
    @IsOptional()
    @Expose({ name: "flow_per_area" })
    /** A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP. */
    flowPerArea: (Autocalculate | number) = new Autocalculate();
	
    @IsOptional()
    @Expose({ name: "min_flow_ratio" })
    /** A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP. */
    minFlowRatio: (Autocalculate | number) = new Autocalculate();
	
    @IsOptional()
    @Expose({ name: "min_flow_per_area" })
    /** A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP. */
    minFlowPerArea: (Autocalculate | number) = new Autocalculate();
	
    @IsOptional()
    @Expose({ name: "hmax_flow_ratio" })
    /** A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP. */
    hmaxFlowRatio: (Autocalculate | number) = new Autocalculate();
	
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "space_polygon_geometry" })
    /** An optional horizontal Face3D object, which will be used to set the SPACE polygon during export to INP. If None, the SPACE polygon is auto-calculated from the 3D Room geometry. Specifying a geometry here can help overcome some limitations of this auto-calculation, particularly for cases where the floors of the Room are composed of AirBoundaries. */
    spacePolygonGeometry?: Face3D;
	

    constructor() {
        super();
        this.type = "RoomDoe2Properties";
        this.assignedFlow = new Autocalculate();
        this.flowPerArea = new Autocalculate();
        this.minFlowRatio = new Autocalculate();
        this.minFlowPerArea = new Autocalculate();
        this.hmaxFlowRatio = new Autocalculate();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RoomDoe2Properties, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "RoomDoe2Properties";
            this.assignedFlow = obj.assignedFlow ?? new Autocalculate();
            this.flowPerArea = obj.flowPerArea ?? new Autocalculate();
            this.minFlowRatio = obj.minFlowRatio ?? new Autocalculate();
            this.minFlowPerArea = obj.minFlowPerArea ?? new Autocalculate();
            this.hmaxFlowRatio = obj.hmaxFlowRatio ?? new Autocalculate();
            this.spacePolygonGeometry = obj.spacePolygonGeometry;
        }
    }


    static override fromJS(data: any): RoomDoe2Properties {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoomDoe2Properties();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoomDoe2Properties";
        data["assigned_flow"] = this.assignedFlow ?? new Autocalculate();
        data["flow_per_area"] = this.flowPerArea ?? new Autocalculate();
        data["min_flow_ratio"] = this.minFlowRatio ?? new Autocalculate();
        data["min_flow_per_area"] = this.minFlowPerArea ?? new Autocalculate();
        data["hmax_flow_ratio"] = this.hmaxFlowRatio ?? new Autocalculate();
        data["space_polygon_geometry"] = this.spacePolygonGeometry;
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
