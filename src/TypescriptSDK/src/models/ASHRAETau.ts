import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _SkyCondition } from "./_SkyCondition";

/** Used to specify sky conditions on a design day. */
export class ASHRAETau extends _SkyCondition {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(1.2)
    @Expose({ name: "tau_b" })
    /** Value for the beam optical depth. Typically found in .stat files. */
    tauB!: number;
	
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(3)
    @Expose({ name: "tau_d" })
    /** Value for the diffuse optical depth. Typically found in .stat files. */
    tauD!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^ASHRAETau$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ASHRAETau";
	

    constructor() {
        super();
        this.type = "ASHRAETau";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ASHRAETau, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.tauB = obj.tauB;
            this.tauD = obj.tauD;
            this.type = obj.type ?? "ASHRAETau";
        }
    }


    static override fromJS(data: any): ASHRAETau {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ASHRAETau();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["tau_b"] = this.tauB;
        data["tau_d"] = this.tauD;
        data["type"] = this.type ?? "ASHRAETau";
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
