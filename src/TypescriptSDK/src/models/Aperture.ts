import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
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
	
    @IsInstance(AperturePropertiesAbridged)
    @Type(() => AperturePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: AperturePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Aperture$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Aperture";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "is_operable" })
    /** Boolean to note whether the Aperture can be opened for ventilation. */
    isOperable: boolean = false;
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "indoor_shades" })
    /** Shades assigned to the interior side of this object (eg. window sill, light shelf). */
    indoorShades?: Shade[];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "outdoor_shades" })
    /** Shades assigned to the exterior side of this object (eg. mullions, louvers). */
    outdoorShades?: Shade[];
	

    constructor() {
        super();
        this.type = "Aperture";
        this.isOperable = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Aperture, _data);
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
        data["boundary_condition"] = this.boundaryCondition;
        data["properties"] = this.properties;
        data["type"] = this.type ?? "Aperture";
        data["is_operable"] = this.isOperable ?? false;
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
