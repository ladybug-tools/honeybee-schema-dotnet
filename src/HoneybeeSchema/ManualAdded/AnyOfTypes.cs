using System;
using System.Collections.Generic;
using System.Linq;

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
            if (Object == null)
                return;

            var objType = Object.GetType();

            // check if there is interface
            var interfaceTypes = AllValidTypes.Where(_ => _.IsInterface).FirstOrDefault(_ => _.IsAssignableFrom(objType));
            if (interfaceTypes != null)
            {
                this.Obj = Object;
                return;
            }

            var isValidType = this.AllValidTypes.Contains(objType);
            if (!isValidType)
            {
                throw new ArgumentException($"Type {objType} doesn't match any of [{string.Join(", ", AllValidTypes.Select(_ => _.ToString()))}]");
            }
            else
            {
                this.Obj = Object;
            }

        }

        public override string ToString()
        {
            return this.Obj?.ToString();
        }

        public virtual string ToJson()
        {
            return this.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, null))
                return ReferenceEquals(obj, null) ? true : false;
            if (obj is AnyOf anotherAnyOf)
                return this.Obj.Equals(anotherAnyOf.Obj);
            return this.Obj.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.Obj.GetHashCode();
        }

        public new Type GetType()
        {
            return this.Obj.GetType();
        }

        public static bool operator ==(AnyOf obj, object anotherObj)
        {
            if (ReferenceEquals(obj, null))
                return ReferenceEquals(anotherObj, null) ? true : false;

            return obj.Obj.Equals(anotherObj);
        }

        public static bool operator !=(AnyOf obj, object anotherObj)
        {
            return !(obj == anotherObj);
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


    public class AnyOf<T, K> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K) };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K> b) => b?.ToString();

        public static implicit operator AnyOf<T, K>(T b) => new AnyOf<T, K>(b);
        public static implicit operator AnyOf<T, K>(K b) => new AnyOf<T, K>(b);

    }

    public class AnyOf<T, K, Q> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q) };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q> b) => b?.ToString();
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

        public static implicit operator string(AnyOf<T, K, Q, W> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W>(T b) => new AnyOf<T, K, Q, W>(b);
        public static implicit operator AnyOf<T, K, Q, W>(K b) => new AnyOf<T, K, Q, W>(b);
        public static implicit operator AnyOf<T, K, Q, W>(Q b) => new AnyOf<T, K, Q, W>(b);
        public static implicit operator AnyOf<T, K, Q, W>(W b) => new AnyOf<T, K, Q, W>(b);
    }

    public class AnyOf<T, K, Q, W, E> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E) };

        public AnyOf(object obj) : base(obj)
        {
        }

        public static implicit operator string(AnyOf<T, K, Q, W, E> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E>(T b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(K b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(Q b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(W b) => new AnyOf<T, K, Q, W, E>(b);
        public static implicit operator AnyOf<T, K, Q, W, E>(E b) => new AnyOf<T, K, Q, W, E>(b);

    }

    public class AnyOf<T, K, Q, W, E, R> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() { typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R) };

        public AnyOf(object obj) : base(obj)
        {
        }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R> b) => b?.ToString();
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
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y> b) => b?.ToString();
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

        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U> b) => b?.ToString();
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
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I> b) => b?.ToString();
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
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O> b) => b?.ToString();
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

        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P> b) => b?.ToString();
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
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A> b) => b?.ToString();
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

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P), typeof(A), typeof(B)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P), typeof(A), typeof(B), typeof(C)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P), typeof(A), typeof(B), typeof(C), typeof(D)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(D b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O), typeof(P), typeof(A), typeof(B), typeof(C), typeof(D), typeof(F)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(D b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(F b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O),
            typeof(P), typeof(A), typeof(B), typeof(C), typeof(D), typeof(F), typeof(G)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(D b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(F b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(G b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O),
            typeof(P), typeof(A), typeof(B), typeof(C), typeof(D), typeof(F), typeof(G), typeof(H)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(D b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(F b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(G b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(H b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H>(b);
    }

    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O),
            typeof(P), typeof(A), typeof(B), typeof(C), typeof(D), typeof(F), typeof(G), typeof(H), typeof(J)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(D b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(F b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(G b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(H b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(J b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J>(b);
    }
    public class AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M> : AnyOf
    {
        internal override List<Type> AllValidTypes => new List<Type>() {
            typeof(T), typeof(K), typeof(Q), typeof(W), typeof(E), typeof(R), typeof(Y), typeof(U), typeof(I), typeof(O),
            typeof(P), typeof(A), typeof(B), typeof(C), typeof(D), typeof(F), typeof(G), typeof(H), typeof(J), typeof(M)
        };

        public AnyOf(object obj) : base(obj) { }
        public static implicit operator string(AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M> b) => b?.ToString();
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(T b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(K b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(Q b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(W b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(E b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(R b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(Y b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(U b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(I b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(O b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(P b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(A b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(B b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(C b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(D b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(F b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(G b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(H b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(J b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
        public static implicit operator AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(M b) => new AnyOf<T, K, Q, W, E, R, Y, U, I, O, P, A, B, C, D, F, G, H, J, M>(b);
    }
    //public class AnyOfList<T> : Collection<T> where T : AnyOf
    //{

    //    public IEnumerable<T1> OfType<T1>()
    //    {
    //        return this.Select(_ => _.Obj).OfType<T1>();
    //    }

    //}

    public static class AnyOfListEntensiton
    {
        public static IEnumerable<T> Select<T>(this IEnumerable<T> Source, Func<object, T> predicate) where T : AnyOf
        {
            return Source.Select(_ => predicate(_.Obj));
        }

        public static IEnumerable<T1> OfType<T1>(this IEnumerable<AnyOf> Source)
        {
            return Source.Select(_ => _.Obj).OfType<T1>();
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> Source, Func<object, bool> predicate) where T : AnyOf
        {
            return Source.Where(_ => predicate(_.Obj));
        }
    }
}