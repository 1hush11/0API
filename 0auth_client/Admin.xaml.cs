using _0auth.Model;
using _0auth_client.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
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
using System.Windows.Shapes;

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public static Admin admin = new Admin();

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public Admin()
        {
            InitializeComponent();

            admin = this;

            LoadProducts();
        }
        public async void LoadProducts()
        {
            ObservableCollection<Product> products = await API.GetProductsAsync();

            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
            productsDG.ItemsSource = Products;

            UpdateList(Products.ToList());
        }
        private void UpdateList(List<Product> products)
        {
            if (!products.Any())
            {
                countTB.Text = "Товаров: 0";
            }
            else
            {
                countTB.Text = "Товаров: " + products.Count.ToString();
            }
        }
        private void editProd_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)productsDG.SelectedItem;
            AdminEditProduct adminEditProduct = new AdminEditProduct(selectedProduct);
            content_frame.NavigationService.Navigate(adminEditProduct, Visibility.Visible);
        }

        private void logOutBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void deleteProd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
