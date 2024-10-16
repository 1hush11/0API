using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using _0auth.Model;
using _0auth_client.Data;

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для AdminAddProduct.xaml
    /// </summary>
    public partial class AdminAddProduct : Page
    {
        public AdminAddProduct()
        {
            InitializeComponent();
        }

        private void exitBT_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void addProd_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product
            {
                ProductArticleNumber = articleTB.Text,
                NameProduct = nameTB.Text,
                MeasureProduct = "шт.",
                CostProduct = decimal.TryParse(costTB.Text, out decimal cost) ? cost : 0,
                DescriptionProduct = string.IsNullOrWhiteSpace(descTB.Text) ? null : descTB.Text,
                IdProductType = (int)typeCB.SelectedValue,
                PhotoProduct = string.IsNullOrWhiteSpace(imageTB.Text) ? null : imageTB.Text,
                IdSupplier = (int)supplierCB.SelectedValue,
                MaxDiscount = null,
                CurrentDiscount = null,
                IdManufacturer = (int)manufacturerCB.SelectedValue,
                QuantityInStock = int.TryParse(quantityTB.Text, out int quantity) ? quantity : 0,
                StatusProduct = ""
            };
            var result = await API.AddProduct(newProduct);
            MessageBox.Show("Товар добавлен.");
            Admin.admin.LoadProducts();
            this.Visibility = Visibility.Hidden;
        }
    }
}
