using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var connectionString = builder.Build().GetConnectionString("CrmDb");

        using var connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("MySQL Connection opened successfully.\n");

            ExecuteReaderDemo(connection);
            ExecuteScalarDemo(connection);
            ExecuteNonQueryDemo(connection);
            ParameterizedQueryDemo(connection);
            SqlInjectionDemo(connection);
            DataAdapterDemo(connection);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    //////////////////////////////////////////////////////
    // ExecuteReader Demo
    //////////////////////////////////////////////////////
    static void ExecuteReaderDemo(MySqlConnection connection)
    {
        Console.WriteLine("=== ExecuteReader Demo ===");

        var query = "SELECT ProductId, ProductName, ListPrice FROM Product";

        using var command = new MySqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["ListPrice"]}");
        }

        Console.WriteLine();
    }

    //////////////////////////////////////////////////////
    // ExecuteScalar Demo
    //////////////////////////////////////////////////////
    static void ExecuteScalarDemo(MySqlConnection connection)
    {
        Console.WriteLine("=== ExecuteScalar Demo ===");

        var query = "SELECT COUNT(*) FROM Product";

        using var command = new MySqlCommand(query, connection);

        var count = Convert.ToInt32(command.ExecuteScalar());

        Console.WriteLine($"Total Products: {count}\n");
    }

    //////////////////////////////////////////////////////
    // ExecuteNonQuery Demo (Insert Supplier)
    //////////////////////////////////////////////////////
    static void ExecuteNonQueryDemo(MySqlConnection connection)
    {
        Console.WriteLine("=== ExecuteNonQuery Demo ===");

        var query = @"
        INSERT INTO Supplier
        (SupplierId, SupplierName, Email, Phone, Website)
        VALUES
        ('SUP777','MySQL Supplier','mysql@mail.com','7777777777','mysql.com')";

        using var command = new MySqlCommand(query, connection);

        try
        {
            var rows = command.ExecuteNonQuery();
            Console.WriteLine($"Rows Inserted: {rows}\n");
        }
        catch
        {
            Console.WriteLine("Supplier already exists (Skipped)\n");
        }
    }

    //////////////////////////////////////////////////////
    // Parameterized Query Demo
    //////////////////////////////////////////////////////
    static void ParameterizedQueryDemo(MySqlConnection connection)
    {
        Console.WriteLine("=== Parameterized Query Demo ===");

        var query = "SELECT * FROM Product WHERE ProductName LIKE @Name";

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Name", "%Laptop%");

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]}");
        }

        Console.WriteLine();
    }

    //////////////////////////////////////////////////////
    // SQL Injection Demo (Unsafe)
    //////////////////////////////////////////////////////
    static void SqlInjectionDemo(MySqlConnection connection)
    {
        Console.WriteLine("=== SQL Injection Demo (Unsafe) ===");

        var userInput = "' OR 1=1 --";

        var query = $"SELECT * FROM Product WHERE ProductName = '{userInput}'";

        using var command = new MySqlCommand(query, connection);

        try
        {
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["ProductName"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
    }

    //////////////////////////////////////////////////////
    // DataAdapter Demo
    //////////////////////////////////////////////////////
    static void DataAdapterDemo(MySqlConnection connection)
    {
        Console.WriteLine("=== DataAdapter Demo ===");

        var query = "SELECT * FROM Product";

        using var adapter = new MySqlDataAdapter(query, connection);

        var table = new DataTable();

        adapter.Fill(table);

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"{row["ProductId"]} | {row["ProductName"]}");
        }

        Console.WriteLine();
    }
}
