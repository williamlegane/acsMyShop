using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace AcsShop.Http
{
    public static class HttpClientRequest
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<String> createGetRequest(String URL, String authType,String token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authType,token);
                HttpResponseMessage response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }


        //static async Task createPostReuest(String URL)
        //{ }
    }
}