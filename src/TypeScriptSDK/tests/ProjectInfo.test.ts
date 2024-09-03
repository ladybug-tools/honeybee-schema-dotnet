import { ProjectInfo, Location } from "../models";

test('test location', () => {
  const json = {
  "city": "My city",
  "latitude": 66.66,
  "longitude": 15.66,
  "elevation": 22.22,
  "time_zone": 5,
  "source": "new source",
  "station_id": "new station id"
  }
  const loc = Location.fromJS(json);
  expect(loc?.city).toBe("My city");
  expect(loc.validate()).resolves.toBe(true);
});

test('test number with default value', () => {
    const json = {
  "building_type": [
    "Hospital",
    "Courthouse",
    "FullServiceRestaurant"
  ]
  }
    const proj = ProjectInfo.fromJS(json);
    expect(proj.north).toBe(0);
    expect(proj.validate()).resolves.toBe(true);
});

test('test invalid vintage in ProjectInfo', () => {
  const json = `{
  "north": 141,
  "building_type": [
    "Hospital",
    "Courthouse",
    "FullServiceRestaurant"
  ],
  "vintage": [
    "ASHRAE_2004",
    "ASHRAE_2009"
  ],
  "ashrae_climate_zone": "6A"
  }`;
  const jsonObj = JSON.parse(json);
  const proj = ProjectInfo.fromJS(jsonObj);
  expect(proj.validate()).rejects.toThrow("Validation failed: each value in vintage must be one of the following values: ASHRAE_2019, ASHRAE_2016, ASHRAE_2013, ASHRAE_2010, ASHRAE_2007, ASHRAE_2004, DOE_Ref_1980_2004, DOE_Ref_Pre_1980");

});

test('test invalid north in ProjectInfo', () => {
  const json = `{
  "north": 888
  }`;
  const jsonObj = JSON.parse(json);
  const proj = ProjectInfo.fromJS(jsonObj);
  expect(proj.north).toBe(888);

  expect(proj.validate()).rejects.toThrow("Validation failed: north must not be greater than 360");

});


test('test ProjectInfo', () => {
  const json = {
  "north": 141,
  "weather_urls": [
    "https://energyplus-weather.s3.amazonaws.com/north_and_central_america_wmo_region_4/USA/MA/USA_MA_Boston-Logan.Intl.AP.725090_TMY3/USA_MA_Boston-Logan.Intl.AP.725090_TMY3.zip",
    "https://climate.onebuilding.org/WMO_Region_4_North_and_Central_America/USA_United_States_of_America/NY_New_York/USA_NY_New.York-Kennedy.Intl.AP.744860_TMYx.zip"
  ],
  "building_type": [
    "Hospital",
    "Courthouse",
    "FullServiceRestaurant"
  ],
  "vintage": [
    "ASHRAE_2004",
    "ASHRAE_2010"
  ],
  "ashrae_climate_zone": "6A",
  "location": {
    "city": "My city",
    "latitude": 66.66,
    "longitude": 15.66,
    "elevation": 22.22,
    "time_zone": 5,
    "source": "new source",
    "station_id": "new station id"
  }
  }
    const proj = ProjectInfo.fromJS(json);
    expect(proj.location?.city).toBe("My city");
    expect(proj.validate()).resolves.toBe(true);
});