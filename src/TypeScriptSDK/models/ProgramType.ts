import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { People } from "./People";
import { Lighting } from "./Lighting";
import { ElectricEquipment } from "./ElectricEquipment";
import { GasEquipment } from "./GasEquipment";
import { ServiceHotWater } from "./ServiceHotWater";
import { Infiltration } from "./Infiltration";
import { Ventilation } from "./Ventilation";
import { Setpoint } from "./Setpoint";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ProgramType extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(People)
    @ValidateNested()
    @IsOptional()
    /** People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. */
    people?: People;
	
    @IsInstance(Lighting)
    @ValidateNested()
    @IsOptional()
    /** Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. */
    lighting?: Lighting;
	
    @IsInstance(ElectricEquipment)
    @ValidateNested()
    @IsOptional()
    /** ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. */
    electric_equipment?: ElectricEquipment;
	
    @IsInstance(GasEquipment)
    @ValidateNested()
    @IsOptional()
    /** GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. */
    gas_equipment?: GasEquipment;
	
    @IsInstance(ServiceHotWater)
    @ValidateNested()
    @IsOptional()
    /** ServiceHotWater object to describe the usage of hot water within the program. If None, no hot water will be assumed. */
    service_hot_water?: ServiceHotWater;
	
    @IsInstance(Infiltration)
    @ValidateNested()
    @IsOptional()
    /** Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. */
    infiltration?: Infiltration;
	
    @IsInstance(Ventilation)
    @ValidateNested()
    @IsOptional()
    /** Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. */
    ventilation?: Ventilation;
	
    @IsInstance(Setpoint)
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
            this.type = _data["type"] !== undefined ? _data["type"] : "ProgramType";
            this.people = _data["people"];
            this.lighting = _data["lighting"];
            this.electric_equipment = _data["electric_equipment"];
            this.gas_equipment = _data["gas_equipment"];
            this.service_hot_water = _data["service_hot_water"];
            this.infiltration = _data["infiltration"];
            this.ventilation = _data["ventilation"];
            this.setpoint = _data["setpoint"];
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
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["people"] = this.people;
        data["lighting"] = this.lighting;
        data["electric_equipment"] = this.electric_equipment;
        data["gas_equipment"] = this.gas_equipment;
        data["service_hot_water"] = this.service_hot_water;
        data["infiltration"] = this.infiltration;
        data["ventilation"] = this.ventilation;
        data["setpoint"] = this.setpoint;
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
