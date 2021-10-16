using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Repositories;
using WpfApp1.Models;
using WpfApp1.ServicesAbstract;

namespace WpfApp1.Services
{
    public class ProductsService : BaseService, IProductsService
    {
        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<ProductModel> GetAllProducts()
        {
            var products = _unitOfWork.ProductsRepository.GetAll();
            return _mapper.Map<List<ProductModel>>(products);
        }
    }
}
