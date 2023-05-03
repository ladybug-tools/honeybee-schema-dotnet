using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace HoneybeeSchema
{
    [Summary(@"A design option of HVAC scenario that contains a group of HVAC detailed systems.")]
    [Serializable]
    [DataContract(Name = "HVACScenario")]
    public class HVACScenario : IDdBaseModel, IEquatable<HVACScenario>, IValidatableObject
    {
        [JsonConstructorAttribute]
        protected HVACScenario()
        {
            this.Type = "HVACScenario";
        }

        //public List<detailed> MyProperty { get; set; }
    }
}
