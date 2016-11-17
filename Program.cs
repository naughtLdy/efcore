using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("SampleConnection");

            // Create an employee instance and save the entity to the database
            var entry = new Employee() { Name = "John", LastName = "Winston" };

            using (var context = EmployeesContextFactory.Create(connectionString))
            {
                context.Add(entry);
                context.SaveChanges();
            }

            Console.WriteLine($"Employee was saved in the database with id: {entry.Id}");
        }
    }
}
