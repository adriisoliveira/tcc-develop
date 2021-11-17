using APIController.Business.Interfaces.Repository.Files;
using APIController.Business.Interfaces.Service.Files;
using System;
using System.Collections.Generic;

namespace APIController.Business.Services.Files
{
    public class FileService : IFileService
    {
        protected IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Entity.Files.UploadedFile UploadFile(Entity.Files.UploadedFile file)
        {
            return _fileRepository.Add(file);
        }

        public Entity.Files.UploadedFile GetById(Guid id)
        {
            return _fileRepository.GetById(id);
        }

        public IEnumerable<Entity.Files.UploadedFile> GetAll(string searchText, int maxResults = 25)
        {
            return _fileRepository.GetAll(searchText, maxResults);
        }
    }
}
