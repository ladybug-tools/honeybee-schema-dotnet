import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _SkyCondition } from "./_SkyCondition";

/** Used to specify sky conditions on a design day. */
export class ASHRAEClearSky extends _SkyCondition {
    @IsNumber()
    @IsDefined()
    /** Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level. */
    clearness!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "ASHRAEClearSky";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.clearness = _data["clearness"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ASHRAEClearSky";
        }
    }


    static override fromJS(data: any): ASHRAEClearSky {
        data = typeof data === 'object' ? data : {};

        let result = new ASHRAEClearSky();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["clearness"] = this.clearness;
        data["type"] = this.type;
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
