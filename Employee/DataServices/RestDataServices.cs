using Employee.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employee.DataServices
{
    public class RestDataServices : IRestDataServices
    {
        private readonly  HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOption;


        public RestDataServices()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5072" : "https://localhost:7072";
            _url = $"{_baseAddress}/api";
            _jsonSerializerOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task AddCompany(Company company)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------->No Interner");
                return ;
            }

            try
            {
                string jsoncompany=JsonSerializer.Serialize<Company>(company,_jsonSerializerOption);
                StringContent content = new StringContent(jsoncompany, Encoding.UTF8, "application/json");
                HttpResponseMessage respons = await _httpClient.PostAsync($"{_url}/Companies",content);

                if(respons.IsSuccessStatusCode)
                {
                    Debug.Write("Successfull");
                }
                else
                {
                    Debug.Write("Not Successfull");

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return;

        }

        public async Task DeleteCompany(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------->No Interner");
                return;
            }
            try
            {
                HttpResponseMessage respons = await _httpClient.DeleteAsync($"{_url}/Companies/{id}");

                if (respons.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"{respons.StatusCode}");
                }
                else
                {
                    Debug.WriteLine($"{respons.StatusCode}");
                    return ;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            return;

        }

        public async Task<List<Company>> GetCompanyListAsync()
        {
           List<Company> company = new List<Company>();
            if(Connectivity.Current.NetworkAccess!=NetworkAccess.Internet)
            {
                Debug.WriteLine("------->No Interner");
                return company;
            }
            try
            {
                HttpResponseMessage respons = await _httpClient.GetAsync($"{_url}/Companies");
                if (respons.IsSuccessStatusCode)
                {
                    string content = await respons.Content.ReadAsStringAsync();
                    company=JsonSerializer.Deserialize<List<Company>>(content,_jsonSerializerOption);
                }
                else
                {
                    Debug.WriteLine($"{respons.StatusCode}");
                    return company;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            return company;

        }

        public async Task UpdateCompany(Company company)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------->No Interner");
                return;
            }

            try
            {
                string jsoncompany = JsonSerializer.Serialize<Company>(company, _jsonSerializerOption);
                StringContent content = new StringContent(jsoncompany, Encoding.UTF8, "application/json");
                HttpResponseMessage respons = await _httpClient.PutAsync($"{_url}/Companies/{company.Id}", content);

                if (respons.IsSuccessStatusCode)
                {
                    Debug.Write("Successfull");
                }
                else
                {
                    Debug.Write("Not Successfull");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return;
        }
    }
}
