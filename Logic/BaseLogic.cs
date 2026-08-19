using System.Collections.Generic;
using Entities;

namespace Logic
{
    public class BaseLogic
    {
        protected readonly object syncRoot = InMemoryDataStore.SyncRoot;
        protected readonly List<Products> products = InMemoryDataStore.Products;
        protected readonly List<Employees> employees = InMemoryDataStore.Employees;
    }
}
