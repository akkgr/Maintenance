using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maintenance.Views
{
    public interface IView
    {
        void Get(ObjectListView olv);
        void Edit(ObjectListView olv);
        void New(ObjectListView olv);
        void Delete(ObjectListView olv);
        void Filter(ObjectListView olv, string filter);
    }
}
