import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { DoorPropertiesAbridged } from "./DoorPropertiesAbridged";
import { Face3D } from "./Face3D";
import { IDdBaseModel } from "./IDdBaseModel";
import { Outdoors } from "./Outdoors";
import { Shade } from "./Shade";
import { Surface } from "./Surface";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Door extends IDdBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsDefined()
    @Expose({ name: "boundary_condition" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'Outdoors') return Outdoors.fromJS(item);
      else if (item?.type === 'Surface') return Surface.fromJS(item);
      else return item;
    })
    /** boundaryCondition */
    boundaryCondition!: (Outdoors | Surface);
	
    @IsInstance(DoorPropertiesAbridged)
    @Type(() => DoorPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: DoorPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Door$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Door";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "is_glass" })
    /** Boolean to note whether this object is a glass door as opposed to an opaque door. */
    isGlass: boolean = false;
	
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
    /** Shades assigned to the exterior side of this object (eg. entryway awning). */
    outdoorShades?: Shade[];
	

    constructor() {
        super();
        this.type = "Door";
        this.isGlass = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Door, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.geometry = obj.geometry;
            this.boundaryCondition = obj.boundaryCondition;
            this.properties = obj.properties;
            this.type = obj.type ?? "Door";
            this.isGlass = obj.isGlass ?? false;
            this.indoorShades = obj.indoorShades;
            this.outdoorShades = obj.outdoorShades;
        }
    }


    static override fromJS(data: any): Door {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Door();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["boundary_condition"] = this.boundaryCondition;
        data["properties"] = this.properties;
        data["type"] = this.type ?? "Door";
        data["is_glass"] = this.isGlass ?? false;
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
