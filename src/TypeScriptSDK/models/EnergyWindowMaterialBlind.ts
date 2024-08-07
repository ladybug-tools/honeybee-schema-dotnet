import { IsString, IsOptional, IsEnum, ValidateNested, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { SlatOrientation } from "./SlatOrientation";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Window blind material consisting of flat, equally-spaced slats. */
export class EnergyWindowMaterialBlind extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(SlatOrientation)
    @ValidateNested()
    @IsOptional()
    slat_orientation?: SlatOrientation;
	
    @IsNumber()
    @IsOptional()
    /** The width of slat measured from edge to edge in meters. */
    slat_width?: number;
	
    @IsNumber()
    @IsOptional()
    /** The distance between the front of a slat and the back of the adjacent slat in meters. */
    slat_separation?: number;
	
    @IsNumber()
    @IsOptional()
    /** The distance between the faces of a slat in meters. The default value is 0.001. */
    slat_thickness?: number;
	
    @IsNumber()
    @IsOptional()
    /** The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45. */
    slat_angle?: number;
	
    @IsNumber()
    @IsOptional()
    /** The thermal conductivity of the slat in W/(m-K). Default: 221. */
    slat_conductivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0. */
    beam_solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_solar_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    /** The slat transmittance for hemispherically diffuse solar radiation. Default: 0. */
    diffuse_solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The front-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5. */
    diffuse_solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The back-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5. */
    diffuse_solar_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    /** The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default: 0. */
    beam_visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_visible_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5. */
    beam_visible_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    /** The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.” */
    diffuse_visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default: 0.5. */
    diffuse_visible_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default: 0.5.” */
    diffuse_visible_reflectance_back?: number;
	
    @IsNumber()
    @IsOptional()
    /** The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0. */
    infrared_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. */
    emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. */
    emissivity_back?: number;
	
    @IsNumber()
    @IsOptional()
    /** The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05. */
    distance_to_glass?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. */
    top_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. */
    bottom_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. */
    left_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
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
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowMaterialBlind";
            this.slat_orientation = _data["slat_orientation"] !== undefined ? _data["slat_orientation"] : SlatOrientation.Horizontal;
            this.slat_width = _data["slat_width"] !== undefined ? _data["slat_width"] : 0.025;
            this.slat_separation = _data["slat_separation"] !== undefined ? _data["slat_separation"] : 0.01875;
            this.slat_thickness = _data["slat_thickness"] !== undefined ? _data["slat_thickness"] : 0.001;
            this.slat_angle = _data["slat_angle"] !== undefined ? _data["slat_angle"] : 45;
            this.slat_conductivity = _data["slat_conductivity"] !== undefined ? _data["slat_conductivity"] : 221;
            this.beam_solar_transmittance = _data["beam_solar_transmittance"] !== undefined ? _data["beam_solar_transmittance"] : 0;
            this.beam_solar_reflectance = _data["beam_solar_reflectance"] !== undefined ? _data["beam_solar_reflectance"] : 0.5;
            this.beam_solar_reflectance_back = _data["beam_solar_reflectance_back"] !== undefined ? _data["beam_solar_reflectance_back"] : 0.5;
            this.diffuse_solar_transmittance = _data["diffuse_solar_transmittance"] !== undefined ? _data["diffuse_solar_transmittance"] : 0;
            this.diffuse_solar_reflectance = _data["diffuse_solar_reflectance"] !== undefined ? _data["diffuse_solar_reflectance"] : 0.5;
            this.diffuse_solar_reflectance_back = _data["diffuse_solar_reflectance_back"] !== undefined ? _data["diffuse_solar_reflectance_back"] : 0.5;
            this.beam_visible_transmittance = _data["beam_visible_transmittance"] !== undefined ? _data["beam_visible_transmittance"] : 0;
            this.beam_visible_reflectance = _data["beam_visible_reflectance"] !== undefined ? _data["beam_visible_reflectance"] : 0.5;
            this.beam_visible_reflectance_back = _data["beam_visible_reflectance_back"] !== undefined ? _data["beam_visible_reflectance_back"] : 0.5;
            this.diffuse_visible_transmittance = _data["diffuse_visible_transmittance"] !== undefined ? _data["diffuse_visible_transmittance"] : 0;
            this.diffuse_visible_reflectance = _data["diffuse_visible_reflectance"] !== undefined ? _data["diffuse_visible_reflectance"] : 0.5;
            this.diffuse_visible_reflectance_back = _data["diffuse_visible_reflectance_back"] !== undefined ? _data["diffuse_visible_reflectance_back"] : 0.5;
            this.infrared_transmittance = _data["infrared_transmittance"] !== undefined ? _data["infrared_transmittance"] : 0;
            this.emissivity = _data["emissivity"] !== undefined ? _data["emissivity"] : 0.9;
            this.emissivity_back = _data["emissivity_back"] !== undefined ? _data["emissivity_back"] : 0.9;
            this.distance_to_glass = _data["distance_to_glass"] !== undefined ? _data["distance_to_glass"] : 0.05;
            this.top_opening_multiplier = _data["top_opening_multiplier"] !== undefined ? _data["top_opening_multiplier"] : 0.5;
            this.bottom_opening_multiplier = _data["bottom_opening_multiplier"] !== undefined ? _data["bottom_opening_multiplier"] : 0.5;
            this.left_opening_multiplier = _data["left_opening_multiplier"] !== undefined ? _data["left_opening_multiplier"] : 0.5;
            this.right_opening_multiplier = _data["right_opening_multiplier"] !== undefined ? _data["right_opening_multiplier"] : 0.5;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialBlind {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowMaterialBlind();
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
