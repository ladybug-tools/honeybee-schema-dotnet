import { IsString, IsOptional, Matches, MinLength, MaxLength, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { PVProperties } from "./PVProperties";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class ShadeEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeEnergyPropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadeEnergyPropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "construction" })
    /** Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, the construction is set by theparent Room construction_set, the Model global_construction_set or (in the case fo an orphaned shade) the EnergyPlus default of 0.2 diffuse reflectance. */
    construction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "transmittance_schedule" })
    /** Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque. */
    transmittanceSchedule?: string;
	
    @IsInstance(PVProperties)
    @Type(() => PVProperties)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "pv_properties" })
    /** An optional PVProperties object to specify photovoltaic behavior of the Shade. If None, the Shade will have no Photovoltaic properties. Note that the normal of the Shade is important in determining the performance of the shade as a PV geometry. */
    pvProperties?: PVProperties;
	

    constructor() {
        super();
        this.type = "ShadeEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadeEnergyPropertiesAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "ShadeEnergyPropertiesAbridged";
            this.construction = obj.construction;
            this.transmittanceSchedule = obj.transmittanceSchedule;
            this.pvProperties = obj.pvProperties;
        }
    }


    static override fromJS(data: any): ShadeEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ShadeEnergyPropertiesAbridged";
        data["construction"] = this.construction;
        data["transmittance_schedule"] = this.transmittanceSchedule;
        data["pv_properties"] = this.pvProperties;
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
