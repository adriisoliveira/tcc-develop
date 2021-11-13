namespace APIController.Business.Interfaces.Repository.Files
{
    public interface IFileRepository
    {
        Entity.Files.UploadedFile Add(Entity.Files.UploadedFile file);
    }
}
