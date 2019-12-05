using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using static System.Linq.ParallelEnumerable;

namespace funcprog {
    public class Utils { 
        public static List<string> FormatToList(List<string> list) {
            // var left = Range(1, list.Count);
            // var right = list.Select(Extensions.ToSentenceCase);
            // var zipped = Enumerable.Zip(left, right, (i, s) => $"{i}. {s}");
            // return zipped.ToList();
            return list.AsParallel()
            .Select(Extensions.ToSentenceCase)
            .Zip(Range(1, list.Count), (s, i) => $"{i}. {s}")
            .ToList();            
        }     
         // Funtions create other functions
        public static Func<int, bool> isMod(int n) => (i) => i % n == 0;
        public static Func<int, bool> isModOf2 => (i) => i % 2 == 0;       
        public static string GetModOfNumbers(int start, int count, Func<int, bool> fMod) {
            var ret = Range(start, count).Where(fMod);
            return string.Join(", ", ret);
        }         
        // Days of the week
        public static IEnumerable<DayOfWeek> Days  {
            get {
                return Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
            }
        }    
        public static IEnumerable<DayOfWeek> DaysStartingWith(string pattern) {
            return Days.Where(d => d.ToString().StartsWith(pattern));
        }    
    }
}