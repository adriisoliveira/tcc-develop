using System;
using System.ComponentModel.DataAnnotations;

namespace APIController.Business.Entity.Files
{
    public class UploadedFile : BaseEntity
    {
        public UploadedFile()
        {
            Id = Guid.NewGuid();
        }

        public UploadedFile(string fileName, string path, string author)
        {
            FileName = fileName;
            Path = path;
            Author = author;
        }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Path { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }
    }
}
