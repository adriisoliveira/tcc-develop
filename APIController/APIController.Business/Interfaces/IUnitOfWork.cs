using System;
using System.Collections.Generic;
using System.Text;

namespace APIController.Business.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
