using _0auth_client.Data;
using _0auth_client.Model;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void logInBT_Click(object sender, RoutedEventArgs e)
        {
            var result = await API.LogIn(login: loginTB.Text, password: passwordTB.Text);
            if (result is User)
            {
                if (result.IdRole == 2)
                {
                    Admin admin = new Admin();
                    admin.usernameLB.Content = result.SurnameUser + result.NameUser;
                    admin.Show();
                    Close();
                }
                else
                {
                    MenuProducts menuProducts = new MenuProducts();
                    menuProducts.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void signUpBT_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuProducts menuProducts = new MenuProducts();
            menuProducts.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }
    }
}