﻿using APIController.Business.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace APIController.Business.Entity.Users
{
    public class User : BaseEntity
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        public UserType Type { get; set; }
    }
}
