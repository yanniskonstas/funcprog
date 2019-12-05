using System;
using System.Diagnostics;
using Unit = System.ValueTuple;

namespace funcprog
{
    public static class Instrumentation
    {
        // Using an action, we transform the Action to Func and we avoid to have duplicates implementations 
        public static void Time(string op, Action action)
            => Time<Unit>(op, action.ToFunc());
        public static T Time<T>(string op, Func<T> f)
        {
            var sw = new Stopwatch();
            sw.Start();

            T t = f();

            sw.Stop();
            Console.WriteLine($"{op} took {sw.ElapsedMilliseconds}ms");
            return t;
        }
    }
}