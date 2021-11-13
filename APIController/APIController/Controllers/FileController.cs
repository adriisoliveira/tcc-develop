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

                    _fileService.UploadFile(new Business.Entity.Files.UploadedFile(fileName, path, author));
                    _uow.Commit();

                    return StatusCode(200, true);
                }
                else
                {
                    return StatusCode(200, false);
                }
            }
            catch (System.Exception ex) { throw ex; }
        }
    }
}
