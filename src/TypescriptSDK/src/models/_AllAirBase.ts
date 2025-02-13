import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Base class for all-air systems.\n\nAll-air systems provide both ventilation and heating + cooling demand with\nthe same stream of warm/cool air. As such, they often grant tight control\nover zone humidity. However, because such systems often involve the\ncooling of air only to reheat it again, they are often more energy intensive\nthan systems that separate ventilation from the meeting of thermal loads. */
export class _AllAirBase extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsEnum(AllAirEconomizerType)
    @Type(() => String)
    @IsOptional()
    /** Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration). */
    economizer_type?: AllAirEconomizerType;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latent_heat_recovery?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demand_controlled_ventilation?: boolean;
	
    @IsString()
    @IsOptional()
    @Matches(/^_AllAirBase$/)
    /** Type */
    type?: string;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.economizer_type = AllAirEconomizerType.NoEconomizer;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.demand_controlled_ventilation = false;
        this.type = "_AllAirBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_AllAirBase, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.economizer_type = obj.economizer_type;
            this.sensible_heat_recovery = obj.sensible_heat_recovery;
            this.latent_heat_recovery = obj.latent_heat_recovery;
            this.demand_controlled_ventilation = obj.demand_controlled_ventilation;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _AllAirBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _AllAirBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage;
        data["economizer_type"] = this.economizer_type;
        data["sensible_heat_recovery"] = this.sensible_heat_recovery;
        data["latent_heat_recovery"] = this.latent_heat_recovery;
        data["demand_controlled_ventilation"] = this.demand_controlled_ventilation;
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

