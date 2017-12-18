using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UOW.Models;

namespace UOW
{
    public class UnitOfWork : IDisposable
    {
        private EmployeeContaxt entities = null;
        public UnitOfWork()
        {
            entities = new EmployeeContaxt();
        }

        // Add all the repository handles here
        IRepository<Employee> EmployeeRepositoryData = null;

        // Add all the repository getters here
        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (EmployeeRepositoryData == null)
                {
                    EmployeeRepositoryData = new EmployeesRepositoryWithUow(entities);
                }
                return EmployeeRepositoryData;
            }
        }

        public void SaveChanges()
        {
            entities.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}