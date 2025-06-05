import { IsString, IsOptional, Matches, IsNumber, Max, IsEnum, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { EnergyBaseModel } from "./EnergyBaseModel";
import { ModuleType } from "./ModuleType";
import { MountingType } from "./MountingType";

/** Base class for all objects requiring a valid EnergyPlus identifier. */
export class PVProperties extends EnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^PVProperties$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "PVProperties";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "rated_efficiency" })
    /** A number between 0 and 1 for the rated nameplate efficiency of the photovoltaic solar cells under standard test conditions (STC). Standard test conditions are 1,000 Watts per square meter solar irradiance, 25 degrees C cell temperature, and ASTM G173-03 standard spectrum. Nameplate efficiencies reported by manufacturers are typically under STC. Standard poly- or mono-crystalline silicon modules tend to have rated efficiencies in the range of 14-17%. Premium high efficiency mono-crystalline silicon modules with anti-reflective coatings can have efficiencies in the range of 18-20%. Thin film photovoltaic modules typically have efficiencies of 11% or less. (Default: 0.15 for standard silicon solar cells). */
    ratedEfficiency: number = 0.15;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
    @Expose({ name: "active_area_fraction" })
    /** The fraction of the parent Shade geometry that is covered in active solar cells. This fraction includes the difference between the PV panel (aka. PV module) area and the active cells within the panel as well as any losses for how the (typically rectangular) panels can be arranged on the Shade geometry. When the parent Shade geometry represents just the solar panels, this fraction is typically around 0.9 given that the framing elements of the panel reduce the overall active area. (Default: 0.9, assuming parent Shade geometry represents only the PV panel geometry). */
    activeAreaFraction: number = 0.9;
	
    @IsEnum(ModuleType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "module_type" })
    /** Text to indicate the type of solar module. This is used to determine the temperature coefficients used in the simulation of the photovoltaic modules. When the rated_efficiency is between 12-18%, the Standard type is typically most appropriate. When the rated_efficiency is greater than 18%, the Premium type is likely more appropriate. When the rated_efficiency is less than 12%, this likely refers to a case where the ThinFilm module type is most appropriate. */
    moduleType: ModuleType = ModuleType.Standard;
	
    @IsEnum(MountingType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "mounting_type" })
    /** Text to indicate the type of mounting and/or tracking used for the photovoltaic array. Note that the OneAxis options have an axis of rotation that is determined by the azimuth of the parent Shade geometry. Also note that, in the case of one or two axis tracking, shadows on the (static) parent Shade geometry still reduce the electrical output, enabling the simulation to account for large context geometry casting shadows on the array. However, the effects of smaller detailed shading may be improperly accounted for and self shading of the dynamic panel geometry is only accounted for via the tracking_ground_coverage_ratio property on this object. FixedOpenRack refers to ground or roof mounting where the air flows freely. FixedRoofMounted refers to mounting flush with the roof with limited air flow. OneAxis refers to a fixed tilt and azimuth, which define an axis of rotation. OneAxisBacktracking is the same as OneAxis but with controls to reduce self-shade at low sun angles. TwoAxis refers to a dynamic tilt and azimuth that track the sun. */
    mountingType: MountingType = MountingType.FixedOpenRack;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "system_loss_fraction" })
    /** A number between 0 and 1 for the fraction of the electricity output lost due to factors other than EPW weather conditions, panel efficiency/type, active area, mounting, and inverter conversion from DC to AC. Factors that should be accounted for in this input include soiling, snow, wiring losses, electrical connection losses, manufacturer defects/tolerances/mismatch in cell characteristics, losses from power grid availability, and losses due to age or light-induced degradation. Losses from these factors tend to be between 10-20% but can vary widely depending on the installation, maintenance and the grid to which the panels are connected.. */
    systemLossFraction: number = 0.14;
	

    constructor() {
        super();
        this.type = "PVProperties";
        this.ratedEfficiency = 0.15;
        this.activeAreaFraction = 0.9;
        this.moduleType = ModuleType.Standard;
        this.mountingType = MountingType.FixedOpenRack;
        this.systemLossFraction = 0.14;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(PVProperties, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "PVProperties";
            this.ratedEfficiency = obj.ratedEfficiency ?? 0.15;
            this.activeAreaFraction = obj.activeAreaFraction ?? 0.9;
            this.moduleType = obj.moduleType ?? ModuleType.Standard;
            this.mountingType = obj.mountingType ?? MountingType.FixedOpenRack;
            this.systemLossFraction = obj.systemLossFraction ?? 0.14;
        }
    }


    static override fromJS(data: any): PVProperties {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new PVProperties();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "PVProperties";
        data["rated_efficiency"] = this.ratedEfficiency ?? 0.15;
        data["active_area_fraction"] = this.activeAreaFraction ?? 0.9;
        data["module_type"] = this.moduleType ?? ModuleType.Standard;
        data["mounting_type"] = this.mountingType ?? MountingType.FixedOpenRack;
        data["system_loss_fraction"] = this.systemLossFraction ?? 0.14;
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
