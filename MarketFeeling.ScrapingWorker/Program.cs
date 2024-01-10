using MarketFeeling.ChatGptClient;
using MarketFeeling.CnbcScraper;
using MarketFeeling.CnbcScraper.Extensions;

Console.WriteLine("Hello, World!");

var targetCompany = "amazon";
var gptClient = new ChatGptClient(new HttpClient());
var httpClient = new HttpClient();
var cnbcClient = new CnbcClient(httpClient);
var trendingNews = await cnbcClient.GetTrendingNewsAsync();

foreach (var article in trendingNews.Data.MostPopularEntries.Assets.FilterByCompany(targetCompany))
{
    var articleHtml = await cnbcClient.GetNew(article.Url);
    var articleContent = CnbcNewsDecoder.GetNewBody(articleHtml);
    var articleStr = CnbcPromptBuilder.GetArticleDescription(article, articleContent);
    var prompt = string.Join("\n", new List<string>()
    {
        PromptBuilder.EvaluateImpactOnStockMarketIntroduction,
        PromptBuilder.AnswerLikeAnExpertOnSwingAndLongTermTrades,
        string.Format(PromptBuilder.ArticleBody, articleStr),
        string.Format(PromptBuilder.AskForTheScore, targetCompany)
    });
    Console.WriteLine("Prompt:");
    Console.WriteLine(prompt);

    var answer = await gptClient.GetAnswerAsync(new List<string>() { prompt });

    Console.WriteLine("Answer:");
    Console.WriteLine(answer);
}

Console.WriteLine("Trending news fetched successfully from CNBC.");
