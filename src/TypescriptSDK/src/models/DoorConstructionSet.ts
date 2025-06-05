import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { WindowConstructionShade } from "./WindowConstructionShade";

/** A set of constructions for door assemblies. */
export class DoorConstructionSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DoorConstructionSet$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DoorConstructionSet";
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "interior_construction" })
    /** An OpaqueConstruction for all opaque doors with a Surface boundary condition. */
    interiorConstruction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "exterior_construction" })
    /** An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face. */
    exteriorConstruction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "overhead_construction" })
    /** An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face. */
    overheadConstruction?: OpaqueConstruction;
	
    @IsOptional()
    @Expose({ name: "exterior_glass_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all glass doors with an Outdoors boundary condition. */
    exteriorGlassConstruction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    @Expose({ name: "interior_glass_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else return item;
    })
    /** A WindowConstruction for all glass doors with a Surface boundary condition. */
    interiorGlassConstruction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	

    constructor() {
        super();
        this.type = "DoorConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorConstructionSet, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "DoorConstructionSet";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.overheadConstruction = obj.overheadConstruction;
            this.exteriorGlassConstruction = obj.exteriorGlassConstruction;
            this.interiorGlassConstruction = obj.interiorGlassConstruction;
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
        data["type"] = this.type ?? "DoorConstructionSet";
        data["interior_construction"] = this.interiorConstruction;
        data["exterior_construction"] = this.exteriorConstruction;
        data["overhead_construction"] = this.overheadConstruction;
        data["exterior_glass_construction"] = this.exteriorGlassConstruction;
        data["interior_glass_construction"] = this.interiorGlassConstruction;
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
