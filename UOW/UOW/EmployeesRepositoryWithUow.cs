using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UOW.Models;

namespace UOW
{
    public class EmployeesRepositoryWithUow : IRepository<Employee>
    {
        private EmployeeContaxt entities = null;

        public EmployeesRepositoryWithUow(EmployeeContaxt _entities)
        {
            entities = _entities;
        }

        public IEnumerable<Employee> GetAll(Func<Employee, bool> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return entities.Employees.Where(predicate);
                }
            }

            return entities.Employees;
        }

        public Employee Get(Func<Employee, bool> predicate)
        {
            return entities.Employees.FirstOrDefault(predicate);
        }

        public void Add(Employee entity)
        {
            entities.Employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            entities.Employees.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Employee entity)
        {
            entities.Employees.Remove(entity);
        }
    }
}