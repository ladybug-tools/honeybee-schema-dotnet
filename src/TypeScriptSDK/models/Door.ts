import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
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
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsDefined()
    boundary_condition!: (Outdoors | Surface);
	
    @IsInstance(DoorPropertiesAbridged)
    @Type(() => DoorPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: DoorPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Door$/)
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether this object is a glass door as opposed to an opaque door. */
    is_glass?: boolean;
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object. */
    indoor_shades?: Shade [];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the exterior side of this object (eg. entryway awning). */
    outdoor_shades?: Shade [];
	

    constructor() {
        super();
        this.type = "Door";
        this.is_glass = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Door, _data);
            this.geometry = obj.geometry;
            this.boundary_condition = obj.boundary_condition;
            this.properties = obj.properties;
            this.type = obj.type;
            this.is_glass = obj.is_glass;
            this.indoor_shades = obj.indoor_shades;
            this.outdoor_shades = obj.outdoor_shades;
        }
    }


    static override fromJS(data: any): Door {
        data = typeof data === 'object' ? data : {};

        let result = new Door();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["geometry"] = this.geometry;
        data["boundary_condition"] = this.boundary_condition;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["is_glass"] = this.is_glass;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
        super.toJSON(data);
        return data;
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
