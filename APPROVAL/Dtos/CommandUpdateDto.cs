using System.ComponentModel.DataAnnotations;

namespace APPROVAL.Dtos
{
    public class CommandUpdateDto
    {
        // camel 표기법 준수
        // error handling 을 위해 형을 명시하는 것이 좋음
        [Required]
        [MaxLength(250)]
        public string howTo { get; set; }

        [Required]
        public string line { get; set; }

        [Required]
        public string platForm { get; set; }
    }
}