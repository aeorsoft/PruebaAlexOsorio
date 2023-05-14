using Newtonsoft.Json;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Services
{
    public class PeopleApiServices : IPeopleApiServices
    {
        static HttpClient client = new HttpClient();
        private static readonly string apiBasicUri = "https://swapi.dev/api";
        public async Task<dynamic> Get()
        {
            PeopleApi api = new PeopleApi();
            string apiBasicUri_ = apiBasicUri + "/people";
            using var client = new HttpClient();
            client.BaseAddress = new Uri(apiBasicUri_);
            var result = await client.GetAsync(apiBasicUri_);
            result.EnsureSuccessStatusCode();
            string resultContentString = await result.Content.ReadAsStringAsync();
            dynamic resultContent = JsonConvert.DeserializeObject(resultContentString);
            return resultContentString;
        }

        public async Task<dynamic> GetId(int id)
        {
            PeopleApi api = new PeopleApi();
            string apiBasicUri_ = apiBasicUri + "/films/" + id+"";
            using var client = new HttpClient();
            client.BaseAddress = new Uri(apiBasicUri_);
            var result = await client.GetAsync(apiBasicUri_);
            result.EnsureSuccessStatusCode();
            string resultContentString = await result.Content.ReadAsStringAsync();
            dynamic resultContent = JsonConvert.DeserializeObject(resultContentString);
            return resultContentString;
        }
    }
}
