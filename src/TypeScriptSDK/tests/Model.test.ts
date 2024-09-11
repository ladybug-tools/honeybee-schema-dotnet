import { plainToClass } from "class-transformer";
import { Model, Face3D, Glass } from "../models";
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


