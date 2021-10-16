using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Repositories;
using WpfApp1.Models;
using WpfApp1.ServicesAbstract;
using WpfApp1.Extensions;
using System.Windows;
using WpfApp1.Common;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : BaseModel
    {
        Visibility _editingMode = Visibility.Collapsed;
        Visibility _simpleMode = Visibility.Visible;

        public Visibility EditingMode
        {
            get => _editingMode;
            set
            {
                _editingMode = value;
                OnPropertyChanged(nameof(EditingMode));
            }
        }
        public Visibility SimpleMode
        {
            get => _simpleMode;
            set
            {
                _simpleMode = value;
                OnPropertyChanged(nameof(SimpleMode));
            }
        }
        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();

        IServiceManager _serviceManager;
        public MainWindowViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            Init();
        }

        private void Init()
        {
            Products.AddRange(_serviceManager.ProductsService.GetAllProducts());
        }

        public void ChangeMode(AppMode mode)
        {
            if (mode == AppMode.Simple)
            {
                SimpleMode = Visibility.Visible;
                EditingMode = Visibility.Collapsed;
            }
            else
            {
                SimpleMode = Visibility.Collapsed;
                EditingMode = Visibility.Visible;
            }
        }
    }
}
