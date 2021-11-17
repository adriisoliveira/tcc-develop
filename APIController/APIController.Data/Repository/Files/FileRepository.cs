using APIController.Business.Entity.Files;
using APIController.Business.Interfaces.Repository.Files;
using APIController.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIController.Data.Repository.Files
{
    public class FileRepository : BaseRepository<UploadedFile>, IFileRepository
    {
        public FileRepository(APIControllerDataContext dataContext) : base(dataContext) { }

        public UploadedFile Add(UploadedFile file)
        {
            return DbSet.Add(file).Entity;
        }

        public UploadedFile GetById(Guid id)
        {
            return DbSet.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<UploadedFile> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
