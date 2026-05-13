import { IsString, IsDefined, MinLength, MaxLength, IsEnum, IsInstance, ValidateNested, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ASHRAEClearSky } from "./ASHRAEClearSky";
import { ASHRAETau } from "./ASHRAETau";
import { DesignDayTypes } from "./DesignDayTypes";
import { DryBulbCondition } from "./DryBulbCondition";
import { HumidityCondition } from "./HumidityCondition";
import { WindCondition } from "./WindCondition";

/** An object representing design day conditions. */
export class DesignDay extends _OpenAPIGenBaseModel {
    @Type(() => String)
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "name" })
    /** Text string for a unique design day name. This name remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). It is also used to reference the object within SimulationParameters. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    name!: string;
	
    @Type(() => String)
    @IsEnum(DesignDayTypes)
    @IsDefined()
    @Expose({ name: "day_type" })
    /** dayType */
    dayType!: DesignDayTypes;
	
    @Type(() => DryBulbCondition)
    @IsInstance(DryBulbCondition)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "dry_bulb_condition" })
    /** A DryBulbCondition describing temperature conditions on the design day. */
    dryBulbCondition!: DryBulbCondition;
	
    @Type(() => HumidityCondition)
    @IsInstance(HumidityCondition)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "humidity_condition" })
    /** A HumidityCondition describing humidity and precipitation conditions on the design day. */
    humidityCondition!: HumidityCondition;
	
    @Type(() => WindCondition)
    @IsInstance(WindCondition)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "wind_condition" })
    /** A WindCondition describing wind conditions on the design day. */
    windCondition!: WindCondition;
	
    @IsDefined()
    @Expose({ name: "sky_condition" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ASHRAEClearSky') return ASHRAEClearSky.fromJS(item);
      else if (item?.type === 'ASHRAETau') return ASHRAETau.fromJS(item);
      else return item;
    })
    /** skyCondition */
    skyCondition!: (ASHRAEClearSky | ASHRAETau);
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("DesignDay")
    @Expose({ name: "type" })
    /** type */
    type: string = "DesignDay";
	

    constructor() {
        super();
        this.type = "DesignDay";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DesignDay, _data);
            this.name = obj.name;
            this.dayType = obj.dayType;
            this.dryBulbCondition = obj.dryBulbCondition;
            this.humidityCondition = obj.humidityCondition;
            this.windCondition = obj.windCondition;
            this.skyCondition = obj.skyCondition;
            this.type = obj.type ?? "DesignDay";
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
        data["day_type"] = this.dayType;
        data["dry_bulb_condition"] = this.dryBulbCondition;
        data["humidity_condition"] = this.humidityCondition;
        data["wind_condition"] = this.windCondition;
        data["sky_condition"] = this.skyCondition;
        data["type"] = this.type ?? "DesignDay";
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
