// See https://aka.ms/new-console-template for more information
using MarketFeeling.XScrapper;

Console.WriteLine("Hello, World!");


var xClient = new XClient(new HttpClient());

await xClient.GetTweets("apple");