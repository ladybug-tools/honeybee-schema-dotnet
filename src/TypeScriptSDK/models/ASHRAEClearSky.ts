import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _SkyCondition } from "./_SkyCondition";

/** Used to specify sky conditions on a design day. */
export class ASHRAEClearSky extends _SkyCondition {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(1.2)
    /** Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level. */
    clearness!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^ASHRAEClearSky$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "ASHRAEClearSky";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ASHRAEClearSky, _data, { enableImplicitConversion: true });
            this.clearness = obj.clearness;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): ASHRAEClearSky {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ASHRAEClearSky();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["clearness"] = this.clearness;
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

