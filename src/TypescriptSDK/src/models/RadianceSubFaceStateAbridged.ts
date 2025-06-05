import { IsInstance, ValidateNested, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { Face3D } from "./Face3D";
import { RadianceShadeStateAbridged } from "./RadianceShadeStateAbridged";

/** RadianceSubFaceStateAbridged is an abridged state for a dynamic Aperture or Door.\n     */
export class RadianceSubFaceStateAbridged extends RadianceShadeStateAbridged {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "vmtx_geometry" })
    /** A Face3D for the view matrix geometry (default: None). */
    vmtxGeometry?: Face3D;
	
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "dmtx_geometry" })
    /** A Face3D for the daylight matrix geometry (default: None). */
    dmtxGeometry?: Face3D;
	
    @IsString()
    @IsOptional()
    @Matches(/^RadianceSubFaceStateAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RadianceSubFaceStateAbridged";
	

    constructor() {
        super();
        this.type = "RadianceSubFaceStateAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RadianceSubFaceStateAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.vmtxGeometry = obj.vmtxGeometry;
            this.dmtxGeometry = obj.dmtxGeometry;
            this.type = obj.type ?? "RadianceSubFaceStateAbridged";
        }
    }


    static override fromJS(data: any): RadianceSubFaceStateAbridged {
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

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vmtx_geometry"] = this.vmtxGeometry;
        data["dmtx_geometry"] = this.dmtxGeometry;
        data["type"] = this.type ?? "RadianceSubFaceStateAbridged";
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
