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

        public UploadedFile(string fileName, string path, string title, string subtitle, string author)
        {
            FileName = fileName;
            Path = path;
            Title = title;
            Subtitle = subtitle;
            Author = author;
            PublishDate = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Path { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Subtitle { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }

        public DateTime PublishDate { get; set; }
        public DateTime? WhenUpdated { get; set; }
    }
}
