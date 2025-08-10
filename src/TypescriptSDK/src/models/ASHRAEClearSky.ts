import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _SkyCondition } from "./_SkyCondition";

/** Used to specify sky conditions on a design day. */
export class ASHRAEClearSky extends _SkyCondition {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(1.2)
    @Expose({ name: "clearness" })
    /** Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level. */
    clearness!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^ASHRAEClearSky$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ASHRAEClearSky";
	

    constructor() {
        super();
        this.type = "ASHRAEClearSky";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ASHRAEClearSky, _data);
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
        data["type"] = this.type ?? "ASHRAEClearSky";
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
