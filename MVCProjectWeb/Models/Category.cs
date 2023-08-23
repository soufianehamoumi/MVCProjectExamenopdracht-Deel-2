using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
      //  public ICollection<Product> Products { get; set; }
    }
}
