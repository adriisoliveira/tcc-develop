using APIController.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIController.Data.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly APIControllerDataContext _context;
        public UnitOfWork(APIControllerDataContext context)
        {
            _context = context;
        }
        public void Commit() => _context.SaveChanges();

        public void Rollback()
        {
            //
        }
    }
}
