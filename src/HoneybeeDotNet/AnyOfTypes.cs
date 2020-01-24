
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HoneybeeDotNet.Model
{


    [JsonObject(MemberSerialization.OptIn)]
    public class AnyOf
    {
        [IgnoreDataMember]
        public Object Obj { get; set; }
        internal virtual List<Type> AllValidTypes => new List<Type>() {typeof(object)};

        public AnyOf(object obj)
        {
            this.CheckType(obj);
        }

        internal void CheckType(object Object)
        {
            var objType = Object.GetType();
            var isValidType = this.AllValidTypes.Contains(objType);
            if (!isValidType)
            {
                throw new ArgumentException("Not acceptable type!");
            }
            else
            {
                this.Obj = Object;
            }

        }

        [JsonExtensionData]
        public IDictionary<string, object> ExtraData { get; set; }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            ExtraData = new Dictionary<string, object>();
            var fields = this.Obj.GetType().GetProperties();
            foreach (var item in fields)
            {
                var name_schema = (item.GetCustomAttributes(typeof(DataMemberAttribute), true)[0] as DataMemberAttribute).Name;
                ExtraData.Add(name_schema, item.GetValue(this.Obj));
            }


        }
        //TODO: I think this will be need when parsing the json.
        //[OnDeserialized]
        //private void OnDeserialized(StreamingContext context)
        //{
        //    foreach (var kvp in ExtraData)
        //    {
        //        if (!kvp.Key.StartsWith("x-"))
        //        {
        //            this[kvp.Key] = kvp.Value.ToObject<OpenApiPathItem>();
        //        }
        //    }
        //}
    }
    public class AnyOf<T> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T) };

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K>: AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K) };

        public AnyOf(object obj):base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q) };

        public AnyOf(object obj) : base(obj)
        {
        }

    }
    public class AnyOf<T, K, Q, W> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W) };

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W) , typeof(E)};

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E, R> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W) , typeof(E) , typeof(R)};

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E, R, Y> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W) , typeof(E) , typeof(R), typeof(Y)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E, R, Y, U> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

    }


    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P), typeof(A)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

    }
}