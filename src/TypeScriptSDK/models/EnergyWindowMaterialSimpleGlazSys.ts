import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Describe an entire glazing system rather than individual layers.

Used when only very limited information is available on the glazing layers or when
specific performance levels are being targeted. */
export class EnergyWindowMaterialSimpleGlazSys extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted. */
    u_factor!: number;
	
    @IsNumber()
    @IsDefined()
    /** Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation. */
    shgc!: number;
	
    @IsString()
    @IsOptional()
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
            this.u_factor = _data["u_factor"];
            this.shgc = _data["shgc"];
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowMaterialSimpleGlazSys";
            this.vt = _data["vt"] !== undefined ? _data["vt"] : 0.54;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialSimpleGlazSys {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowMaterialSimpleGlazSys();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["u_factor"] = this.u_factor;
        data["shgc"] = this.shgc;
        data["type"] = this.type;
        data["vt"] = this.vt;
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
