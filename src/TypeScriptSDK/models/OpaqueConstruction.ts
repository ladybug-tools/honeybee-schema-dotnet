import { IsArray, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { EnergyMaterial } from "./EnergyMaterial";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass";
import { EnergyMaterialVegetation } from "./EnergyMaterialVegetation";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for opaque objects (Face, Shade, Door). */
export class OpaqueConstruction extends IDdEnergyBaseModel {
    @IsArray()
    @IsDefined()
    /** List of opaque material definitions. The order of the materials is from exterior to interior. */
    materials!: (EnergyMaterial | EnergyMaterialNoMass | EnergyMaterialVegetation) [];
	
    @IsString()
    @IsOptional()
    @Matches(/^OpaqueConstruction$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "OpaqueConstruction";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(OpaqueConstruction, _data);
            this.materials = obj.materials;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): OpaqueConstruction {
        data = typeof data === 'object' ? data : {};

        let result = new OpaqueConstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["materials"] = this.materials;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
