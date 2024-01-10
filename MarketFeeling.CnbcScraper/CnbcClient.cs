using HtmlAgilityPack;
using MarketFeeling.CnbcScraper.Models;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MarketFeeling.CnbcScraper
{
    public class CnbcClient
    {
        private readonly HttpClient _httpClient;

        public CnbcClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CnbcNewsListDto> GetTrendingNewsAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://cnbc.p.rapidapi.com/news/v2/list-trending?tag=Articles&count=30"),
                Headers =
                {
                    { "X-RapidAPI-Key", "55f7737045msh33eed1ab5d2e675p1c20f9jsnba74d98b4866" },
                    { "X-RapidAPI-Host", "cnbc.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CnbcNewsListDto>(body);
            }
        }

        public async Task<string> GetNew(string url)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var htmlStr = await response.Content.ReadAsStringAsync();

                return htmlStr;
            }
        }
    }
}
