using System.ComponentModel.DataAnnotations;

namespace MyAssignment.Models
{
    public class Category
    {
        [Key]
        public int IDCate { get; set; }

        public string NameCate { get; set; }
    }
}
