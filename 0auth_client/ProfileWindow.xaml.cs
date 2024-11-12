using _0auth_client.Data;
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
using _0auth_client.Model;

namespace _0auth_client
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private User? _currentUser;
        public ProfileWindow()
        {
            InitializeComponent();

            LoadCurrentUser();
        }
        private async Task LoadCurrentUser()
        {
            _currentUser = await API.GetCurrentUserAsync();
            if (_currentUser != null)
            {
                DataContext = _currentUser;
            }
            else
            {
                MessageBox.Show("Не удалось загрузить данные пользователя.");
            }
        }

        private async void canselBT_Click(object sender, RoutedEventArgs e)
        {
            await LoadCurrentUser();
        }

        private async void updateBT_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields()) return;

            User updatedUser = new User
            {
                IdUser = _currentUser.IdUser,
                SurnameUser = surnameTB.Text,
                NameUser = nameTB.Text,
                PatronymicUser = patronymicTB.Text,
                LoginUser = loginTB.Text,
                PasswordUser = passwordTB.Text,
                IdRole = _currentUser.IdRole
            };

            bool isUpdated = await API.UpdateUser(updatedUser);
            if (isUpdated)
            {
                MessageBox.Show("Пользователь успешно обновлен");
                MenuProducts menuProducts = new MenuProducts();
                menuProducts.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка обновления пользователя.");
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(surnameTB.Text))
            {
                MessageBox.Show("Введите фамилию");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nameTB.Text))
            {
                MessageBox.Show("Введите имя");
                return false;
            }

            if (string.IsNullOrWhiteSpace(patronymicTB.Text))
            {
                MessageBox.Show("Введите отчество");
                return false;
            }

            if (string.IsNullOrWhiteSpace(loginTB.Text))
            {
                MessageBox.Show("Введите логин");
                return false;
            }

            if (string.IsNullOrWhiteSpace(passwordTB.Text))
            {
                MessageBox.Show("Введите пароль");
                return false;
            }

            return true;
        }
    }
}
