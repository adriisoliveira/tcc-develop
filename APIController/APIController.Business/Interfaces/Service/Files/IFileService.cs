using System;

namespace APIController.Business.Interfaces.Service.Files
{
    public interface IFileService
    {
        Entity.Files.UploadedFile UploadFile(Entity.Files.UploadedFile file);
        Entity.Files.UploadedFile GetById(Guid id);

    }
}
