using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Maintenance.Models;
using System.Collections.ObjectModel;

namespace Maintenance.Repositories
{
    public class EmployeesRepository : IDisposable, IRepository<Employee>
    {
        private MaintenanceContext db;

        public EmployeesRepository()
        {
            db = new MaintenanceContext();
        }

        public ObservableCollection<Employee> Get()
        {
            db.Employees.Load();
            return db.Employees.Local;
        }

        public ObservableCollection<Employee> Get(Func<Employee, bool> p)
        {
            db.Employees.Where(p);
            return db.Employees.Local;
        }

        public ObservableCollection<Employee> Get(string filter)
        {
            db.Employees.Where(t => t.Title.Contains(filter));
            return db.Employees.Local;
        }

        public void Delete(Employee obj)
        {
            var entry = db.Employees.Find(obj.Id);
            db.Employees.Remove(entry);
            db.SaveChanges();
        }

        public Employee Insert(Employee obj)
        {
            db.Employees.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Employee Update(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }

        public Employee New()
        {
            Employee obj = new Employee();
            obj.Id = Guid.NewGuid().ToString();
            return obj;
            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
