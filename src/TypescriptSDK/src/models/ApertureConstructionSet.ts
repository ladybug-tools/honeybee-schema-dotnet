import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { WindowConstructionShade } from "./WindowConstructionShade";

/** A set of constructions for aperture assemblies. */
export class ApertureConstructionSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ApertureConstructionSet$/)
    /** Type */
    type?: string;
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all apertures with a Surface boundary condition. */
    interior_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face. */
    window_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylight_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property. */
    operable_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	

    constructor() {
        super();
        this.type = "ApertureConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ApertureConstructionSet, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.interior_construction = obj.interior_construction;
            this.window_construction = obj.window_construction;
            this.skylight_construction = obj.skylight_construction;
            this.operable_construction = obj.operable_construction;
        }
    }


    static override fromJS(data: any): ApertureConstructionSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ApertureConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["interior_construction"] = this.interior_construction;
        data["window_construction"] = this.window_construction;
        data["skylight_construction"] = this.skylight_construction;
        data["operable_construction"] = this.operable_construction;
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

