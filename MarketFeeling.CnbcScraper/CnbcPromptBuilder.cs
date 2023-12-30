using MarketFeeling.CnbcScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.CnbcScraper
{
    public static class CnbcPromptBuilder
    {
        public static string GetArticleDescription(CnbcNewsStoryDto article)
        {
            var sb = new StringBuilder();

            sb.Append(article.Headline);
            sb.AppendLine();
            sb.Append(article.ShorterHeadline);
            sb.AppendLine();
            sb.Append(article.Description);
            sb.AppendLine();
            sb.Append("Published at: "+article.DateLastPublished);
            sb.AppendLine();
            sb.Append("Article by CNBC");

            return sb.ToString();
        }
    }
}
