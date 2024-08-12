//extern alias LBTNewtonSoft;
//using LBTNewtonSoft::Newtonsoft.Json;
//using System.Runtime.Serialization;


//namespace HoneybeeSchema
//{
//    public abstract class HoneybeeObject : IHoneybeeObject
//    {
//        ///// <summary>
//        ///// Gets or Sets Type
//        ///// The default value is set to "InvalidSchemaObject", which should be overridden in subclass' constructor.
//        ///// </summary>
//        // [DataMember(Name = "type", EmitDefaultValue = false)]
//        // public abstract string Type { get; protected set; }

//        public abstract string GetType { get; }

//        /// <summary>
//        /// This is the base class for all honeybee schema objects.
//        /// </summary>
//        protected internal HoneybeeObject()
//        {

//        }


//        public abstract string ToString(bool detailed);

//        public abstract OpenAPIGenBaseModel Duplicate();
//        //public abstract string ToJson(bool indented = false);
//        //public string ToJson(bool indented = false)
//        //{
//        //    var format = indented ? Formatting.Indented : Formatting.None;
//        //    return JsonConvert.SerializeObject(this, format, JsonSetting.AnyOfConvertSetting);
//        //}

//        public static bool operator ==(HoneybeeObject left, HoneybeeObject right)
//        {
//            if (left is null)
//            {
//                if (right is null)
//                {
//                    return true;
//                }

//                // Only the left side is null.
//                return false;
//            }
//            // Equals handles case of null on right side.
//            return left.Equals(right);
//        }

//        public static bool operator !=(HoneybeeObject left, HoneybeeObject right)
//        {
//            return !(left == right);
//        }

//        public override bool Equals(object obj)
//        {
//            if (obj == null)
//                return false;
//            if (obj is HoneybeeObject input)
//                return Extension.Equals(this.GetType, input.GetType);
//            return false;
//        }
//    }
//}
