using System.ComponentModel.DataAnnotations;

namespace APPROVAL.Models 
{
    public class Command
    {
        // camel 표기법 준수
        [Key]
        public int id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string howTo { get; set; }

        [Required]
        public string line { get; set; }

        [Required]
        public string platForm { get; set; }
    }
}