using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain.Repositories
{
    public class ProductsRepository : BaseRepository<int, Product>
    {
        public ProductsRepository(AppDbContext context) : base(context)
        {
        }
        public override List<Product> GetAll()
        {
            return Table.Include((prod) => prod.Category).ToList();
        }
    }
}
