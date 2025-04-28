extern alias LBTNewtonSoft;
using LBTNewtonSoft::Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneybeeSchema
{
    [Summary(@"A design option of HVAC scenario that contains a map of Room - HVAC ID pairs")]
    [Serializable]
    [DataContract(Name = "HVACScenario")]
    public class HVACScenario : IDdBaseModel, IEquatable<HVACScenario>
    {
        [JsonConstructorAttribute]
        protected HVACScenario()
        {
            this.Type = "HVACScenario";
        }

        public HVACScenario(
            string identifier, Dictionary<string, string> roomHvacPairs, // Required parameters
            string displayName = default, Object userData = default) // Optional parameters 
            : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.RoomHVACPairs = roomHvacPairs ?? throw new ArgumentNullException(nameof(roomHvacPairs));

            // Set non-required readonly properties with defaultValue
            this.Type = "HVACScenario";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(HVACScenario))
                this.IsValid(throwException: true);
        }

        public override string ToString()
        {
            return $"HVACScenario: {this.DisplayName ?? this.Identifier}";
        }

        [Summary(@"HVACSystems")]
        [DataMember(Name = "HVACSystems")]
        public Dictionary<string, string> RoomHVACPairs { get; set; }


        public static HVACScenario FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<HVACScenario>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        public HVACScenario DuplicateHVACScenario()
        {
            return FromJson(this.ToJson());
        }

        public bool Equals(HVACScenario input)
        {
            if (input == null)
                return false;
            return base.Equals(input) &&
                    Extension.AllEquals(this.RoomHVACPairs.Keys.ToList(), input.RoomHVACPairs.Keys.ToList()) &&
                    Extension.AllEquals(this.RoomHVACPairs.Values.ToList(), input.RoomHVACPairs.Values.ToList()) &&
                    Extension.Equals(this.Type, input.Type);
        }
    }
}
