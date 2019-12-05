using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static System.Linq.Enumerable;

namespace funcprog {
    public class Funk1 {

        public static void Template() {
            var i = 1;
            WriteLine($"something : {i}");
        }

         public static void Unpredictible() {
             Divider("Unpredictible");
             var nums = Range(-10000, 20001).Reverse().ToList(); 
             Action task1 = () => WriteLine($"Sum nums: {nums.Sum()}");
             Action task2 = () => {nums.Sort(); WriteLine($"Sum nums: {nums.Sum()}");};
             Parallel.Invoke(task1, task2);
         }

        public static void Original(int[] listOfNumbers) {
            Divider("Original");
            WriteLine($"Input : {string.Join(", ", listOfNumbers)}");
            Func<int, bool> isOdd = x => x % 2 == 1;
            WriteLine($"Odd numbers : {string.Join(", ", listOfNumbers.Where(isOdd).Distinct())}");
            WriteLine($"Event numbers : {string.Join(", ", listOfNumbers.Where(x => !isOdd(x)).Distinct())}");
            WriteLine($"Ordered numbers : {string.Join(", ", listOfNumbers.OrderBy(x => x))}");
            WriteLine($"Original list of numbers : {string.Join(", ", listOfNumbers)}");
        }
        public static void Triples() {
            Divider("Triples");
            Func<int, int> triple = x => x * 3;
            var range = Range(1, 3);
            var triples = range.Select(triple);
            WriteLine($"Triples : {string.Join(", ", triples)}");
        }

        public static void Divider(string name) {
            WriteLine($"****************************{name}");            
        }
        public static string GreetingMessage() {
            return "Hello there. Func1 here :-)";
        }
    }
}