using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson10Exercises.Models
{
    public class User
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Remote("UniqueUserName", "RemoteValidation")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }
    }
}