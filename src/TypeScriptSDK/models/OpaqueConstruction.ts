import { IsArray, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { EnergyMaterial } from "./EnergyMaterial.ts";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass.ts";
import { EnergyMaterialVegetation } from "./EnergyMaterialVegetation.ts";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel.ts";

/** Construction for opaque objects (Face, Shade, Door). */
export class OpaqueConstruction extends IDdEnergyBaseModel {
    @IsArray()
    @IsDefined()
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'EnergyMaterial') return EnergyMaterial.fromJS(item);
      else if (item?.type === 'EnergyMaterialNoMass') return EnergyMaterialNoMass.fromJS(item);
      else if (item?.type === 'EnergyMaterialVegetation') return EnergyMaterialVegetation.fromJS(item);
      else return item;
    }))
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
            const obj = plainToClass(OpaqueConstruction, _data, { enableImplicitConversion: true });
            this.materials = obj.materials;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): OpaqueConstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new OpaqueConstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["materials"] = this.materials;
        data["type"] = this.type;
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

