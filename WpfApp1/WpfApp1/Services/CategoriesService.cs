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
    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<CategoryModel> GetAllCategories()
        {
            var categories = _unitOfWork.CategoriesRepository.GetAll();
            return _mapper.Map<List<CategoryModel>>(categories);
        }
    }
}
