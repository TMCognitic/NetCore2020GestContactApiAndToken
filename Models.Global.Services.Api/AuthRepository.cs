using Models.Common.Intefaces;
using Models.Global.Entities;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Models.Global.Services
{
    public class AuthRepository : IAuthRepository<User>
    {
        private Uri _baseAddress;
        public AuthRepository()
        {
            _baseAddress = new Uri("https://localhost:44346/api/");
        }

        public User Login(string login, string passwd)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string jsonContent = JsonConvert.SerializeObject(new { Login = login, Passwd = passwd });
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PostAsync("Auth/Login", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<User>(json);
            }
        }

        public void Register(User user)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string jsonContent = JsonConvert.SerializeObject(user);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PostAsync("Auth/Register", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception                
            }
        }
    }
}
