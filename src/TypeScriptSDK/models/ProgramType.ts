import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { ElectricEquipment } from "./ElectricEquipment";
import { GasEquipment } from "./GasEquipment";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Infiltration } from "./Infiltration";
import { Lighting } from "./Lighting";
import { People } from "./People";
import { ServiceHotWater } from "./ServiceHotWater";
import { Setpoint } from "./Setpoint";
import { Ventilation } from "./Ventilation";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ProgramType extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ProgramType$/)
    type?: string;
	
    @IsInstance(People)
    @Type(() => People)
    @ValidateNested()
    @IsOptional()
    /** People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. */
    people?: People;
	
    @IsInstance(Lighting)
    @Type(() => Lighting)
    @ValidateNested()
    @IsOptional()
    /** Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. */
    lighting?: Lighting;
	
    @IsInstance(ElectricEquipment)
    @Type(() => ElectricEquipment)
    @ValidateNested()
    @IsOptional()
    /** ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. */
    electric_equipment?: ElectricEquipment;
	
    @IsInstance(GasEquipment)
    @Type(() => GasEquipment)
    @ValidateNested()
    @IsOptional()
    /** GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. */
    gas_equipment?: GasEquipment;
	
    @IsInstance(ServiceHotWater)
    @Type(() => ServiceHotWater)
    @ValidateNested()
    @IsOptional()
    /** ServiceHotWater object to describe the usage of hot water within the program. If None, no hot water will be assumed. */
    service_hot_water?: ServiceHotWater;
	
    @IsInstance(Infiltration)
    @Type(() => Infiltration)
    @ValidateNested()
    @IsOptional()
    /** Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. */
    infiltration?: Infiltration;
	
    @IsInstance(Ventilation)
    @Type(() => Ventilation)
    @ValidateNested()
    @IsOptional()
    /** Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. */
    ventilation?: Ventilation;
	
    @IsInstance(Setpoint)
    @Type(() => Setpoint)
    @ValidateNested()
    @IsOptional()
    /** Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned. */
    setpoint?: Setpoint;
	

    constructor() {
        super();
        this.type = "ProgramType";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ProgramType, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.people = obj.people;
            this.lighting = obj.lighting;
            this.electric_equipment = obj.electric_equipment;
            this.gas_equipment = obj.gas_equipment;
            this.service_hot_water = obj.service_hot_water;
            this.infiltration = obj.infiltration;
            this.ventilation = obj.ventilation;
            this.setpoint = obj.setpoint;
        }
    }


    static override fromJS(data: any): ProgramType {
        data = typeof data === 'object' ? data : {};

        let result = new ProgramType();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electric_equipment;
        data["gas_equipment"] = this.gas_equipment;
        data["service_hot_water"] = this.service_hot_water;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
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

