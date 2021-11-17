using APIController.Business.Entity.Files;
using System;
using System.Collections.Generic;

namespace APIController.Business.Interfaces.Repository.Files
{
    public interface IFileRepository
    {
        UploadedFile Add(UploadedFile file);
        UploadedFile GetById(Guid id);
        IEnumerable<UploadedFile> GetAll();
    }
}
