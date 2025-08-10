import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Max, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class _EquipmentBase extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "watts_per_area" })
    /** Equipment level per floor area as [W/m2]. */
    wattsPerArea!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. */
    schedule!: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "radiant_fraction" })
    /** Number for the amount of long-wave radiation heat given off by equipment. Default value is 0. */
    radiantFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_fraction" })
    /** Number for the amount of latent heat given off by equipment. Default value is 0. */
    latentFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "lost_fraction" })
    /** Number for the amount of “lost” heat being given off by equipment. The default value is 0. */
    lostFraction: number = 0;
	
    @IsString()
    @IsOptional()
    @Matches(/^_EquipmentBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_EquipmentBase";
	

    constructor() {
        super();
        this.radiantFraction = 0;
        this.latentFraction = 0;
        this.lostFraction = 0;
        this.type = "_EquipmentBase";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(_EquipmentBase, _data);
            this.wattsPerArea = obj.wattsPerArea;
            this.schedule = obj.schedule;
            this.radiantFraction = obj.radiantFraction ?? 0;
            this.latentFraction = obj.latentFraction ?? 0;
            this.lostFraction = obj.lostFraction ?? 0;
            this.type = obj.type ?? "_EquipmentBase";
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): _EquipmentBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _EquipmentBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["watts_per_area"] = this.wattsPerArea;
        data["schedule"] = this.schedule;
        data["radiant_fraction"] = this.radiantFraction ?? 0;
        data["latent_fraction"] = this.latentFraction ?? 0;
        data["lost_fraction"] = this.lostFraction ?? 0;
        data["type"] = this.type ?? "_EquipmentBase";
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
