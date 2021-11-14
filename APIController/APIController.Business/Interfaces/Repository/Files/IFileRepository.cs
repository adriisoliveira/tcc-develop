using APIController.Business.Entity.Files;
using System;

namespace APIController.Business.Interfaces.Repository.Files
{
    public interface IFileRepository
    {
        UploadedFile Add(UploadedFile file);
        UploadedFile GetById(Guid id);
    }
}
