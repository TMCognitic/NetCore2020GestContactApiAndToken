using Models.Global.Api.Interfaces;
using Models.Global.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Models.Global.Services
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private readonly Uri _baseAddress;
        private readonly string _token;

        public ContactRepository(string token)
        {
            _baseAddress = new Uri("https://localhost:44346/api/");
            _token = token;
        }

        public IEnumerable<Contact> Get()
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"contact/").Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contact[]>(json);
            }
        }

        public Contact Get(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"contact/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }

        public Contact Insert(Contact entity)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PostAsync("contact", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }

        public bool Update(int id, Contact entity)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PutAsync($"Contact/{id}", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<bool>(json);
            }
        }

        public bool Delete(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync($"contact/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode(); // Si pas code 2xx => exception

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<bool>(json);
            }
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = _baseAddress;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            return httpClient;
        }
    }
}
