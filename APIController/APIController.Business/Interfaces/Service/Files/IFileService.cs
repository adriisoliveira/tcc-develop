using System;
using System.Collections.Generic;

namespace APIController.Business.Interfaces.Service.Files
{
    public interface IFileService
    {
        Entity.Files.UploadedFile UploadFile(Entity.Files.UploadedFile file);
        Entity.Files.UploadedFile GetById(Guid id);
        IEnumerable<Entity.Files.UploadedFile> GetAll(string searchText, int maxResults = 25);
        void Remove(Guid fileId);
    }
}
