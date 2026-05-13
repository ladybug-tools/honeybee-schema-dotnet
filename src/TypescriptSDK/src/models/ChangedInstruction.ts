import { IsString, IsOptional, Equals, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DiffObjectBase } from "./_DiffObjectBase";

export class ChangedInstruction extends _DiffObjectBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ChangedInstruction")
    @Expose({ name: "type" })
    /** type */
    type: string = "ChangedInstruction";
	
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "update_geometry" })
    /** A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False). */
    updateGeometry: boolean = true;
	
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "update_energy" })
    /** A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False). */
    updateEnergy: boolean = true;
	
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "update_radiance" })
    /** A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False). */
    updateRadiance: boolean = true;
	

    constructor() {
        super();
        this.type = "ChangedInstruction";
        this.updateGeometry = true;
        this.updateEnergy = true;
        this.updateRadiance = true;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ChangedInstruction, _data);
            this.type = obj.type ?? "ChangedInstruction";
            this.updateGeometry = obj.updateGeometry ?? true;
            this.updateEnergy = obj.updateEnergy ?? true;
            this.updateRadiance = obj.updateRadiance ?? true;
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
        }
    }


    static override fromJS(data: any): ChangedInstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ChangedInstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ChangedInstruction";
        data["update_geometry"] = this.updateGeometry ?? true;
        data["update_energy"] = this.updateEnergy ?? true;
        data["update_radiance"] = this.updateRadiance ?? true;
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
