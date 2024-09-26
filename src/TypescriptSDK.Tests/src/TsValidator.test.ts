
import { IsArray, ValidateNested, IsNumber, IsDefined, IsString, IsOptional, Matches, IsInstance, validate, registerDecorator, ValidationOptions, ValidationArguments, ValidationError as TsValidationError } from 'class-validator';
import { Type,Transform, plainToClass } from 'class-transformer';

import * as fs from 'fs';
import * as path from 'path';
import { IsNestedNumberArray } from 'honeybee-schema/helpers/class-validator';



test('test 2d array', () => {
  const json = {
    "type": "Face3D",
    "boundary": [
      [5.0, 0.0, 3.3],
      [5.0, 0.0, 0.0]
    ]
  }
  const loc = plainToClass(Face3D, json);
  console.log(loc);
  console.log(loc.boundary);
  console.log(loc.boundary[0]);
  console.log(typeof loc.boundary[0]);

    // expect(loc?.type).toBe("Face3D");
  expect(loc.validate()).resolves.toBe(true);
});


test('ArrayOfObjectsDto', () => {
  const json = {
    "objectsCollection": [{
      "field":66.3,
      "field2": "aa66"
    }
    ]
  }
  const json2 = {
    "objectsCollection": [{
      "field":"66.3t",
      "field2": "aa66"
    }
    ]
  }
  const loc = plainToClass(ArrayOfObjectsDto, json);
  const loc2 = plainToClass(ArrayOfObjectsDto, json2);
  console.log(loc);
  console.log(typeof loc);
  console.log(typeof loc.objectsCollection);
  expect(loc.validate()).resolves.toBe(true);
  expect(loc2.validate()).rejects.toThrow("Validation failed");

//   validate(loc).then(errors => {
//     if (errors.length > 0) {
//         console.log('Validation failed:', errors);
//     } else {
//         console.log('Validation succeeded:', loc);
//     }
// });
});


export class __ValidateBase {

  async validate(): Promise<boolean> {
    const errors = await validate(this);
    if (errors.length > 0){
  const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      throw new Error(`Validation failed: ${errorMessages}`);
}
    return true;
}
}





class NumberArray extends Array<number>
{
    constructor(...items: number[]) {
        super(...items);
    }
}

class Face3DNumberArray extends __ValidateBase {
  @IsArray()
  // @IsArray({ each: true })
  @ValidateNested({ each: true })
  @IsInstance(NumberArray,{each: true })
  @Type(() => NumberArray)
  // @IsNumber({},{ each: true })
  @IsDefined()
  // @Transform(({ value }) => new NumberArray(...value), { toClassOnly: true })
  @Transform(({ value }) => value.map((arr: number[]) => new NumberArray(...arr)), { toClassOnly: true })
  /** A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. */
  boundary!: NumberArray [];
}

class Face3D extends __ValidateBase {
  @IsNestedNumberArray()
  @IsDefined()
  /** A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. */
  boundary!: number [] [];
}

export class NestedObject {
  @IsNumber()
  field?: number;

  @IsString()
  field2?: string;

}

export class ArrayOfObjectsDto extends __ValidateBase {
  @IsArray()
  @ValidateNested({ each: true })
  @IsInstance(NestedObject,{each: true })
  @Type(() => NestedObject)
  objectsCollection?: NestedObject[];

}

