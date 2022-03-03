
namespace HoneybeeSchema
{
    public partial interface IIDdBaseModel: IIDdBase
    {
        // string Identifier { get; set;}
        // string DisplayName { get; set; }
        object UserData { get; set; }
    } 

    
}

namespace HoneybeeSchema
{
     
    public partial class IDdBaseModel: IIDdBaseModel
    {
        /// <summary>
        /// Get UserData in Dictionary
        /// </summary>
        public System.Collections.Generic.Dictionary<string, object> UserDictionary => this.GetUserData();
        /// <summary>
        /// Add a new value to UserData
        /// </summary>
        /// <param name="key"></param>
        /// <param name="vaule"></param>
        public void AddData(string key, object vaule) => this.AddUserData(key, vaule);
    }
}