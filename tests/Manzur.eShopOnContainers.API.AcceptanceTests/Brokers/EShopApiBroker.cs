using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Manzur.eShopOnContainers.API.AcceptanceTests.Brokers
{
    public partial class EShopApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;

        public EShopApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.httpClient = this.webApplicationFactory.CreateClient();
        }
        
        public async Task<TResponse> Get<TResponse>(string path)
        {
            var response = await httpClient.GetAsync(path);
            var responseBody = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<TResponse>(responseBody);
            return output;
        }
        
        public async Task<Result<TResponse>> Delete<TResponse>(string path)
        {
            var response = await httpClient.DeleteAsync(path);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<TResponse>(responseBody);
                return Result.Success(data);
            }

            return Result.Failure<TResponse>(responseBody);
        }
        
        public async Task<Result<TResponse>> Post<TRequest, TResponse>(string path, TRequest request)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var requestBody = new StringContent(
                JsonConvert.SerializeObject(request, serializerSettings),
                Encoding.UTF8,
                "application/json");

            var response = await httpClient.PostAsync(path, requestBody);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<TResponse>(responseBody);
                return Result.Success(data);
            }

            return Result.Failure<TResponse>(responseBody);
        }
    }
}