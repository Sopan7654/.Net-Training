using System;

namespace OOPDemo
{
    // =====================================================
    // ABSTRACT CLASS
    // Cannot create object of abstract class
    // Used as base class
    // =====================================================
    abstract class Fruit
    {
        public abstract void ApplyDiscount();
    }

    // =====================================================
    // DERIVED CLASS (INHERITANCE)
    // Apple IS-A Fruit
    // =====================================================
    class Apple : Fruit
    {
        public override void ApplyDiscount()
        {
            Console.WriteLine("Apple Discount Applied: 10%");
        }
    }

    // =====================================================
    // ANOTHER DERIVED CLASS
    // =====================================================
    class Mango : Fruit
    {
        public override void ApplyDiscount()
        {
            Console.WriteLine("Mango Discount Applied: 15%");
        }
    }

    // =====================================================
    // MAIN PROGRAM
    // =====================================================
    class Program
    {
        static void Main()
        {
            // -----------------------------------------
            // POLYMORPHISM
            // Base class reference → Child class object
            // -----------------------------------------
            Fruit discount = new Apple();

            discount.ApplyDiscount();

            // OUTPUT:
            // Apple Discount Applied: 10%


            // -----------------------------------------
            // Change Object Type
            // -----------------------------------------
            discount = new Mango();

            discount.ApplyDiscount();

            // OUTPUT:
            // Mango Discount Applied: 15%
        }
    }
}


// Assignment Fleet Manager

// using System;
// using System.Collections.Generic;

// namespace FleetManagerAssignment
// {
//     // =====================================================
//     // ABSTRACT BASE CLASS
//     // =====================================================
//     abstract class Vehicle
//     {
//         public string VehicleNumber { get; set; }
//         public string Brand { get; set; }
//         public string FuelType { get; set; }
//         public double Mileage { get; set; }

//         public Vehicle(string number, string brand, string fuel, double mileage)
//         {
//             VehicleNumber = number;
//             Brand = brand;
//             FuelType = fuel;
//             Mileage = mileage;
//         }

//         // Abstract Method
//         public abstract void DisplayInfo();
//     }

//     // =====================================================
//     // CAR CLASS
//     // =====================================================
//     class Car : Vehicle
//     {
//         public Car(string number, string brand, string fuel, double mileage)
//             : base(number, brand, fuel, mileage)
//         {
//         }

//         public override void DisplayInfo()
//         {
//             Console.WriteLine($"[CAR] {VehicleNumber} | {Brand} | {FuelType} | {Mileage} km/l");
//         }
//     }

//     // =====================================================
//     // TRUCK CLASS
//     // =====================================================
//     class Truck : Vehicle
//     {
//         public Truck(string number, string brand, string fuel, double mileage)
//             : base(number, brand, fuel, mileage)
//         {
//         }

//         public override void DisplayInfo()
//         {
//             Console.WriteLine($"[TRUCK] {VehicleNumber} | {Brand} | {FuelType} | {Mileage} km/l");
//         }
//     }

//     // =====================================================
//     // BIKE CLASS
//     // =====================================================
//     class Bike : Vehicle
//     {
//         public Bike(string number, string brand, string fuel, double mileage)
//             : base(number, brand, fuel, mileage)
//         {
//         }

//         public override void DisplayInfo()
//         {
//             Console.WriteLine($"[BIKE] {VehicleNumber} | {Brand} | {FuelType} | {Mileage} km/l");
//         }
//     }

//     // =====================================================
//     // FLEET MANAGER CLASS
//     // =====================================================
//     class FleetManager
//     {
//         private List<Vehicle> vehicles = new List<Vehicle>();

//         // Add Vehicle
//         public void AddVehicle(Vehicle vehicle)
//         {
//             vehicles.Add(vehicle);
//         }

//         // Show All Vehicles
//         public void ShowFleet()
//         {
//             Console.WriteLine("\n===== FLEET VEHICLES =====");

//             foreach (var vehicle in vehicles)
//             {
//                 vehicle.DisplayInfo();
//             }
//         }

//         // Average Mileage
//         public void ShowAverageMileage()
//         {
//             double total = 0;

//             foreach (var v in vehicles)
//             {
//                 total += v.Mileage;
//             }

//             double avg = vehicles.Count > 0 ? total / vehicles.Count : 0;

//             Console.WriteLine($"\nAverage Mileage: {avg}");
//         }
//     }

//     // =====================================================
//     // MAIN PROGRAM
//     // =====================================================
//     class Program
//     {
//         static void Main()
//         {
//             FleetManager manager = new FleetManager();

//             // Add Vehicles
//             manager.AddVehicle(new Car("MH12AB1234", "Hyundai", "Petrol", 18));
//             manager.AddVehicle(new Truck("MH14TR5678", "Tata", "Diesel", 10));
//             manager.AddVehicle(new Bike("MH13BK9999", "Honda", "Petrol", 45));

//             // Show Fleet
//             manager.ShowFleet();

//             // Show Average Mileage
//             manager.ShowAverageMileage();
//         }
//     }
// }
