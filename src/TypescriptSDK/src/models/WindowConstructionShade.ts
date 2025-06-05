import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsEnum, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "window_construction" })
    /** A WindowConstruction object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction. */
    windowConstruction!: WindowConstruction;
	
    @IsDefined()
    @Expose({ name: "shade_material" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'EnergyWindowMaterialShade') return EnergyWindowMaterialShade.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialBlind') return EnergyWindowMaterialBlind.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialGlazing') return EnergyWindowMaterialGlazing.fromJS(item);
      else return item;
    })
    /** Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly. */
    shadeMaterial!: (EnergyWindowMaterialShade | EnergyWindowMaterialBlind | EnergyWindowMaterialGlazing);
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowConstructionShade$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WindowConstructionShade";
	
    @IsEnum(ShadeLocation)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "shade_location" })
    /** Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports. */
    shadeLocation: ShadeLocation = ShadeLocation.Interior;
	
    @IsEnum(ControlType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "control_type" })
    /** Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.” */
    controlType: ControlType = ControlType.AlwaysOn;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "setpoint" })
    /** A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn."" */
    setpoint?: number;
	
    @IsOptional()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction. */
    schedule?: (ScheduleRuleset | ScheduleFixedInterval);
	

    constructor() {
        super();
        this.type = "WindowConstructionShade";
        this.shadeLocation = ShadeLocation.Interior;
        this.controlType = ControlType.AlwaysOn;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WindowConstructionShade, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.windowConstruction = obj.windowConstruction;
            this.shadeMaterial = obj.shadeMaterial;
            this.type = obj.type ?? "WindowConstructionShade";
            this.shadeLocation = obj.shadeLocation ?? ShadeLocation.Interior;
            this.controlType = obj.controlType ?? ControlType.AlwaysOn;
            this.setpoint = obj.setpoint;
            this.schedule = obj.schedule;
        }
    }


    static override fromJS(data: any): WindowConstructionShade {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WindowConstructionShade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["window_construction"] = this.windowConstruction;
        data["shade_material"] = this.shadeMaterial;
        data["type"] = this.type ?? "WindowConstructionShade";
        data["shade_location"] = this.shadeLocation ?? ShadeLocation.Interior;
        data["control_type"] = this.controlType ?? ControlType.AlwaysOn;
        data["setpoint"] = this.setpoint;
        data["schedule"] = this.schedule;
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
