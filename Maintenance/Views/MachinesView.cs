using BrightIdeasSoftware;
using Maintenance.Models;
using Maintenance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maintenance.Views
{
    public class MachinesView : IView
    {
        public void Get(ObjectListView olv)
        {
            using (MachinesRepository repo = new MachinesRepository())
            {
                var list = repo.Get();
                olv.ModelFilter = null;
                olv.Columns.Clear();
                olv.Columns.Add(new BrightIdeasSoftware.OLVColumn()
                {
                    Text = "Μηχάνημα",
                    AspectGetter = delegate(object row) { return ((Machine)row).Title; },
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    Width = 200
                });
                olv.SetObjects(list);
            }
        }

        public void Edit(ObjectListView olv)
        {
            var obj = olv.SelectedObject as Machine;
            if (obj == null)
                return;
            TitleForm frm = new TitleForm();
            frm.Text = obj.Title;
            frm.UserInput = obj.Title;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (MachinesRepository repo = new MachinesRepository())
                {
                    obj.Title = frm.UserInput;
                    repo.Update(obj);
                    olv.RefreshObject(obj);
                }
            }
        }

        public void New(ObjectListView olv)
        {
            TitleForm frm = new TitleForm();
            frm.Text = "Νέα Μηχανή";
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (MachinesRepository repo = new MachinesRepository())
                {
                    Machine obj = repo.New();
                    obj.Title = frm.UserInput;
                    repo.Insert(obj);
                    olv.AddObject(obj);
                }
            }
        }

        public void Delete(ObjectListView olv)
        {
            var obj = olv.SelectedObject as Machine;
            using (MachinesRepository repo = new MachinesRepository())
            {
                repo.Delete(obj);
                olv.RemoveObject(obj);
            }
        }

        public void Filter(ObjectListView olv, string filter)
        {
            olv.ModelFilter = new ModelFilter(delegate(object x)
            {
                var obj = x as Machine;
                return x != null && (obj.Title.Contains(filter));
            });
        }
    }
}
