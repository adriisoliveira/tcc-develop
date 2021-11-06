using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Business.DTO;
using WebCrawler.Business.Interfaces;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Business.Interfaces.Repository.Word;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.Business.Services
{
    public class PageUrlService : IPageUrlService
    {
        protected IPageUrlRepository _urlRepository;
        protected IPageWordRepository _wordRepository;
        protected IUnitOfWork _uow;
        public PageUrlService(IPageUrlRepository urlRepository,
            IPageWordRepository wordRepository,
            IUnitOfWork uow)
        {
            _urlRepository = urlRepository;
            _wordRepository = wordRepository;
            _uow = uow;
        }

        public IEnumerable<PageUrlBasicInfoDTO> GetAllBasicInfo(string searchText)
        {
            return _urlRepository.GetAllBasicInfo(searchText);
        }
    }
}
