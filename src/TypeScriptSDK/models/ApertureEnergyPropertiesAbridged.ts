import { IsString, IsOptional, Matches, MinLength, MaxLength, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { VentilationOpening } from "./VentilationOpening";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class ApertureEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ApertureEnergyPropertiesAbridged$/)
    type?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of a WindowConstruction for the aperture. If None, the construction is set by the parent Room construction_set or the Model global_construction_set. */
    construction?: string;
	
    @IsInstance(VentilationOpening)
    @Type(() => VentilationOpening)
    @ValidateNested()
    @IsOptional()
    /** An optional VentilationOpening to specify the operable portion of the Aperture. */
    vent_opening?: VentilationOpening;
	

    constructor() {
        super();
        this.type = "ApertureEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ApertureEnergyPropertiesAbridged, _data);
            this.type = obj.type;
            this.construction = obj.construction;
            this.vent_opening = obj.vent_opening;
        }
    }


    static override fromJS(data: any): ApertureEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ApertureEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["construction"] = this.construction;
        data["vent_opening"] = this.vent_opening;
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

