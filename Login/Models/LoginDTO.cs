using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Models
    
{
    public class LoginDTO
    {
        [Display(Name ="Table")]
        public virtual int TableId { get; set; }
        [ForeignKey("Id")]
        public virtual Register Registers { get; set; }

        [Required]
        public string Username{ get; set; }
        [Required] 
        public string Password { get; set; }
       

        
    }
}
