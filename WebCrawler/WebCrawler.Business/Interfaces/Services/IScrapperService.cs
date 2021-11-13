using HtmlAgilityPack;

namespace WebCrawler.Business.Interfaces.Services
{
    public interface IScrapperService
    {
        void IndexPage(string url);
        void PageRank(string startUrl);
    }
}
