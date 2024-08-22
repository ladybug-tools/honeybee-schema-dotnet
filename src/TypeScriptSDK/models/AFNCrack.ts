import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Properties for airflow through a crack. */
export class AFNCrack extends _OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    /** A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively. */
    flow_coefficient!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured. */
    flow_exponent?: number;
	

    constructor() {
        super();
        this.type = "AFNCrack";
        this.flow_exponent = 0.65;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.flow_coefficient = _data["flow_coefficient"];
            this.type = _data["type"] !== undefined ? _data["type"] : "AFNCrack";
            this.flow_exponent = _data["flow_exponent"] !== undefined ? _data["flow_exponent"] : 0.65;
        }
    }


    static override fromJS(data: any): AFNCrack {
        data = typeof data === 'object' ? data : {};

        let result = new AFNCrack();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["flow_coefficient"] = this.flow_coefficient;
        data["type"] = this.type;
        data["flow_exponent"] = this.flow_exponent;
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
