import { IsEnum, IsDefined, IsString, Matches, MinLength, MaxLength, IsOptional, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { GeometryObjectTypes } from "./GeometryObjectTypes";

export class ChangedInstruction extends _OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "element_type" })
    /** Text for the type of object that has been changed. */
    elementType!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "element_id" })
    /** Text string for the unique object ID that has changed. */
    elementId!: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "element_name" })
    /** Text string for the display name of the object that has changed. */
    elementName?: string;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "update_geometry" })
    /** A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False). */
    updateGeometry: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "update_energy" })
    /** A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False). */
    updateEnergy: boolean = true;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "update_radiance" })
    /** A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False). */
    updateRadiance: boolean = true;
	
    @IsString()
    @IsOptional()
    @Matches(/^ChangedInstruction$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ChangedInstruction";
	

    constructor() {
        super();
        this.updateGeometry = true;
        this.updateEnergy = true;
        this.updateRadiance = true;
        this.type = "ChangedInstruction";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ChangedInstruction, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
            this.updateGeometry = obj.updateGeometry ?? true;
            this.updateEnergy = obj.updateEnergy ?? true;
            this.updateRadiance = obj.updateRadiance ?? true;
            this.type = obj.type ?? "ChangedInstruction";
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
        data["element_type"] = this.elementType;
        data["element_id"] = this.elementId;
        data["element_name"] = this.elementName;
        data["update_geometry"] = this.updateGeometry ?? true;
        data["update_energy"] = this.updateEnergy ?? true;
        data["update_radiance"] = this.updateRadiance ?? true;
        data["type"] = this.type ?? "ChangedInstruction";
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
