using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Shared.Category
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
