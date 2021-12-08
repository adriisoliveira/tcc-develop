using APIController.Business.Enum;
using APIController.Business.Interfaces;
using APIController.Business.Interfaces.Service.Files;
using APIController.Business.Interfaces.Service.Users;
using APIController.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading;

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("file")]
    public class FileController : BaseController
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IFileService _fileService;
        private IUserService _userService;
        private readonly IUnitOfWork _uow;

        public FileController(IWebHostEnvironment webHostEnvironment, IFileService fileService, IUnitOfWork uow, IUserService userService) 
            : base(userService)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _uow = uow;
            _userService = userService;
        }

        /// <summary>
        /// Retorna todos os arquivos da base
        /// </summary>
        /// <param name="searchText">Busca por texto</param>
        /// <param name="maxResults">Quantidade máxima de retornos</param>
        [HttpGet]
        [Route("getAll/{searchText}")]
        public IActionResult GetAllFiles(string searchText, int maxResults = 25)
        {
            var files = _fileService.GetAll(searchText, maxResults);
            return StatusCode(200, files);
        }

        /// <summary>
        /// Retorna os arquivos mais recentes
        /// </summary>
        /// <param name="quantity">Quantidade máxima de arquivos</param>
        [HttpGet]
        [Route("topRecent/{quantity}")]
        public IActionResult GetTopRecent(int quantity = 25)
        {
            try
            {
                CheckAccess(HttpContext, UserType.InstitutionAdministrator | UserType.Teacher);

                var files = _fileService.GetTopRecent(quantity);
                return StatusCode(200, files);
            } catch (Exception e)
            {
                return StatusCode(401, "Acesso negado: " + e);
            }
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
                CheckAccess(HttpContext, UserType.InstitutionAdministrator | UserType.Teacher);

                var uploadedFile = Request.Form.Files[0];
                var fileName =
                    string.Format("{0}_{1}",
                        DateTime.UtcNow.Ticks.ToString(),
                        ContentDispositionHeaderValue.Parse(uploadedFile.ContentDisposition).FileName.Trim('"'));

                var title = Request.Form["title"].ToString() ?? "[Sem Título]";
                var subtitle = Request.Form["subtitle"].ToString() ?? "";
                var author = Request.Form["author"].ToString() ?? "[Anônimo]";
                var course = Request.Form["course"].ToString() ?? "";

                string path = Path.Combine(
                    new DirectoryInfo(_webHostEnvironment.ContentRootPath).Parent.Parent.ToString(),
                    "uploadedFiles");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (uploadedFile.Length > 0)
                {
                    using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        uploadedFile.CopyTo(stream);

                    _fileService.UploadFile(new Business.Entity.Files.UploadedFile(fileName, path, title, subtitle, author, course));
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
        [HttpGet]
        [Route("download/{fileId}")]
        public IActionResult Download(Guid fileId)
        {
            var fileDb = _fileService.GetById(fileId);
            if (string.IsNullOrWhiteSpace(fileDb.Path))
                return File(new byte[0], "application/force-download", "not-found");

            byte[] fileBytes = System.IO.File.ReadAllBytes(fileDb.Path + "/" + fileDb.FileName);

            return File(fileBytes, "application/force-download", fileDb.FileName);
        }

        /// <summary>
        /// Remove o arquivo da base de dados
        /// </summary>
        /// <param name="fileId">Id do arquivo</param>
        [HttpDelete]
        [Route("remove/{fileId}")]
        public IActionResult Remove(Guid fileId)
        {
            var file = _fileService.GetById(fileId);
            var path = file.Path;
            var fileName = file.FileName;

            try
            {
                CheckAccess(HttpContext, UserType.InstitutionAdministrator | UserType.Teacher);
            } catch (Exception e)
            {
                StatusCode(401, e);
            }

            _fileService.Remove(fileId);
            if (System.IO.File.Exists(path + "/" + fileName))
            {
                try
                {
                    System.IO.File.Delete(path + "/" + fileName);
                }
                catch (System.IO.IOException e) { }
            }
            return StatusCode(200, true);
        }
    }
}
