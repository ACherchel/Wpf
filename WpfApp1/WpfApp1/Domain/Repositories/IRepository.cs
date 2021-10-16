using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain.Repositories
{
    public interface IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        TValue Get(TKey id);
        List<TValue> GetAll();
        List<TValue> GetAll(Func<TValue, bool> predicate);
        TValue Create(TValue Entity);
    }
}
