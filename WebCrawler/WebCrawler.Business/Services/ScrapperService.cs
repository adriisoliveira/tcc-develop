using HtmlAgilityPack;
using StopWord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Helpers;
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
        public ScrapperService(IPageUrlRepository urlRepository,
            IPageWordRepository wordRepository)
        {
            _urlRepository = urlRepository;
            _wordRepository = wordRepository;
        }

        public void IndexPage(string url)
        {
            //SUMARIZAÇÃO DE TEXTO:
            //https://www.youtube.com/watch?v=gdGSd2m0bxc&ab_channel=IAExpertAcademy
            //COMO APLICAR O PAGE RANK:
            //https://www.youtube.com/watch?v=P8Kt6Abq_rM&ab_channel=GlobalSoftwareSupport
            //https://www.youtube.com/watch?v=meonLcN7LD4&ab_channel=SpanningTree
            //https://www.youtube.com/watch?v=G4yiRF11YmA&ab_channel=IAExpertAcademy

            ///TODO: falta:
            /// 1 - Salvar a frequência
            /// 2 - Salvar a distância
            /// 3 - Classificar via texto do link
            /// 4 - Aplicar o algorítmo PageRank (provavelmente não será feito neste método)

            url = TextFormattingUtils.UrlConformer(url);
            var pageUrl = _urlRepository.GetByUrl(url);
            if (pageUrl == null)
                return;

            try
            {
                ///TODO: se a página já foi indexada, o que fazer para sobreescrever os dados?

                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Indexando a página \"{0}\".", pageUrl.Url);

                string page = new WebClient().DownloadString(pageUrl.Url);
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);

                var textSections = new Dictionary<string, string>();

                var texts = htmlDoc
                   .DocumentNode
                   .SelectNodes("//p");
                   //.SelectNodes("//h1|//h2|//h3//following-sibling:p");

                //Pré-processamento
                var textConformed = TextConformer(string.Join(' ', texts.Select(e => e.InnerText)));

                var words = ScraperSplit(textConformed).Where(e => !string.IsNullOrWhiteSpace(e)).ToArray();///TODO: avaliar se este método está custoso

                //Salva a Palavra, seus relacionamentos e Localização no banco  
                for (int i = 0; i < words.Length; i++)
                {
                    var word = words[i];
                    var pageWord = new PageWord(word);

                    ///TODO: aqui caberia um Unit of Work
                    _wordRepository.Add(pageWord);
                    _urlRepository.AddPageUrlPageWord(new PageUrlPageWord(pageUrl.Id, pageWord.Id));
                    _wordRepository.AddLocalization(new PageWordLocalization(pageWord.Id, pageUrl.Id, i));
                }

                pageUrl.LastIndexing = DateTime.UtcNow;
                _urlRepository.Update(pageUrl);

                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Encerrado a indexação da página \"{0}\".", ConsoleColor.Yellow, pageUrl.Url);
            }
            catch (Exception e)
            {
                ConsoleUtils.OutputConsole(INDEXER_OUTPUT_PREFFIX, "Erro ao indexar a página \"{0}\". \nDetalhes do erro: {1}", ConsoleColor.Red, url, e.Message);
            }
        }


        #region :: Métodos privados
        private string TextConformer(string text)
        {
            //var result = new Regex("[\u0021-\u007e]+").Replace(text, "").ToLower();
            ///TODO: complementar stop words
            var result = text.RemoveStopWords("pt").ToLower();
            //var stop = StopWords.GetStopWords("pt");

            var charsToSplit = new char[] { '.', ',', ';', '!', '?', ':', '/', '\\', '|',
                '(', ')', '[', ']', '{', '}', '_', '=', '+', '*', };
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
