using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Maintenance.Models;
using System.Collections.ObjectModel;

namespace Maintenance.Repositories
{
    public class SchedulesRepository : IDisposable, IRepository<Schedule>
    {
        private MaintenanceContext db;

        public SchedulesRepository()
        {
            db = new MaintenanceContext();
        }

        public Schedule Reload(Schedule obj)
        {
            db.Entry(obj).Reference(p => p.Machine).Load();
            db.Entry(obj).Reference(p => p.Employee).Load();
            return obj;
        }

        public ObservableCollection<Schedule> Get()
        {
            db.Schedules.Include(p => p.Machine).Include(p => p.Employee).Load();
            return db.Schedules.Local;
        }

        public ObservableCollection<Schedule> Get(Func<Schedule, bool> p)
        {
            db.Schedules.Where(p);
            return db.Schedules.Local;
        }

        public ObservableCollection<Schedule> Get(string filter)
        {
            db.Schedules.Where(t => t.Id.Equals(filter));
            return db.Schedules.Local;
        }

        public void Delete(Schedule obj)
        {
            var entry = db.Schedules.Find(obj.Id);
            db.Schedules.Remove(entry);
            db.SaveChanges();
        }

        public Schedule Insert(Schedule obj)
        {
            obj.UpdateNextTime();
            db.Schedules.Add(obj);
            db.SaveChanges();

            return obj;
        }

        public Schedule Update(Schedule obj)
        {
            obj.UpdateNextTime();
            var tmp = db.Schedules.Find(obj.Id);

            tmp.CurrentDate = obj.CurrentDate;
            tmp.Done = obj.Done;
            tmp.EmployeeId = obj.EmployeeId;
            tmp.Inspection = obj.Inspection;
            tmp.MachineId = obj.MachineId;
            tmp.NextDate = obj.NextDate;
            tmp.Recurrence = obj.Recurrence;
            tmp.Work = obj.Work;

            if (obj.Done)
            {
                var newObj = this.New();
                newObj.CurrentDate = obj.NextDate;
                newObj.Done = false;
                newObj.Inspection = obj.Inspection;
                newObj.MachineId = obj.MachineId;
                newObj.Recurrence = obj.Recurrence;
                newObj.UpdateNextTime();
                db.Schedules.Add(newObj);
            }

            db.SaveChanges();
            db.Entry(tmp).Reference(p => p.Machine).Load();
            db.Entry(tmp).Reference(p => p.Employee).Load();

            obj.CurrentDate = tmp.CurrentDate;
            obj.Done = tmp.Done;
            obj.Employee = tmp.Employee;
            obj.EmployeeId = tmp.EmployeeId;            
            obj.Inspection = tmp.Inspection;
            obj.Machine = tmp.Machine;
            obj.MachineId = tmp.MachineId;
            obj.NextDate = tmp.NextDate;
            obj.Recurrence = tmp.Recurrence;
            obj.Work = tmp.Work;

            return obj;
        }

        public Schedule New()
        {
            Schedule obj = new Schedule();
            obj.Id = Guid.NewGuid().ToString();
            return obj;
            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
