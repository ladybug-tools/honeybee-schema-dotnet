import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for Shade objects. */
export class ShadeConstruction extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeConstruction$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadeConstruction";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "solar_reflectance" })
    /** A number for the solar reflectance of the construction. */
    solarReflectance: number = 0.2;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "visible_reflectance" })
    /** A number for the visible reflectance of the construction. */
    visibleReflectance: number = 0.2;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "is_specular" })
    /** Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material. */
    isSpecular: boolean = false;
	

    constructor() {
        super();
        this.type = "ShadeConstruction";
        this.solarReflectance = 0.2;
        this.visibleReflectance = 0.2;
        this.isSpecular = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ShadeConstruction, _data);
            this.type = obj.type ?? "ShadeConstruction";
            this.solarReflectance = obj.solarReflectance ?? 0.2;
            this.visibleReflectance = obj.visibleReflectance ?? 0.2;
            this.isSpecular = obj.isSpecular ?? false;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ShadeConstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeConstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ShadeConstruction";
        data["solar_reflectance"] = this.solarReflectance ?? 0.2;
        data["visible_reflectance"] = this.visibleReflectance ?? 0.2;
        data["is_specular"] = this.isSpecular ?? false;
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
