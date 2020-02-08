using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;

namespace HoneybeeSchema
{


    public class AnyOf
    {
       
        public Object Obj { get; set; }
        internal virtual List<Type> AllValidTypes => new List<Type>() { typeof(object) };

        public AnyOf(object obj)
        {
            this.CheckType(obj);
        }
        public AnyOf(object obj, Type type)
        {
            var objType = obj.GetType();
            var isValidType = objType == type;
            if (!isValidType)
            {
                throw new ArgumentException("Not acceptable type!");
            }
            else
            {
                this.Obj = objType;
            }
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

        public override string ToString()
        {
            return this.Obj.ToString();
        }

        public virtual string ToJson()
        {
            return this.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.Obj.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.Obj.GetHashCode();
        }
        
        public static implicit operator string(AnyOf b) => b;

        public static implicit operator AnyOf(int d) => new AnyOf(d, typeof(int));
        public static implicit operator AnyOf(string d) => new AnyOf(d, typeof(string));
        public static implicit operator AnyOf(double d) => new AnyOf(d, typeof(double));


    }
    public class AnyOf<T> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T) };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T> b) => b;

    }


    public class AnyOf<T, K>: AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K) };

        public AnyOf(object obj):base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K> b) => b.ToString();

        public static implicit operator AnyOf<T, K>(T b) => new AnyOf<T, K>(b);
        public static implicit operator AnyOf<T, K>(K b) => new AnyOf<T, K>(b);

    }

    public class AnyOf<T, K, Q> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q) };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q>(T b) => new AnyOf<T, K, Q>(b);
        public static implicit operator AnyOf<T, K, Q>(K b) => new AnyOf<T, K, Q>(b);
        public static implicit operator AnyOf<T, K, Q>(Q b) => new AnyOf<T, K, Q>(b);

    }
    public class AnyOf<T, K, Q, W> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W) };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q, W> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W>(T b) => new AnyOf<T, K, Q, W>(b);
        public static implicit operator AnyOf<T, K, Q, W>(K b) => new AnyOf<T, K, Q, W>(b);
        public static implicit operator AnyOf<T, K, Q, W>(Q b) => new AnyOf<T, K, Q, W>(b);
        public static implicit operator AnyOf<T, K, Q, W>(W b) => new AnyOf<T, K, Q, W>(b);
    }

    public class AnyOf<T, K, Q, W, E> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W) , typeof(E)};

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q, W, E> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E>(T b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(K b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(Q b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(W b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(E b) => new AnyOf<T, K, Q, W, E>(b);

    }

    public class AnyOf<T, K, Q, W, E, R> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W) , typeof(E) , typeof(R)};

        public AnyOf(object obj) : base(obj)
        {
        }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R>(T b) => new AnyOf<T, K, Q, W, E, R>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R>(K b) => new AnyOf<T, K, Q, W, E, R>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R>(Q b) => new AnyOf<T, K, Q, W, E, R>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R>(W b) => new AnyOf<T, K, Q, W, E, R>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R>(E b) => new AnyOf<T, K, Q, W, E, R>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R>(R b) => new AnyOf<T, K, Q, W, E, R>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W) , typeof(E) , typeof(R), typeof(Y)
        };

        public AnyOf(object obj) : base(obj)
        {
        }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(T b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(K b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(Q b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(W b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(E b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(R b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y>(Y b) => new AnyOf<T, K, Q, W, E, R, Y>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U>(b);

    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I)
        };

        public AnyOf(object obj) : base(obj)
        {
        }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I>(b);

    }


    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O)
        };

        public AnyOf(object obj) : base(obj)
        {
        }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O>(b);

    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P)
        };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { 
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P), typeof(A)
        };

        public AnyOf(object obj) : base(obj)
        {
        }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A> b) => b.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A>(b);
    }
}