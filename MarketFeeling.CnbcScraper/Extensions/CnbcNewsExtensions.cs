using MarketFeeling.CnbcScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.CnbcScraper.Extensions
{
    public static class CnbcNewsExtensions
    {
        public static IEnumerable<CnbcNewsStoryDto> FilterByCompany(this List<CnbcNewsStoryDto> news, string targetCompany)
        {
            return news.Where(x => x.Headline.Contains(targetCompany, StringComparison.InvariantCultureIgnoreCase) 
                                    || x.RelatedTags.Contains(targetCompany, StringComparison.InvariantCultureIgnoreCase) 
                                    || x.Description.Contains(targetCompany, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
