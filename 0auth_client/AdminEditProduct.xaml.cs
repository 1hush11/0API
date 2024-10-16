using _0auth.Model;
using _0auth_client.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для AdminEditProduct.xaml
    /// </summary>
    public partial class AdminEditProduct : Page
    {
        public static Product productToEdit = new Product();

        //public ObservableCollection<ProductType> ProductTypes { get; set; } = new ObservableCollection<ProductType>();
        public ObservableCollection<Supplier> Suppliers { get; set; } = new ObservableCollection<Supplier>();
        public ObservableCollection<Manufacturer> Manufacturers { get; set; } = new ObservableCollection<Manufacturer>();

        public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();

        public AdminEditProduct(Product _productToEdit)
        {
            InitializeComponent();

            DataContext = _productToEdit;
            productToEdit = _productToEdit;
            
            LoadData();
        }
        private void LoadData()
        {
            LoadProductTypes();
            LoadSuppliers();
            LoadManufacturers();
        }

        private async void LoadProductTypes()
        {
            List<ProductType> productTypes = await API.GetProductTypesAsync();
            typeCB.Items.Clear();
            foreach (var type in productTypes)
            {
                ProductTypes.Add(type);
            }
            typeCB.ItemsSource = ProductTypes;
            typeCB.DisplayMemberPath = "NameProductType";
        }

        private async void LoadSuppliers()
        {
            List<Supplier> suppliers = await API.GetSuppliers();
            supplierCB.Items.Clear();
            foreach (var supplier in suppliers)
            {
                Suppliers.Add(supplier);
            }
            supplierCB.ItemsSource = Suppliers;
            supplierCB.DisplayMemberPath = "NameSupplier";
        }

        private async void LoadManufacturers()
        {
            List<Manufacturer> manufacturers = await API.GetManufacturerAsync();
            manufacturerCB.Items.Clear();
            foreach (var manufacturer in manufacturers)
            {
                Manufacturers.Add(manufacturer);
            }
            manufacturerCB.ItemsSource = Manufacturers;
            manufacturerCB.DisplayMemberPath = "NameManufacturer";
            manufacturerCB.SelectedValuePath = "IdManufacturer";
        }


        private void canselBT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitBT_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void editProdBT_Click(object sender, RoutedEventArgs e)
        {
            Product updateProduct = new Product
            {
                ProductArticleNumber = articleTB.Text ?? string.Empty,
                NameProduct = nameTB.Text ?? string.Empty,
                MeasureProduct = "шт.",
                CostProduct = decimal.TryParse(costTB.Text, out decimal cost) ? cost : 0,
                DescriptionProduct = string.IsNullOrWhiteSpace(descTB.Text) ? null : descTB.Text,
                IdProductType = typeCB.SelectedItem is ProductType selectedType ? selectedType.IdProductType : 0,
                PhotoProduct = string.IsNullOrWhiteSpace(imageTB.Text) ? null : imageTB.Text,
                IdSupplier = supplierCB.SelectedItem is Supplier selectedSupplier ? selectedSupplier.IdSupplier : 0,
                MaxDiscount = null,
                CurrentDiscount = null,
                IdManufacturer = manufacturerCB.SelectedItem is Manufacturer selectedManufacturer ? selectedManufacturer.IdManufacturer : 0,
                QuantityInStock = int.TryParse(quantityTB.Text, out int quantity) ? quantity : 0,
                StatusProduct = ""
            };



            var isOK = await API.UpdateProduct(updateProduct);
            if (isOK)
            {
                MessageBox.Show("Данные о товаре успешно изменены");
                Admin.admin.LoadProducts(); 
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Ошибка при редактировании товара.");
            }
        }
    }
}
