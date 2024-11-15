using _0auth.Model;
using _0auth_client.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
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

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для AdminEditProduct.xaml
    /// </summary>
    public partial class AdminEditProduct : Page
    {
        public static Product productToEdit = new Product();
        private Product originalProduct;

        public AdminEditProduct(Product _productToEdit)
        {
            InitializeComponent();

            DataContext = _productToEdit;
            productToEdit = _productToEdit;
            originalProduct = new Product
            {
                ProductArticleNumber = _productToEdit.ProductArticleNumber,
                NameProduct = _productToEdit.NameProduct,
                MeasureProduct = _productToEdit.MeasureProduct,
                CostProduct = _productToEdit.CostProduct,
                DescriptionProduct = _productToEdit.DescriptionProduct,
                IdProductType = _productToEdit.IdProductType,
                PhotoProduct = _productToEdit.PhotoProduct,
                IdSupplier = _productToEdit.IdSupplier,
                MaxDiscount = _productToEdit.MaxDiscount,
                CurrentDiscount = _productToEdit.CurrentDiscount,
                IdManufacturer = _productToEdit.IdManufacturer,
                QuantityInStock = _productToEdit.QuantityInStock,
                StatusProduct = _productToEdit.StatusProduct
            };

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
            typeCB.ItemsSource = await API.GetProductTypesAsync();
            typeCB.DisplayMemberPath = "NameProductType";
            typeCB.SelectedValuePath = "IdProductType";
        }

        private async void LoadSuppliers()
        {
            supplierCB.ItemsSource = await API.GetSuppliers();
            supplierCB.DisplayMemberPath = "NameSupplier";
            supplierCB.SelectedValuePath = "IdSupplier";
        }

        private async void LoadManufacturers()
        {
            manufacturerCB.ItemsSource = await API.GetManufacturerAsync();
            manufacturerCB.DisplayMemberPath = "NameManufacturer";
            manufacturerCB.SelectedValuePath = "IdManufacturer";
        }

        private void canselBT_Click(object sender, RoutedEventArgs e)
        {
            articleTB.Text = originalProduct.ProductArticleNumber;
            nameTB.Text = originalProduct.NameProduct;
            costTB.Text = originalProduct.CostProduct.ToString();
            descTB.Text = originalProduct.DescriptionProduct;
            typeCB.SelectedValue = originalProduct.IdProductType;
            imageTB.Text = originalProduct.PhotoProduct;
            supplierCB.SelectedValue = originalProduct.IdSupplier;
            maxDiscountTB.Text = originalProduct.MaxDiscount.ToString();
            currentDiscountTB.Text = originalProduct.CurrentDiscount.ToString();
            manufacturerCB.SelectedValue = originalProduct.IdManufacturer;
            quantityTB.Text = originalProduct.QuantityInStock.ToString();
        }

        private void exitBT_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private async void editProdBT_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields()) return;

            Product updateProduct = new Product
            {
                ProductArticleNumber = articleTB.Text,
                NameProduct = nameTB.Text,
                MeasureProduct = "шт.",
                CostProduct = decimal.TryParse(costTB.Text, out decimal cost) ? cost : 0,
                DescriptionProduct = string.IsNullOrWhiteSpace(descTB.Text) ? null : descTB.Text,
                IdProductType = (int)typeCB.SelectedValue,
                PhotoProduct = string.IsNullOrWhiteSpace(imageTB.Text) ? null : imageTB.Text,
                IdSupplier = (int)supplierCB.SelectedValue,
                MaxDiscount = int.TryParse(maxDiscountTB.Text, out int maxDiscount) ? maxDiscount : 0,
                CurrentDiscount = int.TryParse(currentDiscountTB.Text, out int currentDiscount) ? currentDiscount : 0,
                IdManufacturer = (int)manufacturerCB.SelectedValue,
                QuantityInStock = int.TryParse(quantityTB.Text, out int quantity) ? quantity : 0,
                StatusProduct = "",
                IdSupplierNavigation = new Supplier { IdSupplier = (int)supplierCB.SelectedValue },
                IdProductTypeNavigation = new ProductType { IdProductType = (int)typeCB.SelectedValue },
                IdManufacturerNavigation = new Manufacturer { IdManufacturer = (int)manufacturerCB.SelectedValue }
            };

            bool isUpdated = await API.UpdateProduct(updateProduct);
            if (isUpdated)
            {
                MessageBox.Show("Товар успешно обновлен");
                Admin.admin.productsDG.Items.Refresh();
                this.Visibility = Visibility.Hidden;
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(nameTB.Text))
            {
                MessageBox.Show("Введите название товара");
                return false;
            }

            if (!decimal.TryParse(costTB.Text, out _))
            {
                MessageBox.Show("Введите корректную цену");
                return false;
            }

            if (typeCB.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип товара");
                return false;
            }

            if (supplierCB.SelectedValue == null)
            {
                MessageBox.Show("Выберите поставщика");
                return false;
            }

            if (manufacturerCB.SelectedValue == null)
            {
                MessageBox.Show("Выберите производителя");
                return false;
            }

            return true;
        }
    }
}
