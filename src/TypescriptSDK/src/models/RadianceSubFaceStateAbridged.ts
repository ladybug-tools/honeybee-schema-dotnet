import { IsInstance, ValidateNested, IsOptional, IsString, Equals, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Face3D } from "./Face3D";
import { StateGeometryAbridged } from "./StateGeometryAbridged";

/** RadianceSubFaceStateAbridged is an abridged state for a dynamic Aperture or Door.\n     */
export class RadianceSubFaceStateAbridged {
    @Type(() => Face3D)
    @IsInstance(Face3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "vmtx_geometry" })
    /** A Face3D for the view matrix geometry (default: None). */
    vmtxGeometry?: Face3D;
	
    @Type(() => Face3D)
    @IsInstance(Face3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "dmtx_geometry" })
    /** A Face3D for the daylight matrix geometry (default: None). */
    dmtxGeometry?: Face3D;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("RadianceSubFaceStateAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "RadianceSubFaceStateAbridged";
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier" })
    /** A Radiance Modifier identifier (default: None). */
    modifier?: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "modifier_direct" })
    /** A Radiance Modifier identifier (default: None). */
    modifierDirect?: string;
	
    @IsArray()
    @Type(() => StateGeometryAbridged)
    @IsInstance(StateGeometryAbridged, { each: true })
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "shades" })
    /** A list of StateGeometryAbridged objects (default: None). */
    shades?: StateGeometryAbridged[];
	

    constructor() {
        this.type = "RadianceSubFaceStateAbridged";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RadianceSubFaceStateAbridged, _data);
            this.vmtxGeometry = obj.vmtxGeometry;
            this.dmtxGeometry = obj.dmtxGeometry;
            this.type = obj.type ?? "RadianceSubFaceStateAbridged";
            this.modifier = obj.modifier;
            this.modifierDirect = obj.modifierDirect;
            this.shades = obj.shades;
        }
    }


    static fromJS(data: any): RadianceSubFaceStateAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RadianceSubFaceStateAbridged();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vmtx_geometry"] = this.vmtxGeometry;
        data["dmtx_geometry"] = this.dmtxGeometry;
        data["type"] = this.type ?? "RadianceSubFaceStateAbridged";
        data["modifier"] = this.modifier;
        data["modifier_direct"] = this.modifierDirect;
        data["shades"] = this.shades;
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
