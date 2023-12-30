using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.CnbcScraper.Models
{
    using System;
    using System;
    using Newtonsoft.Json;

    public class PromoImage
    {
        [JsonProperty("__typename")]
        public string TypeName { get; set; }

        public int Id { get; set; }

        public string Url { get; set; }
    }

    public class Section
    {
        [JsonProperty("__typename")]
        public string TypeName { get; set; }

        public int Id { get; set; }

        public string ShortestHeadline { get; set; }

        public string TagName { get; set; }

        public string Url { get; set; }

        public bool Premium { get; set; }
    }

    public class CnbcNewsStoryDto
    {
        [JsonProperty("__typename")]
        public string TypeName { get; set; }

        public int Id { get; set; }

        public string Headline { get; set; }

        public string ShorterHeadline { get; set; }

        [JsonProperty("dateLastPublished")]
        public DateTime DateLastPublished { get; set; }

        public string Description { get; set; }

        public string PageName { get; set; }

        [JsonProperty("relatedTagsFilteredFormatted")]
        public string RelatedTags { get; set; }

        [JsonProperty("dateFirstPublished")]
        public DateTime DateFirstPublished { get; set; }

        [JsonProperty("sectionHierarchyFormatted")]
        public string SectionHierarchy { get; set; }

        [JsonProperty("authorFormatted")]
        public string Author { get; set; }

        [JsonProperty("shortDateFirstPublished")]
        public string ShortDateFirstPublished { get; set; }

        [JsonProperty("shortDateLastPublished")]
        public string ShortDateLastPublished { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }

        public bool Premium { get; set; }

        [JsonProperty("promoImage")]
        public PromoImage PromoImage { get; set; }

        [JsonProperty("featuredMedia")]
        public object FeaturedMedia { get; set; }

        public Section Section { get; set; }
    }

}
