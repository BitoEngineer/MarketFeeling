using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.CnbcScraper.Models
{
    public class CnbcNewsListDto
    {
        public CnbcNewsListDataDto Data { get; set; }
    }

    public class CnbcNewsListDataDto
    {
        public MostPopularEntries MostPopularEntries { get; set; }
    }

    public class MostPopularEntries
    {
        public List<CnbcNewsStoryDto> Assets { get; set; }
    }
}
