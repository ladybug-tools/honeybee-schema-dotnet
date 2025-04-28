
using NUnit.Framework;

namespace HoneybeeSchema.Test
{
    public class ScheduleRuleAbridgedTests
    {
        // TODO uncomment below to declare an instance variable for Void
        private ScheduleRuleAbridged instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.instance = new ScheduleRuleAbridged("Always on");
        }

       

        [Test]
        public void IdentifierTest()
        {
            // identifier is added for just fulfilling the interface IModifier, it should not be serialized
            var json = this.instance.ToJson();
            Assert.True(!json.Contains("identifier"));
            Assert.True(!json.Contains("display_name"));
        }

        [Test]
        public void ScheduleDayTest()
        {
            var json = @"
{
    ""values"": [
        0.05,
        0.04311628,
        0.05
    ],
    ""times"": [
                                
        [
            0,
            0
        ],
        [
            6,
            0
        ],
        [
            18,
            0
        ]
    ],
    ""interpolate"": false,
    ""identifier"": ""OfficeMedium BLDG_LIGHT_SCH_2013_Sun"",
    ""type"": ""ScheduleDay""
}";


            var day = ScheduleDay.FromJson(json);

            Assert.AreEqual(day.Identifier, "OfficeMedium BLDG_LIGHT_SCH_2013_Sun");
            Assert.That(day.Values.Count, Is.EqualTo(3));
            Assert.That(day.Times.Count, Is.EqualTo(3));
        }


    }

}
