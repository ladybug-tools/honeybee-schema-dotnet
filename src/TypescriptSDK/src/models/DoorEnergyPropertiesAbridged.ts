import { IsString, IsOptional, Matches, MinLength, MaxLength, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { VentilationOpening } from "./VentilationOpening";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class DoorEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DoorEnergyPropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DoorEnergyPropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "construction" })
    /** Identifier of an OpaqueConstruction or WindowConstruction for the door. Note that the host door must have the is_glass property set to True to assign a WindowConstruction. If None, the construction is set by the parent Room construction_set or the Model global_construction_set. */
    construction?: string;
	
    @IsInstance(VentilationOpening)
    @Type(() => VentilationOpening)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "vent_opening" })
    /** An optional VentilationOpening to specify the operable portion of the Door. */
    ventOpening?: VentilationOpening;
	

    constructor() {
        super();
        this.type = "DoorEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorEnergyPropertiesAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "DoorEnergyPropertiesAbridged";
            this.construction = obj.construction;
            this.ventOpening = obj.ventOpening;
        }
    }


    static override fromJS(data: any): DoorEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DoorEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "DoorEnergyPropertiesAbridged";
        data["construction"] = this.construction;
        data["vent_opening"] = this.ventOpening;
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
