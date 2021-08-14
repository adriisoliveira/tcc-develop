using HtmlAgilityPack;

namespace WebCrawler.Business.Interfaces.Services
{
    public interface IScrapperService
    {
        void Scrapper(HtmlDocument htmlDoc, string url);
    }
}
