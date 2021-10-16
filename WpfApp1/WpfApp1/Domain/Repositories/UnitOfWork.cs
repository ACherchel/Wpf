using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Lazy<IRepository<int, Product>> _productsRepository;
        private Lazy<IRepository<int, Category>> _categoriesRepository;

        public IRepository<int, Product> ProductsRepository => _productsRepository.Value;

        public IRepository<int, Category> CategoriesRepository => _categoriesRepository.Value;

        public UnitOfWork(AppDbContext context)
        {
            _productsRepository = new Lazy<IRepository<int, Product>>(() => new ProductsRepository(context));
            _categoriesRepository = new Lazy<IRepository<int, Category>>(() => new CategoriesRepository(context));
        }
    }
}
