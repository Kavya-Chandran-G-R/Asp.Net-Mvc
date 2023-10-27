using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Login.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        [Required]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public float Price { get; set; }

    }
}
