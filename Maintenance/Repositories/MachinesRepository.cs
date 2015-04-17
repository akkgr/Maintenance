using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Maintenance.Models;
using System.Collections.ObjectModel;

namespace Maintenance.Repositories
{
    public class MachinesRepository : IDisposable, IRepository<Machine>
    {
        private MaintenanceContext db;

        public MachinesRepository()
        {
            db = new MaintenanceContext();
        }

        public ObservableCollection<Machine> Get()
        {
            db.Machines.Load();
            return db.Machines.Local;
        }
        
        public ObservableCollection<Machine> Get(Func<Machine,bool> p)
        {
            db.Machines.Where(p);
            return db.Machines.Local;
        }

        public ObservableCollection<Machine> Get(string filter)
        {
            db.Machines.Where(t=>t.Title.Contains(filter));
            return db.Machines.Local;
        }

        public void Delete(Machine obj)
        {
            var entry = db.Machines.Find(obj.Id);
            db.Machines.Remove(entry);
            db.SaveChanges();
        }

        public Machine Insert(Machine obj)
        {
            db.Machines.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Machine Update(Machine obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }

        public Machine New()
        {
            Machine obj = new Machine();
            obj.Id = Guid.NewGuid().ToString();
            return obj;
            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
