import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, IsBoolean, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Face3D } from "./Face3D";
import { Outdoors } from "./Outdoors";
import { Surface } from "./Surface";
import { AperturePropertiesAbridged } from "./AperturePropertiesAbridged";
import { Shade } from "./Shade";
import { IDdBaseModel } from "./IDdBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Aperture extends IDdBaseModel {
    @IsInstance(Face3D)
    @ValidateNested()
    @IsDefined()
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsDefined()
    boundary_condition!: (Outdoors | Surface);
	
    @IsInstance(AperturePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: AperturePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether the Aperture can be opened for ventilation. */
    is_operable?: boolean;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object (eg. window sill, light shelf). */
    indoor_shades?: Shade [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the exterior side of this object (eg. mullions, louvers). */
    outdoor_shades?: Shade [];
	

    constructor() {
        super();
        this.type = "Aperture";
        this.is_operable = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.geometry = _data["geometry"];
            this.boundary_condition = _data["boundary_condition"];
            this.properties = _data["properties"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Aperture";
            this.is_operable = _data["is_operable"] !== undefined ? _data["is_operable"] : false;
            this.indoor_shades = _data["indoor_shades"];
            this.outdoor_shades = _data["outdoor_shades"];
        }
    }


    static override fromJS(data: any): Aperture {
        data = typeof data === 'object' ? data : {};

        let result = new Aperture();
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
        data["is_operable"] = this.is_operable;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
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
