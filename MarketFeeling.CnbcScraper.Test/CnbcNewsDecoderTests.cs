using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketFeeling.CnbcScraper.Test
{
    [TestClass]
    public class CnbcNewsDecoderTests
    {
        [TestMethod]
        public void ExtractAppleNew()
        {
            var newHtml = File.ReadAllText("./cnbcAppleNew.html");

            var newContent = CnbcNewsDecoder.GetNewBody(newHtml);
        }
    }
}