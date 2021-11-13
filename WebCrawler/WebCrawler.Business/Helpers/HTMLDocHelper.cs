using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebCrawler.Business.Helpers
{
    public static class HTMLDocHelper
    {

        private static IEnumerable<HtmlNode> GetHtmlDocumentLinksInternal(HtmlDocument htmlDoc)
        {
            return htmlDoc
                .DocumentNode
                .SelectNodes("//a")?
                .Where(e => e.Attributes["href"] != null && !e.Attributes["href"].Value.StartsWith("#"));
        }


        public static IEnumerable<string> GetHtmlDocumentLinks(HtmlDocument htmlDoc)
        {
            try
            {
                return GetHtmlDocumentLinksInternal(htmlDoc)
                    .Where(e => e.Attributes["href"].Value.StartsWith("https://")
                    || e.Attributes["href"].Value.StartsWith("http://")
                    || e.Attributes["href"].Value.StartsWith("/"))
                    .Select(e => e.Attributes["href"].Value.TrimEnd('/'));
            }
            catch (HtmlWebException e)
            {
                ConsoleUtils.OutputConsole("[Crawler]", "Erro ao acessar os links da página. \nDetalhes do erro: {0}",
                    ConsoleColor.Red, e.Message);
                return new List<string>();
            }
        }

        public static IEnumerable<string> GetHtmlDocumentOutgoingLinks(HtmlDocument htmlDoc)
        {
            try
            {
                return GetHtmlDocumentLinksInternal(htmlDoc)
                    .Where(e => e.Attributes["href"].Value.StartsWith("https://")
                    || e.Attributes["href"].Value.StartsWith("http://"))
                    .Select(e => e.Attributes["href"].Value.TrimEnd('/'));
            }
            catch (HtmlWebException e)
            {
                ConsoleUtils.OutputConsole("[Crawler]", "Erro ao acessar os links da página. \nDetalhes do erro: {0}",
                    ConsoleColor.Red, e.Message);
                return new List<string>();
            }
        }
    }
}
