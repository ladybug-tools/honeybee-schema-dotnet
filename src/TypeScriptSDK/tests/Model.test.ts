import { plainToClass } from "class-transformer";
import { Model, Face3D, Glass, Plane } from "../models";
import * as fs from 'fs';
import * as path from 'path';

test('test model', () => {
  const dir = path.dirname(path.dirname(path.dirname(__dirname)));
  console.log(dir);
  const sampleDir = path.join(dir, 'samples');
  console.log(sampleDir);

  const filePath = path.join(sampleDir, 'ShoeBox.json');
  const jsonData = fs.readFileSync(filePath, 'utf8');
  // console.log(jsonData);

  const json = JSON.parse(jsonData);
  const model = Model.fromJS(json);
  expect(model.display_name).toBe("ShoeBox0.5");
  expect(model.validate()).resolves.toBe(true);


  model.properties.radiance
});


test('test face3D', () => {
  const json = {
    "type": "Face3D",
    "boundary": [
      [5.0, 0.0, 3.3],
      [5.0, 0.0, 0.0]
    ]
  }
  const loc = plainToClass(Face3D, json);
  expect(loc.validate()).resolves.toBe(true);

  const json2 = {
    "type": "Face3D",
    "boundary": [
      [5.0, 0.0, "aa"],
      [5.0, 0.0, 0.0]
    ]
  }
  const loc2 = plainToClass(Face3D, json2);
  expect(loc2.validate()).rejects.toThrow("Validation failed");


});

test('test glass', () => {
  const json = {
    "modifier": {
        "type": "Void"
    },
    "type": "Glass",
    "identifier": "generic_interior_window_vis_0.88",
    "r_transmissivity": 0.9584154328610596,
    "g_transmissivity": 0.9584154328610596,
    "b_transmissivity": 0.9584154328610596,
    "refraction_index": null,
    "dependencies": []
  }
  const loc = Glass.fromJS(json);
  expect(loc.validate()).resolves.toBe(true);

  console.log(typeof loc.modifier)

  

});



test('test toJson', () => {
  let obj = new Face3D();

  let json = obj.toJSON();
  let hasPlane = json.hasOwnProperty('plane');
  console.log(json)
  expect(hasPlane).toBe(false);

  obj = new Face3D();
  console.log(typeof obj);

  obj.plane = new Plane();
  let p = obj.plane;
  let isPlaneType = p instanceof Plane;
  console.log(isPlaneType);
  expect(isPlaneType).toBe(true);


  json = obj.toJSON();
  hasPlane = json.hasOwnProperty('plane');
  expect(hasPlane).toBe(true);
  console.log(json);

  // const json2 = JSON.stringify(json);
  // json = JSON.parse(json2);

  p = json.plane;
  isPlaneType = p instanceof Plane;
  console.log(isPlaneType);
  expect(isPlaneType).toBe(false);



});

