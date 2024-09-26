/** @type {import('ts-jest').JestConfigWithTsJest} **/
module.exports = {
  testEnvironment: "node",
  setupFiles: ['./src/jest.setup.ts'],
  transform: {
    '^.+\\.tsx?$': 'ts-jest',
  },
};