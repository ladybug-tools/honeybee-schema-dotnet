import { IsEnum, IsDefined, IsString, Matches, MinLength, MaxLength, IsOptional, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { GeometryObjectTypes } from "./GeometryObjectTypes";

export class ChangedInstruction extends _OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @Type(() => String)
    @IsDefined()
    /** Text for the type of object that has been changed. */
    element_type!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    /** Text string for the unique object ID that has changed. */
    element_id!: string;
	
    @IsString()
    @IsOptional()
    /** Text string for the display name of the object that has changed. */
    element_name?: string;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False). */
    update_geometry?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False). */
    update_energy?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False). */
    update_radiance?: boolean;
	
    @IsString()
    @IsOptional()
    @Matches(/^ChangedInstruction$/)
    type?: string;
	

    constructor() {
        super();
        this.update_geometry = true;
        this.update_energy = true;
        this.update_radiance = true;
        this.type = "ChangedInstruction";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ChangedInstruction, _data);
            this.element_type = obj.element_type;
            this.element_id = obj.element_id;
            this.element_name = obj.element_name;
            this.update_geometry = obj.update_geometry;
            this.update_energy = obj.update_energy;
            this.update_radiance = obj.update_radiance;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): ChangedInstruction {
        data = typeof data === 'object' ? data : {};

        let result = new ChangedInstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["element_type"] = this.element_type;
        data["element_id"] = this.element_id;
        data["element_name"] = this.element_name;
        data["update_geometry"] = this.update_geometry;
        data["update_energy"] = this.update_energy;
        data["update_radiance"] = this.update_radiance;
        data["type"] = this.type;
        data = super.toJSON(data);
        return data;
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
