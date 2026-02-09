using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
  class Program
  {
    public static void Main()
    {
      List<string> list = new List<string>();
      list.Add("1");
      list.Add("2");
      list.Add("3");
      list.Add("4");

      foreach (var item in list)
      {
        Console.WriteLine(item);
      }

      CollectionClassesDemo();
    }

    public static void CollectionClassesDemo()
    {
      List<int> marks = new List<int>(10);

      marks.Add(1);
      marks.Add(1);

      Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

      marks.AddRange(new int[] { 1, 2, 3 });
      Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

      marks.AddRange(new List<int> { 4, 5, 6 });
      Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

      marks.AddRange(new List<int> { 4, 5, 6 });
      Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

      Console.WriteLine($"Marks Avg: {marks.Average()}");
    }
  }
}
