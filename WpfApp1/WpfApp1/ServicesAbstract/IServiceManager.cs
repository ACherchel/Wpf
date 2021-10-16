using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ServicesAbstract
{
    public interface IServiceManager
    {
        IProductsService ProductsService { get; }
        ICategoriesService CategoriesService { get; }
    }
}
