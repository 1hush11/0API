using _0auth.Model;
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

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для ItemProductUC.xaml
    /// </summary>
    public partial class ItemProductUC : UserControl
    {
        public static ItemProductUC itemProductUC;
        public ItemProductUC(Product product)
        {
            InitializeComponent();

            itemProductUC = this;

            DataContext = product;
        }
    }
}
