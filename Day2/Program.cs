
using System;

namespace MethodsDemo
{
    // ============================================================
    // ParametersDemo Class
    // Demonstrates:
    // - Optional Parameters
    // - out Parameter
    // - params Keyword
    // - Method Overloading (via Logger class)
    // ============================================================
    class ParametersDemo
    {
        // Optional Parameters Method
        // If values are not passed, default values will be used
        public void Configure(int timeout = 30, bool verbose = false)
        {
            Console.WriteLine($"Timeout set to: {timeout} seconds");
            Console.WriteLine($"Verbose mode: {verbose}");
        }

        // OUT Parameter Method
        // Must assign value before method ends
        public void SetCount(out int count)
        {
            // Imagine fetching from DB or API
            count = 42;
        }

        // PARAMS Keyword Method
        // Allows passing multiple integers without array creation
        public int ParamsDemo(params int[] numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        // Method Overloading Example
        class Logger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }

            public int Log(int message)
            {
                return message;
            }
        }
    }

    // ============================================================
    // Student Class
    // Demonstrates:
    // - Static Fields
    // - Properties
    // - Constructor
    // - this Keyword
    // - Optional Parameter in Method
    // ============================================================
    class Student
    {
        // Static Field → Shared Across All Objects
        public static int NumberOfStudents = 0;

        // Properties
        public string Name { get; set; }
        public int Age { get; set; }

        // Constructor
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            NumberOfStudents++;
        }

        // Instance Method
        public void Print()
        {
            Console.WriteLine($"Name: {this.Name}, Age: {this.Age}, Student Count: {NumberOfStudents}");
        }

        // Method with Optional Parameter
        public int DoubleTheAge(int multiplyBy = 2)
        {
            return this.Age * multiplyBy;
        }
    }

    // ============================================================
    // Calculator Class
    // Demonstrates:
    // - Instance Method
    // - Static Method
    // - Method Overloading Style Usage
    // ============================================================
    class Calculator
    {
        public int a { get; set; }
        public int b { get; set; }

        public Calculator(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        // Instance Method
        public int Add()
        {
            return this.a + this.b;
        }

        // Static Method
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

    // ============================================================
    // Main Program
    // ============================================================
    public class Program
    {
        static void Main(string[] args)
        {
            // ===============================
            // Student Object Demo
            // ===============================
            var alice = new Student("Alice", 20);
            alice.Print();

            var bob = new Student("Bob", 22);
            bob.Print();

            var dave = new Student("Dave", 24);
            dave.Print();

            var charlie = new Student("Charlie", 26);
            charlie.Print();


            // ===============================
            // Uncomment to Test Below Methods
            // ===============================

            /*
            // ParametersDemo Usage
            var options = new ParametersDemo();

            // Optional Parameters
            options.Configure();
            options.Configure(timeout: 10, verbose: true);

            // OUT Parameter
            int count;
            options.SetCount(out count);
            Console.WriteLine($"Count: {count}");

            // PARAMS Demo
            int total = options.ParamsDemo(1, 2, 3);
            Console.WriteLine($"Total: {total}");

            total = options.ParamsDemo(1, 2, 3, 4, 5);
            Console.WriteLine($"Total: {total}");
            */

            /*
            // Calculator Usage

            // Instance Method
            var calc = new Calculator(10, 20);
            Console.WriteLine(calc.Add());

            // Static Method
            Console.WriteLine(Calculator.Add(30, 40));
            */

            /*
            // Student Extra Method
            Console.WriteLine(alice.DoubleTheAge());
            Console.WriteLine(alice.DoubleTheAge(3));
            */
        }
    }
}
