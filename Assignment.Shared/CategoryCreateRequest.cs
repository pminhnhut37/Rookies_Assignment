using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Shared
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
