using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIController.Business.Entity.Logs
{
    public class ApiTokenLog : BaseEntity
    {
        public ApiTokenLog()
        {
            Id = Guid.NewGuid();
        }

        public ApiTokenLog(string ip, string userAgent, string token, DateTime tokenGenerateDate, DateTime tokenExpireDate) : this()
        {
            IP = ip;
            UserAgent = userAgent;
            Token = token;
            TokenGenerateDate = tokenGenerateDate;
            TokenExpireDate = tokenExpireDate;            
        }

        [Required]
        [MaxLength(255)]
        public string IP { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserAgent { get; set; }

        [Required]
        [MaxLength]
        public string Token { get; set; }

        [Required]
        public DateTime TokenGenerateDate { get; set; }

        [Required]
        public DateTime TokenExpireDate { get; set; }
    }
}
