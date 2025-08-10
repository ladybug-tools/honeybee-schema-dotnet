
namespace HoneybeeSchema
{
    public partial interface IIDdBaseModel: IIDdBase
    {
        // string Identifier { get; set;}
        // string DisplayName { get; set; }
        object UserData { get; set; }
        
    } 

    public partial class IDdBaseModel: IIDdBaseModel
    {
        /// <summary>
        /// Get UserData in Dictionary
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public System.Collections.Generic.Dictionary<string, object> UserDictionary => this.GetUserData();
        /// <summary>
        /// Add a new value to UserData
        /// </summary>
        /// <param name="key"></param>
        /// <param name="vaule"></param>
        public void AddData(string key, object vaule) => this.AddUserData(key, vaule);
    }

       
    public partial class IDdEnergyBaseModel: IIDdBaseModel
    {
        /// <summary>
        /// Get UserData in Dictionary
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public System.Collections.Generic.Dictionary<string, object> UserDictionary => this.GetUserData();
        /// <summary>
        /// Add a new value to UserData
        /// </summary>
        /// <param name="key"></param>
        /// <param name="vaule"></param>
        public void AddData(string key, object vaule) => this.AddUserData(key, vaule);
    }
    
}
