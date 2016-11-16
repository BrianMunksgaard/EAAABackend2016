using Lesson10Exercises.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson10Exercises.Models
{
    public class Interviewee : IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"\d{4}")]
        public string Zip { get; set; }

        [Required]
        [RegularExpression(@"\d{8}")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [FutureDate(ErrorMessage = "Please enter a future date.")]
        public DateTime FirstInterviewDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [FutureDate(ErrorMessage = "Please enter a future date.")]
        public DateTime SecondInterviewDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (FirstInterviewDate >= SecondInterviewDate)
            {
                errors.Add(new ValidationResult("Second interview date must be after first interview date."));
            }

            return errors;
        }
    }
}
