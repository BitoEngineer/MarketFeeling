using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.CnbcScraper
{
    public static class CnbcNewsDecoder
    {

        public static string GetNewBody(string newHtml)
        {
            var xpath = "//*[@id=\"RegularArticle-ArticleBody-6\"]/div[3]";
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(newHtml);

            var newContent = new StringBuilder();
            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes(xpath))
            {
                newContent.AppendLine(node.InnerText.Trim());
            }

            return newContent.ToString();
        }
    }
}
