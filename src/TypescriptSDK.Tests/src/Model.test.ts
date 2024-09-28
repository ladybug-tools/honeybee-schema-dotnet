import { plainToClass } from "class-transformer";
import { Model, Face3D, Glass, Plane, Face, GlobalModifierSet, Plastic } from "honeybee-schema";
import * as fs from 'fs';
import * as path from 'path';

test('test model', () => {
  const dir = path.dirname(path.dirname(path.dirname(__dirname)));
  // console.log(dir);
  const sampleDir = path.join(dir, 'samples');
  // console.log(sampleDir);

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


});



test('test toJson', () => {
  let obj = new Face3D();

  let json = obj.toJSON();
  let hasPlane = json.hasOwnProperty('plane');
  expect(hasPlane).toBe(false);
  expect(json).not.toEqual(expect.objectContaining({ plane: expect.anything() }));

  obj = new Face3D();

  obj.plane = new Plane();
  expect(obj.plane).toBeInstanceOf(Plane);

  // test toJSON to plain object
  json = obj.toJSON();
  expect(json).toHaveProperty('plane');
  expect( json.plane instanceof Plane).toBe(false);

});

test('test toJson2', () => {
  let obj = new Face();
  expect(obj).toHaveProperty('apertures');
  expect(obj.apertures).toBeUndefined();

  let jsonObj = obj.toJSON();
  const hasProp = jsonObj.hasOwnProperty('apertures');
  expect(hasProp).toBe(false);
});


const GlobalModifierSetData = {
  "shade_set": {
      "type": "ShadeModifierSetAbridged",
      "interior_modifier": "generic_interior_shade_0.50",
      "exterior_modifier": "generic_exterior_shade_0.35"
  },
  "roof_ceiling_set": {
      "type": "RoofCeilingModifierSetAbridged",
      "interior_modifier": "generic_ceiling_0.80",
      "exterior_modifier": "generic_ceiling_0.80"
  },
  "context_modifier": "generic_context_0.20",
  "modifiers": [
      {
          "dependencies": [],
          "modifier": null,
          "g_reflectance": 0.5,
          "identifier": "generic_wall_0.50",
          "specularity": 0,
          "b_reflectance": 0.5,
          "r_reflectance": 0.5,
          "type": "Plastic",
          "roughness": 0
      },
      {
          "b_transmissivity": 0.9584154328610596,
          "r_transmissivity": 0.9584154328610596,
          "modifier": null,
          "identifier": "generic_interior_window_vis_0.88",
          "refraction_index": null,
          "type": "Glass",
          "dependencies": [],
          "g_transmissivity": 0.9584154328610596
      }
  ],
  
  "type": "GlobalModifierSet",
};

test('test modifiers', () => {
  const data = GlobalModifierSetData;
  
  const obj = GlobalModifierSet.fromJS(data);
  const mod = obj.modifiers?.at(0);
  expect(mod).toBeInstanceOf(Plastic);
  expect(mod?.identifier).toBe('generic_wall_0.50');

  const glass = obj.modifiers?.at(1) as Glass;
  expect(glass).toBeInstanceOf(Glass);
  expect(glass.b_transmissivity).toBe(0.9584154328610596);
}
);


test('test GlobalModifierSet', () => {
  const obj = new GlobalModifierSet();
  const mod = obj.modifiers?.at(0);
  expect(mod).toBeInstanceOf(Plastic);
  expect(mod?.identifier).toBe('generic_floor_0.20');
}
);


test('test Plastic', () => {
  const data = {
    "dependencies": [],
    "modifier": null,
    "g_reflectance": 0.5,
    "identifier": "generic_wall_0.50",
    "specularity": 0,
    "b_reflectance": 0.5,
    "r_reflectance": 0.5,
    "type": "Plastic",
    "roughness": 0
};

  const obj = Plastic.fromJS(data);
  expect(obj).toBeInstanceOf(Plastic);
  expect(obj?.identifier).toBe('generic_wall_0.50');
}
);