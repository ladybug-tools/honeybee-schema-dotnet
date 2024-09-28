import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel.ts";
import { OpaqueConstruction } from "./OpaqueConstruction.ts";
import { WindowConstruction } from "./WindowConstruction.ts";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic.ts";
import { WindowConstructionShade } from "./WindowConstructionShade.ts";

/** A set of constructions for door assemblies. */
export class DoorConstructionSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DoorConstructionSet$/)
    type?: string;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for all opaque doors with a Surface boundary condition. */
    interior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face. */
    exterior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face. */
    overhead_construction?: OpaqueConstruction;
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all glass doors with an Outdoors boundary condition. */
    exterior_glass_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all glass doors with a Surface boundary condition. */
    interior_glass_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	

    constructor() {
        super();
        this.type = "DoorConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorConstructionSet, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.interior_construction = obj.interior_construction;
            this.exterior_construction = obj.exterior_construction;
            this.overhead_construction = obj.overhead_construction;
            this.exterior_glass_construction = obj.exterior_glass_construction;
            this.interior_glass_construction = obj.interior_glass_construction;
        }
    }


    static override fromJS(data: any): DoorConstructionSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DoorConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["interior_construction"] = this.interior_construction;
        data["exterior_construction"] = this.exterior_construction;
        data["overhead_construction"] = this.overhead_construction;
        data["exterior_glass_construction"] = this.exterior_glass_construction;
        data["interior_glass_construction"] = this.interior_glass_construction;
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

