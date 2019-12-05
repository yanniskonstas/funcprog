using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;
using static System.Console;
using static LaYumba.Functional.F;

namespace funcprog
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine(Funk1.GreetingMessage());
            Funk1.Triples();
            Funk1.Original(new int[] {1, 5, 3, 8, 2, 4, 6, 9, 8, 3});
            Funk1.Unpredictible(); 

            var circle  = new Circle(10);
            WriteLine($"New circle with Circumference: {circle.Stats.Circumference} and Area: {circle.Stats.Area}");
            WriteLine($"Days of the week: {string.Join(", ", Utils.Days)}");            
            WriteLine($"Days of the week starting with S : {string.Join(", ", Utils.DaysStartingWith("S"))}");          
            
            Func<DayOfWeek, bool> daysStartingWith = d => d.ToString().StartsWith("T");  
            WriteLine($"Days of the week starting with T : {string.Join(", ", Utils.Days.Where(daysStartingWith))}");         

            Func<double, double, double> divide = (x, y) =>  x / y; 
            WriteLine($"Divide 10 / 5: {divide(10, 5)}");
            var divideBy = divide.SwapArgs();
            WriteLine($"Divide 10 / 5: {divideBy(10, 5)}");

            WriteLine($"Mode of range: {Utils.GetModOfNumbers(1, 20, Utils.isModOf2)}");
            WriteLine($"Mode of range: {Utils.GetModOfNumbers(1, 20, Utils.isMod(3))}");

            var shoppingList = new List<string> { "coffee beans", "BANANAS", "Dates" };            
            WriteLine($"Shopping list in sequence: {string.Join(", ", shoppingList.Select(Extensions.ToSentenceCase))}");
            WriteLine($"Shopping list in sequence: {string.Join(", ", shoppingList.AsParallel().Select(Extensions.ToSentenceCase))}");
            WriteLine($"Shopping list (Formated): {string.Join(", ", Utils.FormatToList(shoppingList))}");     

            WriteLine(LaYumba.Greet(None));       
            WriteLine(LaYumba.Greet("Yannis"));   

            WriteLine(Int.Parse("10") == 10);           
            WriteLine(Int.Parse("blblb"));           
            
        }
    }
}
