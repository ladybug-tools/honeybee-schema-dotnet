import { IsNumber, IsDefined, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Describe an entire glazing system rather than individual layers.\n\nUsed when only very limited information is available on the glazing layers or when\nspecific performance levels are being targeted. */
export class EnergyWindowMaterialSimpleGlazSys extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Max(12)
    /** The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted. */
    u_factor!: number;
	
    @IsNumber()
    @IsDefined()
    /** Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation. */
    shgc!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialSimpleGlazSys$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** The fraction of visible light falling on the window that makes it through the glass at normal incidence. */
    vt?: number;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialSimpleGlazSys";
        this.vt = 0.54;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialSimpleGlazSys, _data, { enableImplicitConversion: true });
            this.u_factor = obj.u_factor;
            this.shgc = obj.shgc;
            this.type = obj.type;
            this.vt = obj.vt;
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
        data["u_factor"] = this.u_factor;
        data["shgc"] = this.shgc;
        data["type"] = this.type;
        data["vt"] = this.vt;
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

