using BrightIdeasSoftware;
using Maintenance.Models;
using Maintenance.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maintenance.Views
{
    public class SchedulesView : IView
    {
        public void Get(ObjectListView olv)
        {
            using (SchedulesRepository repo = new SchedulesRepository())
            {
                var list = repo.Get();
                olv.ModelFilter = null;
                olv.Columns.Clear();

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn() 
                { 
                    Text = "Μηχάνημα",
                    AspectGetter = delegate(object row) 
                    {
                        var obj = row as Schedule;
                        if (obj.Machine == null)
                            return string.Empty;
                        else
                            return obj.Machine.Title; 
                    },
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 100
                });

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Χρονική Επιθεώρηση",
                    AspectGetter = delegate(object row) { return ((Schedule)row).Recurrence; },
                    AspectToStringFormat = "{0:d}",
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 150
                });

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Είδος Επιθεώρησης",
                    AspectGetter = delegate(object row) { return ((Schedule)row).Inspection; },
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 150
                });

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Είδος Εργασίας",
                    AspectGetter = delegate(object row) { return ((Schedule)row).Work; },
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 150
                });

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Επόμενη Επιθεώρηση",
                    AspectGetter = delegate(object row) { return ((Schedule)row).NextDate; },
                    AspectToStringFormat = "{0:d}",
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 150
                });

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Συντηρητής",
                    AspectGetter = delegate(object row) 
                    {
                        var obj = row as Schedule;
                        if (obj.Employee == null)
                            return string.Empty;
                        else
                            return obj.Employee.Title; 
                    },
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 150
                });

                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Ολοκληρώθηκε",
                    AspectGetter = delegate(object row) { return ((Schedule)row).Done; },
                    CheckBoxes = true
                });

                olv.SetObjects(list);
            }
        }

        public void Edit(ObjectListView olv)
        {
            var obj = olv.SelectedObject as Schedule;
            if (obj == null)
                return;
            if (obj.Done)
                return;
            using (SchedulesRepository repo = new SchedulesRepository())
            {
                ScheduleForm frm = new ScheduleForm(obj);
                frm.Text = obj.Id;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    obj = repo.Update(frm.Schedule);
                    olv.RefreshObject(obj);
                }
            }
        }

        public void New(ObjectListView olv)
        {
            using (SchedulesRepository repo = new SchedulesRepository())
            {
                Schedule obj = repo.New();
                obj.CurrentDate = DateTime.Now.Date;
                obj.Done = false;
                ScheduleForm frm = new ScheduleForm(obj);
                frm.Text = "Νέα Επιθεώρηση";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    obj = frm.Schedule;
                    repo.Insert(obj);
                    obj = repo.Reload(obj);
                    olv.AddObject(obj);
                }
            }
        }

        public void Delete(ObjectListView olv)
        {
            var obj = olv.SelectedObject as Schedule;
            using (SchedulesRepository repo = new SchedulesRepository())
            {
                repo.Delete(obj);
                olv.RemoveObject(obj);
            }
        }

        public void Filter(ObjectListView olv, string filter)
        {
            olv.ModelFilter = TextMatchFilter.Contains(olv, filter);
        }
    }
}
