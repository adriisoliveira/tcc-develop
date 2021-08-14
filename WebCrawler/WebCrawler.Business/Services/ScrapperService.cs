using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Business.Interfaces;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.Business.Services
{
    public class ScrapperService : IScrapperService
    {
        public ScrapperService() { }

        public void Scrapper(HtmlDocument htmlDoc, string url) // DEVE SER ASSINCRONO
        {
            //PERGUNTA: devo puxar o HTMLDoc direto do banco?
            //RESPOSTA: SIMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
            // O Crawler e Scrapper devem ser independentes
            
            var paragraphs = htmlDoc.DocumentNode.SelectNodes("//p");
            var words = new List<string>();
            if (paragraphs?.Any() ?? false)
                return;

            foreach (var p in paragraphs)
                words.AddRange(p.InnerText.Split());

            //Sumariza as palavras, deixando só as mais importantes no código

            //Salva em banco as palavras, relacionando cada uma à uma página (url)

            //Ranqueia a URL em questão
        }
    }
}
