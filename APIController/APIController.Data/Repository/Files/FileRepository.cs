using APIController.Business.Entity.Files;
using APIController.Business.Interfaces.Repository.Files;
using APIController.Data.DataContext;

namespace APIController.Data.Repository.Files
{
    public class FileRepository : BaseRepository<UploadedFile>, IFileRepository
    {
        public FileRepository(APIControllerDataContext dataContext) : base(dataContext) { }

        public UploadedFile Add(UploadedFile file)
        {
            return DbSet.Add(file).Entity;
        }
    }
}
