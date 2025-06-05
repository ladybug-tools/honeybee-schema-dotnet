import { IsString, IsOptional, Matches, IsEnum, IsNumber, Max, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { SlatOrientation } from "./SlatOrientation";

/** Window blind material consisting of flat, equally-spaced slats. */
export class EnergyWindowMaterialBlind extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialBlind$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialBlind";
	
    @IsEnum(SlatOrientation)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "slat_orientation" })
    /** slatOrientation */
    slatOrientation: SlatOrientation = SlatOrientation.Horizontal;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
    @Expose({ name: "slat_width" })
    /** The width of slat measured from edge to edge in meters. */
    slatWidth: number = 0.025;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
    @Expose({ name: "slat_separation" })
    /** The distance between the front of a slat and the back of the adjacent slat in meters. */
    slatSeparation: number = 0.01875;
	
    @IsNumber()
    @IsOptional()
    @Max(0.1)
    @Expose({ name: "slat_thickness" })
    /** The distance between the faces of a slat in meters. The default value is 0.001. */
    slatThickness: number = 0.001;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(180)
    @Expose({ name: "slat_angle" })
    /** The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45. */
    slatAngle: number = 45;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "slat_conductivity" })
    /** The thermal conductivity of the slat in W/(m-K). Default: 221. */
    slatConductivity: number = 221;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "beam_solar_transmittance" })
    /** The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0. */
    beamSolarTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "beam_solar_reflectance" })
    /** The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beamSolarReflectance: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "beam_solar_reflectance_back" })
    /** The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beamSolarReflectanceBack: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "diffuse_solar_transmittance" })
    /** The slat transmittance for hemispherically diffuse solar radiation. Default: 0. */
    diffuseSolarTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "diffuse_solar_reflectance" })
    /** The front-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5. */
    diffuseSolarReflectance: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "diffuse_solar_reflectance_back" })
    /** The back-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5. */
    diffuseSolarReflectanceBack: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "beam_visible_transmittance" })
    /** The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default: 0. */
    beamVisibleTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "beam_visible_reflectance" })
    /** The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beamVisibleReflectance: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "beam_visible_reflectance_back" })
    /** The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beamVisibleReflectanceBack: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "diffuse_visible_transmittance" })
    /** The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.” */
    diffuseVisibleTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "diffuse_visible_reflectance" })
    /** The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default: 0.5. */
    diffuseVisibleReflectance: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "diffuse_visible_reflectance_back" })
    /** The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default: 0.5.” */
    diffuseVisibleReflectanceBack: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "infrared_transmittance" })
    /** The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0. */
    infraredTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "emissivity" })
    /** Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. */
    emissivity: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "emissivity_back" })
    /** Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. */
    emissivityBack: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0.01)
    @Max(1)
    @Expose({ name: "distance_to_glass" })
    /** The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05. */
    distanceToGlass: number = 0.05;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "top_opening_multiplier" })
    /** The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. */
    topOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "bottom_opening_multiplier" })
    /** The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. */
    bottomOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "left_opening_multiplier" })
    /** The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. */
    leftOpeningMultiplier: number = 0.5;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "right_opening_multiplier" })
    /** The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. */
    rightOpeningMultiplier: number = 0.5;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialBlind";
        this.slatOrientation = SlatOrientation.Horizontal;
        this.slatWidth = 0.025;
        this.slatSeparation = 0.01875;
        this.slatThickness = 0.001;
        this.slatAngle = 45;
        this.slatConductivity = 221;
        this.beamSolarTransmittance = 0;
        this.beamSolarReflectance = 0.5;
        this.beamSolarReflectanceBack = 0.5;
        this.diffuseSolarTransmittance = 0;
        this.diffuseSolarReflectance = 0.5;
        this.diffuseSolarReflectanceBack = 0.5;
        this.beamVisibleTransmittance = 0;
        this.beamVisibleReflectance = 0.5;
        this.beamVisibleReflectanceBack = 0.5;
        this.diffuseVisibleTransmittance = 0;
        this.diffuseVisibleReflectance = 0.5;
        this.diffuseVisibleReflectanceBack = 0.5;
        this.infraredTransmittance = 0;
        this.emissivity = 0.9;
        this.emissivityBack = 0.9;
        this.distanceToGlass = 0.05;
        this.topOpeningMultiplier = 0.5;
        this.bottomOpeningMultiplier = 0.5;
        this.leftOpeningMultiplier = 0.5;
        this.rightOpeningMultiplier = 0.5;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialBlind, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.slatOrientation = obj.slatOrientation;
            this.slatWidth = obj.slatWidth;
            this.slatSeparation = obj.slatSeparation;
            this.slatThickness = obj.slatThickness;
            this.slatAngle = obj.slatAngle;
            this.slatConductivity = obj.slatConductivity;
            this.beamSolarTransmittance = obj.beamSolarTransmittance;
            this.beamSolarReflectance = obj.beamSolarReflectance;
            this.beamSolarReflectanceBack = obj.beamSolarReflectanceBack;
            this.diffuseSolarTransmittance = obj.diffuseSolarTransmittance;
            this.diffuseSolarReflectance = obj.diffuseSolarReflectance;
            this.diffuseSolarReflectanceBack = obj.diffuseSolarReflectanceBack;
            this.beamVisibleTransmittance = obj.beamVisibleTransmittance;
            this.beamVisibleReflectance = obj.beamVisibleReflectance;
            this.beamVisibleReflectanceBack = obj.beamVisibleReflectanceBack;
            this.diffuseVisibleTransmittance = obj.diffuseVisibleTransmittance;
            this.diffuseVisibleReflectance = obj.diffuseVisibleReflectance;
            this.diffuseVisibleReflectanceBack = obj.diffuseVisibleReflectanceBack;
            this.infraredTransmittance = obj.infraredTransmittance;
            this.emissivity = obj.emissivity;
            this.emissivityBack = obj.emissivityBack;
            this.distanceToGlass = obj.distanceToGlass;
            this.topOpeningMultiplier = obj.topOpeningMultiplier;
            this.bottomOpeningMultiplier = obj.bottomOpeningMultiplier;
            this.leftOpeningMultiplier = obj.leftOpeningMultiplier;
            this.rightOpeningMultiplier = obj.rightOpeningMultiplier;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialBlind {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialBlind();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["slat_orientation"] = this.slatOrientation;
        data["slat_width"] = this.slatWidth;
        data["slat_separation"] = this.slatSeparation;
        data["slat_thickness"] = this.slatThickness;
        data["slat_angle"] = this.slatAngle;
        data["slat_conductivity"] = this.slatConductivity;
        data["beam_solar_transmittance"] = this.beamSolarTransmittance;
        data["beam_solar_reflectance"] = this.beamSolarReflectance;
        data["beam_solar_reflectance_back"] = this.beamSolarReflectanceBack;
        data["diffuse_solar_transmittance"] = this.diffuseSolarTransmittance;
        data["diffuse_solar_reflectance"] = this.diffuseSolarReflectance;
        data["diffuse_solar_reflectance_back"] = this.diffuseSolarReflectanceBack;
        data["beam_visible_transmittance"] = this.beamVisibleTransmittance;
        data["beam_visible_reflectance"] = this.beamVisibleReflectance;
        data["beam_visible_reflectance_back"] = this.beamVisibleReflectanceBack;
        data["diffuse_visible_transmittance"] = this.diffuseVisibleTransmittance;
        data["diffuse_visible_reflectance"] = this.diffuseVisibleReflectance;
        data["diffuse_visible_reflectance_back"] = this.diffuseVisibleReflectanceBack;
        data["infrared_transmittance"] = this.infraredTransmittance;
        data["emissivity"] = this.emissivity;
        data["emissivity_back"] = this.emissivityBack;
        data["distance_to_glass"] = this.distanceToGlass;
        data["top_opening_multiplier"] = this.topOpeningMultiplier;
        data["bottom_opening_multiplier"] = this.bottomOpeningMultiplier;
        data["left_opening_multiplier"] = this.leftOpeningMultiplier;
        data["right_opening_multiplier"] = this.rightOpeningMultiplier;
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
