import { IsString, IsOptional, IsNumber, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for Shade objects. */
export class ShadeConstruction extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A number for the solar reflectance of the construction. */
    solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the visible reflectance of the construction. */
    visible_reflectance?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material. */
    is_specular?: boolean;
	

    constructor() {
        super();
        this.type = "ShadeConstruction";
        this.solar_reflectance = 0.2;
        this.visible_reflectance = 0.2;
        this.is_specular = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ShadeConstruction";
            this.solar_reflectance = _data["solar_reflectance"] !== undefined ? _data["solar_reflectance"] : 0.2;
            this.visible_reflectance = _data["visible_reflectance"] !== undefined ? _data["visible_reflectance"] : 0.2;
            this.is_specular = _data["is_specular"] !== undefined ? _data["is_specular"] : false;
        }
    }


    static override fromJS(data: any): ShadeConstruction {
        data = typeof data === 'object' ? data : {};

        let result = new ShadeConstruction();
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
        data["solar_reflectance"] = this.solar_reflectance;
        data["visible_reflectance"] = this.visible_reflectance;
        data["is_specular"] = this.is_specular;
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
