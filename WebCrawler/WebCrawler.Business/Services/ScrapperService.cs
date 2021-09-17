using HtmlAgilityPack;
using StopWord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebCrawler.Business.DTO;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Business.Interfaces.Repository.Word;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.Business.Services
{
    public class ScrapperService : IScrapperService
    {
        #region :: Constantes
        private const string INDEXER_OUTPUT_PREFFIX = "[Indexer]";
        #endregion

        protected IPageUrlRepository _urlRepository;
        protected IPageWordRepository _wordRepository;
        protected IUnitOfWork _uow;
        public ScrapperService(IPageUrlRepository urlRepository,
            IPageWordRepository wordRepository,
            IUnitOfWork uow)
        {
            _urlRepository = urlRepository;
            _wordRepository = wordRepository;
            _uow = uow;
        }

        public void PageRank(string url)
        {
            #region :: Explicação do PageRank (apagar depois)
            //COMO APLICAR O PAGE RANK:
            //https://www.youtube.com/watch?v=P8Kt6Abq_rM&ab_channel=GlobalSoftwareSupport
            //https://www.youtube.com/watch?v=meonLcN7LD4&ab_channel=SpanningTree
            //https://www.youtube.com/watch?v=G4yiRF11YmA&ab_channel=IAExpertAcademy
            ///o cálculo é:
            ///Para uma página X, somamos RankPoints dividido pela quantidade de páginas que esta aponta
            ///de todas as páginas que apontam para X.
            ///Ou seja, PR(x) = SUM(PR(y) / OL(y))
            ///onde:
            ///SUM = somatório
            ///y = páginas que apontam para a página que está sendo ranqueada
            ///PR = Page Rank
            ///OL = quantidade inteira de páginas que y aponta
            #endregion

            ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Ranqueando a página \"{0}\" e suas relacionadas.", url);

            if (!_urlRepository.Exists(url))
            {
                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX,
                    "Erro ao ranquear a página \"{0}\" pois esta não existe na base de dados", ConsoleColor.Red, url);
                return;
            }

            var startPage = _urlRepository.GetPageUrlRankDTOByUrl(url);
            
            var pages = new List<PageUrlRankDTO> { startPage };
            pages.AddRange(_urlRepository.GetAllPageUrlRankDTOByPageUrlIds(startPage.ReferencedByPageUrlIds));
            pages.AddRange(_urlRepository.GetAllPageUrlRankDTOByPageUrlIds(startPage.OutgoingPageUrlIds));            
            
            foreach (var page in pages)
            {

                float rank = 0;
                foreach(var pointingPage in pages.Where(e => page.ReferencedByPageUrlIds.Contains(e.PageUrlId)) ?? new List<PageUrlRankDTO>())                
                    rank += pointingPage.PageRankPontcuationDefault / pointingPage.OutgoingPageUrlIds.Count();

                page.PageRankPonctuation = (float)Math.Round(rank, 3);

                var pageRankDb = _urlRepository.GetPageRankByPageUrlId(page.PageUrlId);
                if(pageRankDb == null)
                {
                    pageRankDb = new PageRank(page.PageUrlId, page.PageRankPonctuation);
                    pageRankDb.SetLastRankingToNow();
                    _urlRepository.AddPageRank(pageRankDb);
                }
                else
                {
                    pageRankDb.Ponctuation = page.PageRankPonctuation;
                    _urlRepository.UpdatePageRank(pageRankDb);
                }
                _uow.Commit();
            }
            ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Fim do ranqueamento da página \"{0}\" e suas relacionadas", ConsoleColor.Yellow, url);
        }

        public void IndexPage(string url)
        {
            url = TextFormattingUtils.UrlConformer(url);
            var pageUrl = _urlRepository.GetByUrl(url);
            if (pageUrl == null)
                return;

            if (pageUrl.LastIndexing.HasValue && pageUrl.LastIndexing.Value.AddDays(30) > DateTime.Now)
                return;

            try
            {
                //Removendo todas as relações e palavras
                _urlRepository.RemoveWordRange(pageUrl.Words);
                _urlRepository.RemoveRelationRange(pageUrl.RelatedUrls);
                
                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Indexando a página \"{0}\".", pageUrl.Url);

                string page = new WebClient().DownloadString(pageUrl.Url);
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);

                var outgoingLinks = HTMLDocHelper.GetHtmlDocumentOutgoingLinks(htmlDoc);

                //Salva Relações
                foreach(var link in outgoingLinks ?? new List<string>())
                {
                    ///TODO1: realizar assincronamente?
                    var outgoingPageUrlId = _urlRepository.GetPageUrlIdByUrl(link);
                    if(outgoingPageUrlId.HasValue && outgoingPageUrlId != Guid.Empty && !_urlRepository.RelationExists(pageUrl.Id, outgoingPageUrlId.GetValueOrDefault()))
                        _urlRepository.AddRelation(new PageUrlRelation(pageUrl.Id, outgoingPageUrlId.GetValueOrDefault()));
                }

                var texts = htmlDoc
                   .DocumentNode
                   .SelectNodes("//p")?.Select(e => e.InnerText) ?? new List<string>();
                //.SelectNodes("//h1|//h2|//h3//following-sibling:p");

                //Pré-processamento
                var textConformed = TextConformer(string.Join(' ', texts));

                var words = ScraperSplit(textConformed).Where(e => !string.IsNullOrWhiteSpace(e)).ToArray();///TODO: avaliar se este método está custoso

                //Salva a Palavra, seus relacionamentos e Localização no banco  
                for (int i = 0; i < words.Length; i++)
                {
                    ///TODO: realizar assincronamente?
                    var word = words[i];
                    var pageWord = new PageWord(word);

                    _wordRepository.Add(pageWord);
                    _urlRepository.AddWord(new PageUrlPageWord(pageUrl.Id, pageWord.Id));
                    _wordRepository.AddLocalization(new PageWordLocalization(pageWord.Id, pageUrl.Id, i));
                }

                pageUrl.LastIndexing = DateTime.UtcNow;
                _urlRepository.Update(pageUrl);

                _uow.Commit();
                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Fim da indexação da página \"{0}\".", ConsoleColor.Yellow, pageUrl.Url);
            }
            catch (Exception e)
            {
                _uow.Rollback();
                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Erro ao indexar a página \"{0}\". \nDetalhes do erro: {1}", ConsoleColor.Red, url, e.Message);
            }
        }


        #region :: Métodos privados
        private string TextConformer(string text)
        {
            ///TODO: complementar stop words
            var result = System.Web.HttpUtility.HtmlDecode(text).RemoveStopWords(System.Globalization.CultureInfo.GetCultureInfo("pt-BR")).ToLower();
            
            //foreach(var word in new string[] { "a", "A", "e", "E", "o", "O", "da", "Da" })            
            //    result = result.Replace(word, string.Empty);

            var charsToSplit = new char[] { '.', ',', ';', '!', '?', ':', '/', '\\', '|',
                '(', ')', '[', ']', '{', '}', '_', '=', '+', '*', ' ' };
            result = string.Join(' ', text.Split(charsToSplit)).Trim();
            return result;
        }

        private string[] ScraperSplit(string text)
        {
            var charsToSplit = new char[] { '.', ',', ';', '!', '?', ':', '/', '\\', '|',
                '(', ')', '[', ']', '{', '}', '_', '=', '+', '*', ' ' };
            return text.Split(charsToSplit);
        }

        private void WordsFrequency(string[] words)
        {
            var result = new Dictionary<string, int>();

            foreach (var word in words)
                result.Add(word, words.Where(e => e == word).Count());
            var a = result;
        }
        #endregion
    }
}
/////FREQUENCIA-PROPORCIONAL (PESOS)
//private void WordsFrequencyWeight(Dictionary<string, int> wordsFrequency)
//{
//    var max = wordsFrequency.Max(e => e.Value);

//    var result = new Dictionary<string, float>();
//    foreach (var word in wordsFrequency)
//        result.Add(word.Key, word.Value / max);

//    var a = result;
//}
