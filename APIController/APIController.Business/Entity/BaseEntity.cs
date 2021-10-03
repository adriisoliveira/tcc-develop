using System;
using System.ComponentModel.DataAnnotations;

namespace APIController.Business.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
