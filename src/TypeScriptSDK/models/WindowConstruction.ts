import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, IsInstance, validate, ValidationError } from 'class-validator';
import { EnergyWindowMaterialSimpleGlazSys } from "./EnergyWindowMaterialSimpleGlazSys";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing";
import { EnergyWindowMaterialGas } from "./EnergyWindowMaterialGas";
import { EnergyWindowMaterialGasCustom } from "./EnergyWindowMaterialGasCustom";
import { EnergyWindowMaterialGasMixture } from "./EnergyWindowMaterialGasMixture";
import { EnergyWindowFrame } from "./EnergyWindowFrame";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for window objects (Aperture, Door). */
export class WindowConstruction extends IDdEnergyBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** List of glazing and gas material definitions. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. */
    materials!: (EnergyWindowMaterialSimpleGlazSys | EnergyWindowMaterialGlazing | EnergyWindowMaterialGas | EnergyWindowMaterialGasCustom | EnergyWindowMaterialGasMixture) [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(EnergyWindowFrame)
    @ValidateNested()
    @IsOptional()
    /** An optional window frame material for the frame that surrounds the window construction. */
    frame?: EnergyWindowFrame;
	

    constructor() {
        super();
        this.type = "WindowConstruction";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.materials = _data["materials"];
            this.type = _data["type"] !== undefined ? _data["type"] : "WindowConstruction";
            this.frame = _data["frame"];
        }
    }


    static override fromJS(data: any): WindowConstruction {
        data = typeof data === 'object' ? data : {};

        let result = new WindowConstruction();
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
        data["frame"] = this.frame;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
