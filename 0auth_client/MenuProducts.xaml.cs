using _0auth_client.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using _0auth.Model;

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для MenuProducts.xaml
    /// </summary>
    public partial class MenuProducts : Window
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();

        public MenuProducts()
        {
            InitializeComponent();
            DataContext = this;
            LoadProducts();
            LoadProductTypes();

            List<string> sorts = new List<string>
            {
                "",
                "По возрастанию цены",
                "По убыванию цены"
            };
            sorCB.ItemsSource = sorts;
        }

        private async void LoadProductTypes()
        {
            List<ProductType> productTypes = await API.GetProductTypesAsync();
            filCB.Items.Clear();
            ProductTypes.Add(new ProductType { IdProductType = 0, NameProductType = "Все категории" });
            foreach (var type in productTypes)
            {
                ProductTypes.Add(type);
            }
            filCB.ItemsSource = ProductTypes;
            filCB.DisplayMemberPath = "NameProductType";
        }

        private async void LoadProducts()
        {
            ObservableCollection<Product> products = await API.GetProductsAsync();
            Products.Clear(); 
            foreach (var product in products)
            {
                Products.Add(product); 
            }
            UpdateListView(Products.ToList()); 
        }

        private void ApplyFilters()
        {
            var filteredProducts = Products.ToList();

            string searchText = searchTB.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                filteredProducts = filteredProducts
                    .Where(p => p.NameProduct.ToLower().Contains(searchText))
                    .ToList();
            }

            if (filCB.SelectedItem is ProductType selectedType && selectedType.IdProductType != 0)
            {
                filteredProducts = filteredProducts
                    .Where(p => p.IdProductType == selectedType.IdProductType)
                    .ToList();
            }

            if (sorCB.SelectedItem is string selectedSort && !string.IsNullOrEmpty(selectedSort))
            {
                switch (selectedSort)
                {
                    case "По возрастанию цены":
                        filteredProducts = filteredProducts.OrderBy(p => p.CostProduct).ToList();
                        break;
                    case "По убыванию цены":
                        filteredProducts = filteredProducts.OrderByDescending(p => p.CostProduct).ToList();
                        break;
                }
            }


            UpdateListView(filteredProducts);
        }

        private void UpdateListView(List<Product> products)
        {

            if (!products.Any())
            {
                //MessageBox.Show("Продукты не найдены или список пуст.");
                countTB.Text = "0";
            }
            else
            {
                productsLV.Items.Clear();
                foreach (var product in products)
                {
                    ItemProductUC productUC = new ItemProductUC(product);
                    productsLV.Items.Add(productUC);
                }
                countTB.Text = products.Count().ToString();
            }
        }

        private void sorCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void filCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}
