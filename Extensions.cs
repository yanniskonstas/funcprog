using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using static System.Linq.Enumerable;
using Unit = System.ValueTuple;


namespace funcprog {

    using static F;
    public static class Extensions {

        // Return Unit instead of having void functions
        public static Func<Unit> ToFunc(this Action action) => () => {action(); return Unit();};
        public static Func<T, Unit> ToFunc<T>(this Action<T> action) => (t) => { action(t); return Unit(); };
        
        // Pure string functions         
        public static string ToSentenceCase(this string s) 
            => s.ToUpper()[0] + s.ToLower().Substring(1);
        
        //Functions depend to other functions
        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> predicate) {
            foreach (T t in list) 
                if (predicate(t))
                    yield return t;
        }      

        //Adapter functions
        public static Func<T1, T2, R> SwapArgs<T2, T1, R> (this Func<T2, T1, R> f) 
            => (t1, t2) => f(t2, t1);
    }

    public static partial class F {
        public static Unit Unit() => default(Unit);
    }
}