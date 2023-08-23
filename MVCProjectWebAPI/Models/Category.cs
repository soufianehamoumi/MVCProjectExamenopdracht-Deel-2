using System.ComponentModel.DataAnnotations;

namespace MVCProjectWebAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
