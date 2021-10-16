using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain.Repositories
{
    public class CategoriesRepository : BaseRepository<int, Category>
    {
        public CategoriesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
