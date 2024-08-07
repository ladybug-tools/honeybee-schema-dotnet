import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { PVProperties } from "./PVProperties";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class ShadeEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, the construction is set by theparent Room construction_set, the Model global_construction_set or (in the case fo an orphaned shade) the EnergyPlus default of 0.2 diffuse reflectance. */
    construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque. */
    transmittance_schedule?: string;
	
    @IsInstance(PVProperties)
    @ValidateNested()
    @IsOptional()
    /** An optional PVProperties object to specify photovoltaic behavior of the Shade. If None, the Shade will have no Photovoltaic properties. Note that the normal of the Shade is important in determining the performance of the shade as a PV geometry. */
    pv_properties?: PVProperties;
	

    constructor() {
        super();
        this.type = "ShadeEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ShadeEnergyPropertiesAbridged";
            this.construction = _data["construction"];
            this.transmittance_schedule = _data["transmittance_schedule"];
            this.pv_properties = _data["pv_properties"];
        }
    }


    static override fromJS(data: any): ShadeEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ShadeEnergyPropertiesAbridged();
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
        data["transmittance_schedule"] = this.transmittance_schedule;
        data["pv_properties"] = this.pv_properties;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
