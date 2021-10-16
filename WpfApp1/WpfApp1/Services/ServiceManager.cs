using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Repositories;
using WpfApp1.ServicesAbstract;

namespace WpfApp1.Services
{
    public class ServiceManager : IServiceManager
    {
        Lazy<IProductsService> _productsService;
        Lazy<ICategoriesService> _categoriesService;
        public IProductsService ProductsService => _productsService.Value;
        public ICategoriesService CategoriesService => _categoriesService.Value;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productsService = new Lazy<IProductsService>(() => new ProductsService(unitOfWork, mapper));
            _categoriesService = new Lazy<ICategoriesService>(() => new CategoriesService(unitOfWork, mapper));
        }
    }
}
