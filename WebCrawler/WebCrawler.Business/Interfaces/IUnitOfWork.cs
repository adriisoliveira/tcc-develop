using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.Business.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
