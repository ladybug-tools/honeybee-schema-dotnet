import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { AperturePropertiesAbridged } from "./AperturePropertiesAbridged";
import { Face3D } from "./Face3D";
import { IDdBaseModel } from "./IDdBaseModel";
import { Outdoors } from "./Outdoors";
import { Shade } from "./Shade";
import { Surface } from "./Surface";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Aperture extends IDdBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsDefined()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'Outdoors') return Outdoors.fromJS(item);
      else if (item?.type === 'Surface') return Surface.fromJS(item);
      else return item;
    })
    /** BoundaryCondition */
    boundary_condition!: (Outdoors | Surface);
	
    @IsInstance(AperturePropertiesAbridged)
    @Type(() => AperturePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: AperturePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Aperture$/)
    /** Type */
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether the Aperture can be opened for ventilation. */
    is_operable?: boolean;
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object (eg. window sill, light shelf). */
    indoor_shades?: Shade [];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
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
            const obj = plainToClass(Aperture, _data, { enableImplicitConversion: true });
            this.geometry = obj.geometry;
            this.boundary_condition = obj.boundary_condition;
            this.properties = obj.properties;
            this.type = obj.type;
            this.is_operable = obj.is_operable;
            this.indoor_shades = obj.indoor_shades;
            this.outdoor_shades = obj.outdoor_shades;
        }
    }


    static override fromJS(data: any): Aperture {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Aperture();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["boundary_condition"] = this.boundary_condition;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["is_operable"] = this.is_operable;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
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

