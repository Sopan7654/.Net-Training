namespace DelegatesDemo;


public class OnClickEventArgs : EventArgs
{
  public string ButtonName { get; set; }
}

//Publisher
public class Button
{
  public delegate void OnClickHandler();
  public event OnClickHandler OnClick;

  public void Click()
  {
    OnClick?.Invoke();
  }
}

class Program
{
  public static void Main(string[] args)
  {
    Button button = new Button();

    // LINQDemo Run File 
    LinqDemo demo = new LinqDemo();
    demo.Run(); 

    // Subscriber 1: Alarm System
    button.OnClick += () => Console.WriteLine("Button Rings!");

    // Susbscriber Electricity Board
    button.OnClick += () => Console.WriteLine("Charge for Electricity!");
    button.OnClick += () => Console.WriteLine("third!");
    button.OnClick += () => Console.WriteLine("fourth!");

    // Raise Event
    button.Click();
  }
}




// class Program
// {
//   public void HigherOrderFunction()
//   {
//     var result = CalculateArea(AreaOfRectangle);
//     var result2 = CalculateArea(AreaOfTriangle);

//     Console.WriteLine($"Area of Rectangle is : {result}");
//     Console.WriteLine($"Area of Triangle is : {result2}");
//   }

//   int CalculateArea(Func<int, int, int> areaFunction)
//   {
//     return areaFunction(5, 10);
//   

//   int AreaOfRectangle(int length, int width)
//   {
//     return length * width;
//   }

//   int AreaOfTriangle(int baseLength, int height)
//   {
//     return (baseLength * height) / 2;
//   }

//   public static void Main(string[] args)
//   {
//     Program program = new Program();
//     program.HigherOrderFunction();
//   }
// }





// 
// {
//   static void Main(string[] args)
//   {
//     DelegatesDemoApp app = new DelegatesDemoApp();
//     app.Run();
//   }
// }

// //void Add(int a, int b)
// // delegate void MathOperation(int a, int b);
// //int Add(int a, int b)
// delegate int MathOperation(int a, int b);

// // Generic Delegate

// // delegate TResult GenericTwoParameterFunction<TFirst, TSecond, TResult>(TFirst a, TSecond b);

// delegate void GenericTwoParameterAtion<TFirst, TSecond>(TFirst a, TSecond b);

// class DelegatesDemoApp
// {

//   void PrintMessage(string message)
//   {
//     Console.WriteLine(message);
//   }

//   bool IsEven(int number)
//   {
//     return number % 2 == 0;
//   }

//   public void Run()
//   {
//     // MathOperation operation = Add;
//     // GenericTwoParameterFunction<int, int, int> genericOperation = Add;
//     Func<int, int, int> genericOperation = Add;

//     Action<string> action = PrintMessage;
//     action("Hello from Action delegate!");

//     Predicate<int> predicate = IsEven;
//     int testNumber = 7;

//     Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

//     return;

//     Func<string, string, string> stringOperation = Concatenate;

//     var x = stringOperation("Hello, ", "World!");
//     Console.WriteLine($"Concatenation result: {x}");

//     // Multicast delegate: adding more methods to the invocation list
//     genericOperation += Subtract;
//     genericOperation += Multiply;
//     genericOperation += Divide;

//     genericOperation -= Subtract; // Removing the Subtract method from the invocation list

//     var result = genericOperation(5, 3);
//     Console.WriteLine($"Final result: {result}");
//   }

//   public string Concatenate(string a, string b)
//   {
//     string result = a + b;
//     Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
//     return result;
//   }

//   public int Add(int a, int b)
//   {
//     Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
//     return a + b;
//   }

//   public int Subtract(int a, int b)
//   {
//     Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
//     return a - b;
//   }

//   public int Multiply(int a, int b)
//   {
//     Console.WriteLine($"The product of {a} and {b} is: {a * b}");
//     return a * b;
//   }

//   public int Divide(int a, int b)
//   {
//     if (b != 0)
//     {
//       Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
//       return a / b;
//     }
//     else
//     {
//       Console.WriteLine("Cannot divide by zero.");
//     }
//     return 0;
//   }


// }





// namespace Day6;

// class DelegatesDemoApp
// {

//   //void add 
//   delegate int MathOperation(int a, int b);

//   public static int Main(string[] args)
//   {
//     DelegatesDemoApp app = new DelegatesDemoApp();
//     app.Run();
//     return 0;
//   }
//   public void Run()
//   {

//     MathOperation operation = Add;
//     operation += Subtract;
//     operation += Multiply;
//     operation += Divide;

//     operation -= Subtract;


//     var result = operation(5, 3);
//     Console.WriteLine($"Final result is: {result}");
//   }

//   public int Add(int a, int b)
//   {
//     Console.WriteLine($"The sum of {a} and {b} is : {a + b}");
//     return a + b;
//   }

//   public int Subtract(int a, int b)
//   {
//     Console.WriteLine($"The difference between {a} and {b} is : {a - b}");
//     return a - b;
//   }

//   public int Multiply(int a, int b)
//   {
//     Console.WriteLine($"The product of {a} and {b} is : {a * b}");
//     return a * b;
//   }

//   public int Divide(int a, int b)
//   {
//     if (b != 0)
//     {
//       Console.WriteLine($"The quotient of {a} and {b} is : {a / b}");
//       return a / b;
//     }
//     else
//     {
//       Console.WriteLine("Invalid operation");
//     }
//     return 0;
//   }
// }
