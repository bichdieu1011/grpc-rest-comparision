using DataModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Client.Test.Client
{
    public class RESTClient
    {
        private static HttpClient client = new HttpClient();
        public RESTClient()
        {
            //var httpHandler = new HttpClientHandler();
            //httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        }
        public async Task<string> GetNewId(int version)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await client.GetStringAsync($"http://localhost:5291/restApi/id?version={version}");
        }

        public async Task<List<TestingData>> GetStudents()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string meteoriteLandingsString = await client.GetStringAsync("http://localhost:5291/restApi/GetAllStudentInfo");

            return JsonConvert.DeserializeObject<List<TestingData>>(meteoriteLandingsString);
        }

        public async Task<string> PostStudents(List<TestingData> data)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("http://localhost:5291/restApi/PostAllStudentInfo", data);

            return await response.Content.ReadAsStringAsync();
        }
    }
}