import { IsNumber, IsDefined, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Describe an entire glazing system rather than individual layers.\n\nUsed when only very limited information is available on the glazing layers or when\nspecific performance levels are being targeted. */
export class EnergyWindowMaterialSimpleGlazSys extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Max(12)
    @Expose({ name: "u_factor" })
    /** The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted. */
    uFactor!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "shgc" })
    /** Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation. */
    shgc!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialSimpleGlazSys$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialSimpleGlazSys";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "vt" })
    /** The fraction of visible light falling on the window that makes it through the glass at normal incidence. */
    vt: number = 0.54;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialSimpleGlazSys";
        this.vt = 0.54;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialSimpleGlazSys, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.uFactor = obj.uFactor;
            this.shgc = obj.shgc;
            this.type = obj.type ?? "EnergyWindowMaterialSimpleGlazSys";
            this.vt = obj.vt ?? 0.54;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialSimpleGlazSys {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialSimpleGlazSys();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["u_factor"] = this.uFactor;
        data["shgc"] = this.shgc;
        data["type"] = this.type ?? "EnergyWindowMaterialSimpleGlazSys";
        data["vt"] = this.vt ?? 0.54;
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
