using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<int, Product> ProductsRepository { get; }
        IRepository<int, Category> CategoriesRepository { get; }
    }
}
