using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Logic
{
    public class ProductsLogic : BaseLogic, IABMLogic<Products>
    {
        public List<Products> GetAll()
        {
            lock (syncRoot)
            {
                return products.ToList();
            }
        }

        public Products GetData(int id)
        {
            lock (syncRoot)
            {
                return products.FirstOrDefault(r => r.ProductID == id);
            }
        }

        public int GetLastID()
        {
            lock (syncRoot)
            {
                return products.Count == 0 ? 0 : products.Max(u => u.ProductID);
            }
        }

        public void Add(Products newObject)
        {
            lock (syncRoot)
            {
                newObject.ProductID = GetLastID() + 1;
                products.Add(newObject);
            }
        }


        public void Delete(int id)
        {
            lock (syncRoot)
            {
                var productoAEliminar = products.FirstOrDefault(r => r.ProductID == id);

                if (productoAEliminar == default(Products))
                {
                    throw new Exception("El producto no existe.");
                }
                products.Remove(productoAEliminar);
            }
        }

        public void Update(Products objectSelected)
        {
            lock (syncRoot)
            {
                var productUpdate = products.FirstOrDefault(r => r.ProductID == objectSelected.ProductID);

                if (productUpdate == null)
                {
                    throw new Exception("El producto no existe.");
                }

                productUpdate.ProductName = objectSelected.ProductName;
                productUpdate.QuantityPerUnit = objectSelected.QuantityPerUnit;
                productUpdate.UnitPrice = objectSelected.UnitPrice;
            }

        }
    }
}
