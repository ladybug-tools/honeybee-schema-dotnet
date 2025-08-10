import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { WindowConstructionShade } from "./WindowConstructionShade";

/** A set of constructions for aperture assemblies. */
export class ApertureConstructionSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ApertureConstructionSet$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ApertureConstructionSet";
	
    @IsOptional()
    @Expose({ name: "interior_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all apertures with a Surface boundary condition. */
    interiorConstruction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Expose({ name: "window_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face. */
    windowConstruction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Expose({ name: "skylight_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylightConstruction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Expose({ name: "operable_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property. */
    operableConstruction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	

    constructor() {
        super();
        this.type = "ApertureConstructionSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ApertureConstructionSet, _data);
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
        data["type"] = this.type ?? "ApertureConstructionSet";
        data["interior_construction"] = this.interiorConstruction;
        data["window_construction"] = this.windowConstruction;
        data["skylight_construction"] = this.skylightConstruction;
        data["operable_construction"] = this.operableConstruction;
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
