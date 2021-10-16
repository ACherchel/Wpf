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
        private Lazy<IRepository<int, CartProducts>> _CartRepository;

        public IRepository<int, Product> ProductsRepository => _productsRepository.Value;

        public IRepository<int, Category> CategoriesRepository => _categoriesRepository.Value;

        public IRepository<int, CartProducts> CartRepository => _CartRepository.Value;

        public UnitOfWork(AppDbContext context)
        {
            _productsRepository = new Lazy<IRepository<int, Product>>(() => new ProductsRepository(context));
            _categoriesRepository = new Lazy<IRepository<int, Category>>(() => new CategoriesRepository(context));
            _CartRepository = new Lazy<IRepository<int, CartProducts>>(() => new CartRepository(context));
        }
    }
}
