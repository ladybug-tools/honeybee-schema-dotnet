import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { Autocalculate } from "./Autocalculate";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class PeopleAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "people_per_area" })
    /** People per floor area expressed as [people/m2] */
    peoplePerArea!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "occupancy_schedule" })
    /** Identifier of a schedule for the occupancy over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the people_per_area to yield a complete occupancy profile. */
    occupancySchedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^PeopleAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "PeopleAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "activity_schedule" })
    /** Identifier of a schedule for the activity of the occupants over the course of the year. The type of this schedule should be ActivityLevel and the values of the schedule equal to the number of Watts given off by an individual person in the room. If None, a default constant schedule with 120 Watts per person will be used, which is typical of awake, adult humans who are seated. */
    activitySchedule?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "radiant_fraction" })
    /** The radiant fraction of sensible heat released by people. (Default: 0.3). */
    radiantFraction: number = 0.3;
	
    @IsOptional()
    @Expose({ name: "latent_fraction" })
    /** Number for the latent fraction of heat gain due to people or an Autocalculate object. */
    latentFraction: (Autocalculate | number) = new Autocalculate();
	

    constructor() {
        super();
        this.type = "PeopleAbridged";
        this.radiantFraction = 0.3;
        this.latentFraction = new Autocalculate();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(PeopleAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.peoplePerArea = obj.peoplePerArea;
            this.occupancySchedule = obj.occupancySchedule;
            this.type = obj.type ?? "PeopleAbridged";
            this.activitySchedule = obj.activitySchedule;
            this.radiantFraction = obj.radiantFraction ?? 0.3;
            this.latentFraction = obj.latentFraction ?? new Autocalculate();
        }
    }


    static override fromJS(data: any): PeopleAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new PeopleAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["people_per_area"] = this.peoplePerArea;
        data["occupancy_schedule"] = this.occupancySchedule;
        data["type"] = this.type ?? "PeopleAbridged";
        data["activity_schedule"] = this.activitySchedule;
        data["radiant_fraction"] = this.radiantFraction ?? 0.3;
        data["latent_fraction"] = this.latentFraction ?? new Autocalculate();
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
