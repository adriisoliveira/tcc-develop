using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Business.DTO;

namespace WebCrawler.Business.Interfaces.Services
{
    public interface IPageUrlService
    {
        IEnumerable<PageUrlBasicInfoDTO> GetAllBasicInfo(string searchText);
    }
}
