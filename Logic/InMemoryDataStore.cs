using System;
using System.Collections.Generic;
using Entities;

namespace Logic
{
    internal static class InMemoryDataStore
    {
        internal static readonly object SyncRoot = new object();
        internal static readonly List<Products> Products = new List<Products>
        {
            new Products { ProductID = 1, ProductName = "Chai", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m },
            new Products { ProductID = 2, ProductName = "Chang", QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 19.00m },
            new Products { ProductID = 3, ProductName = "Aniseed Syrup", QuantityPerUnit = "12 - 550 ml bottles", UnitPrice = 10.00m },
            new Products { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", QuantityPerUnit = "48 - 6 oz jars", UnitPrice = 22.00m }
        };

        internal static readonly List<Employees> Employees = new List<Employees>
        {
            new Employees
            {
                EmployeeID = 1,
                LastName = "Davolio",
                FirstName = "Nancy",
                Title = "Sales Representative",
                BirthDate = new DateTime(1948, 12, 8),
                HireDate = new DateTime(1992, 5, 1),
                HomePhone = "(206) 555-9857"
            },
            new Employees
            {
                EmployeeID = 2,
                LastName = "Fuller",
                FirstName = "Andrew",
                Title = "Vice President, Sales",
                BirthDate = new DateTime(1952, 2, 19),
                HireDate = new DateTime(1992, 8, 14),
                HomePhone = "(206) 555-9482"
            }
        };
    }
}
