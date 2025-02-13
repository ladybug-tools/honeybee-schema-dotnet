import { IsString, IsDefined, MinLength, MaxLength, IsEnum, IsInstance, ValidateNested, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ASHRAEClearSky } from "./ASHRAEClearSky";
import { ASHRAETau } from "./ASHRAETau";
import { DesignDayTypes } from "./DesignDayTypes";
import { DryBulbCondition } from "./DryBulbCondition";
import { HumidityCondition } from "./HumidityCondition";
import { WindCondition } from "./WindCondition";

/** An object representing design day conditions. */
export class DesignDay extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    /** Text string for a unique design day name. This name remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). It is also used to reference the object within SimulationParameters. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    name!: string;
	
    @IsEnum(DesignDayTypes)
    @Type(() => String)
    @IsDefined()
    /** DayType */
    day_type!: DesignDayTypes;
	
    @IsInstance(DryBulbCondition)
    @Type(() => DryBulbCondition)
    @ValidateNested()
    @IsDefined()
    /** A DryBulbCondition describing temperature conditions on the design day. */
    dry_bulb_condition!: DryBulbCondition;
	
    @IsInstance(HumidityCondition)
    @Type(() => HumidityCondition)
    @ValidateNested()
    @IsDefined()
    /** A HumidityCondition describing humidity and precipitation conditions on the design day. */
    humidity_condition!: HumidityCondition;
	
    @IsInstance(WindCondition)
    @Type(() => WindCondition)
    @ValidateNested()
    @IsDefined()
    /** A WindCondition describing wind conditions on the design day. */
    wind_condition!: WindCondition;
	
    @IsDefined()
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ASHRAEClearSky') return ASHRAEClearSky.fromJS(item);
      else if (item?.type === 'ASHRAETau') return ASHRAETau.fromJS(item);
      else return item;
    })
    /** SkyCondition */
    sky_condition!: (ASHRAEClearSky | ASHRAETau);
	
    @IsString()
    @IsOptional()
    @Matches(/^DesignDay$/)
    /** Type */
    type?: string;
	

    constructor() {
        super();
        this.type = "DesignDay";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DesignDay, _data, { enableImplicitConversion: true });
            this.name = obj.name;
            this.day_type = obj.day_type;
            this.dry_bulb_condition = obj.dry_bulb_condition;
            this.humidity_condition = obj.humidity_condition;
            this.wind_condition = obj.wind_condition;
            this.sky_condition = obj.sky_condition;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): DesignDay {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DesignDay();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["day_type"] = this.day_type;
        data["dry_bulb_condition"] = this.dry_bulb_condition;
        data["humidity_condition"] = this.humidity_condition;
        data["wind_condition"] = this.wind_condition;
        data["sky_condition"] = this.sky_condition;
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

