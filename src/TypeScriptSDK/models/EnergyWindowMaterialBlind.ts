import { IsString, IsOptional, Matches, IsEnum, IsNumber, Max, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { SlatOrientation } from "./SlatOrientation";

/** Window blind material consisting of flat, equally-spaced slats. */
export class EnergyWindowMaterialBlind extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialBlind$/)
    type?: string;
	
    @IsEnum(SlatOrientation)
    @Type(() => String)
    @IsOptional()
    slat_orientation?: SlatOrientation;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
    /** The width of slat measured from edge to edge in meters. */
    slat_width?: number;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
    /** The distance between the front of a slat and the back of the adjacent slat in meters. */
    slat_separation?: number;
	
    @IsNumber()
    @IsOptional()
    @Max(0.1)
    /** The distance between the faces of a slat in meters. The default value is 0.001. */
    slat_thickness?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(180)
    /** The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45. */
    slat_angle?: number;
	
    @IsNumber()
    @IsOptional()
    /** The thermal conductivity of the slat in W/(m-K). Default: 221. */
    slat_conductivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0. */
    beam_solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_solar_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The slat transmittance for hemispherically diffuse solar radiation. Default: 0. */
    diffuse_solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The front-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5. */
    diffuse_solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The back-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5. */
    diffuse_solar_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default: 0. */
    beam_visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_visible_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_visible_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.” */
    diffuse_visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default: 0.5. */
    diffuse_visible_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default: 0.5.” */
    diffuse_visible_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0. */
    infrared_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. */
    emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. */
    emissivity_back?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.01)
    @Max(1)
    /** The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05. */
    distance_to_glass?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. */
    top_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. */
    bottom_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. */
    left_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. */
    right_opening_multiplier?: number;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialBlind";
        this.slat_orientation = SlatOrientation.Horizontal;
        this.slat_width = 0.025;
        this.slat_separation = 0.01875;
        this.slat_thickness = 0.001;
        this.slat_angle = 45;
        this.slat_conductivity = 221;
        this.beam_solar_transmittance = 0;
        this.beam_solar_reflectance = 0.5;
        this.beam_solar_reflectance_back = 0.5;
        this.diffuse_solar_transmittance = 0;
        this.diffuse_solar_reflectance = 0.5;
        this.diffuse_solar_reflectance_back = 0.5;
        this.beam_visible_transmittance = 0;
        this.beam_visible_reflectance = 0.5;
        this.beam_visible_reflectance_back = 0.5;
        this.diffuse_visible_transmittance = 0;
        this.diffuse_visible_reflectance = 0.5;
        this.diffuse_visible_reflectance_back = 0.5;
        this.infrared_transmittance = 0;
        this.emissivity = 0.9;
        this.emissivity_back = 0.9;
        this.distance_to_glass = 0.05;
        this.top_opening_multiplier = 0.5;
        this.bottom_opening_multiplier = 0.5;
        this.left_opening_multiplier = 0.5;
        this.right_opening_multiplier = 0.5;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialBlind, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.slat_orientation = obj.slat_orientation;
            this.slat_width = obj.slat_width;
            this.slat_separation = obj.slat_separation;
            this.slat_thickness = obj.slat_thickness;
            this.slat_angle = obj.slat_angle;
            this.slat_conductivity = obj.slat_conductivity;
            this.beam_solar_transmittance = obj.beam_solar_transmittance;
            this.beam_solar_reflectance = obj.beam_solar_reflectance;
            this.beam_solar_reflectance_back = obj.beam_solar_reflectance_back;
            this.diffuse_solar_transmittance = obj.diffuse_solar_transmittance;
            this.diffuse_solar_reflectance = obj.diffuse_solar_reflectance;
            this.diffuse_solar_reflectance_back = obj.diffuse_solar_reflectance_back;
            this.beam_visible_transmittance = obj.beam_visible_transmittance;
            this.beam_visible_reflectance = obj.beam_visible_reflectance;
            this.beam_visible_reflectance_back = obj.beam_visible_reflectance_back;
            this.diffuse_visible_transmittance = obj.diffuse_visible_transmittance;
            this.diffuse_visible_reflectance = obj.diffuse_visible_reflectance;
            this.diffuse_visible_reflectance_back = obj.diffuse_visible_reflectance_back;
            this.infrared_transmittance = obj.infrared_transmittance;
            this.emissivity = obj.emissivity;
            this.emissivity_back = obj.emissivity_back;
            this.distance_to_glass = obj.distance_to_glass;
            this.top_opening_multiplier = obj.top_opening_multiplier;
            this.bottom_opening_multiplier = obj.bottom_opening_multiplier;
            this.left_opening_multiplier = obj.left_opening_multiplier;
            this.right_opening_multiplier = obj.right_opening_multiplier;
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
        data["slat_orientation"] = this.slat_orientation;
        data["slat_width"] = this.slat_width;
        data["slat_separation"] = this.slat_separation;
        data["slat_thickness"] = this.slat_thickness;
        data["slat_angle"] = this.slat_angle;
        data["slat_conductivity"] = this.slat_conductivity;
        data["beam_solar_transmittance"] = this.beam_solar_transmittance;
        data["beam_solar_reflectance"] = this.beam_solar_reflectance;
        data["beam_solar_reflectance_back"] = this.beam_solar_reflectance_back;
        data["diffuse_solar_transmittance"] = this.diffuse_solar_transmittance;
        data["diffuse_solar_reflectance"] = this.diffuse_solar_reflectance;
        data["diffuse_solar_reflectance_back"] = this.diffuse_solar_reflectance_back;
        data["beam_visible_transmittance"] = this.beam_visible_transmittance;
        data["beam_visible_reflectance"] = this.beam_visible_reflectance;
        data["beam_visible_reflectance_back"] = this.beam_visible_reflectance_back;
        data["diffuse_visible_transmittance"] = this.diffuse_visible_transmittance;
        data["diffuse_visible_reflectance"] = this.diffuse_visible_reflectance;
        data["diffuse_visible_reflectance_back"] = this.diffuse_visible_reflectance_back;
        data["infrared_transmittance"] = this.infrared_transmittance;
        data["emissivity"] = this.emissivity;
        data["emissivity_back"] = this.emissivity_back;
        data["distance_to_glass"] = this.distance_to_glass;
        data["top_opening_multiplier"] = this.top_opening_multiplier;
        data["bottom_opening_multiplier"] = this.bottom_opening_multiplier;
        data["left_opening_multiplier"] = this.left_opening_multiplier;
        data["right_opening_multiplier"] = this.right_opening_multiplier;
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

