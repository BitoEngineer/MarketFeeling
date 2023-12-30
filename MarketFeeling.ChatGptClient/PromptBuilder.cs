using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.ChatGptClient
{
    public static class PromptBuilder
    {
        public const string EvaluateImpactOnStockMarketIntroduction = 
            @"I'm going to ask you to analyze an article related to companies news 
              in order to evaluate the possible impact of that new  on the stock market.";
        
        public const string AnswerLikeAnExpertOnSwingAndLongTermTrades = 
            "It's highly important that you answer as if you were a professional trader with focus on swing and long term trades.";

        public const string ArticleBody =
            @"Please consider the article below:
              ------------------------------------
              {0}
              ------------------------------------";


        public const string AskForTheScore =
            @"Please give me a score, from 0 to 100
              where 100 means that the article is super optimistic and will probably have a very a positive 
              impact on the {0} stock market and 0 means that the impact is negative and probably it isn't a good time to buy stocks.";
    }
}
