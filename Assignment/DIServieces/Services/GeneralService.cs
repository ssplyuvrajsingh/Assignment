using Assignment.DIServieces.IServices;
using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment.DIServieces.Services
{
    public class GeneralService : IGeneralService
    {
        public string GetISO8601Format()
        {
            return DateTime.Now.Date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        public async Task<List<MinimaModel>> ReadMinima()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/posts").ConfigureAwait(false);
            if (Res.IsSuccessStatusCode)
            {
                var minimaJson = Res.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<MinimaModel>>(minimaJson).Where(x=> x.body.Contains("minima")).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}