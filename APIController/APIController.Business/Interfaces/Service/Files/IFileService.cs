namespace APIController.Business.Interfaces.Service.Files
{
    public interface IFileService
    {
        Entity.Files.UploadedFile UploadFile(Entity.Files.UploadedFile file);
    }
}
