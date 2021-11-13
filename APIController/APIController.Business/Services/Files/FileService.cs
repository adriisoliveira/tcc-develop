using APIController.Business.Interfaces.Repository.Files;
using APIController.Business.Interfaces.Service.Files;
using System;

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
    }
}
