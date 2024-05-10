using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Linq;

namespace SupermarketApp.ViewModel
{
    internal class ProductsReportVM
    {
        public ProductsReportVM()
        {
        }

        public ProductsReportVM(ObservableCollection<Product> products)
        {
            Products = new ObservableCollection<Product>();
            foreach (var item in products.OrderBy(item => item.Category.Name).ToList())
            {
                Products.Add(item);
            };
        }

        public ObservableCollection<Product> Products { get; set; }
    }
}
