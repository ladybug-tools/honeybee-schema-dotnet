import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for Shade objects. */
export class ShadeConstruction extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeConstruction$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number for the solar reflectance of the construction. */
    solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
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
            const obj = plainToClass(ShadeConstruction, _data);
            this.type = obj.type;
            this.solar_reflectance = obj.solar_reflectance;
            this.visible_reflectance = obj.visible_reflectance;
            this.is_specular = obj.is_specular;
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
        data["type"] = this.type;
        data["solar_reflectance"] = this.solar_reflectance;
        data["visible_reflectance"] = this.visible_reflectance;
        data["is_specular"] = this.is_specular;
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

