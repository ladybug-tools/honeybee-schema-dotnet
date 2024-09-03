import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsEnum, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { ControlType } from "./ControlType";
import { EnergyWindowMaterialBlind } from "./EnergyWindowMaterialBlind";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing";
import { EnergyWindowMaterialShade } from "./EnergyWindowMaterialShade";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";
import { ShadeLocation } from "./ShadeLocation";
import { WindowConstruction } from "./WindowConstruction";

/** Construction for window objects (Aperture, Door). */
export class WindowConstructionShade extends IDdEnergyBaseModel {
    @IsInstance(WindowConstruction)
    @Type(() => WindowConstruction)
    @ValidateNested()
    @IsDefined()
    /** A WindowConstruction object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction. */
    window_construction!: WindowConstruction;
	
    @IsDefined()
    /** Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly. */
    shade_material!: (EnergyWindowMaterialShade | EnergyWindowMaterialBlind | EnergyWindowMaterialGlazing);
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowConstructionShade$/)
    type?: string;
	
    @IsEnum(ShadeLocation)
    @Type(() => String)
    @IsOptional()
    /** Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports. */
    shade_location?: ShadeLocation;
	
    @IsEnum(ControlType)
    @Type(() => String)
    @IsOptional()
    /** Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.” */
    control_type?: ControlType;
	
    @IsNumber()
    @IsOptional()
    /** A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn."" */
    setpoint?: number;
	
    @IsOptional()
    /** An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction. */
    schedule?: (ScheduleRuleset | ScheduleFixedInterval);
	

    constructor() {
        super();
        this.type = "WindowConstructionShade";
        this.shade_location = ShadeLocation.Interior;
        this.control_type = ControlType.AlwaysOn;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WindowConstructionShade, _data);
            this.window_construction = obj.window_construction;
            this.shade_material = obj.shade_material;
            this.type = obj.type;
            this.shade_location = obj.shade_location;
            this.control_type = obj.control_type;
            this.setpoint = obj.setpoint;
            this.schedule = obj.schedule;
        }
    }


    static override fromJS(data: any): WindowConstructionShade {
        data = typeof data === 'object' ? data : {};

        let result = new WindowConstructionShade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["window_construction"] = this.window_construction;
        data["shade_material"] = this.shade_material;
        data["type"] = this.type;
        data["shade_location"] = this.shade_location;
        data["control_type"] = this.control_type;
        data["setpoint"] = this.setpoint;
        data["schedule"] = this.schedule;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
