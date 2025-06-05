import { IsString, IsOptional, Matches, IsNumber, Min, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** This object specifies the properties of window shade materials. */
export class EnergyWindowMaterialShade extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialShade$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialShade";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "solar_transmittance" })
    /** The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4. */
    solarTransmittance: number = 0.4;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "solar_reflectance" })
    /** The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5 */
    solarReflectance: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "visible_transmittance" })
    /** The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4. */
    visibleTransmittance: number = 0.4;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "visible_reflectance" })
    /** The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4 */
    visibleReflectance: number = 0.4;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "emissivity" })
    /** The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9. */
    emissivity: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "infrared_transmittance" })
    /** The effective long-wave transmittance. It is assumed independent of incidence angle. Default: 0. */
    infraredTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "thickness" })
    /** The thickness of the shade material in meters. Default: 0.005. */
    thickness: number = 0.005;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "conductivity" })
    /** The conductivity of the shade material in W/(m-K). Default value is 0.1. */
    conductivity: number = 0.1;
	
    @IsNumber()
    @IsOptional()
    @Min(0.001)
    @Max(1)
    @Expose({ name: "distance_to_glass" })
    /** The distance from shade to adjacent glass in meters. Default value is 0.05 */
    distanceToGlass: number = 0.05;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "top_opening_multiplier" })
    /** The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5. */
    topOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "bottom_opening_multiplier" })
    /** The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5. */
    bottomOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "left_opening_multiplier" })
    /** The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5. */
    leftOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "right_opening_multiplier" })
    /** The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5. */
    rightOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(0.8)
    @Expose({ name: "airflow_permeability" })
    /** The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability = 0. Default: 0. */
    airflowPermeability: number = 0;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialShade";
        this.solarTransmittance = 0.4;
        this.solarReflectance = 0.5;
        this.visibleTransmittance = 0.4;
        this.visibleReflectance = 0.4;
        this.emissivity = 0.9;
        this.infraredTransmittance = 0;
        this.thickness = 0.005;
        this.conductivity = 0.1;
        this.distanceToGlass = 0.05;
        this.topOpeningMultiplier = 0.5;
        this.bottomOpeningMultiplier = 0.5;
        this.leftOpeningMultiplier = 0.5;
        this.rightOpeningMultiplier = 0.5;
        this.airflowPermeability = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialShade, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "EnergyWindowMaterialShade";
            this.solarTransmittance = obj.solarTransmittance ?? 0.4;
            this.solarReflectance = obj.solarReflectance ?? 0.5;
            this.visibleTransmittance = obj.visibleTransmittance ?? 0.4;
            this.visibleReflectance = obj.visibleReflectance ?? 0.4;
            this.emissivity = obj.emissivity ?? 0.9;
            this.infraredTransmittance = obj.infraredTransmittance ?? 0;
            this.thickness = obj.thickness ?? 0.005;
            this.conductivity = obj.conductivity ?? 0.1;
            this.distanceToGlass = obj.distanceToGlass ?? 0.05;
            this.topOpeningMultiplier = obj.topOpeningMultiplier ?? 0.5;
            this.bottomOpeningMultiplier = obj.bottomOpeningMultiplier ?? 0.5;
            this.leftOpeningMultiplier = obj.leftOpeningMultiplier ?? 0.5;
            this.rightOpeningMultiplier = obj.rightOpeningMultiplier ?? 0.5;
            this.airflowPermeability = obj.airflowPermeability ?? 0;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialShade {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialShade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "EnergyWindowMaterialShade";
        data["solar_transmittance"] = this.solarTransmittance ?? 0.4;
        data["solar_reflectance"] = this.solarReflectance ?? 0.5;
        data["visible_transmittance"] = this.visibleTransmittance ?? 0.4;
        data["visible_reflectance"] = this.visibleReflectance ?? 0.4;
        data["emissivity"] = this.emissivity ?? 0.9;
        data["infrared_transmittance"] = this.infraredTransmittance ?? 0;
        data["thickness"] = this.thickness ?? 0.005;
        data["conductivity"] = this.conductivity ?? 0.1;
        data["distance_to_glass"] = this.distanceToGlass ?? 0.05;
        data["top_opening_multiplier"] = this.topOpeningMultiplier ?? 0.5;
        data["bottom_opening_multiplier"] = this.bottomOpeningMultiplier ?? 0.5;
        data["left_opening_multiplier"] = this.leftOpeningMultiplier ?? 0.5;
        data["right_opening_multiplier"] = this.rightOpeningMultiplier ?? 0.5;
        data["airflow_permeability"] = this.airflowPermeability ?? 0;
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
