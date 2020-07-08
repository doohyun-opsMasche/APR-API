using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_COMMON_CODE")]
    public class TB_COMMON_CODE
    {
        [Column("COMMON_CODE")]
        [MaxLength(20, ErrorMessage = "구분 코드 정보는 20자를 넘지 않습니다.")]
        [Required(ErrorMessage = "구분용 코드를 입력하여 주십시오.")]
        public string commonCode { get; set; }

        [Column("COMMON_VALUE")]
        [MaxLength(20, ErrorMessage = "코드 값은 20자를 넘지 않습니다.")]
        [Required(ErrorMessage = "코드 값을 입력하여 주십시오.")]
        public string commonValue { get; set; }
    }
}
