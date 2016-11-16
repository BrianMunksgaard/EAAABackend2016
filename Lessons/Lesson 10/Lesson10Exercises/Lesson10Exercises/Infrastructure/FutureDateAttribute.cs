using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson10Exercises.Infrastructure
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
            return (DateTime.TryParse(value.ToString(), out dt) && (DateTime)value > DateTime.Now);
        }
    }
}