import { IsNumber, IsDefined, IsString, IsOptional, Matches, Min, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Properties for airflow through a crack. */
export class AFNCrack extends _OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    @Expose({ name: "flow_coefficient" })
    /** A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively. */
    flowCoefficient!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^AFNCrack$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "AFNCrack";
	
    @IsNumber()
    @IsOptional()
    @Min(0.5)
    @Max(1)
    @Expose({ name: "flow_exponent" })
    /** An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured. */
    flowExponent: number = 0.65;
	

    constructor() {
        super();
        this.type = "AFNCrack";
        this.flowExponent = 0.65;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(AFNCrack, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.flowCoefficient = obj.flowCoefficient;
            this.type = obj.type ?? "AFNCrack";
            this.flowExponent = obj.flowExponent ?? 0.65;
        }
    }


    static override fromJS(data: any): AFNCrack {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new AFNCrack();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["flow_coefficient"] = this.flowCoefficient;
        data["type"] = this.type ?? "AFNCrack";
        data["flow_exponent"] = this.flowExponent ?? 0.65;
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
