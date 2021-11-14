using APIController.Business.Interfaces;
using APIController.Business.Interfaces.Service.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("file")]
    public class FileController : BaseController
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IFileService _fileService;
        private readonly IUnitOfWork _uow;

        public FileController(IWebHostEnvironment webHostEnvironment, IFileService fileService, IUnitOfWork uow) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _uow = uow;
        }

        /// <summary>
        /// Salva o arquivo em banco
        /// </summary>
        [Route("save")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult SaveFile()
        {
            try
            {
                var uploadedFile = Request.Form.Files[0];
                var fileName =
                    string.Format("{0}_{1}",
                        DateTime.UtcNow.Ticks.ToString(),
                        ContentDispositionHeaderValue.Parse(uploadedFile.ContentDisposition).FileName.Trim('"'));

                var title = Request.Form["title"].ToString() ?? "[Sem Título]";
                var subtitle = Request.Form["subtitle"].ToString() ?? "";
                var author = Request.Form["author"].ToString() ?? "[Anônimo]";

                string path = Path.Combine(
                    new DirectoryInfo(_webHostEnvironment.ContentRootPath).Parent.Parent.ToString(),
                    "uploadedFiles");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (uploadedFile.Length > 0)
                {
                    using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        uploadedFile.CopyTo(stream);

                    _fileService.UploadFile(new Business.Entity.Files.UploadedFile(fileName, path, title, subtitle, author));
                    _uow.Commit();

                    return StatusCode(200, true);
                }
                else
                    return StatusCode(200, false);
            }
            catch (System.Exception ex) { throw ex; }
        }

        /// <summary>
        /// Retorna o arquivo da base de dados
        /// </summary>
        /// <param name="fileId">Id do arquivo</param>
        [HttpGet("download/{fileId}")]
        public IActionResult Download(Guid fileId)
        {
            var fileDb = _fileService.GetById(fileId);
            if (string.IsNullOrWhiteSpace(fileDb.Path))
                return File(new byte[0], "application/force-download", "not-found");

            byte[] fileBytes = System.IO.File.ReadAllBytes(fileDb.Path + "/" + fileDb.FileName);

            return File(fileBytes, "application/force-download", fileDb.FileName);
        }
        
    }
}
