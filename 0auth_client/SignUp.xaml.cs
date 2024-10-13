using _0auth_client.Data;
using _0auth_client.Model;
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
using System.Windows.Shapes;

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void signUpBT_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.SurnameUser = surNameTB.Text;
            user.NameUser = nameTB.Text;
            user.PatronymicUser = patronymicTB.Text;
            user.LoginUser = loginTB.Text;
            user.PasswordUser = passwordTB.Password.ToString();
            user.IdRole = 1;

            API.Registration(user);
            MessageBox.Show("Регистрация прошла успешно");
        }
    }
}
