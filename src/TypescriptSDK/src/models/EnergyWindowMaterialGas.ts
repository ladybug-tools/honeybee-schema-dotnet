import { IsString, IsOptional, Matches, IsNumber, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { GasType } from "./GasType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Create single layer of gas in a window construction.\n\nCan be combined with EnergyWindowMaterialGlazing to make multi-pane windows. */
export class EnergyWindowMaterialGas extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGas$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialGas";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "thickness" })
    /** Thickness of the gas layer in meters. Default: 0.0125. */
    thickness: number = 0.0125;
	
    @IsEnum(GasType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "gas_type" })
    /** gasType */
    gasType: GasType = GasType.Air;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGas";
        this.thickness = 0.0125;
        this.gasType = GasType.Air;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialGas, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "EnergyWindowMaterialGas";
            this.thickness = obj.thickness ?? 0.0125;
            this.gasType = obj.gasType ?? GasType.Air;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGas {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialGas();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "EnergyWindowMaterialGas";
        data["thickness"] = this.thickness ?? 0.0125;
        data["gas_type"] = this.gasType ?? GasType.Air;
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
