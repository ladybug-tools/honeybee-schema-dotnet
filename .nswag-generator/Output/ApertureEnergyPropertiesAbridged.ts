import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { VentilationOpening } from "./VentilationOpening";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class ApertureEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a WindowConstruction for the aperture. If None, the construction is set by the parent Room construction_set or the Model global_construction_set. */
    construction?: string;
	
    @IsInstance(VentilationOpening)
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
            this.type = _data["type"] !== undefined ? _data["type"] : "ApertureEnergyPropertiesAbridged";
            this.construction = _data["construction"];
            this.vent_opening = _data["vent_opening"];
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
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["construction"] = this.construction;
        data["vent_opening"] = this.vent_opening;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
