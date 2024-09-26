import { ProjectInfo } from 'honeybee-schema';
import { sum } from './sum';

test('adds 1 + 2 to equal 3', () => {
  expect(sum(1, 2)).toBe(3);
});


test('tt', () => {
  const obj = new ProjectInfo();
  obj.north = 10;
  const jsonObj = obj.toJSON();
  expect(jsonObj.north).toBe(10);
}
);

