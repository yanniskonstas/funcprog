using System;

namespace funcprog {
    public class Health {        

        Risk CalculateRiskProfileDynamic(dynamic age) => (age < 60) ? Risk.Low : Risk.High;  
        Risk CalculateRiskProfileStatically(int age) => (age < 60) ? Risk.Low : Risk.High;  
        Risk CalculateRiskProfile(Age age) => (age < 60) ? Risk.Low : Risk.High;  //Honest function Age -> Risk

        enum Risk { Low, Medium, High }        
    }

    public class Age {
        private int Value { get; }        
        public Age(int value) {
            if (!isValid(value)) 
                throw new ArgumentException($"{value} is not a valid type [int]"); // the type validation is handled in the constructor 
            this.Value = value;
        }

        public static bool operator <(Age l, Age r) => l.Value < r.Value;
        public static bool operator >(Age l, Age r) => l.Value > r.Value;
        public static bool operator <(Age l, int r) => l.Value < r;
        public static bool operator >(Age l, int r) => l.Value > r;


        private static bool isValid(int value) 
            => 0 <= value && value < 120;
    }
}