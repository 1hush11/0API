using _0auth.Model;
using _0auth_client.Data;
using Microsoft.Office.Interop.Word;
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
using System.Reflection;

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : System.Windows.Window
    {
        public static Admin admin = new Admin();

        //private Microsoft.Office.Interop.Word Word;

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

        private void exportProdBT_Click(object sender, RoutedEventArgs e)
        {
            int rowCount = productsDG.Items.Count;
            int columnCount = productsDG.Columns.Count;
            Object[,] dataExport = new Object[rowCount+1, columnCount+1];

            int r = 0;
            foreach (Product product in Products)
            {
                //dataExport[r, 0] = product.ProductArticleNumber;
                //dataExport[r, 1] = product.NameProduct;
                //dataExport[r, 2] = product.CostProduct;
                //dataExport[r, 3] = product.DescriptionProduct;
                //dataExport[r, 4] = product.IdProductTypeNavigation?.NameProductType ?? "Не задано";
                //dataExport[r, 5] = product.PhotoProduct;
                //dataExport[r, 6] = product.IdSupplierNavigation?.NameSupplier ?? "Не задано";  
                //dataExport[r, 7] = product.MaxDiscount;
                //dataExport[r, 8] = product.IdManufacturerNavigation?.NameManufacturer ?? "Не задано";
                //dataExport[r, 9] = product.CurrentDiscount;
                //dataExport[r, 10] = product.QuantityInStock + product.MeasureProduct;
                dataExport[r, 1] = product.ProductArticleNumber;
                dataExport[r, 2] = product.NameProduct;
                dataExport[r, 3] = product.CostProduct;
                dataExport[r, 4] = product.DescriptionProduct ?? "Не задано";
                dataExport[r, 5] = product.IdProductType;
                dataExport[r, 6] = product.PhotoProduct ?? "Не задано";
                dataExport[r, 7] = product.IdSupplier;
                dataExport[r, 8] = product.MaxDiscount ?? 0;
                dataExport[r, 9] = product.IdManufacturer;
                dataExport[r, 10] = product.CurrentDiscount ?? 0;
                dataExport[r, 11] = product.QuantityInStock + product.MeasureProduct;

                r++;
            }

            Microsoft.Office.Interop.Word.Document document = new Microsoft.Office.Interop.Word.Document();
            document.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
            dynamic range = document.Content.Application.Selection.Range;
            string temp = "";
            for (r = 0; r <= rowCount - 1; r++)
            {
                for (int c = 0; c <= columnCount - 1; c++)
                {
                    if (c != columnCount)
                        temp = temp + dataExport[r, c] + "\t";
                    else
                        temp = temp + dataExport[r, c];
                }
            }

            range.Text = temp;
            object missing = Missing.Value;
            object separator = Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs;
            object applyBorders = true;
            object autoFit = true;
            object autoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;

            range.ConvertToTable(ref separator, ref rowCount, ref columnCount,
                                Type.Missing, Type.Missing, ref applyBorders,
                                Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, ref autoFit, ref autoFitBehavior, Type.Missing);

            range.Select();

            document.Application.Selection.Tables[1].Select();
            document.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
            document.Application.Selection.Tables[1].Rows.Alignment = 0;
            document.Application.Selection.Tables[1].Rows[1].Select();
            document.Application.Selection.InsertRowsAbove(1);
            document.Application.Selection.Tables[1].Rows[1].Select();

            document.Application.Selection.Tables[1].Rows[1].Range.Bold = 2;
            document.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Times New Roman";
            document.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 13;

            for (int c = 0; c <= columnCount - 1; c++)
            {
                document.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = productsDG.Columns[c].Header.ToString();
            }

            document.Application.Selection.Tables[1].Rows[1].Select();
            //document.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment;
            document.Application.Selection.Tables[1].Borders.Enable = 1;

            foreach (Microsoft.Office.Interop.Word.Section section in document.Application.ActiveDocument.Sections)
            {
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;

                headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                headerRange.Text = "Продукты";
                headerRange.Font.Size = 16;
                headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            document.Application.Visible = true;
        }
    }
}
