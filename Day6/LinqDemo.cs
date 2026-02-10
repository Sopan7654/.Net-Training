namespace DelegatesDemo;
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
}
public class LinqDemo
{
    public void Run()
    {
        // var alice = new Student { Name = "Alice", Age = 20, Grade = "A" };

        // var x = new { Name = alice.Name, Status = false };

        // Console.WriteLine($"Hello {alice.Name} : Type: {alice.GetType().Name}!");
        // Console.WriteLine($"Hello {x.Name} Staus: {x.Status} : Type: {x.GetType().Name}!");

        var students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20, Grade = "A" },
            new Student { Name = "Bob", Age = 22, Grade = "B" },
            new Student { Name = "Charlie", Age = 21, Grade = "A" },
            new Student { Name = "David", Age = 23, Grade = "C" },
            new Student { Name = "Eve", Age = 20, Grade = "B" }
        };

        // var olderStudents = from s in students
        //                     where s.Age > 21
        //                     select new { s.Name };

        // var olderStudents = students.Where(filter);
        // foreach (var s in students) {}
        var olderStudents =
            students
                .Where(s => s.Age > 21)
                .Select(s => new { s.Name });

        foreach (var student in olderStudents)
        {
            Console.WriteLine($"{student.Name} more than 21 years old.");
        }

        var x = students
                .Where(s => s.Age > 21)
                .Select(s => new { s.Name })
                .FirstOrDefault();

        Console.WriteLine($"{x.Name} is the first result.");

        var orderedByAge = students
                .OrderByDescending(s => s.Age);

        foreach (var student in orderedByAge)
        {
            Console.WriteLine($"{student.Name} is {student.Age}.");
        }

        var anyOlderThan25 = students
            .Any(s => s.Age > 25);

        Console.WriteLine($"Anybody older than 25: {anyOlderThan25}.");
    }

    // bool filter(Student s)
    // {
    //     return s.Age > 21;
    // }
}



// // Assignment 
// // question : Create below Types and list of those types. 
// Customers: contains customer details such as customer ID and customer name Orders: contains order details such as order ID, customer ID,
// and order amount Assignment: Write LINQ code to take a join between these two and provide which customer have placed which orders and how many orders. Also provide what is the total value for each customer



// namespace DelegatesDemo;

// public class Customer
// {
//     public int CustomerId { get; set; }
//     public string CustomerName { get; set; }
// }

// public class Order
// {
//     public int OrderId { get; set; }
//     public int CustomerId { get; set; }
//     public decimal OrderAmount { get; set; }
// }

// public class LinqDemo
// {
//     public void Run()
//     {
//         var customers = new List<Customer>
//         {
//             new Customer { CustomerId = 1, CustomerName = "Sopan" },
//             new Customer { CustomerId = 2, CustomerName = "Rahul" },
//             new Customer { CustomerId = 3, CustomerName = "Amit" }
//         };

//         var orders = new List<Order>
//         {
//             new Order { OrderId = 101, CustomerId = 1, OrderAmount = 500 },
//             new Order { OrderId = 102, CustomerId = 1, OrderAmount = 700 },
//             new Order { OrderId = 103, CustomerId = 2, OrderAmount = 300 },
//             new Order { OrderId = 104, CustomerId = 2, OrderAmount = 200 },
//             new Order { OrderId = 105, CustomerId = 2, OrderAmount = 100 }
//         };

//         var result =
//             from c in customers
//             join o in orders
//             on c.CustomerId equals o.CustomerId
//             group o by new { c.CustomerId, c.CustomerName } into g
//             select new
//             {
//                 CustomerName = g.Key.CustomerName,
//                 OrderCount = g.Count(),
//                 TotalOrderValue = g.Sum(x => x.OrderAmount)
//             };

//         foreach (var item in result)
//         {
//             Console.WriteLine($"Customer: {item.CustomerName}");
//             Console.WriteLine($"Orders Placed: {item.OrderCount}");
//             Console.WriteLine($"Total Value: {item.TotalOrderValue}");
//             Console.WriteLine("---------------------------");
//         }
//     }
// }
