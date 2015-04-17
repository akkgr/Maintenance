using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Maintenance.Repositories
{
    public interface IRepository<T>
    {
        ObservableCollection<T> Get();
        ObservableCollection<T> Get(Func<T, bool> p);
        ObservableCollection<T> Get(string filter);
        T New();
        void Delete(T obj);
        T Insert(T obj);
        T Update(T obj);
    }
}
