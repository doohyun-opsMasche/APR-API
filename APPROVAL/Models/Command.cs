using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("Account")]
    public class Command
    {
        // camel 표기법 준수
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "How to is required")]
        [MaxLength(250)]
        public string howTo { get; set; }

        [Required(ErrorMessage = "line is required")]
        public string line { get; set; }

        [Required(ErrorMessage = "platForm is required")]
        public string platForm { get; set; }
    }
}