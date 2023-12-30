// See https://aka.ms/new-console-template for more information
using MarketFeeling.ChatGptClient;
using MarketFeeling.CnbcScraper;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var httpClient = new HttpClient();
var cnbcClient = new CnbcClient(httpClient);
var trendingNews = await cnbcClient.GetTrendingNewsAsync();

var article = trendingNews.Data.MostPopularEntries.Assets.FirstOrDefault(t => t.Author == "kif leswing");
var articleStr = CnbcPromptBuilder.GetArticleDescription(article);
var targetCompany = "Apple";

Console.WriteLine("Trending news fetched successfully from CNBC.");

var gptClient = new ChatGptClient(new HttpClient());


var prompt = string.Join("\n", new List<string>()
{
    PromptBuilder.EvaluateImpactOnStockMarketIntroduction,
    PromptBuilder.AnswerLikeAnExpertOnSwingAndLongTermTrades,
    string.Format(PromptBuilder.ArticleBody, articleStr),
    string.Format(PromptBuilder.AskForTheScore, targetCompany)
});
Console.WriteLine("Prompt:");
Console.WriteLine(prompt);

var answer= await gptClient.GetAnswerAsync(new List<string>() { prompt });

Console.WriteLine("Answer:");
Console.WriteLine(answer);

/*
var client = new HttpClient();
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
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}*/