using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            lock (syncRoot)
            {
                return employees.ToList();
            }
        }

        public int GetLastID()
        {
            throw new NotImplementedException();
        }

        public Employees GetData(int id)
        {
            lock (syncRoot)
            {
                var employee = employees.FirstOrDefault(e => e.EmployeeID == id);

                if (employee == null)
                {
                    throw new Exception("El empleado no existe.");
                }

                return employee;
            }
        }

        public void Add(Employees newObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employees objectSelected)
        {
            throw new NotImplementedException();
        }
    }
}
