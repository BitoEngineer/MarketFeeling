using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.XScrapper
{
    public class XClient
    {
        public string API_KEY = "9ltIPTLM9cFHmVpdaoksv9pAJ";
        public string API_KEY_SECRET = "dggu6h2RjIFx3v6jx4y8Z79Paxq81VKhZUBVBKUdTSDOiFCw7c";
        public string BEARER_TOKEN = "AAAAAAAAAAAAAAAAAAAAAJp4rwEAAAAAcvuOxLTj4FmQgnjY3Hw6IRh7B3E%3Dlo7cIK3DxqB3jxm6WhkdN4oY5tCWJPXEt4G3FTRFLnjqzHc3No";
        public string ACCESS_TOKEN = "1727292015220592640-JSdYBEfkmoGZAPrh967wpKid57eJEV";
        public string ACCESS_TOKEN_SECRET = "lQ8UaI76Ul2t7GJyqtkRlRA3CGP6pJv7iELQwdSUqT7a0";
        public string apiUrl = "https://api.twitter.com/2/tweets/search/recent?query={0}&max_results={1}";

        private readonly HttpClient _client;

        public XClient(HttpClient client)
        {
            _client = client;
        }

        public async Task GetTweets(string query)
        {
            string bearerToken = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{API_KEY}:{API_KEY_SECRET}"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {BEARER_TOKEN}");

            // Make the request to the Twitter API
            HttpResponseMessage response = await _client.GetAsync(string.Format(apiUrl, query, 2));

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}
