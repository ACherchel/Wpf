using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain.Repositories
{
    public abstract class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected AppDbContext db;
        protected DbSet<TValue> Table => db.Set<TValue>();

        public BaseRepository(AppDbContext context)
        {
            db = context;
        }

        public virtual TValue Create(TValue entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
            return entity;
        }

        public virtual TValue Get(TKey id)
        {
            return Table.FirstOrDefault(entity => entity.Id.GetHashCode() == id.GetHashCode());
        }

        public virtual List<TValue> GetAll()
        {
            return Table.ToList();
        }

        public virtual List<TValue> GetAll(Func<TValue, bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }
    }
}
