using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;
using static System.Console;
using static LaYumba.Functional.F;

namespace funcprog
{
    public static class LaYumba    
    {
        public static string Greet(Option<string> greetee) 
            => greetee.Match(
               None: () => "Sorry, who are you?",
               Some: (name) => $"Hello {name}!"
            );
    }
}
