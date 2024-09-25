
using NUnit.Framework;

namespace HoneybeeSchema.Test
{
    public class ProjectInfoTests
    {
        [Test]
        public void ProjectInfoTest()
        {
            var proj = new HoneybeeSchema.ProjectInfo();
            proj.Location = new Location(timeZone: -5);
            var json = proj.ToJson();

            var updatedProjInfo = HoneybeeSchema.ProjectInfo.FromJson(json);
            Assert.IsInstanceOf(typeof(ProjectInfo), updatedProjInfo);

        }

        [Test]
        public void ProjectInfoDeserializationTest()
        {
            var json = @"
{""location"": {""station_id"": ""725090"", ""source"": ""TMY3"", ""type"": ""Location"", ""elevation"": 6.0, ""time_zone"": -5.0, ""city"": ""Boston Logan IntL Arpt"", ""state"": ""MA"", ""country"": ""USA"", ""latitude"": 42.369999999999997, ""longitude"": -71.019999999999996}, ""vintage"": [], ""north"": 0.0, ""ashrae_climate_zone"": ""5A"", ""building_type"": [], ""type"": ""ProjectInfo"", ""weather_urls"": [""https://energyplus-weather.s3.amazonaws.com/north_and_central_america_wmo_region_4/USA/MA/USA_MA_Boston-Logan.Intl.AP.725090_TMY3/USA_MA_Boston-Logan.Intl.AP.725090_TMY3.zip""]}
";

            var p = HoneybeeSchema.ProjectInfo.FromJson(json);
            Assert.IsInstanceOf(typeof(ProjectInfo), p);
            Assert.That(p.Location, Is.InstanceOf(typeof(Location)));
            Assert.That(p.Location.TimeZone.Obj, Is.EqualTo(-5));

        }
    }

}
