using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using _0auth.Model;
using _0auth_client.Model;
using Newtonsoft.Json;

namespace _0auth_client.Data
{
    public static class API
    {
        public static async Task<User?> Auth(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Логин и пароль не должны быть пустыми");
            }
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5117/API/Auth/{login}, {password}").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<User>((await result.Content.ReadAsStringAsync()));
                }
                return null;
            }
        }

        public static async Task<bool> Registration(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Данные пользователя пустые");
            }

            if (string.IsNullOrWhiteSpace(user.LoginUser))
            {
                throw new ArgumentException("Логин не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(user.PasswordUser))
            {
                throw new ArgumentException("Пароль не может быть пустым");
            }
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(user);
                StringContent jsonContent = new(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:5117/API/Auth/registration", jsonContent);
                return result.StatusCode == System.Net.HttpStatusCode.OK;
            }
        }

        public static async Task<ObservableCollection<Product>> GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:5117/API/Products");

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await result.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(jsonResponse);
                    if (products != null)
                        return products;
                }
                return new ObservableCollection<Product>();
            }
        }
        public static async Task<List<ProductType>> GetProductTypesAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:5117/API/Products/ProductsTypes");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await result.Content.ReadAsStringAsync();
                    var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(jsonResponse);
                    if (productTypes != null)
                        return productTypes;
                }
                return new List<ProductType>();
            }
        }
        public static async Task<List<Manufacturer>> GetManufacturerAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:5117/API/Products/Manufacturers");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await result.Content.ReadAsStringAsync();
                    var manufacturers = JsonConvert.DeserializeObject<List<Manufacturer>>(jsonResponse);
                    if (manufacturers != null)
                        return new List<Manufacturer>(manufacturers);
                }
                return new List<Manufacturer>();
            }
        }
        //public static async Task<List<ProductType>> GetProductTypes()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var result = await client.GetAsync("http://localhost:5117/API/Products/ProductsTypes");
        //        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            return JsonConvert.DeserializeObject<List<ProductType>>(await result.Content.ReadAsStringAsync());
        //        }
        //        return new List<ProductType>();
        //    }
        //}
        public static async Task<List<Supplier>> GetSuppliers()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:5117/API/Products/Suppliers");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                    return JsonConvert.DeserializeObject<List<Supplier>>(await result.Content.ReadAsStringAsync());
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                }
                return new List<Supplier>();
            }
        }
        public static async Task<List<Manufacturer>> GetManufacturers()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:5117/API/Products/Manufacturers");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                    return JsonConvert.DeserializeObject<List<Manufacturer>>(await result.Content.ReadAsStringAsync());
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                }
                return new List<Manufacturer>();
            }
        }
        public static async Task<bool> AddProduct(Product newProduct)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(newProduct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5117/API/Products", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка добавления: {error}");
                    return false;
                }
            }
        }

        public static async Task<bool> UpdateProduct(Product updatedProduct)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(updatedProduct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("http://localhost:5117/API/Products/UpdateProduct", content);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                //if (response.IsSuccessStatusCode)
                //{
                //    return true;
                //}
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка редактирования: {error}");
                    return false;
                }
            }
        }
    }
}
