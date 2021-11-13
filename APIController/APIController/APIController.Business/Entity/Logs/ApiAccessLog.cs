using System;
using System.ComponentModel.DataAnnotations;

namespace APIController.Business.Entity.Logs
{
    public class ApiAccessLog : BaseEntity
    {
        public ApiAccessLog()
        {
            Id = Guid.NewGuid();
        }

        public ApiAccessLog(string ip, string userAgent, string requestAction, DateTime requestDate) : this()
        {
            IP = ip;
            UserAgent = userAgent;
            RequestAction = requestAction;
            RequestDate = requestDate;
        }

        [Required]
        [MaxLength(255)]
        public string IP { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserAgent { get; set; }

        [Required]
        [MaxLength(255)]
        public string RequestAction { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }
    }
}
